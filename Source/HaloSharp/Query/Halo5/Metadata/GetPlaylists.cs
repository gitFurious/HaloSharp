using HaloSharp.Model.Halo5.Metadata;
using System.Collections.Generic;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetPlaylists : Query<List<Playlist>>
    {
        public override string Uri => HaloUriBuilder.Build("metadata/h5/metadata/playlists");
    }
}