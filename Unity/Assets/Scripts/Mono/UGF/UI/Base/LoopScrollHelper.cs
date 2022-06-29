using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine.UI
{
    public class LoopScrollHelper : MonoBehaviour, LoopScrollPrefabSource, LoopScrollDataSource
    {
        [SerializeField] private GameObject m_Item;
        [SerializeField] private LoopScrollRect m_LoopScrollRect;

        // Implement your own Cache Pool here. The following is just for example.
        private readonly Stack<Transform> m_Pool = new Stack<Transform>();

        public LoopScrollRect LoopScrollRect => m_LoopScrollRect;
        
        private Action<Transform, int> m_ProvideDataAction;

        public GameObject GetObject(int index)
        {
            GameObject obj;
            if (m_Pool.Count == 0)
            {
                obj = Instantiate(m_Item);
            }
            else
            {
                obj = m_Pool.Pop().gameObject;
            }
            obj.SetActive(true);
            obj.name = index.ToString();
            return obj;
        }

        public void ReturnObject(Transform trans)
        {
            // Use `DestroyImmediate` here if you don't need Pool
            trans.SendMessage("ScrollCellReturn", SendMessageOptions.DontRequireReceiver);
            trans.SetParent(transform, false);
            trans.gameObject.SetActive(false);
            m_Pool.Push(trans);
            Debug.Log("return" + trans);
        }

        public void ProvideData(Transform transform, int idx)
        {
            m_ProvideDataAction.Invoke(transform, idx);
        }

        void Awake()
        {
            m_Item.SetActive(false);
            m_Item.transform.SetParent(transform, false);
            m_Pool.Push(m_Item.transform);
            m_LoopScrollRect.prefabSource = this;
            m_LoopScrollRect.dataSource = this;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="provideDataAction"></param>
        public void Set(int totalCount, Action<Transform,int> provideDataAction)
        {
            m_ProvideDataAction = provideDataAction;
            m_LoopScrollRect.totalCount = totalCount;
            m_LoopScrollRect.RefillCells();
        }
    }
}
