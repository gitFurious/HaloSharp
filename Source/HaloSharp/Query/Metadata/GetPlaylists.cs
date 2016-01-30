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
        private const string CacheKey = "Playlists";

        private bool _useCache = true;

        public GetPlaylists SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Playlist>> ApplyTo(IHaloSession session)
        {
            var playlists = _useCache
                ? Cache.Get<List<Playlist>>(CacheKey)
                : null;

            if (playlists != null)
            {
                return playlists;
            }

            playlists = await session.Get<List<Playlist>>(GetConstructedUri());

            Cache.Add(CacheKey, playlists);

            return playlists;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/playlists");

            return builder.ToString();
        }
    }
}