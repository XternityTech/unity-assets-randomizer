using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xternity
{
    [Serializable]
    public class Part
    {
        public string Name;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity Rarity;
        
        public string ID;

        public string CardDescription;
        
        public uint Efficiency = 0;
    }
}