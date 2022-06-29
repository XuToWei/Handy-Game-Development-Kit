using System.Collections.Generic;
using GameFramework;
using UnityEditor;

namespace UGF.Editor{
    public class SpriteImportEditor : AssetPostprocessor
    {
        private readonly List<string> SpritePaths = new List<string>()
        {
            "Assets/Res/Sprites/",
            "Assets/Res/UI/UISprites/"
        };

        private void OnPreprocessTexture()
        {
            TextureImporter textureImporter = assetImporter as TextureImporter;
            string regularPath = Utility.Path.GetRegularPath(textureImporter.assetPath);
            foreach (var path in SpritePaths)
            {
                if (regularPath.StartsWith(path))
                {
                    textureImporter.textureType = TextureImporterType.Sprite;
                    textureImporter.mipmapEnabled = false;
                }
            }
        }
    }
}