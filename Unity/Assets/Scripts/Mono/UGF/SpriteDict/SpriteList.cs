using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UGF
{
    public class SpriteList : MonoBehaviour
    {
        [SerializeField]
        private List<Sprite> m_Sprites;

        public List<Sprite> Sprites => m_Sprites;
    }
}
