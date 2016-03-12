using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Model;
using HaloSharp.Model.Metadata;

namespace HaloSharp.Query.Metadata
{
    /// <summary>
    ///     Construct a query to retrieve detailed Vehicle Metadata. Use them to translate IDs from other APIs.
    /// </summary>
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