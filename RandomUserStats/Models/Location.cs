/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using Newtonsoft.Json;

namespace RandomUserStats.Models
{
    public class Location
    {
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
        
        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }
    }
}