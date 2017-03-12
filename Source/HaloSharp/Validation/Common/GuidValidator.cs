using System;

namespace HaloSharp.Validation.Common
{
    public static class GuidValidator
    {
        public static bool IsValid(this Guid guid)
        {
            return guid != default(Guid);
        }
    }
}
