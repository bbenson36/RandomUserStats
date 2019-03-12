/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using Newtonsoft.Json;

namespace RandomUserStats.Models
{
    public class Coordinates
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
