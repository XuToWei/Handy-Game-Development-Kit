using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

namespace UGF
{
    internal abstract class HotfixEntityHelperBase : IReference
    {
        protected string HotfixProxyTypeName => "Hotfix.Framework.EntityLogicProxy";
        protected internal abstract void OnInit(string hotfixEntityLogicType, HotfixEntity hotfixEntity, object userData);
        protected internal abstract void OnRecycle();
        protected internal abstract void OnShow(object userData);
        protected internal abstract void OnHide(bool isShutdown, object userData);
        protected internal abstract void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData);
        protected internal abstract void OnDetached(EntityLogic childEntity, object userData);
        protected internal abstract void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData);
        protected internal abstract void OnDetachFrom(EntityLogic parentEntity, object userData);
        protected internal abstract void OnUpdate(float elapseSeconds, float realElapseSeconds);
        protected internal abstract void InternalSetVisible(bool visible);
        public abstract void Clear();
    }
}
