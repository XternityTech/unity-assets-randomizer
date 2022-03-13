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

        public string Name;

        public string Nickname;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public BaseClass Class;

        public int RoboId;

        
        //Parts
        public Part Core;
        
        public Part Head;
        
        public Part Back;
        
        public Part Shoulder;

        public Part Hands;

        //Stats

        public double HP;
        public double DMG;
        public float AttackSpeed;
        public double SpecialAbilityChange;
    }
}