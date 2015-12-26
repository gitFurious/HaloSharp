using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Profile;

namespace HaloSharp.Query.Profile
{
    public class GetEmblemImage : IQuery<GetImage>
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