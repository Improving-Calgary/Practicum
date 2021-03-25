using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MotorCompany.Orders.Core;
using System.Linq;
using MotorCompany.Orders.Core.Utility;
using MotorCompany.Orders.API.Contracts;

namespace MotorCompany.Orders.API.Queries.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IResult<IEnumerable<OrderDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<OrderDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {           
            var result = await _unitOfWork.GetRepository<Order>().Get();

            var orders = result.Value.Where(x => x.State.Equals(request.State)).ToList();

            return Result.Success().For(_mapper.Map<IEnumerable<OrderDto>>(orders)); 
        }
    }
}
