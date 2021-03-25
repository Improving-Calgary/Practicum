using System.Linq;
using System.Threading.Tasks;

namespace MotorCompany.Orders.Core.Utility
{
    public interface IRepository<T> : IRepositoryReadOnly<T>
    {
        Task<IResult<T>> Add(T entity);

        Task<IResult<T>> Update(T entity);
    }

    public interface IRepositoryReadOnly<T>
    {
        Task<IResult<IQueryable<T>>> Get();
    }
}