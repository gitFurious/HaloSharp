using HaloSharp.Model.Halo5.Metadata;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetWeapons : Query<List<Weapon>>
    {
        public override string Uri => HaloUriBuilder.Build("metadata/h5/metadata/weapons");
    }
}