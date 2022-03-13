using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Xternity.Extension;

namespace Xternity
{
    public static class AssetBundlesLoader
    {
        private const string BaseUrl = "";
        
        public static async Task<GameObject> LoadAssetBundlesAsync(RobotPart part, string name)
        {
            var url = Path.Combine(part.ToString(), name);
            var fullUrl = Path.Combine(BaseUrl, url);

            var gameObject = LoadFromStreamingAssetsAsync(url, name);
            if (gameObject != null)
            {
                return gameObject;
            }

            return await LoadFromS3Async(fullUrl, name);
        }

        private static async Task<GameObject> LoadFromStreamingAssetsAsync(string fullUrl, string name)
        {
            var assetBundle = await AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, fullUrl));
            
        }

        private static async Task<GameObject> LoadFromS3Async(string fullUrl, string name)
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(fullUrl);
            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                var gameObject = assetBundle.LoadAsset<GameObject>(name);

                return gameObject;
            }

            return null;
        }
    }
}