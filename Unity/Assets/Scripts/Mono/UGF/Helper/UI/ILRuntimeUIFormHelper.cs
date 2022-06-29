#if ILRuntime
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;

namespace UGF
{
    internal sealed class ILRuntimeUIFormHelper : HotfixUIFormHelperBase
    {
        private object m_HotfixProxyInstance;
        
        private IMethod m_OnInitMethod;
        private IMethod m_OnRecycleMethod;
        private IMethod m_OnOpenMethod;
        private IMethod m_OnCloseMethod;
        private IMethod m_OnPauseMethod;
        private IMethod m_OnResumeMethod;
        private IMethod m_OnCoverMethod;
        private IMethod m_OnRevealMethod;
        private IMethod m_OnRefocusMethod;
        private IMethod m_OnUpdateMethod;
        private IMethod m_OnDepthChangedMethod;
        private IMethod m_InternalSetVisibleMethod;
        
        protected internal override void OnInit(string hotfixUIFormType, HotfixUIForm hotfixUIForm, object userData)
        {
            ILType hotfixProxyType = GameEntry.Hotfix.ILRuntime.AppDomain.LoadedTypes[HotfixProxyTypeName] as ILType;
            m_HotfixProxyInstance = GameEntry.Hotfix.ILRuntime.AppDomain.Invoke(HotfixProxyTypeName, "Acquire", null, null);
            
            m_OnInitMethod = hotfixProxyType.GetMethod("OnInit");
            m_OnRecycleMethod = hotfixProxyType.GetMethod("OnRecycle");
            m_OnOpenMethod = hotfixProxyType.GetMethod("OnOpen");
            m_OnCloseMethod = hotfixProxyType.GetMethod("OnClose");
            m_OnPauseMethod = hotfixProxyType.GetMethod("OnPause");
            m_OnResumeMethod = hotfixProxyType.GetMethod("OnResume");
            m_OnCoverMethod = hotfixProxyType.GetMethod("OnCover");
            m_OnRevealMethod = hotfixProxyType.GetMethod("OnReveal");
            m_OnRefocusMethod = hotfixProxyType.GetMethod("OnRefocus");
            m_OnUpdateMethod = hotfixProxyType.GetMethod("OnUpdate");
            m_OnDepthChangedMethod = hotfixProxyType.GetMethod("OnDepthChanged");
            m_InternalSetVisibleMethod = hotfixProxyType.GetMethod("InternalSetVisible");
            
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnInitMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(hotfixUIFormType);
            ctx.PushObject(hotfixUIForm);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnRecycle()
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnRecycleMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.Invoke();
        }

        protected internal override void OnOpen(object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnOpenMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnClose(bool isShutdown, object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnCloseMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushBool(isShutdown);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnPause()
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnPauseMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.Invoke();
        }

        protected internal override void OnResume()
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnResumeMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.Invoke();
        }

        protected internal override void OnCover()
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnCoverMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.Invoke();
        }

        protected internal override void OnReveal()
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnRevealMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.Invoke();
        }

        protected internal override void OnRefocus(object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnRefocusMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.Invoke();
        }

        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnUpdateMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushFloat(elapseSeconds);
            ctx.PushFloat(realElapseSeconds);
            ctx.Invoke();
        }

        protected internal override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnDepthChangedMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushInteger(uiGroupDepth);
            ctx.PushInteger(depthInUIGroup);
            ctx.Invoke();
        }

        protected internal override void InternalSetVisible(bool visible)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_InternalSetVisibleMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushBool(visible);
            ctx.Invoke();
        }

        public override void Clear()
        {
            m_OnInitMethod = null;
            m_OnRecycleMethod = null;
            m_OnOpenMethod = null;
            m_OnCloseMethod = null;
            m_OnPauseMethod = null;
            m_OnResumeMethod = null;
            m_OnCoverMethod = null;
            m_OnRevealMethod = null;
            m_OnRefocusMethod = null;
            m_OnUpdateMethod = null;
            m_OnDepthChangedMethod = null;
            m_InternalSetVisibleMethod = null;
            
            GameEntry.Hotfix.ILRuntime.AppDomain.Invoke(HotfixProxyTypeName, "Release", null, m_HotfixProxyInstance);
            m_HotfixProxyInstance = default;
        }
    }
}
#endif
