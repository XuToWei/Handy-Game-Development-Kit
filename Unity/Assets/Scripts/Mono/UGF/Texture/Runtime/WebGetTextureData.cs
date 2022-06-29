using GameFramework;

namespace UGF
{
    public class WebGetTextureData : IReference
    {
        private ISetTexture2dObject m_SetTexture2dObject;
        private TextureComponent m_UserData;
        private string m_FilePath;

        public ISetTexture2dObject SetTexture2dObject => m_SetTexture2dObject;
        public TextureComponent UserData => m_UserData;
        public string FilePath => m_FilePath;

        public static WebGetTextureData Create(ISetTexture2dObject setTexture2dObject, TextureComponent userData,string filePath)
        {
            WebGetTextureData webGetTextureData = ReferencePool.Acquire<WebGetTextureData>();
            webGetTextureData.m_SetTexture2dObject = setTexture2dObject;
            webGetTextureData.m_UserData = userData;
            webGetTextureData.m_FilePath = filePath;
            return webGetTextureData;
        }

        public void Clear()
        {
            m_SetTexture2dObject = null;
            m_UserData = null;
            m_FilePath = null;
        }
    }
}
