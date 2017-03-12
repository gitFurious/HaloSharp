using HaloSharp.Model.Halo5.Profile;
using System;
using System.Threading.Tasks;

namespace HaloSharp
{
    public interface IHaloSession : IDisposable
    {
        Task<TResult> Get<TResult>(string path);
        Task<HaloImage> GetImage(string path);
    }
}