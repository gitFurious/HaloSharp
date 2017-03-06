using HaloSharp.Exception;
using HaloSharp.Model;

namespace HaloSharp.Validation.HaloWars2.Metadata
{
    public static class GetTechsValidator
    {
        public static void Validate(this Query.HaloWars2.Metadata.GetTechs query)
        {
            var validationResult = new ValidationResult();

            if (query.Parameters.ContainsKey("startAt"))
            {
                int startAt;
                var parsed = int.TryParse(query.Parameters["startAt"], out startAt);

                if (!parsed || startAt % 100 != 0)
                {
                    validationResult.Messages.Add($"GetTechs optional parameter 'startAt' is invalid: {startAt}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}