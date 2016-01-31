using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; }
        public bool Success => !Messages.Any();
    }
}
