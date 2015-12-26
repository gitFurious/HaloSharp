using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    public class GetWeapons : IQuery<List<Weapon>>
    {
        private const string CacheKey = "Weapons";

        private bool _useCache = true;

        public GetWeapons SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<Weapon>> ApplyTo(IHaloSession session)
        {
            var weapons = _useCache
                ? Cache.Get<List<Weapon>>(CacheKey)
                : null;

            if (weapons != null)
            {
                return weapons;
            }

            weapons = await session.Get<List<Weapon>>(GetConstructedUri());

            Cache.Add(CacheKey, weapons);

            return weapons;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/weapons");

            return builder.ToString();
        }
    }
}
