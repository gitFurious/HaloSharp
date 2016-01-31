using System.Collections.Generic;
using HaloSharp.Model.Error;

namespace HaloSharp.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationError ValidationError { get; private set; }

        public ValidationException(ValidationError validationError)
        {
            ValidationError = validationError;
        }

        public ValidationException(List<string> messages)
        {
            ValidationError = new ValidationError
            {
                Messages = messages
            };
        }
    }
}