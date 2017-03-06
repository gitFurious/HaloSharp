﻿using System.Linq;
using System.Text;

namespace HaloSharp.Query.Halo5Forge.Stats
{
    public class GetMatches : Halo5.Stats.GetMatches
    {
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