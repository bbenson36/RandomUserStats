/// <summary>
/// Used under MIT license from https://github.com/tsjdev-apps/RandomUserSharp
/// </summary>
using System;
using Newtonsoft.Json;
using RandomUserStats.Utils;

namespace RandomUserStats.Models
{
    public class PictureInfo
    {
        [JsonProperty("medium")]
        [JsonConverter(typeof(UriConverter))]
        public Uri Medium { get; set; }

        [JsonProperty("large")]
        [JsonConverter(typeof(UriConverter))]
        public Uri Large { get; set; }

        [JsonProperty("thumbnail")]
        [JsonConverter(typeof(UriConverter))]
        public Uri Thumbnail { get; set; }
    }
}