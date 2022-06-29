using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
    public class UIStateHelper : MonoBehaviour
    {
        [Serializable]
        private class StateData
        {
            public List<Vector2> Positions;
            public List<bool> IsActives;
        }

        [SerializeField] private List<RectTransform> m_Transforms;
        [SerializeField] private List<StateData> m_StateDatas;

        public List<RectTransform> Transforms => m_Transforms;

        public int StateCount => m_StateDatas?.Count ?? 0;

        public void SetState(int index)
        {
            StateData stateData = m_StateDatas[index];
            for (int i = 0; i < m_Transforms.Count; i++)
            {
                m_Transforms[i].anchoredPosition = stateData.Positions[i];
                m_Transforms[i].gameObject.SetActive(stateData.IsActives[i]);
            }
        }

        public void SyncState(int index)
        {
            StateData stateData = m_StateDatas[index];
            stateData.Positions = new List<Vector2>();
            stateData.IsActives = new List<bool>();
            for (int i = 0; i < m_Transforms.Count; i++)
            {
                stateData.Positions.Add(m_Transforms[i].anchoredPosition);
                stateData.IsActives.Add(m_Transforms[i].gameObject.activeSelf);
            }
        }

        public void AddState()
        {
            if (m_StateDatas == null)
            {
                m_StateDatas = new List<StateData>();
            }
            m_StateDatas.Add(new StateData());
            SyncState(m_StateDatas.Count - 1);
        }
    }
}
