using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UGF
{
    public class AreaCamera : MonoBehaviour
    {
        private enum CameraState
        {
            None = 0,
            Moving = 1,
            Scaling = 2,
        }
        
        private Camera m_Camera;
        private Transform m_CameraTransform;

        private Vector2? m_InputMovingDownScreenPos;
        private Vector3? m_InputMovingDownCameraPos;
        private Vector3 m_TargetPos;

        private float? m_InputScalingDownDis;
        private float? m_InputScalingDownFieldOfView;
        private float m_TargetFieldOfView;

        private CameraState m_CameraState;

        [SerializeField] private float m_MinFieldOfView = 21;
        [SerializeField] private float m_MaxFieldOfView = 179;

        private void Awake()
        {
            m_CameraState = CameraState.None;
            m_Camera = GetComponent<Camera>();
            m_CameraTransform = transform;
            m_TargetPos = m_CameraTransform.position;
            m_TargetFieldOfView = m_Camera.fieldOfView;
        }

        private void Start()
        {
            enabled = false;
        }

        private void Update()
        {
            UpdateInputState();
        }

        private void LateUpdate()
        {
            if (m_CameraState == CameraState.None)
                return;
            if (m_CameraState == CameraState.Moving)
            {
                m_CameraTransform.position = m_TargetPos;
            }
            else if (m_CameraState == CameraState.Scaling)
            {
                m_Camera.fieldOfView = m_TargetFieldOfView;
            }
        }

        private void UpdateInputState()
        {
            m_CameraState = GetInputState();
            if (m_CameraState == CameraState.Moving)
            {
                Vector3 screenPos = GetInputScreenPos();
                m_InputMovingDownScreenPos ??= screenPos;
                m_InputMovingDownCameraPos ??= m_CameraTransform.position;
                float depth = m_CameraTransform.position.y;
                Vector3 p1 = m_Camera.ScreenToWorldPoint(new Vector3(m_InputMovingDownScreenPos.Value.x, m_InputMovingDownScreenPos.Value.y, depth));
                Vector3 p2 = m_Camera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, depth));
                m_TargetPos = m_InputMovingDownCameraPos.Value + p1 - p2;
            }
            else
            {
                if (m_InputMovingDownScreenPos.HasValue)
                {
                    m_InputMovingDownScreenPos = null;
                }
                if (m_InputMovingDownCameraPos.HasValue)
                {
                    m_InputMovingDownCameraPos = null;
                }
            }
            
            if (m_CameraState == CameraState.Scaling)
            {
#if UNITY_EDITOR
                m_InputScalingDownFieldOfView = m_Camera.fieldOfView;
                m_TargetFieldOfView = m_InputScalingDownFieldOfView.Value + Input.GetAxis("Mouse ScrollWheel") * 10;
                m_TargetFieldOfView = Mathf.Clamp(m_TargetFieldOfView, m_MinFieldOfView, m_MaxFieldOfView);
#else
                m_InputScalingDownDis ??= GetTwoInputScreenDis();
                m_InputScalingDownFieldOfView ??= m_Camera.fieldOfView;
                m_TargetFieldOfView = m_InputScalingDownFieldOfView.Value + m_InputScalingDownDis.Value;
                m_TargetFieldOfView = Mathf.Clamp(m_TargetFieldOfView, m_MinFieldOfView, m_MaxFieldOfView);
#endif
            }
            else
            {
                if (m_InputScalingDownDis.HasValue)
                {
                    m_InputScalingDownDis = null;
                }
                if (m_InputScalingDownFieldOfView.HasValue)
                {
                    m_InputScalingDownFieldOfView = null;
                }
            }
        }

        private CameraState GetInputState()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                return CameraState.Moving;
            }
            if (Input.GetAxis("Mouse ScrollWheel") !=0)
            {
                return CameraState.Scaling;
            }
            return CameraState.None;
#else
            if (Input.touchCount == 1)
            {
                return CameraState.Moving;
            }
            if (Input.touchCount == 2)
            {
                return CameraState.Scaling;
            }
            return CameraState.None;
#endif
        }


        private Vector2 GetInputScreenPos()
        {
#if UNITY_EDITOR
            return Input.mousePosition;
#else
            return Input.touches[0].position;
#endif
        }

        private float GetTwoInputScreenDis()
        {
            return Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
        }
    }
}