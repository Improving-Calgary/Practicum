using Microsoft.EntityFrameworkCore;
using MotorCompany.Orders.Core.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace MotorCompany.Orders.Datastore.SQLServer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _dbset = context.Set<T>();
        }

        public Task<IResult<T>> Add(T entity)
        {
            return Task.Run(() =>
            {
                _dbset.Add(entity);
                return Result.Success().For(entity);
            });
        }

        public Task<IResult<IQueryable<T>>> Get()
        {
            return Task.Run(() =>
            {
                return Result.Success().For(_dbset.AsQueryable());
            });
        }

        public Task<IResult<T>> Update(T entity)
        {
            return Task.Run(() =>
            {
                _dbset.Update(entity);
                return Result.Success().For(entity);
            });
        }
    }
}