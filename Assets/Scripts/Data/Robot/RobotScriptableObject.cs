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

        [UnityEditor.MenuItem("Xternity/SaveFirst1000ToFile")]
        public static void SaveFirst1000ToFile()
        {
            const string FileNamePattern = "robo#{0}.json";
            
            var path = UnityEditor.EditorUtility.SaveFilePanel(
                "Save to JSON",
                "",
                "",
                "");

            if (Directory.Exists(path))
            {
               Directory.Delete(path); 
            }
            else
            {
                Directory.CreateDirectory(path);
            }
            
            for (var index = 0; index < 1000; index++)
            {
                var robotScriptableObject = CreateInstance<RobotScriptableObject>();
                robotScriptableObject.GenerateRandom();
                
                var robot = robotScriptableObject.Robot;
                robot.RoboId = (1000 + index).ToString();
                
                var json = JsonConvert.SerializeObject(robot, Formatting.Indented);

                var robotPath = Path.Combine(path, string.Format(FileNamePattern, robot.RoboId));
                
                File.WriteAllText(robotPath, json);
            }
        }
        
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
            robot.Type = EnumExtensions.GetRandom<Type>();
            robot.Name = EnumExtensions.GetRandom<Name>();
            robot.Nickname = RobotData.GetRandomNickName();
            robot.Class = EnumExtensions.GetRandom<Class>();
            robot.RoboId = 1.ToString();

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

            robot.CoreEfficiency = RobotData.GetRandomCoreEfficiency().ToString();
            robot.HeadEfficiency = RobotData.GetRandomHeadEfficiency().ToString();
            robot.BackEfficiency = RobotData.GetRandomBackEfficiency().ToString();
            robot.ShouldersEfficiency = RobotData.GetRandomShouldersEfficiency().ToString();
            robot.HandsEfficiency = RobotData.GetRandomHandsEfficiency().ToString();

            robot.HP = RobotData.GetRandomHP().ToString();
            robot.DMG = RobotData.GetRandomDamage().ToString();
            robot.AttackSpeed = RobotData.GetRandomAttackSpeeds().ToString();
            robot.SpecialAbilityChange = RobotData.GetSpecialAbilityCharge().ToString();

            Robot = robot;
        }
#endif
    }
}