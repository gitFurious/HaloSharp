
namespace HaloSharp.Validation.Common
{
    public static class TakeValidator
    {
        public static bool IsValidTake(this int take)
        {
            return take > 0;
        }
    }
}
