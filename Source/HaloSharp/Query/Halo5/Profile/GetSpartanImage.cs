using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Profile;
using HaloSharp.Validation.Halo5.Profile;

namespace HaloSharp.Query.Halo5.Profile
{
    public class GetSpartanImage : IQuery<GetImage>
    {
        internal readonly IDictionary<string, string> Parameters = new Dictionary<string, string>();
        internal readonly string Player;

        private bool _useCache = true;

        public GetSpartanImage(string gamertag)
        {
            Player = gamertag;
        }

        public GetSpartanImage SkipCache()
        {
            _useCache = false;

            return this;
        }

        public GetSpartanImage Size(int size)
        {
            Parameters["size"] = size.ToString();

            return this;
        }

        public GetSpartanImage Crop(Enumeration.Halo5.CropType cropType)
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