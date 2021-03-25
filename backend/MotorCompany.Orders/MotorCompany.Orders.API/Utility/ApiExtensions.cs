using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using JsonApiSerializer;
using System.Collections.Generic;
using MotorCompany.Orders.Core.Utility;

namespace MotorCompany.Orders.API.Utility
{
    public static class ApiExtensions
    {
        public static IEnumerable<JsonApiSerializer.JsonApi.Error> ToJsonApiErrors(this IResult result, IMapper mapper)
        {
            return mapper.Map<IEnumerable<JsonApiSerializer.JsonApi.Error>>(result.Errors);
        }

        public static string WrapInJsonApiDoc<T>(this T value)
        {
            return JsonConvert.SerializeObject(value, new JsonApiSerializerSettings());
        }

        public static ObjectResult AsPostResult<T>(this T value, string location = "")
        {
            return new CreatedResult(location, value.WrapInJsonApiDoc());
        }

        public static ObjectResult AsGetResult<T>(this T value)
        {
            return new OkObjectResult(value.WrapInJsonApiDoc());
        }

        public static ObjectResult AsBadRequestErrorResult<T>(this T value)
        {
            return new BadRequestObjectResult(value.WrapInJsonApiDoc());
        }

        public static ObjectResult AsNotFoundErrorResult<T>(this T value)
        {
            return new NotFoundObjectResult(value.WrapInJsonApiDoc());
        }
    }
}

