using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Metadata;

namespace HaloSharp.Query.Halo5.Metadata
{
    public class GetVehicles : IQuery<List<Vehicle>>
    {
        private bool _useCache = true;

        public GetVehicles SkipCache()
        {
            _useCache = false;

            return this;
        }

        public async Task<List<Vehicle>> ApplyTo(IHaloSession session)
        {
            var uri = GetConstructedUri();

            var vehicles = _useCache
                ? Cache.Get<List<Vehicle>>(uri)
                : null;

            if (vehicles == null)
            {
                vehicles = await session.Get<List<Vehicle>>(uri);

                Cache.AddMetadata(uri, vehicles);
            }

            return vehicles;
        }

        public string GetConstructedUri()
        {
            var builder = new StringBuilder("metadata/h5/metadata/vehicles");

            return builder.ToString();
        }
    }
}