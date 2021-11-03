using BlazorAPIClient.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAPIClient.Client.DataServices
{
    public interface ISpaceXDataService
    {
        Task<Launch[]> GetAllLaunches(); 
    }
}
