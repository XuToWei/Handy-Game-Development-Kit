namespace Hotfix.Logic
{
    public class IL2Array<T>
    {
        private T[] m_Data;

        public T[] Datas => m_Data;

        public int XNum
        {
            get;
        }

        public int YNum
        {
            get;
        }

        public IL2Array(int xNum, int yNum)
        {
            m_Data = new T[xNum * yNum];
            XNum = xNum;
            YNum = yNum;
        }

        public T this[int x, int y]
        {
            get
            {
                return m_Data[y * XNum + x];
            }
            set
            {
                m_Data[y * XNum + x] = value;
            }
        }

        public T GetByDir(int x, int y, int dir)
        {
            if (dir == 1)
            {
                return GetUp(x, y);
            }
            if (dir == 2)
            {
                return GetDown(x, y);
            }
            if (dir == 3)
            {
                return GetLeft(x, y);
            }
            if (dir == 4)
            {
                return GetRight(x, y);
            }
            return default;
        }
        
        public T GetRight(int x, int y)
        {
            if (x < 0 || y < 0 || x >= XNum - 1 || y >= YNum)
            {
                return default;
            }
            x++;
            return this[x, y];
        }
        
        public T GetLeft(int x, int y)
        {
            if (x <= 0 || y < 0 || x >= XNum || y >= YNum)
            {
                return default;
            }
            x--;
            return this[x, y];
        }
        
        public T GetDown(int x, int y)
        {
            if (x < 0 || y <= 0 || x >= XNum || y >= YNum)
            {
                return default;
            }
            y--;
            return this[x, y];
        }
        
        public T GetUp(int x, int y)
        {
            if (x < 0 || y < 0 || x >= XNum || y >= YNum - 1)
            {
                return default;
            }
            y++;
            return this[x, y];
        }

        public void Switch(int x1, int y1, int x2, int y2)
        {
            //ILRuntime 使用(x,y)=(y,x)有点问题
            T temp = this[x1, y1];
            this[x1, y1] = this[x2, y2];
            this[x2, y2] = temp;
        }
    }
}