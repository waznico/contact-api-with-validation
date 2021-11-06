using System.Collections.Generic;
using System.Runtime.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace ContactService.Exceptions
{
    public class MediatorValidationException : ValidationException
    {
        public MediatorValidationException(string message) : base(message)
        {
        }

        public MediatorValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
        {
        }

        public MediatorValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
        {
        }

        public MediatorValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MediatorValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
        {
        }
    }
}
