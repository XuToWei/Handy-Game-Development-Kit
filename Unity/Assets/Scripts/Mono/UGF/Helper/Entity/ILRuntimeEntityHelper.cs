#if ILRuntime
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Enviorment;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UGF
{
    internal sealed class ILRuntimeEntityHelper : HotfixEntityHelperBase
    {
        private object m_HotfixProxyInstance;
        
        private IMethod m_OnInitMethod;
        private IMethod m_OnShowMethod;
        private IMethod m_OnHideMethod;
        private IMethod m_OnRecycleMethod;
        private IMethod m_OnAttachedMethod;
        private IMethod m_OnDetachedMethod;
        private IMethod m_OnAttachToMethod;
        private IMethod m_OnDetachFromMethod;
        private IMethod m_OnUpdateMethod;
        private IMethod m_InternalSetVisibleMethod;

        protected internal override void OnInit(string hotfixEntityType, HotfixEntity hotfixEntity, object userData)
        {
            ILType hotfixProxyType = GameEntry.Hotfix.ILRuntime.AppDomain.LoadedTypes[HotfixProxyTypeName] as ILType;
            m_HotfixProxyInstance = GameEntry.Hotfix.ILRuntime.AppDomain.Invoke(HotfixProxyTypeName, "Acquire", null, null);
            
            m_OnInitMethod = hotfixProxyType.GetMethod("OnInit");
            m_OnShowMethod = hotfixProxyType.GetMethod("OnShow");
            m_OnHideMethod = hotfixProxyType.GetMethod("OnHide");
            m_OnRecycleMethod = hotfixProxyType.GetMethod("OnRecycle");
            m_OnAttachedMethod = hotfixProxyType.GetMethod("OnAttached");
            m_OnDetachedMethod = hotfixProxyType.GetMethod("OnDetached");
            m_OnAttachToMethod = hotfixProxyType.GetMethod("OnAttachTo");
            m_OnDetachFromMethod = hotfixProxyType.GetMethod("OnDetachFrom");
            m_OnUpdateMethod = hotfixProxyType.GetMethod("OnUpdate");
            m_InternalSetVisibleMethod = hotfixProxyType.GetMethod("InternalSetVisible");

            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnInitMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(hotfixEntityType);
            ctx.PushObject(hotfixEntity);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnShow(object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnShowMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnHide(bool isShutdown, object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnHideMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushBool(isShutdown);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnRecycle()
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnRecycleMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.Invoke();
        }
        
        protected internal override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnAttachedMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(childEntity);
            ctx.PushObject(parentTransform);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnDetached(EntityLogic childEntity, object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnDetachedMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(childEntity);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnAttachToMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(parentEntity);
            ctx.PushObject(parentTransform);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnDetachFromMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(parentEntity);
            ctx.PushObject(userData);
            ctx.Invoke();
        }

        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            using InvocationContext ctx = GameEntry.Hotfix.ILRuntime.AppDomain.BeginInvoke(m_OnUpdateMethod);
            ctx.PushObject(m_HotfixProxyInstance);
            ctx.PushObject(elapseSeconds);
            ctx.PushObject(realElapseSeconds);
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
            m_OnInitMethod = default;
            m_OnShowMethod = default;
            m_OnHideMethod = default;
            m_OnRecycleMethod = default;
            m_OnAttachedMethod = default;
            m_OnDetachedMethod = default;
            m_OnAttachToMethod = default;
            m_OnDetachFromMethod = default;
            m_OnUpdateMethod = default;
            m_InternalSetVisibleMethod = default;
            
            GameEntry.Hotfix.ILRuntime.AppDomain.Invoke(HotfixProxyTypeName, "Release", null, m_HotfixProxyInstance);
            m_HotfixProxyInstance = default;
        }
    }
}
#endif
