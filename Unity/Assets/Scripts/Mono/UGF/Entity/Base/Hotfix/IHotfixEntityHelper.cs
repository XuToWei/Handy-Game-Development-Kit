using UnityEngine;

namespace UGF
{
    public interface IHotfixEntityLogicHelper
    {
        void OnInit(object userData);
        void OnRecycle();
        void OnShow(object userData);
        void OnHide(bool isShutdown, object userData);
        void OnAttached(UnityGameFramework.Runtime.EntityLogic childEntity, Transform parentTransform, object userData);
        void OnDetached(UnityGameFramework.Runtime.EntityLogic childEntity, object userData);
        void OnAttachTo(UnityGameFramework.Runtime.EntityLogic parentEntity, Transform parentTransform, object userData);
        void OnDetachFrom(UnityGameFramework.Runtime.EntityLogic parentEntity, object userData);
        void OnUpdate(float elapseSeconds, float realElapseSeconds);
    }
}