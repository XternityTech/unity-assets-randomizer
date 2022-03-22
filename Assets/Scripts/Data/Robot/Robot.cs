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
        public Type Type;

        [JsonConverter(typeof(StringEnumConverter))]
        public Name Name;

        public string Nickname;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Class Class;

        public string RoboId;

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
        
        public string CoreEfficiency;
        
        public string HeadEfficiency;

        public string BackEfficiency;

        public string ShouldersEfficiency;

        public string HandsEfficiency;

        //Stats

        public string HP;
        public string DMG;
        public string AttackSpeed;
        public string SpecialAbilityChange;
    }
}