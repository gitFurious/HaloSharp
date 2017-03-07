using System.Linq;
using System.Text;

namespace HaloSharp.Query.Halo5Forge.Stats
{
    public class GetMatchHistory : Halo5.Stats.GetMatchHistory
    {
        public GetMatchHistory(string gamertag) : base(gamertag) { }

        public override string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5pc/players/{Player}/matches");

            if (Parameters.Any())
            {
                builder.Append("?");
                builder.Append(string.Join("&", Parameters.Select(p => $"{p.Key}={p.Value}")));
            }

            return builder.ToString();
        }
    }
}