using GameFramework;

namespace UGF
{
    public static class AssetUtility
    {
        public static string GetConfigAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDataTableAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetDictionaryAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/Localization/{0}/Dictionaries/{1}.{2}", GameEntry.Localization.Language.ToString(), assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Fonts/{0}.asset", assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Sounds/{0}.wav", assetName);
        }

        public static string GetEntityAsset(string groupName, string assetName)
        {
            return Utility.Text.Format("Assets/Res/Entities/{0}/{1}.prefab", groupName, assetName);
        }

        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/UI/UIForms/{0}.prefab", assetName);
        }
        
        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/Res/UI/UISounds/{0}.wav", assetName);
        }
        
        public static string GetHotfixDllAsset(string assetName)
        {
            return Utility.Text.Format("{0}{1}.dll.bytes", HotfixConfig.DllFolderPath, assetName);
        }

        public static string GetHotfixPdbAsset(string assetName)
        {
            return Utility.Text.Format("{0}{1}.pdb.bytes", HotfixConfig.DllFolderPath, assetName);
        }
        
        public static string GetHotfixLubanAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/Luban/Hotfix/{0}.{1}", assetName, fromBytes ? "bytes" : "json");
        }
        
        public static string GetGameLubanAsset(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/Luban/Game/{0}.{1}", assetName, fromBytes ? "bytes" : "json");
        }
    }
}
