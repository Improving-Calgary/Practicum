using MediatR;
using System.Collections.Generic;
using MotorCompany.Orders.Core;
using MotorCompany.Orders.Core.Utility;
using MotorCompany.Orders.API.Contracts;

namespace MotorCompany.Orders.API.Queries
{
    public class GetOrdersQuery : IRequest<IResult<IEnumerable<OrderDto>>>
    {
        public GetOrdersQuery(EnumOrderStates status)
        {
            State = status;
        }

        public EnumOrderStates State { get; set; }
    }
}
