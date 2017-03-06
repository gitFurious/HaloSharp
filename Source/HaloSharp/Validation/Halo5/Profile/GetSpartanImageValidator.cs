using System;
using System.Collections.Generic;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Query.Halo5.Profile;
using HaloSharp.Validation.Common;

namespace HaloSharp.Validation.Halo5.Profile
{
    public static class GetSpartanImageValidator
    {
        public static void Validate(this GetSpartanImage getSpartanImage)
        {
            var validationResult = new ValidationResult();

            if (!getSpartanImage.Player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetSpartanImage query requires a valid Gamertag (Player) to be set.");
            }

            if (getSpartanImage.Parameters.ContainsKey("size"))
            {
                var validSizes = new List<int> { 95, 128, 190, 256, 512 };

                int size;
                var parsed = int.TryParse(getSpartanImage.Parameters["size"], out size);

                if (!parsed || !validSizes.Contains(size))
                {
                    validationResult.Messages.Add($"GetSpartanImage optional parameter 'Size' is invalid: {size}.");
                }
            }

            if (getSpartanImage.Parameters.ContainsKey("crop"))
            {
                var crop = getSpartanImage.Parameters["crop"];

                var defined = Enum.IsDefined(typeof(Enumeration.Halo5.CropType), crop);

                if (!defined)
                {
                    validationResult.Messages.Add($"GetSpartanImage optional parameter 'Crop' is invalid: {crop}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
