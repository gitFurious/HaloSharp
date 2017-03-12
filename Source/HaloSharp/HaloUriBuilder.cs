using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaloSharp
{
    public static class HaloUriBuilder
    {
        public static string Build(string path, IDictionary<string, string> parameters = null)
        {
            var uriBuilder = new UriBuilder("https", "www.haloapi.com")
            {
                Path = path
            };

            if (parameters != null && parameters.Any())
            {
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);

                foreach (var parameter in parameters)
                {
                    query[parameter.Key] = parameter.Value;
                }

                uriBuilder.Query = query.ToString();
            }

            return uriBuilder.Uri.ToString();
        }
    }
}
