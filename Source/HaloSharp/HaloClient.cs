using HaloSharp.Model;

namespace HaloSharp
{
    public class HaloClient
    {
        private readonly Product _product;
        private readonly CacheSettings _cacheSettings;

        public HaloClient(Product product, CacheSettings cacheSettings = null)
        {
            _product = product;
            _cacheSettings = cacheSettings;
        }

        public IHaloSession StartSession()
        {
            var session = new HaloSession(_product);

            Cache.CacheDuration = _cacheSettings?.CacheDuration;

            return session;
        }
    }
}