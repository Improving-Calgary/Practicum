using MediatR;
using MotorCompany.Orders.Core.Utility;
using System.Threading;
using System.Threading.Tasks;

namespace MotorCompany.Orders.Core.Commands.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IResult<Order>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TransactionScope<Order>((repo) =>
            {
                var result = Order.Create(request.CustomerId, request.VehicleId);

                if (result.Failed)
                    return result;

                return repo.Add(result.Value).Result;
            });
        }
    }
}