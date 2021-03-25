using MediatR;
using MotorCompany.Orders.API.Contracts;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.API.Queries
{
    public class GetNextOrderQuery : IRequest<IResult<OrderDto>>
    {
    }
}
