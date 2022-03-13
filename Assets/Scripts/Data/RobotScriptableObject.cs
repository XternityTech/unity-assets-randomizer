using System.IO;
using Newtonsoft.Json;
using UnityEngine;

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
#endif
    }
}