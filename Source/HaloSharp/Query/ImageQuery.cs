using System.Threading.Tasks;
using HaloSharp.Model.Halo5.Profile;

namespace HaloSharp.Query
{
    public abstract class ImageQuery : IQuery<HaloImage>
    {
        private bool _useCache = true;

        public ImageQuery SkipCache()
        {
            _useCache = false;

            return this;
        }

        public abstract string Uri { get; }

        public async Task<HaloImage> ApplyTo(IHaloSession session)
        {
            Validate();

            var response = _useCache
                ? Cache.Get<HaloImage>(Uri)
                : null;

            if (response == null)
            {
                response = await session.GetImage(Uri);

                Cache.Add(Uri, response);
            }

            return response;
        }

        protected virtual void Validate() { }
    }
}
