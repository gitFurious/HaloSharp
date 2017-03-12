using HaloSharp.Model.Halo5.Metadata;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetSpartanRanks : Query<List<SpartanRank>>
    {
        public override string Uri => HaloUriBuilder.Build("metadata/h5/metadata/spartan-ranks");
    }
}