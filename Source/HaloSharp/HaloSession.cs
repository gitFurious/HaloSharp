using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Error;
using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HaloSharp.Model;

namespace HaloSharp
{
    public class HaloSession : IHaloSession
    {
        private const string Root = "https://www.haloapi.com/";
        private const string HeaderName = "Ocp-Apim-Subscription-Key";

        private readonly RateGate _rateGate;
        private readonly HttpClient _httpClient;

        private bool _isDisposed;

        public HaloSession(Product product)
        {
            if (product.RateLimit != null)
            {
                _rateGate = new RateGate(product.RateLimit);
            }

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Add(HeaderName, product.SubscriptionKey);
        }

        public async Task<TResult> Get<TResult>(string path)
        {
            var entered = _rateGate?.WaitToProceed() ?? true;
            if (!entered)
            {
                throw new HaloApiException(new HaloApiError
                {
                    Message = "Rate limit timeout reached."
                });
            }

            var httpResponseMessage = await _httpClient.GetAsync(GetUrl(path));
            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            _rateGate?.SignalExit();

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var haloApiError = await content.ParsedAsJson<HaloApiError>();

                if (haloApiError?.StatusCode != null)
                {
                    throw new HaloApiException(haloApiError);
                }

                throw new HaloApiException((int) httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
            }

            return await content.ParsedAsJson<TResult>();
        }

        public async Task<Tuple<string, Image>> GetImage(string path)
        {
            var entered = _rateGate?.WaitToProceed() ?? true;
            if (!entered)
            {
                throw new HaloApiException(new HaloApiError
                {
                    Message = "Rate limit timeout reached."
                });
            }

            var htpResponseMessage = await _httpClient.GetAsync(GetUrl(path));

            _rateGate?.SignalExit();

            if (!htpResponseMessage.IsSuccessStatusCode)
            {
                throw new HaloApiException((int)htpResponseMessage.StatusCode, htpResponseMessage.ReasonPhrase);
            }

            var uri = htpResponseMessage.RequestMessage.RequestUri.ToString();

            Image image;
            using (var stream = await htpResponseMessage.Content.ReadAsStreamAsync())
            {
                image = Image.FromStream(stream);
            }

            return new Tuple<string, Image>(uri, image);
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
                    _rateGate?.Dispose();

                    _isDisposed = true;
                }
            }
        }
    }
}