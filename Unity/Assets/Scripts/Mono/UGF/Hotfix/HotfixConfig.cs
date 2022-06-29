namespace UGF
{
    public static class HotfixConfig
    {
        public const string DllFolderPath = "Assets/Res/Code/";

        public static readonly string[] DllNames = {
            "Unity.Hotfix.Framework",
            "Unity.Hotfix.Logic",
            "Unity.Hotfix.LogicView",
            "Unity.Hotfix.Model",
            "Unity.Hotfix.ModelView"
        };

        public static readonly string[] ReloadDllNames = {
            "Unity.Hotfix.Logic",
            "Unity.Hotfix.LogicView",
        };

        public static readonly string EntryTypeFullName = "Hotfix.Logic.HotfixEntry";
    }
}

