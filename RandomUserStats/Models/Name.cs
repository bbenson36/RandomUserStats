/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using Newtonsoft.Json;

namespace RandomUserStats.Models
{
    public class Name
    {
        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}