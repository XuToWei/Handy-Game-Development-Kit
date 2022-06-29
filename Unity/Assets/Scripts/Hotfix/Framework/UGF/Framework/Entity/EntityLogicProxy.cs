using System;
using UGF;
using UnityEngine;

namespace Hotfix.Framework
{
    public sealed class EntityLogicProxy : IReference
    {
        public static EntityLogicProxy Acquire()
        {
            return ReferencePool.Acquire<EntityLogicProxy>();
        }

        public static void Release(object obj)
        {
            EntityLogicProxy entityLogic = obj as EntityLogicProxy;
            ReferencePool.Release(entityLogic);
        }

        private EntityLogic m_EntityLogic;
        
        public void Clear()
        {
            m_EntityLogic.Clear();
            m_EntityLogic = null;
        }
        
        public void OnInit(string entityLogicType, HotfixEntity hotfixEntity, object userData)
        {
            m_EntityLogic = GameEntry.Hotfix.HotfixHelper.CreateInstance(entityLogicType) as EntityLogic;
            m_EntityLogic.Fill(hotfixEntity);
            m_EntityLogic.OnInit(userData);
        }

        public void OnRecycle()
        {
            m_EntityLogic.OnRecycle();
        }

        public void OnShow(object userData)
        {
            m_EntityLogic.OnShow(userData);
        }

        public void OnHide(bool isShutdown, object userData)
        {
            m_EntityLogic.OnHide(isShutdown, userData);
        }

        public void OnAttached(UnityGameFramework.Runtime.EntityLogic childEntity, Transform parentTransform, object userData)
        {
            m_EntityLogic.OnAttached(childEntity, parentTransform, userData);
        }

        public void OnDetached(UnityGameFramework.Runtime.EntityLogic childEntity, object userData)
        {
            m_EntityLogic.OnDetached(childEntity, userData);
        }

        public void OnAttachTo(UnityGameFramework.Runtime.EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            m_EntityLogic.OnAttachTo(parentEntity, parentTransform, userData);
        }

        public void OnDetachFrom(UnityGameFramework.Runtime.EntityLogic parentEntity, object userData)
        {
            m_EntityLogic.OnDetachFrom(parentEntity, userData);
        }

        public void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            m_EntityLogic.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        public void InternalSetVisible(bool visible)
        {
            m_EntityLogic.InternalSetVisible(visible);
        }
    }
}