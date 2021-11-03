using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorAPIClient.Client.Models
{
    public class GraphQLLaunch
    {
    }
    public partial class GraphQLData
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("launches")]
        public Launch[] Launches { get; set; }
    }   
}
