using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Akibrk.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class Fetch : IFetch
    {
        private readonly HttpClient _client;
        public Fetch()
        {
            _client = new HttpClient();
        }
        public Fetch(string baseURL)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseURL),
            };
        }

        public Fetch(string baseURL, IEnumerable<KeyValuePair<string, string>> defaultHeaders)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseURL),
            };

            foreach (var header in defaultHeaders)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

        }

        public async Task<FetchResponse<T>> Get<T>(string uri, IEnumerable<KeyValuePair<string, string>> headers = null)
        {
            try
            {
                // Create the request
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Content.Headers.Add(header.Key, header.Value);
                    }
                }

                // Send the request
                var response = await _client.SendAsync(request);

                if (response.Content == null)
                {
                    return new FetchResponse<T>(response.StatusCode);

                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new FetchResponse<T>(response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // We assume the content is the JSON response we are expecting
                    // Try parsing the response to an Object
                    T data = JsonConvert.DeserializeObject<T>(content);
                    return new FetchResponse<T>(response.StatusCode, data);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FetchResponse<T>> Post<T>(string uri, dynamic body, IEnumerable<KeyValuePair<string, string>> headers = null)
        {
            if (body.GetType() != typeof(string))
            {
                body = JsonConvert.SerializeObject(body);
            }

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri, UriKind.Relative),
                Method = HttpMethod.Post,
                Content = new StringContent(body)
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Content.Headers.Add(header.Key, header.Value);
                }
            }

            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            try
            {
                var response = await _client.SendAsync(request);

                if (response.Content == null)
                {
                    return new FetchResponse<T>(response.StatusCode);

                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new FetchResponse<T>(response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // We assume the content is the JSON response we are expecting
                    // Try parsing the response to an Object
                    T data = JsonConvert.DeserializeObject<T>(content);
                    return new FetchResponse<T>(response.StatusCode, data);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FetchResponse<T>> Put<T>(string uri, dynamic body, IEnumerable<KeyValuePair<string, string>> headers = null)
        {
            if (body.GetType() != typeof(string))
            {
                body = JsonConvert.SerializeObject(body);
            }

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Put,
                Content = new StringContent(body),
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Content.Headers.Add(header.Key, header.Value);
                }
            }

            try
            {
                var response = await _client.SendAsync(request);

                if (response.Content == null)
                {
                    return new FetchResponse<T>(response.StatusCode);

                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new FetchResponse<T>(response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // We assume the content is the JSON response we are expecting
                    // Try parsing the response to an Object
                    T data = JsonConvert.DeserializeObject<T>(content);
                    return new FetchResponse<T>(response.StatusCode, data);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FetchResponse<T>> Patch<T>(string uri, dynamic body, IEnumerable<KeyValuePair<string, string>> headers = null)
        {
            if (body.GetType() != typeof(string))
            {
                body = JsonConvert.SerializeObject(body);
            }

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Patch,
                Content = new StringContent(body),
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Content.Headers.Add(header.Key, header.Value);
                }
            }

            try
            {
                var response = await _client.SendAsync(request);

                if (response.Content == null)
                {
                    return new FetchResponse<T>(response.StatusCode);

                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new FetchResponse<T>(response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // We assume the content is the JSON response we are expecting
                    // Try parsing the response to an Object
                    T data = JsonConvert.DeserializeObject<T>(content);
                    return new FetchResponse<T>(response.StatusCode, data);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FetchResponse<T>> Delete<T>(string uri, IEnumerable<KeyValuePair<string, string>> headers = null)
        {
            try
            {
                // Create the request
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Content.Headers.Add(header.Key, header.Value);
                    }
                }

                // Send the request
                var response = await _client.SendAsync(request);

                if (response.Content == null)
                {
                    return new FetchResponse<T>(response.StatusCode);

                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new FetchResponse<T>(response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // We assume the content is the JSON response we are expecting
                    // Try parsing the response to an Object
                    T data = JsonConvert.DeserializeObject<T>(content);
                    return new FetchResponse<T>(response.StatusCode, data);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetDefaultHeaders(HttpHeaders headers)
        {
            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public void SetAuthenticationHeader(string scheme, string value)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, value);
        }

    }
}
