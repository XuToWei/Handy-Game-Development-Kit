//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using System.Threading.Tasks;
using GameFramework;
using UnityGameFramework.Runtime;

namespace UGF
{
    public static partial class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        public static EntityLogic GetEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (EntityLogic)entity.Logic;
        }

        public static void HideEntity(this EntityComponent entityComponent, EntityLogic entityLogic)
        {
            entityComponent.HideEntity(entityLogic.Entity);
        }

        public static void AttachEntity(this EntityComponent entityComponent, EntityLogic entityLogic, int ownerId, string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entityLogic.Entity, ownerId, parentTransformPath, userData);
        }

        /// <summary>
        /// 显示实体
        /// </summary>
        public static int? ShowEntity(this EntityComponent entityComponent, int entityTypeId, Type logicType, object userData)
        {
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(entityTypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", entityTypeId.ToString());
                return null;
            }

            int serialId = entityComponent.GenerateSerialId();
            entityComponent.ShowEntity(serialId, logicType, AssetUtility.GetEntityAsset(drEntity.EntityGroupName, drEntity.AssetName), drEntity.EntityGroupName, drEntity.Priority, userData);
            return serialId;
        }
        
        /// <summary>
        /// 显示实体
        /// </summary>
        public static int? ShowEntity<T>(this EntityComponent entityComponent, int entityTypeId, object userData) where T : EntityLogic
        {
            return entityComponent.ShowEntity(entityTypeId, typeof(T), userData);
        }

        /// <summary>
        /// 显示实体
        /// </summary>
        public static Task<UnityGameFramework.Runtime.Entity> ShowEntityAsync<T>(this EntityComponent entityComponent, int entityTypeId, object userData) where T : EntityLogic
        {
            return entityComponent.ShowEntityAsync(entityTypeId, typeof(T), userData);
        }
        
        /// <summary>
        /// 显示实体
        /// </summary>
        public static Task<UnityGameFramework.Runtime.Entity> ShowEntityAsync(this EntityComponent entityComponent, int entityTypeId, Type logicType, object userData) 
        {
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(entityTypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", entityTypeId.ToString());
                return null;
            }
            
            int serialId = entityComponent.GenerateSerialId();
            return entityComponent.ShowEntityAsync(serialId, logicType, AssetUtility.GetEntityAsset(drEntity.EntityGroupName, drEntity.AssetName), drEntity.EntityGroupName, drEntity.Priority, userData);
        }
        
        /// <summary>
        /// 显示Hotfix实体
        /// </summary>
        public static int? ShowHotfixEntity(this EntityComponent entityComponent, int entityTypeId, string hotfixLogicType, object userData)
        {
            HotfixEntityData entityData = ReferencePool.Acquire<HotfixEntityData>();
            entityData.Fill(hotfixLogicType, userData);
            
            return entityComponent.ShowEntity<HotfixEntity>(entityTypeId, entityData);
        }
        
        /// <summary>
        /// 显示Hotfix实体
        /// </summary>
        public static Task<UnityGameFramework.Runtime.Entity> ShowHotfixEntityAsync(this EntityComponent entityComponent, int entityTypeId, string hotfixLogicType, object userData)
        {
            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(entityTypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", entityTypeId.ToString());
                return null;
            }

            HotfixEntityData entityData = ReferencePool.Acquire<HotfixEntityData>();
            entityData.Fill(hotfixLogicType, userData);
            
            int serialId = entityComponent.GenerateSerialId();
            return entityComponent.ShowEntityAsync(serialId, typeof(HotfixEntity), AssetUtility.GetEntityAsset(drEntity.EntityGroupName, drEntity.AssetName), drEntity.EntityGroupName, drEntity.Priority, entityData);
        }
        
        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }
    }
}
