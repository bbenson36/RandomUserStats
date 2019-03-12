/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using Newtonsoft.Json;

namespace RandomUserStats.Models
{
    public class Info
    {
        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}