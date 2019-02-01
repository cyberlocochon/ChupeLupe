using System;
using ChupeLupe.Models.Helpers;
using Newtonsoft.Json;

namespace ChupeLupe.Models
{
    public class Promotion : ObservableObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Detail { get; set; }

        public Promotion()
        {
        }
    }
}
