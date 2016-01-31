using System.Text.RegularExpressions;

namespace HaloSharp.Validation.Common
{
    public static class GamertagValidator
    {
        public static bool IsValidGamertag(this string gamertag)
        {
            var regex = new Regex(@"^[a-zA-Z0-9 ]{1,16}$");

            return !string.IsNullOrWhiteSpace(gamertag) && regex.IsMatch(gamertag);
        }
    }
}
