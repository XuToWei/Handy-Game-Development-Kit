using System.Collections.Generic;

namespace Hotfix.Logic
{
    public class ILMap2Dictionary<K>
    {
        private Dictionary<K, K> m_Dict1;
        private Dictionary<K, K> m_Dict2;

        public ILMap2Dictionary()
        {
            m_Dict1 = new Dictionary<K, K>();
            m_Dict2 = new Dictionary<K, K>();
        }

        public K this[K k]
        {
            get
            {
                if (m_Dict1.ContainsKey(k))
                    return m_Dict1[k];
                return m_Dict2[k];
            }
            set
            {
                m_Dict1[k] = value;
                m_Dict2[value] = k;
            }
        }

        public void Add(K k1, K k2)
        {
            m_Dict1.Add(k1, k2);
            m_Dict2.Add(k2, k1);
        }

        public void Remove(K k)
        {
            if (m_Dict1.ContainsKey(k))
            {
                K v = m_Dict1[k];
                m_Dict1.Remove(k);
                m_Dict2.Remove(v);
            }
            else
            {
                K v = m_Dict2[k];
                m_Dict2.Remove(k);
                m_Dict1.Remove(v);
            }
        }

        public void Clear()
        {
            m_Dict1.Clear();
            m_Dict2.Clear();
        }
    }
}