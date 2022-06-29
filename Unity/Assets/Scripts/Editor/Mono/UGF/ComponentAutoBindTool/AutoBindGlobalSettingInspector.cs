using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AutoBindGlobalSetting))]
public class AutoBindGlobalSettingInspector : Editor
{
    private SerializedProperty m_Namespace;
    private SerializedProperty m_CodePath;

    private void OnEnable()
    {
        m_Namespace = serializedObject.FindProperty("m_Namespace");
        m_CodePath = serializedObject.FindProperty("m_CodePath");
    }

    public override void OnInspectorGUI()
    {
        m_Namespace.stringValue = EditorGUILayout.TextField(new GUIContent("默认命名空间"), m_Namespace.stringValue);

        EditorGUILayout.LabelField("默认代码保存路径：");
        EditorGUILayout.LabelField(m_CodePath.stringValue);
        if (GUILayout.Button("选择路径", GUILayout.Width(140f)))
        {
            string defaultRootPath = Directory.GetParent(Application.dataPath).FullName.Replace('\\', '/');
            string codePath = EditorUtility.OpenFolderPanel("选择代码保存路径", defaultRootPath, "").Replace('\\', '/');
            if (codePath.StartsWith(defaultRootPath))
            {
                m_CodePath.stringValue = codePath.Substring(defaultRootPath.Length + 1, codePath.Length - defaultRootPath.Length - 1);
            }
            else
            {
                Debug.LogError("请选择工程相对目录！");
            }
        }

        serializedObject.ApplyModifiedProperties();
       
    }
}
