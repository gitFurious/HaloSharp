﻿using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Validation.Common;
using System;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Profile
{
    public class GetSpartanImage : ImageQuery
    {
        public override string Uri => HaloUriBuilder.Build($"profile/h5/profiles/{_player}/spartan", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string SizeParameter = "size";
        private const string CropParameter = "crop";

        private readonly string _player;

        public GetSpartanImage(string gamertag)
        {
            _player = gamertag;
        }

        public GetSpartanImage Size(int size)
        {
            _parameters[SizeParameter] = size.ToString();

            return this;
        }

        public GetSpartanImage Crop(Enumeration.Halo5.CropType cropType)
        {
            _parameters[CropParameter] = cropType.ToString();

            return this;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("GetSpartanImage query requires a valid Gamertag (Player) to be set.");
            }

            if (_parameters.ContainsKey(SizeParameter))
            {
                int size;
                var parsed = int.TryParse(_parameters[SizeParameter], out size);

                if (!parsed || !size.IsValidSize())
                {
                    validationResult.Messages.Add($"GetSpartanImage optional parameter '{SizeParameter}' is invalid: {size}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}