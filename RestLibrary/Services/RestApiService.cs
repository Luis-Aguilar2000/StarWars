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
        public async Task Get(string url, string endpoint = "")
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"{url}{endpoint ?? string.Empty}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            throw new Exception(result);
        }
    }
}
