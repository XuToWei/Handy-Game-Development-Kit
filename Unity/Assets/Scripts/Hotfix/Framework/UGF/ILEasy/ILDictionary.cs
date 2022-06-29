using System.Collections.Generic;

namespace Hotfix.Logic
{
    public class ILDictionary<K, V>
    {
        private List<K> m_Keys;
        public List<K> Keys => m_Keys;

        private List<V> m_Values;

        private Dictionary<K, int> m_Dict;

        public int Count => m_Keys.Count;

        public ILDictionary()
        {
            m_Keys = new List<K>();
            m_Values = new List<V>();
            m_Dict = new Dictionary<K, int>();
        }

        public V this[K k]
        {
            get { return m_Values[m_Dict[k]]; }
            set
            {
                if (m_Dict.ContainsKey(k))
                {
                    m_Values[m_Dict[k]] = value;
                }
                else
                {
                    m_Dict[k] = m_Values.Count;
                    m_Keys.Add(k);
                    m_Values.Add(value);
                }
            }
        }

        public void Clear()
        {
            m_Dict.Clear();
            m_Keys.Clear();
            m_Values.Clear();
        }

        public void Remove(K k)
        {
            m_Values[m_Dict[k]] = default;
            m_Dict.Remove(k);
            m_Keys.Remove(k);
        }
        
        public void RemoveByIndex(int index)
        {
            m_Values[m_Dict[GetKeyByIndex(index)]] = default;
            m_Keys.RemoveAt(index);
        }

        public K GetKeyByIndex(int index)
        {
            return m_Keys[index];
        }

        public V GetValueByIndex(int index)
        {
            return this[GetKeyByIndex(index)];
        }

        public bool ContainsKey(K k)
        {
            return m_Dict.ContainsKey(k);
        }
    }
}