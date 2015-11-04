using System;
using System.Drawing;
using System.Threading.Tasks;

namespace HaloSharp
{
    public interface IHaloSession : IDisposable
    {
        Task<TResult> Get<TResult>(string path);
        Task<Image> GetImage(string path);
    }
}