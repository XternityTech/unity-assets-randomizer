using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Xternity.Extension;

namespace Xternity
{
    [CreateAssetMenu(menuName = "Xternity/CreateRobot")]
    public class RobotScriptableObject : ScriptableObject
    {
        public Robot Robot;
        
#if UNITY_EDITOR
        [ContextMenu("Save to file")]
        private void SaveToFile()
        {
            var path = UnityEditor.EditorUtility.SaveFilePanel(
                "Save to JSON",
                "",
                Robot?.Nickname + ".json",
                "json");

            if (path.Length != 0)
            {
                var json = JsonConvert.SerializeObject(Robot, Formatting.Indented);
                
                File.WriteAllText(path, json);
            }
        }
        
        [ContextMenu("Load to file")]
        private void LoadFromFile()
        {
            var path = UnityEditor.EditorUtility.OpenFilePanel(
                "Save to JSON",
                "",
                "json");
            
            if (path.Length != 0)
            {
                var json = File.ReadAllText(path);

                Robot = JsonConvert.DeserializeObject(json) as Robot;
            }
        }

        [ContextMenu("Generate random")]
        private void GenerateRandom()
        {
            var robot = new Robot();
            robot.BaseType = EnumExtensions.GetRandom<BaseType>();
            robot.Name = EnumExtensions.GetRandom<Name>();
            robot.Nickname = RobotData.GetRandomNickName();
            robot.Class = EnumExtensions.GetRandom<BaseClass>();
            robot.RoboId = GetRandomId();

            robot.Head = RobotData.GetRandomHead();
            robot.Back = RobotData.GetRandomBack();
            robot.Shoulders = RobotData.GetRandomShoulders();
            robot.Hands = RobotData.GetRandomHands();

            robot.CoreElement = EnumExtensions.GetRandom<Element>();
            robot.HeadElement = EnumExtensions.GetRandom<Element>();
            robot.BackElement = EnumExtensions.GetRandom<Element>();
            robot.ShouldersElement = EnumExtensions.GetRandom<Element>();
            robot.HandsElement = EnumExtensions.GetRandom<Element>();

            robot.CoreRarity = EnumExtensions.GetRandom<Rarity>();
            robot.HeadRarity = EnumExtensions.GetRandom<Rarity>();
            robot.BackRarity = EnumExtensions.GetRandom<Rarity>();
            robot.ShouldersRarity = EnumExtensions.GetRandom<Rarity>();
            robot.HandsRarity = EnumExtensions.GetRandom<Rarity>();
            robot.BodyRarity = EnumExtensions.GetRandom<Rarity>();

            robot.CoreEfficiency = RobotData.GetRandomCoreEfficiency();
            robot.HeadEfficiency = RobotData.GetRandomHeadEfficiency();
            robot.BackEfficiency = RobotData.GetRandomBackEfficiency();
            robot.ShouldersEfficiency = RobotData.GetRandomShouldersEfficiency();
            robot.HandsEfficiency = RobotData.GetRandomHandsEfficiency();

            robot.HP = RobotData.GetRandomHP();
            robot.DMG = RobotData.GetRandomDamage();
            robot.AttackSpeed = RobotData.GetRandomAttackSpeeds();
            robot.SpecialAbilityChange = RobotData.GetSpecialAbilityCharge();

            Robot = robot;
        }

        private int GetRandomId()
        {
            throw new System.NotImplementedException();
        }
#endif
    }
}