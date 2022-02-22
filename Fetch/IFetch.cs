using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Akibrk.Utility.Fetch
{
    public interface IFetch
    {
        Task<FetchResponse<T>> Get<T>(string uri, HttpHeaders headers = null);

        Task<FetchResponse<T>> Post<T>(string uri, dynamic body, HttpHeaders headers = null);

        Task<FetchResponse<T>> Put<T>(string uri, dynamic body, HttpHeaders headers = null);

        Task<FetchResponse<T>> Patch<T>(string uri, dynamic body, HttpHeaders headers = null);

        Task<FetchResponse<T>> Delete<T>(string uri, HttpHeaders headers = null);
        void SetDefaultHeaders(HttpHeaders headers);
        void SetAuthenticationHeader(string scheme, string value);

    }
}
