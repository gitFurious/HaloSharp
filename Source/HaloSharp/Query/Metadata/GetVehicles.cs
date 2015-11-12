using HaloSharp.Model.Metadata;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp.Query.Metadata
{
    public class GetVehicles : IQuery<List<Vehicle>>
    {
        private const string CacheKey = "Vehicles";

        private bool _useCache = true;

        public GetVehicles SkipCache()
        {
            _useCache = false;
            return this;
        }

        public async Task<List<Vehicle>> ApplyTo(IHaloSession session)
        {
            var vehicles = _useCache
                ? Cache.Get<List<Vehicle>>(CacheKey)
                : null;

            if (vehicles != null)
            {
                return vehicles;
            }

            vehicles = await session.Get<List<Vehicle>>(GetConstructedUri());

            Cache.Add(CacheKey, vehicles);

            return vehicles;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/vehicles");

            return builder.ToString();
        }
    }
}
