using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.UserGeneratedContent
{
    public static class ListMapVariantsValidator
    {
        public static void Validate(this ListMapVariants query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("ListMapVariants query requires a valid Gamertag (Player) to be set.");
            }

            if (query.Parameters.ContainsKey("count"))
            {
                int count;
                var parsed = int.TryParse(query.Parameters["count"], out count);

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
