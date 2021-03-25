using AutoMapper;
using MotorCompany.Orders.API.Contracts;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.API
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Core.Order, OrderDto>();
            CreateMap<Error, JsonApiSerializer.JsonApi.Error>();
        }
    }
}
