using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.UserGeneratedContent;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.UserGeneratedContent
{
    public static class ListMapVariantsValidator
    {
        public static void Validate(this ListMapVariants listMapVariants)
        {
            var validationResult = new ValidationResult();

            if (!listMapVariants.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("ListMapVariants query requires a valid Gamertag (Player) to be set.");
            }

            if (listMapVariants.Parameters.ContainsKey("count"))
            {
                int count;
                var parsed = int.TryParse(listMapVariants.Parameters["count"], out count);

                if (!parsed || count < 1 || count > 100)
                {
                    validationResult.Messages.Add($"ListMapVariants optional parameter 'Take' is invalid: {count}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
