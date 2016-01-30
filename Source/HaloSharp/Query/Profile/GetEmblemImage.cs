using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Profile;
using HaloSharp.Validation.Profile;

namespace HaloSharp.Query.Profile
{
    /// <summary>
    ///     Construct a query to retrieve a player's Emblem Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetEmblemImage : IQuery<GetImage>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal string Player;

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

            var tuple = await session.GetImage(GetConstructedUri());

            return new GetImage
            {
                Uri = tuple.Item1,
                Image = tuple.Item2
            };
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