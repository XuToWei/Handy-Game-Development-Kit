using System;
using UGF;
using UnityEngine;

namespace Hotfix.Framework
{
    public class UIFormLogicProxy : IReference
    {
        public static UIFormLogicProxy Acquire()
        {
            return ReferencePool.Acquire<UIFormLogicProxy>();
        }

        public static void Release(object obj)
        {
            UIFormLogicProxy uiFormLogic = obj as UIFormLogicProxy;
            ReferencePool.Release(uiFormLogic);
        }

        private UIFormLogic m_UIFormLogic;
        
        public void Clear()
        {
            m_UIFormLogic.Clear();
            m_UIFormLogic = default;
        }
        
        public void OnInit(string uiFormLogicType, HotfixUIForm hotfixUIForm, object userData)
        {
            m_UIFormLogic = GameEntry.Hotfix.HotfixHelper.CreateInstance(uiFormLogicType) as UIFormLogic;
            m_UIFormLogic.Fill(hotfixUIForm);
            m_UIFormLogic.OnInit(userData);
        }
        
        public void OnRecycle()
        {
            m_UIFormLogic.OnRecycle();
        }

        public void OnOpen(object userData)
        {
            m_UIFormLogic.OnOpen(userData);
        }

        public void OnClose(bool isShutdown, object userData)
        {
            m_UIFormLogic.OnClose(isShutdown, userData);
        }

        public void OnPause()
        {
            m_UIFormLogic.OnPause();
        }

        public void OnResume()
        {
            m_UIFormLogic.OnResume();
        }

        public void OnCover()
        {
            m_UIFormLogic.OnCover();
        }

        public void OnReveal()
        {
            m_UIFormLogic.OnReveal();
        }

        public void OnRefocus(object userData)
        {
            m_UIFormLogic.OnRefocus(userData);
        }

        public void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            m_UIFormLogic.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        public void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            m_UIFormLogic.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        }

        public void InternalSetVisible(bool visible)
        {
            m_UIFormLogic.InternalSetVisible(visible);
        }
    }
}
