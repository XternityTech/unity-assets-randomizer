using System.IO;
using UnityEngine;
using Xternity.Helpers;

namespace Xternity
{
    public class UIController : MonoBehaviour
    {
        public Camera Camera;
        public RenderTexture RenderTexture;

        public void TakeScreenshot()
        {
            var path = Path.Combine(Application.dataPath, "Images", "test.png");
            TextureHelper.TakeScreenshot(Camera, RenderTexture, path, () =>
            {
                Debug.Log("Made a screenshot");
            });
        }

        public void ParseXml()
        {
            string excelPath = Application.dataPath + "/Robo NFT Json.xlsx";


            CSVReader.ParseFile(excelPath);
        }
    }
}