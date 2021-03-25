using MediatR;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.Core.Commands
{
    public class CreateOrderCommand : IRequest<IResult<Order>>
    {
        public CreateOrderCommand(int customerId, int vehicleId)
        {
            CustomerId = customerId;
            VehicleId = vehicleId;
        }

        private CreateOrderCommand()
        {
        }

        public int CustomerId { get; }

        public int VehicleId { get; }
    }
}
