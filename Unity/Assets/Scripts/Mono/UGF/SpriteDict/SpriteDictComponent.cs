using System;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UGF
{
    public class SpriteDictComponent : GameFrameworkComponent
    {
        private Dictionary<string, Sprite> m_SpriteDict;

        private void Start()
        {
            m_SpriteDict = new Dictionary<string, Sprite>();
        }

        public void LoadSprites(string spriteListAssetName, Action onLoadSuccess)
        {
            GameEntry.Resource.LoadAsset(spriteListAssetName, new LoadAssetCallbacks(
                delegate(string assetName, object asset, float duration, object data)
                {
                    SpriteList spriteList = (asset as GameObject).GetComponent<SpriteList>();
                    foreach (var sprite in spriteList.Sprites)
                    {
                        m_SpriteDict.Add(sprite.name, sprite);
                    }
                    onLoadSuccess.Invoke();
                }));
        }

        public Sprite Get(string spriteName)
        {
            if (!m_SpriteDict.ContainsKey(spriteName))
            {
                Debug.LogError(Utility.Text.Format("{0} not exist!", spriteName));
                throw new GameFrameworkException(Utility.Text.Format("{0} not exist!", spriteName));
            }
            return m_SpriteDict[spriteName];
        }
    }
}
