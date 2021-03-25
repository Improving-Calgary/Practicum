using System.Collections.Generic;
using System.Linq;

namespace MotorCompany.Orders.Core.Utility
{

    public class Result : IResult
    {
        public Result()
        {
            Errors = new IError[] { };
        }

        public static IResult Success() => new Result();

        public static IResult Failure(IEnumerable<IError> errors) => new Result()
        {
            Errors = errors ?? new IError[] { }
        };

        public static Result Failure(IError error) => new Result()
        {
            Errors = new[] { error }
        };

        public bool Succeeded => !Failed;

        public bool Failed => Errors.Any();

        public IEnumerable<IError> Errors { get; private set; }


        public IResult Add(IError error)
        {
            Errors = Errors.ToArray().Append(error);
            return this;
        }

        public IResult Add(IResult result)
        {
            Errors = Errors.Union(result.Errors);
            return this;
        }
    }

    public static class ResultExtensions
    {
        public static IResult<T> For<T>(this IResult result, T value)
        {
            return new ResultWithValue<T>(result, value);
        }

        private class ResultWithValue<T> : IResult<T>
        {
            private readonly IResult _inner;

            public ResultWithValue(IResult inner, T value)
            {
                Value = value;
                _inner = inner;
            }

            public T Value { get; }

            public bool Succeeded => _inner.Succeeded;

            public bool Failed => _inner.Failed;

            public IEnumerable<IError> Errors => _inner.Errors;

            public IResult Add(IResult result)
            {
                _inner.Add(result);
                return this;
            }

            public IResult Add(IError error)
            {
                _inner.Add(error);
                return this;
            }
        }
    }
}