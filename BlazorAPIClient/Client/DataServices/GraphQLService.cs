using BlazorAPIClient.Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorAPIClient.Client.DataServices
{
    public class GraphQLService : ISpaceXDataService
    {

        private readonly HttpClient _httpClient;

        //constructor injection
        public GraphQLService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Launch[]> GetAllLaunches()
        {
            // body
            var queryObject = new
            {
                query = @"{launches {id is_tentative mission_name launch_date_local}}"                
            };

            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObject)
                ,Encoding.UTF8, 
                "application/json");

            // PostAsync(rest of uri thats not part of the api_base_url, content)
            var response = await _httpClient.PostAsync("graphql", launchQuery);

            if (response.IsSuccessStatusCode)
            {
                var data = await JsonSerializer.DeserializeAsync<GraphQLData>(await response.Content.ReadAsStreamAsync());

                // data . top array (Data) . returning array(Launches)
                return data.Data.Launches;
            }
            
            return null;
        }
    }
}
