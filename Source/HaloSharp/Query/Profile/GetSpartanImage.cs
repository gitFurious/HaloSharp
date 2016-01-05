using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model;
using HaloSharp.Model.Profile;

namespace HaloSharp.Query.Profile
{
    /// <summary>
    /// Construct a query to retrieve a player's Spartan Image Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetSpartanImage : IQuery<GetImage>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        private string _player;

        /// <summary>
        /// The Player's gamertag.
        /// </summary>
        /// <param name="gamertag">The Player's gamertag.</param>
        public GetSpartanImage ForPlayer(string gamertag)
        {
            _player = gamertag;
            return this;
        }

        /// <summary>
        /// An optional size (specified in pixels) of the image requested. When specified, this value must be one of the
        ///  following values: 95, 128, 190, 256, 512.
        /// </summary>
        /// <param name="size">An optional size (specified in pixels) of the image requested.</param>
        public GetSpartanImage Size(int size)
        {
            _parameters["size"] = size.ToString();
            return this;
        }

        /// <summary>
        /// An optional crop that will be used to determine what portion of the Spartan is returned in the image.
        /// </summary>
        /// <param name="cropType">Crop that will be used to determine what portion of the Spartan is returned.</param>
        public GetSpartanImage Crop(Enumeration.CropType cropType)
        {
            _parameters["crop"] = cropType.ToString();
            return this;
        }

        public async Task<GetImage> ApplyTo(IHaloSession session)
        {
            var tuple = await session.GetImage(GetConstructedUri());

            return new GetImage
            {
                Uri = tuple.Item1,
                Image = tuple.Item2
            };
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder($"profile/h5/profiles/{_player}/spartan");

            if (_parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", _parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}