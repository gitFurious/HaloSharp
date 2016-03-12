using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Profile;
using HaloSharp.Validation.Profile;

namespace HaloSharp.Query.Profile
{
    /// <summary>
    ///     Construct a query to retrieve a player's Spartan Image Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetSpartanImage : IQuery<GetImage>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal string Player;

        private bool _useCache = true;

        public GetSpartanImage SkipCache()
        {
            _useCache = false;

            return this;
        }

        /// <summary>
        ///     The Player's gamertag.
        /// </summary>
        /// <param name="gamertag">The Player's gamertag.</param>
        public GetSpartanImage ForPlayer(string gamertag)
        {
            Player = gamertag;

            return this;
        }

        /// <summary>
        ///     An optional size (specified in pixels) of the image requested. When specified, this value must be one of the
        ///     following values: 95, 128, 190, 256, 512.
        /// </summary>
        /// <param name="size">An optional size (specified in pixels) of the image requested.</param>
        public GetSpartanImage Size(int size)
        {
            Parameters["size"] = size.ToString();

            return this;
        }

        /// <summary>
        ///     An optional crop that will be used to determine what portion of the Spartan is returned in the image.
        /// </summary>
        /// <param name="cropType">Crop that will be used to determine what portion of the Spartan is returned.</param>
        public GetSpartanImage Crop(Enumeration.CropType cropType)
        {
            Parameters["crop"] = cropType.ToString();

            return this;
        }

        public async Task<GetImage> ApplyTo(IHaloSession session)
        {
            this.Validate();

            var uri = GetConstructedUri();

            var spartanImage = _useCache
                ? Cache.Get<GetImage>(uri)
                : null;

            if (spartanImage == null)
            {
                var tuple = await session.GetImage(uri);

                spartanImage = new GetImage
                {
                    Uri = tuple.Item1,
                    Image = tuple.Item2
                };

                Cache.AddProfile(uri, spartanImage);
            }

            return spartanImage;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"profile/h5/profiles/{Player}/spartan");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}