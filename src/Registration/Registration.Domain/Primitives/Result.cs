using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registration.Domain.Primitives
{
    // Result Pattern
    public class Result
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }

        protected Result(bool success, IEnumerable<string> errors)
        {
            Success = success;
            Errors = errors;
        }
        public static Result FailMany(IEnumerable<string> errors) => new(false, errors);
        public static Result Fail(string error) => new(false, new string[]{ error });

        public static Result Ok() => new(true, Array.Empty<string>());

        public static Result<T> FailMany<T>(IEnumerable<string> errors) => new(default, false, errors);

        public static Result<T> Fail<T>(string error) => new(default, false, new string[] { error });

        public static Result<T> Ok<T>(T result) => new(result, true, Array.Empty<string>());

    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        public Result(T res, bool success, IEnumerable<string> errors) : base(success, errors)
        {
            Data = res;
        }
        
    }
}
