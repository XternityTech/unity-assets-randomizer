using UnityEditor;
using UnityEngine;

namespace Xternity
{
    [CreateAssetMenu(menuName = "Xternity/CreateModel")]
    public class Model : ScriptableObject
    {
        public GameObject Body;
        public GameObject Head;
        public GameObject Shoulder;
        public GameObject Back;
        public GameObject Gloves;

#if UNITY_EDITOR
        [ContextMenu("Save to file")]
        private void SaveToFile()
        {
            BuildPipeline.BuildAssetBundles(, BuildAssetBundleOptions.ForceRebuildAssetBundle, EditorUserBuildSettings.activeBuildTarget.)
        }
    }
#endif
}