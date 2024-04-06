using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoginFlowInMauiBlazorApp.Services.HTTPService
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public HttpService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
        }
        public async Task<HttpResponseMessage> Delete<T>(string url, string token)
        {
            Uri uri = new Uri(string.Format(url));
            HttpResponseMessage? response = null;
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return response!;
        }

        public async Task<HttpResponseMessage> Get(string url, string token)
        {
            Uri uri = new(string.Format(url, string.Empty));
            HttpResponseMessage? response = null;
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                response = await _client.GetAsync(uri);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
            }

            return response!;
        }

        public async Task<HttpResponseMessage> GetWithoutToken(string url)
        {
            Uri uri = new(string.Format(url, string.Empty));
            HttpResponseMessage? response = null;
            try
            {
                response = await _client.GetAsync(uri);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
            }

            return response!;
        }

        public Task<HttpResponseMessage> Get<T>(string url, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> Post<T>(bool isNew, string url, T data)
        {
            Uri uri = new(string.Format(url, string.Empty));
            HttpResponseMessage? response = null;
            try
            {
                string json = JsonConvert.SerializeObject(data);
                StringContent content = new(json, Encoding.UTF8, "application/json");
                if (isNew)
                    response = await _client.PostAsync(uri, content);
                else
                    response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return response!;
        }

        public async Task<HttpResponseMessage> PostWithToken<T>(bool isNew, string url, T data, string token)
        {
            Uri uri = new(string.Format(url, string.Empty));
            HttpResponseMessage? response = null;
            try
            {
                string json = JsonConvert.SerializeObject(data);
                StringContent content = new(json, Encoding.UTF8, "application/json");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                if (isNew)
                    response = await _client.PostAsync(uri, content);
                else
                    response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return response!;
        }

        public Task<HttpResponseMessage> Put<T>(string url, T data, string token)
        {
            throw new NotImplementedException();
        }

    }
}
