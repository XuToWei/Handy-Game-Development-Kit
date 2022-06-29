using System.Collections.Generic;

namespace Hotfix.Logic
{
    public class ILKey2Array<T>
    {
        private readonly Dictionary<int, T[]> m_Dict;
        public readonly int[] Keys;

        public int KeyCount
        {
            get;
            private set;
        }

        public int YNum;
        
        public ILKey2Array(int yNum, List<int> xs)
        {
            Keys = new int[xs.Count];
            m_Dict = new Dictionary<int, T[]>();
            for (int i = 0; i < xs.Count; i++)
            {
                int x = xs[i];
                m_Dict.Add(x, new T[yNum]);
                Keys[i] = x;
            }
            KeyCount = xs.Count;
            YNum = yNum;
        }

        public ILKey2Array(int yNum, params int[] xs)
        {
            Keys = new int[xs.Length];
            m_Dict = new Dictionary<int, T[]>();
            for (int i = 0; i < xs.Length; i++)
            {
                int x = xs[i];
                m_Dict.Add(x, new T[yNum]);
                Keys[i] = x;
            }
            KeyCount = xs.Length;
            YNum = yNum;
        }

        public T this[int x, int y]
        {
            get => m_Dict[x][y];
            set => m_Dict[x][y] = value;
        }
    }
}