using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UGF
{
    public class HotfixEntity : Entity
    {
        private HotfixEntityHelperBase m_EntityLogicHelper;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            HotfixEntityData entityData = userData as HotfixEntityData;
            if (GameEntry.Hotfix.HotfixType == HotfixType.Mono)
            {
                m_EntityLogicHelper = ReferencePool.Acquire<MonoEntityHelper>();
            }
#if ILRuntime
            else if (GameEntry.Hotfix.HotfixType == HotfixType.ILRuntime)
            {
                m_EntityLogicHelper = ReferencePool.Acquire<ILRuntimeEntityHelper>();
            }
#endif
            m_EntityLogicHelper.OnInit(entityData.HotfixEntityType, this, entityData.UserData);
        }

        private void OnDestroy()
        {
            ReferencePool.Release(m_EntityLogicHelper);
            m_EntityLogicHelper = null;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            if (userData is HotfixEntityData entityData)
            {
                userData = entityData.UserData;
                ReferencePool.Release(entityData);
            }
            m_EntityLogicHelper.OnShow(userData);
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
            m_EntityLogicHelper.OnRecycle();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            m_EntityLogicHelper.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            m_EntityLogicHelper.OnHide(isShutdown, userData);
        }

        protected override void InternalSetVisible(bool visible)
        {
            base.InternalSetVisible(visible);
            m_EntityLogicHelper.InternalSetVisible(visible);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);
            m_EntityLogicHelper.OnAttached(childEntity, parentTransform, userData);
        }

        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);
            m_EntityLogicHelper.OnDetached(childEntity, userData);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);
            m_EntityLogicHelper.OnAttachTo(parentEntity, parentTransform, userData);
        }

        protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            base.OnDetachFrom(parentEntity, userData);
            m_EntityLogicHelper.OnDetachFrom(parentEntity, userData);
        }
    }
}
