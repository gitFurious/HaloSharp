using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.HaloWars2.Metadata;
using System.Collections.Generic;

namespace HaloSharp.Query.HaloWars2.Metadata
{
    public class GetCardKeywords : Query<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CardKeyword.View>>>
    {
        public override string Uri => HaloUriBuilder.Build("metadata/hw2/card-keywords", Parameters);

        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        private const string StartAtParameter = "startAt";

        public GetCardKeywords Skip(int count)
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

                if (!parsed || startAt % 100 != 0)
                {
                    validationResult.Messages.Add($"GetCardKeywords optional parameter '{StartAtParameter}' is invalid: {startAt}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}
