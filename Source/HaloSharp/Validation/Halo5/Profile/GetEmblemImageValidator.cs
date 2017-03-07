using System.Collections.Generic;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Profile;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.Profile
{
    public static class GetEmblemImageValidator
    {
        public static void Validate(this GetEmblemImage query)
        {
            var validationResult = new ValidationResult();

            if (!query.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetEmblemImage query requires a valid Gamertag (Player) to be set.");
            }

            if (query.Parameters.ContainsKey("size"))
            {
                var validSizes = new List<int> { 95, 128, 190, 256, 512 };

                int size;
                var parsed = int.TryParse(query.Parameters["size"], out size);

                if (!parsed || !validSizes.Contains(size))
                {
                    validationResult.Messages.Add($"GetEmblemImage optional parameter 'size' is invalid: {size}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
