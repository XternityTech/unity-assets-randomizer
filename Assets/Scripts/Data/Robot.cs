using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xternity
{
    [Serializable]
    public class Robot
    {
        //General
        public int ID = 1;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public BaseType BaseType;

        public string Nickname;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public BaseClass Class;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Subclass Subclass;
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Rarity Rarity;
        
        
        //Cosmetics
        public CosmeticsId CosmeticsId1;
        public CosmeticsId CosmeticsId2;
        public CosmeticsId CosmeticsId3;
        public CosmeticsId CosmeticsId4;
        
        
        //Stats
        public uint DamageRerHit = 1;
        
        public uint HitPoints = 1;
        
        public uint HitPerSecond = 0;
        
        public uint EnergyCost = 0;
        
        public string SpecialAttack;
        
        
        //Parts
        //Body
        public Rarity BodyRarity;
        
        public uint BodyEfficiency = 0;
        
        //Core
        public Rarity CoreRarity;
        
        public CoreElement CoreElement;
        
        public uint CoreEfficiency = 0;
        
        //Other
        public Part Head;
        
        public Part Shoulder;
        
        public Part Back;
        
        public Part Gloves;
    }
}