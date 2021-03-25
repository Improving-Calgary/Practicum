using MediatR;
using MotorCompany.Orders.API.Contracts;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.API.Queries
{
    public class GetOrderQuery : IRequest<IResult<OrderDto>>
    {        
        public GetOrderQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
