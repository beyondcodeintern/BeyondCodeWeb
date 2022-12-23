using BeyondCode.Core;
using BeyondCode.Core.Helper;
using BeyondCode.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeyondCode.Helper
{
    public class HttpClientHelper : IRestHelper
    {

        public AuthenticationHeaderValue Authorization { get; set; }
        public HttpClientHelper()
        {
        }

 
        public async Task<string> GetAsync(string requestUri)
        {
            string result = "Error";
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient httpClient = new HttpClient(httpClientHandler))
                {
                    result = await httpClient.GetStringAsync(requestUri);
                }
            }
            return result;
        }

      
        public async Task<string> PostAsync<T>(string requestUri, T request) where T : class
        {
            string result = "Error";
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient httpClient = new HttpClient(httpClientHandler))
                {
                    if (Authorization != null)
                        httpClient.DefaultRequestHeaders.Authorization = Authorization;
                    //var settings = new JsonSerializerSettings()
                    //{
                    //    DateParseHandling = DateParseHandling.DateTimeOffset,
                    //    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    //    DateFormatString = "yyyy-MM-ddTHH:mm:ss"
                    //};
                    result = await httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(request))
                    {
                        Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                    }).Result.Content.ReadAsStringAsync();
                }
            }
            return result;
        }

        private void AddHeaders(HttpClient httpClient, Dictionary<string, string> additionalHeaders)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
           
            
            if (additionalHeaders == null)
                return;
          
            foreach (KeyValuePair<string, string> current in additionalHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(current.Key, current.Value);
            }
        }

        public async Task<string> PostAsync(string requestUri)
        {
             string result = "Error";
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient httpClient = new HttpClient(httpClientHandler))
                {
                    if (Authorization != null)
                        httpClient.DefaultRequestHeaders.Authorization = Authorization;

                    result = await httpClient.PostAsync(requestUri, new StringContent("")
                    {
                        Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                    }).Result.Content.ReadAsStringAsync();
                }
            }
            return result;
        }

        public async Task<string> PostAsync(string requestUri, string content)
        {
            string result = "Error";
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient httpClient = new HttpClient(httpClientHandler))
                {
                    if (Authorization != null)
                        httpClient.DefaultRequestHeaders.Authorization = Authorization;

                    result = await httpClient.PostAsync(requestUri, new StringContent(content)
                    {
                        Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                    }).Result.Content.ReadAsStringAsync();
                }
            }
            return result;
        }
    }
}