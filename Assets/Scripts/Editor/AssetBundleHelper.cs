using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Xternity.Editor
{
    public static class AssetBundleHelper
    {
        [MenuItem("AssetBundles/PackDirectories to asset bundles")]
        public static void PackDirectoriesToAssetBundle()
        {
            string assetPath = null;
            
            var builds = new List<AssetBundleBuild>();
            
            foreach (var obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
            {
                assetPath = AssetDatabase.GetAssetPath(obj);
                
                builds.Add(new AssetBundleBuild
                {
                    assetBundleName = obj.name,
                    assetNames = new[]
                    {
                        assetPath
                    }
                });
            }

            var savePath = Path.GetDirectoryName(assetPath.Replace("Assets", "Assets/AssetBundles"));
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            BuildPipeline.BuildAssetBundles(savePath, 
                builds.ToArray(), 
                BuildAssetBundleOptions.ForceRebuildAssetBundle, 
                EditorUserBuildSettings.activeBuildTarget);
        }
    }
}