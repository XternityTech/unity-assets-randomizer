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
            robot.Class = EnumExtensions.GetRandom<BaseClass>();

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

            robot.CoreEfficiency = (uint)Random.Range(1, 101);
            robot.HeadEfficiency = (uint)Random.Range(1, 101);
            robot.BackEfficiency = (uint)Random.Range(1, 101);
            robot.ShouldersEfficiency = (uint)Random.Range(1, 101);
            robot.HandsEfficiency = (uint)Random.Range(1, 101);

            robot.HP = (uint)Random.Range(15, 26);
            robot.DMG = (uint)Random.Range(1, 6);

            Robot = robot;
        }
#endif
    }
}