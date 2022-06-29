using UnityGameFramework.Runtime;
using GameEntry = UGF.GameEntry;
using UGF;
using GameFramework;

namespace Hotfix.Logic
{
    public static class EntityExtension
    {
        /// <summary>
        /// 显示实体
        /// </summary>
        internal static void ShowEntity<T>(this EntityComponent entityComponent, int entityTypeId, object data) where T : HotfixEntityLogic
        {
            entityComponent.ShowHotfixEntity(entityTypeId, typeof(T).FullName, data);
        }
    }
}