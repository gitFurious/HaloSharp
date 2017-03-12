
namespace HaloSharp.Validation.Common
{
    public static class StartAtValidator
    {
        public static bool IsValidStartAt(this int startAt)
        {
            return startAt % 100 == 0;
        }
    }
}
