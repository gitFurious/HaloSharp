using System.Threading.Tasks;

namespace HaloSharp.Extension
{
    public static class HaloSessionExtensions
    {
        public static Task<TResult> Query<TResult>(this IHaloSession session, IQuery<TResult> results)
        {
            return results.ApplyTo(session);
        }
    }
}