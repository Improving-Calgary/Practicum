using System.Collections.Generic;

namespace MotorCompany.Orders.Core.Utility
{
    public interface IResult
    {
        bool Succeeded { get; }
        bool Failed { get; }
        IEnumerable<IError> Errors { get; }
        IResult Add(IError error);
        IResult Add(IResult result);
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
    }
}
