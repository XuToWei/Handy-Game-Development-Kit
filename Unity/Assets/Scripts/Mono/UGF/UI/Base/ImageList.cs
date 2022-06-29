using System.Collections.Generic;

namespace UnityEngine.UI
{
    [RequireComponent(typeof(LayoutGroup))]
    public class ImageList : MonoBehaviour
    {
        private Image m_FirstImage;

        private List<Image> m_Images;

        private void Awake()
        {
            m_Images = new List<Image>();
            m_FirstImage = transform.GetChild(0).GetComponent<Image>();
            m_Images.Add(m_FirstImage);
        }

        public void SetCount(int count)
        {
            int addCount = count - m_Images.Count;
            for (int i = 0; i < addCount; i++)
            {
                Image image = GameObject.Instantiate(m_FirstImage, transform);
                m_Images.Add(image);
            }
            for (int i = 0; i < count; i++)
            {
                m_Images[i].gameObject.SetActive(true);
            }
            for (int i = count; i < m_Images.Count; i++)
            {
                m_Images[i].gameObject.SetActive(false);
            }
        }

        public void Set(int index, Sprite sprite)
        {
            m_Images[index].sprite = sprite;
        }

        public Image Get(int index)
        {
            return m_Images[index];
        }
    }
}
