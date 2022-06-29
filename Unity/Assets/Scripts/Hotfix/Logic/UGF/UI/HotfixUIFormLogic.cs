using UGF;

namespace Hotfix.Logic
{
    public abstract class HotfixUIFormLogic : Framework.UIFormLogic
    {
        protected override void OnInit(object userData)
        {
            
        }

        protected override void OnRecycle()
        {
            
        }

        protected override void OnOpen(object userData)
        {
            
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            
        }

        protected override void OnPause()
        {
            
        }

        protected override void OnResume()
        {
            
        }

        protected override void OnCover()
        {
            
        }

        protected override void OnReveal()
        {
            
        }

        protected override void OnRefocus(object userData)
        {
            
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            
        }

        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            
        }

        protected override void InternalSetVisible(bool visible)
        {
            
        }

        public void Close()
        {
            GameEntry.UI.CloseUIForm(UIForm);
        }
    }
}
