using MotorCompany.Orders.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorCompany.Orders.Datastore.SQLServer
{
     public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(OrderDbContext context)
        {
            Context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public OrderDbContext Context { get; }

        public async Task<IResult<T>> TransactionScope<T>(Func<IRepository<T>, IResult<T>> transaction) where T : class
        {
            var result = transaction(GetGenericRepository<T>());

            if (result.Failed)
                return result;

            var commitResult = await Commit();

            if (commitResult.Failed)
                return commitResult.For<T>(null);

            return result;
        }

        public IRepositoryReadOnly<T> GetRepository<T>() where T : class
        {
            return GetGenericRepository<T>() as IRepositoryReadOnly<T>;
        }

        private IRepository<T> GetGenericRepository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)) == false)
            {
                _repositories.Add(typeof(T), new Repository<T>(Context));
            }

            return _repositories[typeof(T)] as IRepository<T>;
        }

        private async Task<IResult> Commit()
        {
            if (await Context.SaveChangesAsync() < 1)
            {
                return Result.Failure(new Error("Fail to save changes in the database."));
            }

            return Result.Success();
        }
    }
}