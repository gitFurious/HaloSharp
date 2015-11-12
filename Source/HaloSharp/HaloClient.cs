using HaloSharp.Model;

namespace HaloSharp
{
    public class HaloClient
    {
        private readonly Product _product;

        public HaloClient(Product product)
        {
            _product = product;
        }

        public IHaloSession StartSession()
        {
            var session = new HaloSession(_product);

            return session;
        }
    }
}