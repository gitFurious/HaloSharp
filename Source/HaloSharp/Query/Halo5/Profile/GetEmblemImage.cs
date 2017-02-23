using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Profile;
using HaloSharp.Validation.Halo5.Profile;

namespace HaloSharp.Query.Halo5.Profile
{
    /// <summary>
    ///     Construct a query to retrieve a player's Emblem Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetEmblemImage : IQuery<GetImage>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal string Player;

        private bool _useCache = true;

        public GetEmblemImage SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     The Player's gamertag.
        /// </summary>
        /// <param name="gamertag">The Player's gamertag.</param>
        public GetEmblemImage ForPlayer(string gamertag)
        {
            Player = gamertag;

            return this;
        }

        /// <summary>
        ///     An optional size (specified in pixels) of the image requested. When specified, this value must be one of the
        ///     following values: 95, 128, 190, 256, 512.
        /// </summary>
        /// <param name="size">An optional size (specified in pixels) of the image requested.</param>
        public GetEmblemImage Size(int size)
        {
            Parameters["size"] = size.ToString();

            return this;
        }

        public async Task<GetImage> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var emblemImage = _useCache
                ? Cache.Get<GetImage>(uri)
                : null;

            if (emblemImage == null)
            {
                var tuple = await session.GetImage(uri);

                emblemImage = new GetImage
                {
                    Uri = tuple.Item1,
                    Image = tuple.Item2
                };

                Cache.AddProfile(uri, emblemImage);
            }

            return emblemImage;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"profile/h5/profiles/{Player}/emblem");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}