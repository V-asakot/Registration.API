using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            => ErrorsDictionary = errorsDictionary;

        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}
