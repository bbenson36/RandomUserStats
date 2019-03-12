/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using System;
using Newtonsoft.Json;
namespace RandomUserStats.Models
{
    public class AgeInfo
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        
        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
