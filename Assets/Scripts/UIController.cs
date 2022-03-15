using System.IO;
using UnityEngine;

namespace Xternity
{
    public class UIController : MonoBehaviour
    {
        public async void LoadBody()
        {
            var gameObject = await AssetBundlesLoader.LoadAssetBundlesAsync(RobotPart.Body, "testbody");
            Debug.LogError(gameObject);

            Instantiate(gameObject, transform.parent);

            var camera = Camera.main;
            
            Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
            image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
            image.Apply();

            var bytes = image.EncodeToPNG();
            File.WriteAllBytes(Path.Combine(Application.streamingAssetsPath, "test.png"), bytes);
        }
    }
}