using UnityEngine;
using UnityGameFramework.Runtime;

namespace UGF
{
    public class CameraComponent : GameFrameworkComponent
    {
        [SerializeField] private Camera m_UICamera;
        [SerializeField] private Camera m_SceneCamera;
        [SerializeField] private AreaCamera m_AreaCamera;

        /// <summary>
        /// UI相机
        /// </summary>
        public Camera UICamera => m_UICamera;

        /// <summary>
        /// 场景相机
        /// </summary>
        public Camera SceneCamera => m_SceneCamera;

        /// <summary>
        /// 区域摄像机
        /// </summary>
        public AreaCamera AreaCamera => m_AreaCamera;
    }
}