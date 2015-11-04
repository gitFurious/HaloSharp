using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

            weapons = await session.Get<List<Weapon>>(MakeUrl());

            Cache.Add(CacheKey, weapons);

            return weapons;
        }

        private static string MakeUrl()
        {
            var builder = new StringBuilder("metadata/h5/metadata/weapons");

            return builder.ToString();
        }
    }
}
