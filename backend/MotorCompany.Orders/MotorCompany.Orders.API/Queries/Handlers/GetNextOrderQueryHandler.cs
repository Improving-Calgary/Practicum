using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MotorCompany.Orders.Core;
using System.Linq;
using MotorCompany.Orders.Core.Utility;
using MotorCompany.Orders.API.Contracts;

namespace MotorCompany.Orders.API.Queries.Handlers
{
    public class GetNextOrderQueryHandler : IRequestHandler<GetNextOrderQuery, IResult<OrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNextOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<OrderDto>> Handle(GetNextOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.GetRepository<Order>().Get();

            var order = result.Value
                .Where(x => x.State.Equals(EnumOrderStates.New))
                .OrderBy(o => o.CreationDate)
                .FirstOrDefault();

            return Result.Success().For(_mapper.Map<OrderDto>(order));
        }
    }
}
