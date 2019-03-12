/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RandomUserStats.Models
{
    public class RootObject
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("results")]
        public List<User> Users { get; set; }
    }
}
