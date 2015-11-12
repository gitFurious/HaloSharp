using System.Threading.Tasks;

namespace HaloSharp
{
    public interface IQuery<TResult>
    {
        Task<TResult> ApplyTo(IHaloSession session);
        string GetConstructedUri();
    }
}