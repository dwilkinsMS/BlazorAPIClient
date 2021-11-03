using BlazorAPIClient.Client.DataServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAPIClient.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

            // here you can swap GraphQL concrete for the RestService to change which service is inject and used when calling for the ISpaceXDataService
            builder.Services.AddHttpClient<ISpaceXDataService, GraphQLService>(s => s.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
            
            await builder.Build().RunAsync();
        }
    }
}
