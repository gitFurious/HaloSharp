﻿using System.Text;

namespace HaloSharp.Query.Halo5Forge.Stats.CarnageReport
{
    public class GetCustomMatchDetails : Halo5.Stats.CarnageReport.GetCustomMatchDetails
    {
        public override string GetConstructedUri()
        {
            var builder = new StringBuilder($"stats/h5pc/custom/matches/{MatchId}");

            return builder.ToString();
        }
    }
}