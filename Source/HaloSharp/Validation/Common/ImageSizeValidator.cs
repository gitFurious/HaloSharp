using System.Collections.Generic;

namespace HaloSharp.Validation.Common
{
    public static class ImageSizeValidator
    {
        public static bool IsValidSize(this int size)
        {
            var validSizes = new List<int> { 95, 128, 190, 256, 512 };

            return validSizes.Contains(size);
        }
    }
}
