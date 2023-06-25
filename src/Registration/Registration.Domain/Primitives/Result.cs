using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Registration.Domain.Primitives
{
    // Result Pattern
    public class Result
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string error) => new(false, error);

        public static Result Ok() => new(true, String.Empty);

        public static Result<T> Fail<T>(string error) => new(default, true, String.Empty);

        public static Result<T> Ok<T>(T result) => new(result, true, String.Empty);

    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        protected internal Result(T res, bool success, string error) : base(success, error)
        {
            Data = res;
        }
    }
}
