using System;
using System.Threading.Tasks;

namespace MotorCompany.Orders.Core.Utility
{

    public interface IUnitOfWork
    {
        Task<IResult<T>> TransactionScope<T>(Func<IRepository<T>, IResult<T>> transaction) where T : class;

        IRepositoryReadOnly<T> GetRepository<T>() where T : class;
    }
}