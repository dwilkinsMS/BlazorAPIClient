using BlazorAPIClient.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorAPIClient.Client.DataServices
{
    public class RestService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;

        public RestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Launch[]> GetAllLaunches()
        {
            return await _httpClient.GetFromJsonAsync<Launch[]>("/rest/launches");
        }
    }
}
