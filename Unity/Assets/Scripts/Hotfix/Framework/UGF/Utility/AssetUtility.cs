using GameFramework;

namespace Hotfix.Framework
{
    public static class AssetUtility
    {
        public static string GetLubanAsset(string assetName,string lubanType, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/Luban/{0}/{1}.{2}", lubanType, assetName, fromBytes ? "bytes" : "json");
        }
    }
}
