using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.UserGeneratedContent
{
    public static class ListGameVariantsValidator
    {
        public static void Validate(this ListGameVariants listGameVariants)
        {
            var validationResult = new ValidationResult();

            if (!listGameVariants.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("ListGameVariants query requires a valid Gamertag (Player) to be set.");
            }

            if (listGameVariants.Parameters.ContainsKey("count"))
            {
                int count;
                var parsed = int.TryParse(listGameVariants.Parameters["count"], out count);

                if (!parsed || count < 1 || count > 100)
                {
                    validationResult.Messages.Add($"ListGameVariants optional parameter 'Take' is invalid: {count}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
