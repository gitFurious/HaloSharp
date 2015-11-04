using HaloSharp.Model.Error;

namespace HaloSharp.Exception
{
    public class HaloApiException : System.Exception
    {
        public HaloApiError HaloApiError { get; set; }

        public HaloApiException(HaloApiError haloApiError)
        {
            HaloApiError = haloApiError;
        }

        public HaloApiException(int statusCode, string reasonPhrase)
        {
            HaloApiError = new HaloApiError
            {
                StatusCode = statusCode,
                Message = reasonPhrase
            };
        }
    }
}