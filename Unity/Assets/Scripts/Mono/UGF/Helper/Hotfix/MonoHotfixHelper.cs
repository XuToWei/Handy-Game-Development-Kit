using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using GameFramework;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;
using Debug = UnityEngine.Debug;

namespace UGF
{
    public class MonoHotfixHelper : HotfixHelperBase
    {
        public override HotfixType HotfixType => HotfixType.Mono;

        private readonly Dictionary<string, Type> m_HotfixTypeDict = new();

        private Type m_EntryType;
        private object m_EntryInstance;
        private Action m_OnEnterMethodAction;
        private Action m_ShutDownMethodAction;
        private Action<float, float> m_OnUpdateMethodAction;
        private Action<bool> m_OnApplicationPauseMethodAction;
        private Action<bool> m_OnApplicationFocusMethodAction;
        private Action m_OnApplicationQuitMethodAction;

        public override object GetType(string hotfixTypeFullName)
        {
            if (m_HotfixTypeDict.TryGetValue(hotfixTypeFullName, out Type hotfixType))
            {
                return hotfixType;
            }
            throw new GameFrameworkException(Utility.Text.Format("HotfixType [{0}] get fail!", hotfixTypeFullName));
        }

        public override object CreateInstance(string hotfixTypeFullName)
        {
            Type type = GetType(hotfixTypeFullName) as Type;
            return Activator.CreateInstance(type);
        }

        public T CreateMethodAction<T>(Type hotfixType, object instance, string methodName) where T : Delegate
        {
            MethodInfo methodInfo = hotfixType.GetMethod(methodName);
            return (T)Delegate.CreateDelegate(typeof(T), instance, methodInfo);
        }

        public object Invoke(Type hotfixType, string methodName, object instance, params object[] p)
        {
            MethodInfo methodInfo = hotfixType.GetMethod(methodName);
            return methodInfo.Invoke(instance, p);
        }

        public override async Task Load()
        {
#if UNITY_EDITOR
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
#endif

            Assembly GetLoadedAssembly(string assemblyName)
            {
#if UNITY_EDITOR
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly.GetName().Name == assemblyName)
                    {
                        return assembly;
                    }
                }
#endif
                return null;
            }

            foreach (var dllName in HotfixConfig.DllNames)
            {
                Assembly assembly = GetLoadedAssembly(dllName);
                if (assembly == null)
                {
                    string dllAssetName = AssetUtility.GetHotfixDllAsset(dllName);
                    TextAsset dllAsset = await GameEntry.Resource.LoadAssetAsync<TextAsset>(dllAssetName);
                    string pdbAssetName = AssetUtility.GetHotfixPdbAsset(dllName);
                    if (GameEntry.Resource.HasAsset(pdbAssetName) == HasAssetResult.NotExist)
                    {
                        assembly = Assembly.Load(dllAsset.bytes);
                    }
                    else
                    {
                        TextAsset pdbAsset = await GameEntry.Resource.LoadAssetAsync<TextAsset>(pdbAssetName);
                        assembly = Assembly.Load(dllAsset.bytes, pdbAsset.bytes);
                    }
                }
                foreach (var type in assembly.GetTypes())
                {
                    if (!string.IsNullOrEmpty(type.FullName))
                    {
                        m_HotfixTypeDict[type.FullName] = type;
                    }
                }
            }
            
            Log.Info("Hotfix mono load completed!");
        }
        
        public override void Init()
        {
            m_EntryType = GetType(HotfixConfig.EntryTypeFullName) as Type;
            m_EntryInstance = CreateInstance(HotfixConfig.EntryTypeFullName);
            m_OnEnterMethodAction = CreateMethodAction<Action>(m_EntryType, m_EntryInstance, "OnEnter");
            m_ShutDownMethodAction = CreateMethodAction<Action>(m_EntryType, m_EntryInstance, "OnShutDown");
            m_OnUpdateMethodAction = CreateMethodAction<Action<float, float>>(m_EntryType, m_EntryInstance, "OnUpdate");
            m_OnApplicationPauseMethodAction = CreateMethodAction<Action<bool>>(m_EntryType, m_EntryInstance, "OnApplicationPause");
            m_OnApplicationFocusMethodAction = CreateMethodAction<Action<bool>>(m_EntryType, m_EntryInstance, "OnApplicationFocus");
            m_OnApplicationQuitMethodAction = CreateMethodAction<Action>(m_EntryType, m_EntryInstance, "OnApplicationQuit");
        }

        public override void OnEnter()
        {
            m_OnEnterMethodAction.Invoke();
        }

        public override void OnShutDown()
        {
            m_ShutDownMethodAction.Invoke();
        }

        public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            m_OnUpdateMethodAction.Invoke(elapseSeconds, realElapseSeconds);
        }

        public override void OnApplicationPause(bool pauseStatus)
        {
            m_OnApplicationPauseMethodAction?.Invoke(pauseStatus);
        }

        public override void OnApplicationFocus(bool hasFocus)
        {
            m_OnApplicationFocusMethodAction?.Invoke(hasFocus);
        }

        public override void OnApplicationQuit()
        {
            m_OnApplicationQuitMethodAction?.Invoke();
        }
        
#if UNITY_EDITOR
        public void Reload()
        {
            foreach (var dllName in HotfixConfig.ReloadDllNames)
            {
                string dllAssetName = AssetUtility.GetHotfixDllAsset(dllName);
                byte[] dllBytes = System.IO.File.ReadAllBytes(dllAssetName);
                string pdbAssetName = AssetUtility.GetHotfixPdbAsset(dllName);
                Assembly assembly;
                if (!System.IO.File.Exists(pdbAssetName))
                {
                    assembly = Assembly.Load(dllBytes);
                }
                else
                {
                    byte[] pdbBytes = System.IO.File.ReadAllBytes(pdbAssetName);
                    assembly = Assembly.Load(dllBytes, pdbBytes);
                }
                foreach (var type in assembly.GetTypes())
                {
                    if (type.FullName != null)
                    {
                        m_HotfixTypeDict[type.FullName] = type;
                    }
                }
            }
        }
#endif
    }
}