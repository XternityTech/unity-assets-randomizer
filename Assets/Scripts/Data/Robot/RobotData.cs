using System.IO;
using UnityEngine;
using Xternity.Extension;

namespace Xternity
{
    public static class RobotData
    {
        private static readonly string NicknamesPath = Application.dataPath + "/Nicknames.txt";
        private static string[] nickNames;
        
        private static readonly string[] Heads =
        {
            "Common Power Gear",
            "Common Brave Gear"
        };

        private static readonly string[] Backs =
        {
            "Common Primal Gear",
            "Common Fearless Gear"
        };

        private static readonly string[] Shoulders =
        {
            "Common Kinetic Gear",
            "Common Bold Gear"
        };

        private static readonly string[] Hands =
        {
            "Common Mega Gear",
            "Common Force Gear"
        };

        private static readonly double[] AttackSpeeds =
        {
            0.4, 0.5, 0.6, 0.7, 0.8
        };


        public static string GetRandomNickName()
        {
            if (nickNames == null)
            {
                nickNames = File.ReadAllLines(NicknamesPath);
            }

            return nickNames.GetRandom();
        }
        

        public static string GetRandomHead()
        {
            return Heads.GetRandom();
        }

        public static string GetRandomBack()
        {
            return Backs.GetRandom();
        }

        public static string GetRandomShoulders()
        {
            return Shoulders.GetRandom();
        }

        public static string GetRandomHands()
        {
            return Hands.GetRandom();
        }
        

        public static uint GetRandomCoreEfficiency()
        {
            return (uint)Random.Range(1, 101);
        }
        
        public static uint GetRandomHeadEfficiency()
        {
            return (uint)Random.Range(1, 101);
        }
        
        public static uint GetRandomBackEfficiency()
        {
            return (uint)Random.Range(1, 101);
        }
        
        public static uint GetRandomShouldersEfficiency()
        {
            return (uint)Random.Range(1, 101);
        }

        public static uint GetRandomHandsEfficiency()
        {
            return (uint)Random.Range(1, 101);
        }
        

        public static uint GetRandomHP()
        {
            return (uint)Random.Range(15, 26);
        }

        public static uint GetRandomDamage()
        {
            return (uint)Random.Range(1, 6);
        }
        
        public static double GetRandomAttackSpeeds()
        {
            return AttackSpeeds.GetRandom();
        }

        public static uint GetSpecialAbilityCharge()
        {
            return (uint)Random.Range(8, 11);
        }
    }
}