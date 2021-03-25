using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MotorCompany.Orders.Core;
using MotorCompany.Orders.Core.Utility;
using System.Linq;
using MotorCompany.Orders.API.Contracts;

namespace MotorCompany.Orders.API.Queries.Handlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IResult<OrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GetRepository<Order>().Get();

            var order = result.Value
                .Where(x => x.Id.Equals(request.Id))
                .SingleOrDefault();

            if (order == null)
                return Result.Failure(new Error($"Order # {request.Id} not found.")).For<OrderDto>(null);

            return Result.Success().For(_mapper.Map<OrderDto>(order));
        }
    }
}
