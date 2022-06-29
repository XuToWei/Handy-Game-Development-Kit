using System;
using System.Collections.Generic;
using UGF;
using UnityEngine;
/// <summary>
/// 组件自动绑定工具
/// </summary>
public class ComponentAutoBindTool : MonoBehaviour
{
#if UNITY_EDITOR
    [Serializable]
    public class BindData
    {
        public BindData()
        {
        }

        public BindData(string name, Component bindCom)
        {
            Name = name;
            BindCom = bindCom;
        }

        public string Name;
        public Component BindCom;
    }

    public List<BindData> BindDatas = new List<BindData>();

    [SerializeField]
    private string m_ClassName;

    [SerializeField]
    private string m_Namespace;

    [SerializeField]
    private string m_CodePath;

    [SerializeField] 
    private bool m_IsPublic;

    public string ClassName
    {
        get
        {
            HotfixUIForm hotfixUIForm = GetComponent<HotfixUIForm>();
            if (hotfixUIForm != null)
                return hotfixUIForm.HotfixClassName;
            return m_ClassName;
        }
    }

    public string Namespace
    {
        get
        {
            HotfixUIForm hotfixUIForm = GetComponent<HotfixUIForm>();
            if (hotfixUIForm != null)
                return hotfixUIForm.HotfixNameSpace;
            return m_Namespace;
        }
    }

    public string CodePath
    {
        get
        {
            return m_CodePath;
        }
    }

    public bool IsPublic
    {
        get
        {
            return m_IsPublic;
        }
    }

    public IAutoBindRuleHelper RuleHelper
    {
        get;
        set;
    }
#endif

    [SerializeField]
    public List<Component> m_BindComs = new List<Component>();


    public T GetBindComponent<T>(int index) where T : Component
    {
        if (index >= m_BindComs.Count)
        {
            Debug.LogError("索引无效" + gameObject.name);
            return null;
        }

        T bindCom = m_BindComs[index] as T;

        if (bindCom == null)
        {
            Debug.LogError("类型无效" + gameObject.name);
            return null;
        }

        return bindCom;
    }
}
