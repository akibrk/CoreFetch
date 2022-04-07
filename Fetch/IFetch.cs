using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Akibrk.Utility
{
    public interface IFetch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<FetchResponse<T>> Get<T>(string uri, IEnumerable<KeyValuePair<string, string>> headers = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<FetchResponse<T>> Post<T>(string uri, dynamic body, IEnumerable<KeyValuePair<string, string>> headers = null);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<FetchResponse<T>> Put<T>(string uri, dynamic body, IEnumerable<KeyValuePair<string, string>> headers = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<FetchResponse<T>> Patch<T>(string uri, dynamic body, IEnumerable<KeyValuePair<string, string>> headers = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<FetchResponse<T>> Delete<T>(string uri, IEnumerable<KeyValuePair<string, string>> headers = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        void SetDefaultHeaders(HttpHeaders headers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="value"></param>
        void SetAuthenticationHeader(string scheme, string value);

    }
}
