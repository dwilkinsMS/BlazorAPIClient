using BlazorAPIClient.Client.DataServices;
using BlazorAPIClient.Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAPIClient.Client.Pages
{
    public partial class Launches
    {
        [Inject]
        ISpaceXDataService SpaceXDataService { get; set; }

        private Launch[] launches;

        protected override async Task OnInitializedAsync()
        {
            launches = await SpaceXDataService.GetAllLaunches();
        }
    }
}
