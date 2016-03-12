using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Playlist Metadata. Use them to translate IDs from other APIs.
    /// </summary>
    public class GetPlaylists : IQuery<List<Playlist>>
    {
        private bool _useCache = true;

        public GetPlaylists SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Playlist>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var playlists = _useCache
                ? Cache.Get<List<Playlist>>(uri)
                : null;

            if (playlists == null)
            {
                playlists = await session.Get<List<Playlist>>(uri);

                Cache.AddMetadata(uri, playlists);
            }

            return playlists;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/playlists");

            return builder.ToString();
        }
    }
}