using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MotorCompany.Orders.API.Queries;
using MotorCompany.Orders.Core.Commands;
using MotorCompany.Orders.Core;
using AutoMapper;
using MotorCompany.Orders.API.Utility;
using MotorCompany.Orders.API.Contracts;

namespace MotorCompany.Orders.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get(EnumOrderStates state)
        {
            var result = await _mediator.Send(new GetOrdersQuery(state));

            if (result.Succeeded) return result.Value.AsGetResult();

            return result.ToJsonApiErrors(_mapper).AsNotFoundErrorResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetOrderQuery(id));

            if (result.Succeeded) return result.Value.AsGetResult();

            return result.ToJsonApiErrors(_mapper).AsNotFoundErrorResult();
        }

        [HttpGet("next")]
        public async Task<ActionResult> Next()
        {
            var result = await _mediator.Send(new GetNextOrderQuery());

            if (result.Succeeded) return result.Value.AsGetResult();

            return result.ToJsonApiErrors(_mapper).AsNotFoundErrorResult();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateOrderDto createOrderDto)
        {
            var result = await _mediator.Send(new CreateOrderCommand(createOrderDto.CustomerId, createOrderDto.VehicleId));

            if (result.Succeeded) return _mapper.Map<OrderDto>(result.Value).AsPostResult(); 

            return result.ToJsonApiErrors(_mapper).AsBadRequestErrorResult();
        }

        [HttpPut("{id}/start")]
        public async Task<ActionResult> Start(int id)
        {
            var result = await _mediator.Send(new StartCommand(id));

            if (result.Succeeded) return new NoContentResult();

            return result.ToJsonApiErrors(_mapper).AsBadRequestErrorResult();
        }

        [HttpPut("{id}/pause")]
        public async Task<ActionResult> Pause(int id)
        {
            var result = await _mediator.Send(new PauseCommand(id));

            if (result.Succeeded) return new NoContentResult();

            return result.ToJsonApiErrors(_mapper).AsBadRequestErrorResult();
        }

        [HttpPut("{id}/cancel")]
        public async Task<ActionResult> Cancel(int id)
        {
            var result = await _mediator.Send(new CancelCommand(id));

            if (result.Succeeded) return new NoContentResult();

            return result.ToJsonApiErrors(_mapper).AsBadRequestErrorResult();
        }

        [HttpPut("{id}/complete")]
        public async Task<ActionResult> Complete(int id)
        {
            var result = await _mediator.Send(new CompleteCommand(id));

            if (result.Succeeded) return new NoContentResult();

            return result.ToJsonApiErrors(_mapper).AsBadRequestErrorResult();
        }
    }
}

