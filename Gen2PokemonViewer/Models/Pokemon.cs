using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gen2PokemonViewer.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public object[] Abilities { get; set; }
        public object[] Forms { get; set; }
        public int Height { get; set; }
        
        [JsonProperty("id")]
        public int InternalId { get; set; }
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        public object[] Species { get; set; }
        public Dictionary<string, string> Sprites { get; set; }

        public object[] Types { get; set; }
        public int Weight { get; set; }
    }

    
}