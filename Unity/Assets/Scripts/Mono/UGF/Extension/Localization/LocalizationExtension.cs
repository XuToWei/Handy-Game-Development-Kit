using UnityGameFramework.Runtime;

namespace UGF
{
    public static class LocalizationExtension
    {
        public static void LoadDictionary(this LocalizationComponent localizationComponent, string dictionaryName,
            bool fromBytes, object userData = null)
        {
            if (string.IsNullOrEmpty(dictionaryName))
            {
                Log.Warning("Dictionary name is invalid.");
                return;
            }
            GameEntry.Localization.ReadData( AssetUtility.GetDictionaryAsset(dictionaryName, fromBytes),userData); 
        }
        
    }
}