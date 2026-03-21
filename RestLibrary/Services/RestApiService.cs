
using Newtonsoft.Json;
using RestLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.Services
{
    public class RestApiService : IRestApi
    {

        private readonly HttpClient _httpClient;

        public RestApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> Get<T>(string url, string endpoint = "") where T : class
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri($"{url}{endpoint ?? string.Empty}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
