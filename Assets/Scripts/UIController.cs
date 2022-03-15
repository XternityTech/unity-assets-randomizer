using System.Collections;
using System.IO;
using UnityEngine;

namespace Xternity
{
    public class UIController : MonoBehaviour
    {
        public Camera Camera;

        public int Wight = 1080;
        public int Height = 1920;
        
        public void TakeScreenshot()
        {
            StartCoroutine(TakeScreenshotIenumerator());
        }

        public IEnumerator TakeScreenshotIenumerator()
        {
            yield return new WaitForEndOfFrame();
            
            RenderTexture activeRenderTexture = RenderTexture.active;
            RenderTexture.active = Camera.targetTexture;
 
            Camera.Render();
            
            Texture2D image = new Texture2D(Camera.targetTexture.width, Camera.targetTexture.height);
            image.ReadPixels(new Rect(0, 0, Camera.targetTexture.width, Camera.targetTexture.height), 0, 0);
            image.Apply();

            var bytes = image.EncodeToPNG();
            File.WriteAllBytes(Path.Combine(Application.dataPath, "Images", "test.png"), bytes);
            
            RenderTexture.active = activeRenderTexture;
            
            Debug.Log("Save screenshot");
        }
    }
}