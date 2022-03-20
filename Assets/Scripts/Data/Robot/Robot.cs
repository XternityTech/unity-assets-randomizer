using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xternity
{
    [Serializable]
    public class Robot
    {
        //General
        [JsonConverter(typeof(StringEnumConverter))]
        public BaseType BaseType;

        [JsonConverter(typeof(StringEnumConverter))]
        public Name Name;

        public string Nickname;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public BaseClass Class;

        public int RoboId;

        //[JsonConverter(typeof(StringEnumConverter))]
        
        //Parts
        public string Head;
        
        public string Back;
        
        public string Shoulders;
        
        public string Hands;
        

        [JsonConverter(typeof(StringEnumConverter))]
        public Element CoreElement;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Element HeadElement;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Element BackElement;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Element ShouldersElement;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Element HandsElement;

        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity CoreRarity;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity HeadRarity;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity BackRarity;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity ShouldersRarity;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity HandsRarity;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity BodyRarity;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public uint CoreEfficiency;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public uint HeadEfficiency;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public uint BackEfficiency;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public uint ShouldersEfficiency;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public uint HandsEfficiency;

        //Stats

        public uint HP;
        public uint DMG;
        public double AttackSpeed;
        public uint SpecialAbilityChange;
    }
}