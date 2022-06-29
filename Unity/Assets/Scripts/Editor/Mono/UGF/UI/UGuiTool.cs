using UnityEditor;
using UnityEngine;

namespace UGF.Editor
{
    public class UGuiTool
    {
        private static readonly string UGuiFormTemplate = "Assets/Res/Configs/UGuiForm.prefab";
        
        [MenuItem("GameObject/UI/Form")]
        static void CreateForm()
        {
            GameObject obj = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(UGuiFormTemplate));
            obj.name = "Form";
            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.SetParent(Selection.activeTransform);
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = Vector3.one;
            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform.sizeDelta = Vector3.zero;
        }
    }
}
