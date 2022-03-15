using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Xternity
{
    public class UIController : MonoBehaviour
    {
        public Camera Camera;
        public RenderTexture RenderTexture;
        
        public void TakeScreenshot()
        {
            StartCoroutine(TakeScreenshotIenumerator());
        }

        public IEnumerator TakeScreenshotIenumerator()
        {
            yield return new WaitForEndOfFrame();

            Camera.targetTexture = RenderTexture;
            
            RenderTexture activeRenderTexture = RenderTexture.active;
            RenderTexture.active = Camera.targetTexture;
 
            Camera.Render();

            var targetTexture = Camera.targetTexture;
            
            var image = new Texture2D(targetTexture.width, targetTexture.height);
            image.ReadPixels(new Rect(0, 0, targetTexture.width, targetTexture.height), 0, 0);
            image.Apply();

            var bytes = image.EncodeToPNG();
            File.WriteAllBytes(Path.Combine(Application.dataPath, "Images", "test.png"), bytes);
            
            RenderTexture.active = activeRenderTexture;

            Camera.targetTexture = null;
            
            AssetDatabase.Refresh();
            
            Debug.Log("Save screenshot");
        }
    }
}