using System;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Validation.Common;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.UserGeneratedContent
{
    public class ListGameVariants : Query<GameVariantResult>
    {
        public override string Uri => HaloUriBuilder.Build($"ugc/h5/players/{_player}/gamevariants", _parameters);

        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();
        private const string SortParameter = "sort";
        private const string OrderParameter = "order";
        private const string StartParameter = "start";
        private const string CountParameter = "count";

        private readonly string _player;

        public ListGameVariants(string gamertag)
        {
            _player = gamertag;
        }

        public ListGameVariants SortBy(Enumeration.Halo5.UserGeneratedContentSort sort)
        {
            _parameters[SortParameter] = sort.ToString();

            return this;
        }

        public ListGameVariants OrderByDescending()
        {
            _parameters[OrderParameter] = "desc";

            return this;
        }

        public ListGameVariants OrderByAscending()
        {
            _parameters[OrderParameter] = "asc";

            return this;
        }

        public ListGameVariants Skip(int count)
        {
            _parameters[StartParameter] = count.ToString();

            return this;
        }

        public ListGameVariants Take(int count)
        {
            _parameters[CountParameter] = count.ToString();

            return this;
        }

        protected override void Validate()
        {
            var validationResult = new ValidationResult();

            if (!_player.IsValidGamertag())
            {
                validationResult.Messages.Add("ListGameVariants query requires a valid Gamertag to be set.");
            }

            if (_parameters.ContainsKey(SortParameter))
            {
                var sort = _parameters[SortParameter];

                var defined = Enum.IsDefined(typeof(Enumeration.Halo5.UserGeneratedContentSort), sort);

                if (!defined)
                {
                    validationResult.Messages.Add($"ListGameVariants optional parameter '{SortParameter}' is invalid: {sort}.");
                }
            }

            if (_parameters.ContainsKey(CountParameter))
            {
                int take;
                var parsed = int.TryParse(_parameters[CountParameter], out take);

                if (!parsed || !take.IsValidTake())
                {
                    validationResult.Messages.Add($"ListGameVariants optional parameter '{CountParameter}' is invalid: {take}.");
                }
            }

            if (!validationResult.Success)
            {
                throw new ValidationException(validationResult.Messages);
            }
        }
    }
}