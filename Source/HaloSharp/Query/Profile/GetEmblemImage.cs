using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Profile
{
    public class GetEmblemImage : IQuery<Image>
    {
        private readonly IDictionary<string, string> _parameters = new Dictionary<string, string>();

        private string _player;

        public GetEmblemImage ForPlayer(string gamertag)
        {
            _player = gamertag;
            return this;
        }

        public GetEmblemImage Size(int size)
        {
            _parameters["size"] = size.ToString();
            return this;
        }

        public async Task<Image> ApplyTo(IHaloSession session)
        {
            var emblem = await session.GetImage(MakeUrl());

            return emblem;
        }

        private string MakeUrl()
        {
            var builder = new StringBuilder($"profile/h5/profiles/{_player}/emblem");

            if (_parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", _parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}