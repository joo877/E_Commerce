using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public IReadOnlyList<Error> Errors { get; }
        protected Result(bool isSucess , IReadOnlyList<Error> errors )
        {
            IsSuccess = isSucess;
            Errors = errors;
        }

        public static Result OK() => new(true, Array.Empty<Error>());
        public static Result Fail(Error error) => new(false, new[] { error });
        public static Result Fail(IReadOnlyList<Error> errors) => new(false,  errors);


    }


    public class Result<TValue> : Result
    {
        private readonly TValue _value;
        public TValue data => IsSuccess ? _value : throw new InvalidOperationException("Cannot Access The Value Of Failed Result");

        private Result( TValue value) : base( true, Array.Empty<Error>())
        {
            _value = value;
        }
        private Result( Error error) : base( false, new[] { error})
        {
            _value = default!;
        }
        private Result(IReadOnlyList<Error> errors) : base( false, errors)
        {
            _value = default!;
        }

        public static Result<TValue> OK(TValue value) => new(value);
        public static Result<TValue> Fail(Error error) => new(error);
        public static Result<TValue> Fail(IReadOnlyList<Error> errors) => new(errors);



       
       
    }

}
