using UnityEditor;
using UnityEngine;

namespace Xternity.Editor
{
    public class AssetBundlesWindow : EditorWindow
    {
        public Model Model;
        
        [MenuItem("Window/My Window")]
        private static void Init()
        {
            var window = (AssetBundlesWindow)GetWindow(typeof(AssetBundlesWindow));
            window.Show();
        }
    }
}