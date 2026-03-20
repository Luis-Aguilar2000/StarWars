using RestLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.Services
{
    public class RestApiService : IRestApi
    {

        private readonly HttpClient _httpClient;
        public Task Get(string url, string endpoint = "")
        {
            throw new NotImplementedException();
        }
    }
}
