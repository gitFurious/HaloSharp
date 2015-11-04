using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Error;
using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HaloSharp
{
    public class HaloSession : IHaloSession
    {
        private const string Root = "https://www.haloapi.com/";
        private const string HeaderName = "Ocp-Apim-Subscription-Key";

        private readonly HttpClient _httpClient;
        private bool _isDisposed;

        public HaloSession(string subscriptionKey)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Add(HeaderName, subscriptionKey);
        }

        public async Task<TResult> Get<TResult>(string path)
        {
            var htpResponseMessage = await _httpClient.GetAsync(GetUrl(path));
            var content = await htpResponseMessage.Content.ReadAsStringAsync();

            if (!htpResponseMessage.IsSuccessStatusCode)
            {
                var haloApiError = await content.ParsedAsJson<HaloApiError>();

                if (haloApiError?.StatusCode != null)
                {
                    throw new HaloApiException(haloApiError);
                }

                throw new HaloApiException((int) htpResponseMessage.StatusCode, htpResponseMessage.ReasonPhrase);
            }

            return await content.ParsedAsJson<TResult>();
        }

        public async Task<Image> GetImage(string path)
        {
            var htpResponseMessage = await _httpClient.GetAsync(GetUrl(path));

            if (!htpResponseMessage.IsSuccessStatusCode)
            {
                throw new HaloApiException((int)htpResponseMessage.StatusCode, htpResponseMessage.ReasonPhrase);
            }

            using (var stream = await htpResponseMessage.Content.ReadAsStreamAsync())
            {
                return Image.FromStream(stream);
            }
        }

        private static string GetUrl(string path)
        {
            var builder = new StringBuilder();
            if (!path.StartsWith("http"))
            {
                builder.Append(Root);
            }
            builder.Append(path);
            return builder.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    _httpClient.Dispose();

                    _isDisposed = true;
                }
            }
        }
    }
}