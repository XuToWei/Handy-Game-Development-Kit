using UGF;
using UnityEngine;

namespace Hotfix.Framework
{
    public abstract class UIFormLogic
    {
        private HotfixUIForm m_GameUIForm = null;

        /// <summary>
        /// 获取界面。
        /// </summary>
        public UnityGameFramework.Runtime.UIForm UIForm => m_GameUIForm.UIForm;
        
        /// <summary>
        /// 获取界面逻辑。
        /// </summary>
        public HotfixUIForm GameUIForm => m_GameUIForm;

        /// <summary>
        /// 获取或设置界面名称。
        /// </summary>
        public string Name
        {
            get => m_GameUIForm.Name;
            set => m_GameUIForm.Name = value;
        }

        /// <summary>
        /// 获取界面是否可用。
        /// </summary>
        public bool Available => m_GameUIForm.Available;

        /// <summary>
        /// 获取或设置界面是否可见。
        /// </summary>
        public bool Visible
        {
            get => m_GameUIForm.Visible;
            set => m_GameUIForm.Visible = value;
        }

        /// <summary>
        /// 获取已缓存的 Transform。
        /// </summary>
        public Transform CachedTransform => m_GameUIForm.CachedTransform;
        
        public void Clear()
        {
            m_GameUIForm = default;
        }

        public void Fill(HotfixUIForm hotfixUIForm)
        {
            m_GameUIForm = hotfixUIForm;
        }

        /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected internal abstract void OnInit(object userData);

        /// <summary>
        /// 界面回收。
        /// </summary>
        protected internal abstract void OnRecycle();

        /// <summary>
        /// 界面打开。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected internal abstract void OnOpen(object userData);

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="isShutdown">是否是关闭界面管理器时触发。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected internal abstract void OnClose(bool isShutdown, object userData);

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected internal abstract void OnPause();

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected internal abstract void OnResume();

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected internal abstract void OnCover();

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected internal abstract void OnReveal();

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected internal abstract void OnRefocus(object userData);

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected internal abstract void OnUpdate(float elapseSeconds, float realElapseSeconds);

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        protected internal abstract void OnDepthChanged(int uiGroupDepth, int depthInUIGroup);

        /// <summary>
        /// 设置界面的可见性。
        /// </summary>
        /// <param name="visible">界面的可见性。</param>
        protected internal abstract void InternalSetVisible(bool visible);
    }
}
