using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExchangeApi.Models
{
    public class RateReponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "historical")]
        public bool Historical { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public int timestamp { get; set; }

        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }

        [JsonProperty(PropertyName = "rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
