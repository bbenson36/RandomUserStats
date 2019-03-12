/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using Newtonsoft.Json;

namespace RandomUserStats.Models
{
    public class Id
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}