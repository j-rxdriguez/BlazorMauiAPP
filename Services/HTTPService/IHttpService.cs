using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginFlowInMauiBlazorApp.Services.HTTPService
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> Get(string url, string token);
        Task<HttpResponseMessage> Get<T>(string url, string token);
        Task<HttpResponseMessage> GetWithoutToken(string url);
        Task<HttpResponseMessage> Post<T>(bool isNew, string url, T data);
        Task<HttpResponseMessage> PostWithToken<T>(bool isNew, string url, T data, string token);
        Task<HttpResponseMessage> Put<T>(string url, T data, string token);
        Task<HttpResponseMessage> Delete<T>(string url, string token);

    }
}
