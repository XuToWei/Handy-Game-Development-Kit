using System.IO;
using GameFramework;
using UnityEditor;
using UnityEngine;

namespace UGF.Editor
{
    public static class DataTableFolderEditor
    {
        [MenuItem("Tools/打开文件夹：Hotfix Luban", priority = 99)]
        static void OpenHotfixLuban()
        {
            Application.OpenURL(Utility.Path.GetRemotePath(Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Configs/Luban/Hotfix/Datas")));
        }
    }
}
