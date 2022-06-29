using System;
using UnityEditor;
using UnityEngine;

namespace UGF.Editor
{
    [CustomEditor(typeof(HotfixUIForm))]
    [CanEditMultipleObjects]
    public class HotfixUIFormInspector : UnityEditor.Editor
    {
        private HotfixUIForm m_Target;
        
        private SerializedProperty m_HotfixAssemblyName;
        private SerializedProperty m_HotfixNameSpace;
        private SerializedProperty m_HotfixClassName;

        private void OnEnable()
        {
            m_Target = target as HotfixUIForm;
            
            m_HotfixAssemblyName = serializedObject.FindProperty("m_HotfixAssemblyName");
            m_HotfixNameSpace = serializedObject.FindProperty("m_HotfixNameSpace");
            m_HotfixClassName = serializedObject.FindProperty("m_HotfixClassName");

            serializedObject.ApplyModifiedProperties();
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_HotfixAssemblyName);
            EditorGUILayout.PropertyField(m_HotfixNameSpace);

            EditorGUILayout.BeginHorizontal();
            m_HotfixClassName.stringValue = EditorGUILayout.TextField(new GUIContent("HotfixClassName："), m_HotfixClassName.stringValue);
            if (GUILayout.Button("物体名"))
            {
                m_HotfixClassName.stringValue = m_Target.Name;
            }

            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
       
        }
    }
}
