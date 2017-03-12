using System.Collections.Generic;

namespace HaloSharp.Query.Halo5Forge.Stats.Lifetime
{
    public class GetCustomServiceRecord : Halo5.Stats.Lifetime.GetCustomServiceRecord
    {
        protected override string Path => "stats/h5pc/servicerecords/custom";

        public GetCustomServiceRecord(string gamertag) : base(gamertag) { }

        public GetCustomServiceRecord(IEnumerable<string> gamertags) : base(gamertags) { }
    }
}