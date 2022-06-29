using GameFramework;

namespace UGF
{
    internal class HotfixEntityData : IReference
    {
        /// <summary>
        /// 
        /// </summary>
        public string HotfixEntityType
        {
            private set;
            get;
        }

        public object UserData
        {
            private set;
            get;
        }
        
        public void Clear()
        {
            HotfixEntityType = default;
            UserData = default;
        }

        public void Fill(string hotfixEntityType, object userData)
        {
            HotfixEntityType = hotfixEntityType;
            UserData = userData;
        }
    }
}
