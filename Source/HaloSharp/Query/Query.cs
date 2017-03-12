using System.Threading.Tasks;

namespace HaloSharp.Query
{
    public abstract class Query<T> : IQuery<T> where T : class
    {
        private bool _useCache = true;

        public Query<T> SkipCache()
        {
            _useCache = false;

            return this;
        }

        public abstract string Uri { get; }

        public virtual async Task<T> ApplyTo(IHaloSession session)
        {
            Validate();

            var response = _useCache
                ? Cache.Get<T>(Uri)
                : null;

            if (response == null)
            {
                response = await session.Get<T>(Uri);

                Cache.Add(Uri, response);
            }

            return response;
        }

        protected virtual void Validate() { }
    }
}
