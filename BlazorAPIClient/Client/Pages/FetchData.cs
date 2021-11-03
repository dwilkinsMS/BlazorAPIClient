using BlazorAPIClient.Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorAPIClient.Client.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient Http { get; set; }
        private Launch[] launches;        

        protected override async Task OnInitializedAsync()
        {
            launches = await Http.GetFromJsonAsync<Launch[]>("/rest/launches");
        }
    }
}
