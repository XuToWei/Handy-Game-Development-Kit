using System;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = Hotfix.Framework.IFsm<Hotfix.Framework.ProcedureManager>;
using UGF;
using GameEntry = UGF.GameEntry;
using GameFramework.Event;
using GameFramework;
using UnityEngine;

namespace Hotfix.Logic
{
    public class ProcedurePreload : Hotfix.Framework.ProcedureBase
    {
        private static readonly List<string> DataTableNames = new List<string>()
        {
            "UIForm",
            "Entity",
        };

        private readonly GameFrameworkLinkedList<string> m_LoadedFlags = new GameFrameworkLinkedList<string>();

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            GameEntry.Event.Subscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
            GameEntry.Event.Subscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            GameEntry.Event.Subscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);
            GameEntry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            GameEntry.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);

            m_LoadedFlags.Clear();

            PreloadResources();
            Debug.Log("---------" + Type.GetType("Hotfix.Logic.LoginForm"));
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            GameEntry.Event.Unsubscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
            GameEntry.Event.Unsubscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            GameEntry.Event.Unsubscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);
            GameEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            GameEntry.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds,
            float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            
            if (m_LoadedFlags.Count > 0)
            {
                return;
            }
            
            ChangeState<ProcedureEnterGame>(procedureOwner);
        }

        private void PreloadResources()
        {
            // Preload configs
            LoadConfig("DefaultConfig");

            // Preload data tables
            foreach (string dataTableName in DataTableNames)
            {
                LoadDataTable(dataTableName);
            }

            PreloadLuban();

            LoadSprites();

            // Preload dictionaries
            // LoadDictionary("Default");

            // Preload fonts
            // LoadFont("MainFont");
        }
        
        
        private void LoadSprites()
        {
            string spritesAssetName = "Assets/Res/Sprites/Sprites.prefab";
            m_LoadedFlags.AddLast(spritesAssetName);
            GameEntry.SpriteDict.LoadSprites(spritesAssetName, delegate
            {
                m_LoadedFlags.Remove(spritesAssetName);
            });
        }

        private async void PreloadLuban()
        {
            m_LoadedFlags.AddLast("Game.Luban");
            m_LoadedFlags.AddLast("Hotfix.Luban");
            
            //await LubanLoader.LoadGameLuban();
            m_LoadedFlags.Remove("Game.Luban");
            Log.Info("Load game luban OK.");
            
            await LubanLoader.LoadHotfixLuban();
            m_LoadedFlags.Remove("Hotfix.Luban");
            Log.Info("Load hotfix luban OK.");
            
            Log.Info("Load luban OK.");
        }

        private void LoadConfig(string configName)
        {
            string configAssetName = AssetUtility.GetConfigAsset(configName, false);
            m_LoadedFlags.AddLast(configAssetName);
            GameEntry.Config.ReadData(configAssetName, this);
        }

        private void LoadDataTable(string dataTableName)
        {
            string dataTableAssetName = AssetUtility.GetDataTableAsset(dataTableName, false);
            m_LoadedFlags.AddLast(dataTableAssetName);
            GameEntry.DataTable.LoadDataTable(dataTableName, dataTableAssetName, this);
            Log.Info("Load data table '{0}' row config OK.", dataTableName);
        }

        private void LoadDictionary(string dictionaryName)
        {
            string dictionaryAssetName = AssetUtility.GetDictionaryAsset(dictionaryName, false);
            m_LoadedFlags.AddLast(dictionaryAssetName);
            GameEntry.Localization.ReadData(dictionaryAssetName, this);
        }

        private void OnLoadConfigSuccess(object sender, GameEventArgs e)
        {
            LoadConfigSuccessEventArgs ne = (LoadConfigSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlags.Remove(ne.ConfigAssetName);
            Log.Info("Load config '{0}' OK.", ne.ConfigAssetName);
        }

        private void OnLoadConfigFailure(object sender, GameEventArgs e)
        {
            LoadConfigFailureEventArgs ne = (LoadConfigFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load config '{0}' from '{1}' with error message '{2}'.", ne.ConfigAssetName,
                ne.ConfigAssetName, ne.ErrorMessage);
        }

        private void OnLoadDictionarySuccess(object sender, GameEventArgs e)
        {
            LoadDictionarySuccessEventArgs ne = (LoadDictionarySuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlags.Remove(ne.DictionaryAssetName);
            Log.Info("Load dictionary '{0}' OK.", ne.DictionaryAssetName);
        }

        private void OnLoadDictionaryFailure(object sender, GameEventArgs e)
        {
            LoadDictionaryFailureEventArgs ne = (LoadDictionaryFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load dictionary '{0}' from '{1}' with error message '{2}'.", ne.DictionaryAssetName,
                ne.DictionaryAssetName, ne.ErrorMessage);
        }
        
        private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
        {
            LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlags.Remove(ne.DataTableAssetName);
            Log.Info("Load data table '{0}' OK.", ne.DataTableAssetName);
        }

        private void OnLoadDataTableFailure(object sender, GameEventArgs e)
        {
            LoadDataTableFailureEventArgs ne = (LoadDataTableFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", ne.DataTableAssetName, ne.DataTableAssetName, ne.ErrorMessage);
        }
    }
}