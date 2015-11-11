using HaloSharp.Model;
using HaloSharp.Model.Profile;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Profile
{
    public class GetSpartanImage : IQuery<GetImage>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        private string _player;

        public GetSpartanImage ForPlayer(string gamertag)
        {
            _player = gamertag;
            return this;
        }

        public GetSpartanImage Size(int size)
        {
            _parameters["size"] = size.ToString();
            return this;
        }

        public GetSpartanImage Crop(Enumeration.CropType cropType)
        {
            _parameters["crop"] = cropType.ToString();
            return this;
        }

        public async Task<GetImage> ApplyTo(IHaloSession session)
        {
            var tuple = await session.GetImage(MakeUrl());

            return new GetImage
            {
                Uri = tuple.Item1,
                Image = tuple.Item2
            };
        }

        private string MakeUrl()
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