using GameFramework;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace UGF
{
    public class ScreenComponent : GameFrameworkComponent
    {
        [SerializeField] private int m_StandardWidth = 1080;
        [SerializeField] private int m_StandardHeight = 1920;
        
        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public int Width { private set; get; }

        /// <summary>
        /// 屏幕高度
        /// </summary>
        public int Height { private set; get; }

        /// <summary>
        /// 屏幕安全区域
        /// </summary>
        public Rect SafeArea { private set; get; }

        /// <summary>
        /// 标准屏幕宽
        /// </summary>
        public int StandardWidth => m_StandardWidth;
        
        /// <summary>
        /// 标准屏幕高
        /// </summary>
        public int StandardHeight => m_StandardHeight;

        /// <summary>
        /// UI宽
        /// </summary>
        public float UIWidth;
        
        /// <summary>
        /// UI高
        /// </summary>
        public float UIHeight;
        
        /// <summary>
        /// 标准屏幕比例（高/宽）
        /// </summary>
        public float StandardVerticalRatio { private set; get; }
        
        /// <summary>
        /// 标准屏幕比例（高/宽）
        /// </summary>
        public float StandardHorizontalRatio { private set; get; }

        protected override void Awake()
        {
            base.Awake();
            StandardVerticalRatio = 1f * m_StandardHeight / m_StandardWidth;
            StandardHorizontalRatio = 1f * m_StandardWidth / m_StandardHeight;
            Set(Screen.width, Screen.height, Screen.safeArea);
        }

        /// <summary>
        /// 设置屏幕数据
        /// </summary>
        /// <param name="width">屏幕宽</param>
        /// <param name="height">屏幕高</param>
        /// <param name="safeArea">屏幕的安全区域</param>
        private void Set(int width, int height, Rect safeArea)
        {
            Width = width;
            Height = height;
            Log.Info(Utility.Text.Format("设置屏幕宽:{0} ,高:{1} .", width, height));
            SafeArea = safeArea;
            Log.Info(Utility.Text.Format("设置屏幕安全区域 x:{0} ,y:{1} ,width:{2} ,height:{3} .", safeArea.x, safeArea.y, safeArea.width, safeArea.height));
            AdjustCanvasScaler();
        }

        private void AdjustCanvasScaler()
        {
            CanvasScaler canvasScaler = GameObject.Find("UI Form Instances").GetComponent<CanvasScaler>();
            float ratio = SafeArea.height / SafeArea.width;
            canvasScaler.matchWidthOrHeight = ratio > StandardVerticalRatio ? 0 : 1;
            Canvas.ForceUpdateCanvases();
            RectTransform rectTransform = canvasScaler.GetComponent<RectTransform>();
            UIWidth = rectTransform.sizeDelta.x;
            UIHeight = rectTransform.sizeDelta.y;
        }
    }
}