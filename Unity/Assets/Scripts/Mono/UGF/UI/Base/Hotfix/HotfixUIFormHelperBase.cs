using GameFramework;

namespace UGF
{
    internal abstract class HotfixUIFormHelperBase : IReference
    {
        protected string HotfixProxyTypeName => "Hotfix.Framework.UIFormLogicProxy";
        protected internal abstract void OnInit(string hotfixUIFormType, HotfixUIForm hotfixUIForm, object userData);
        protected internal abstract void OnRecycle();
        protected internal abstract void OnOpen(object userData);
        protected internal abstract void OnClose(bool isShutdown, object userData);
        protected internal abstract void OnPause();
        protected internal abstract void OnResume();
        protected internal abstract void OnCover();
        protected internal abstract void OnReveal();
        protected internal abstract void OnRefocus(object userData);
        protected internal abstract void OnUpdate(float elapseSeconds, float realElapseSeconds);
        protected internal abstract void OnDepthChanged(int uiGroupDepth, int depthInUIGroup);
        protected internal abstract void InternalSetVisible(bool visible);
        public abstract void Clear();
    }
}
