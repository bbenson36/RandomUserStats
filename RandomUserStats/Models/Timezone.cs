/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using Newtonsoft.Json;

namespace RandomUserStats.Models
{
    public class Timezone
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
