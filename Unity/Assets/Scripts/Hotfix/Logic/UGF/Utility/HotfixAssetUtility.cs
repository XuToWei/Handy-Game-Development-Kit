using GameFramework;

namespace Hotfix.Logic
{
    public static class HotfixAssetUtility
    {
        public static string GetShareTexture(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Textures/Share/{0}.bytes", assetName);
        }

        public static string GetUIItem(string assetName)
        {
            return Utility.Text.Format("Assets/Res/UI/UIItems/{0}.prefab", assetName);
        }

        public static string GetGameConfig(string gameConfig)
        {
            return Utility.Text.Format("Assets/Res/Configs/Game/Theme/{0}.asset", gameConfig);
        }

        public static string GetDataTable(string assetName, bool fromBytes)
        {
            return Utility.Text.Format("Assets/Res/DataTables/Hotfix/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        }

        public static string GetEmployeeEntity(string assetName)
        {
            return Utility.Text.Format("Assets/Res/Entities/Employee/{0}.prefab", assetName);
        }

        public static string GetSanXiaoMap(string assetName)
        {
            return Utility.Text.Format("Assets/Res/UI/SanXiao/Map/{0}.prefab", assetName);
        }

        public static string GetSanXiaoBlock()
        {
            return "Assets/Res/UI/SanXiao/Block/Block.prefab";
        }
    }
}