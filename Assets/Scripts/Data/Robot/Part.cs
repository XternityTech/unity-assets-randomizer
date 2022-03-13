using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xternity
{
    [Serializable]
    public class Part
    {
        public string Name;

        [JsonConverter(typeof(StringEnumConverter))]
        public Element Element;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity Rarity;
        
        public uint Efficiency = 0;
    }
}