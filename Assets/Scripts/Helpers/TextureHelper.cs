using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Xternity.Helpers
{
    public static class TextureHelper
    {
        public static void TakeScreenshot(Camera Camera, RenderTexture RenderTexture, string path, Action onComplete)
        {
            Camera.GetComponent<MonoBehaviour>().StartCoroutine(TakeScreenshotIenumerator(Camera, 
                RenderTexture, path, onComplete));
        }
        
        public static IEnumerator TakeScreenshotIenumerator(Camera Camera, RenderTexture RenderTexture, string path, Action onComplete)
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
            File.WriteAllBytes(path, bytes);
            
            RenderTexture.active = activeRenderTexture;

            Camera.targetTexture = null;
            
            AssetDatabase.Refresh();
            
            onComplete?.Invoke();
        }
    }
}