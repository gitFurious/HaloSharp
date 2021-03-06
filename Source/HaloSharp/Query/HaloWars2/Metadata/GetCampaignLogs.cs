﻿using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.HaloWars2.Metadata;
using System.Collections.Generic;
using HaloSharp.Validation.Common;

namespace HaloSharp.Query.HaloWars2.Metadata
{
    public class GetCampaignLogs : Query<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLog.View>>>
    {
        public override string Uri => HaloUriBuilder.Build("metadata/hw2/campaign-logs", Parameters);

        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        private const string StartAtParameter = "startAt";

        public GetCampaignLogs Skip(int count)
        {
            Parameters[StartAtParameter] = count.ToString();

            return this;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (Parameters.ContainsKey(StartAtParameter))
            {
                int startAt;
                var parsed = int.TryParse(Parameters[StartAtParameter], out startAt);

                if (!parsed || !startAt.IsValidStartAt())
                {
                    validationResult.Messages.Add($"GetCampaignLogs optional parameter '{StartAtParameter}' is invalid: {startAt}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
