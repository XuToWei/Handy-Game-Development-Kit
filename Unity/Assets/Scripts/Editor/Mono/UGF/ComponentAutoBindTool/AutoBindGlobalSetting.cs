using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 自动绑定全局设置
/// </summary>
public class AutoBindGlobalSetting : ScriptableObject
{
    [SerializeField]
    private string m_CodePath;

    [SerializeField]
    private string m_Namespace;

    public string CodePath
    {
        get
        {
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, m_CodePath).Replace('\\', '/');
        }
    }

    public string Namespace
    {
        get
        {
            return m_Namespace;
        }
      
    }

    [MenuItem("Tools/CatWorkflow/CreateAutoBindGlobalSetting")]
    private static void CreateAutoBindGlobalSetting()
    {
        string[] paths = AssetDatabase.FindAssets("t:AutoBindGlobalSetting");
        if (paths.Length >= 1)
        {
            string path = AssetDatabase.GUIDToAssetPath(paths[0]);
            EditorUtility.DisplayDialog("警告", $"已存在AutoBindGlobalSetting，路径:{path}", "确认");
            return;
        }
        
        AutoBindGlobalSetting setting = CreateInstance<AutoBindGlobalSetting>();
        AssetDatabase.CreateAsset(setting, "Assets/AutoBindGlobalSetting.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
