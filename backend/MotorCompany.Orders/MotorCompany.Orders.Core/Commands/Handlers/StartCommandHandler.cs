using MediatR;
using MotorCompany.Orders.Core.Utility;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MotorCompany.Orders.Core.Commands.Handlers
{
    public class StartCommandHandler : IRequestHandler<StartCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;


        public StartCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TransactionScope<Order>((repo) =>
            {
                var order = repo.Get().Result.Value.Where(x => x.Id.Equals(request.Id)).SingleOrDefault();

                IResult result = order.Start();

                if (result.Failed)
                    return result.For<Order>(null);

                return repo.Update(order).Result;
            });
        }
    }
}