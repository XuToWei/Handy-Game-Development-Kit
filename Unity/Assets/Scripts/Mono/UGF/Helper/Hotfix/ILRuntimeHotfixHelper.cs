#if ILRuntime
using System.IO;
using System.Threading.Tasks;
using GameFramework;
using GameFramework.Resource;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using UnityEngine;
using UnityGameFramework.Runtime;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace UGF
{
    public class ILRuntimeHotfixHelper : HotfixHelperBase
    {
        private AppDomain m_AppDomain;
        public AppDomain AppDomain => m_AppDomain;

        private ILType m_EntryType;
        private ILTypeInstance m_EntryInstance;
        private IMethod m_OnEnterMethod;
        private IMethod m_ShutDownMethod;
        private IMethod m_OnUpdateMethod;
        private IMethod m_OnApplicationPauseMethod;
        private IMethod m_OnApplicationFocusMethod;
        private IMethod m_OnApplicationQuitMethod;

        public override HotfixType HotfixType => HotfixType.ILRuntime;

        public override object GetType(string hotfixTypeFullName)
        {
            if (m_AppDomain.LoadedTypes.TryGetValue(hotfixTypeFullName, out IType hotfixType))
            {
                return hotfixType;
            }
            throw new GameFrameworkException(Utility.Text.Format("HotfixType [{0}] get fail!", hotfixTypeFullName));
        }

        public override object CreateInstance(string hotfixTypeFullName)
        {
            ILType type = GetType(hotfixTypeFullName) as ILType;
            return type.Instantiate();
        }

        public override async Task Load()
        {
            m_AppDomain = new AppDomain(ILRuntimeJITFlags.JITOnDemand);
            foreach (var dllName in HotfixConfig.DllNames)
            {
                string dllAssetName = AssetUtility.GetHotfixDllAsset(dllName);
                TextAsset dllAsset = await GameEntry.Resource.LoadAssetAsync<TextAsset>(dllAssetName);
                string pdbAssetName = AssetUtility.GetHotfixPdbAsset(dllName);
                if (GameEntry.Resource.HasAsset(pdbAssetName) == HasAssetResult.NotExist)
                {
                    m_AppDomain.LoadAssembly(new MemoryStream(dllAsset.bytes));
                }
                else
                {
                    TextAsset pdbAsset = await GameEntry.Resource.LoadAssetAsync<TextAsset>(pdbAssetName);
                    m_AppDomain.LoadAssembly(new MemoryStream(dllAsset.bytes), new MemoryStream(pdbAsset.bytes), new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());
                }
            }
            ILRuntimeUtility.InitILRuntime(m_AppDomain);
            //启动调试服务器
            m_AppDomain.DebugService.StartDebugService(56789);
            Log.Info("启动ILRuntime调试服务器:56789");
#if DEBUG && !NO_PROFILER
            //设置Unity主线程ID 这样就可以用Profiler看性能消耗了
            m_AppDomain.UnityMainThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
#endif
            System.AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Log.Error(e.ExceptionObject.ToString());
            };
            
            Log.Info("Hotfix ILRuntime load completed!");
        }

        public override void Init()
        {
            m_EntryType = m_AppDomain.LoadedTypes[HotfixConfig.EntryTypeFullName] as ILType;
            m_OnEnterMethod = m_EntryType.GetMethod("OnEnter");
            m_ShutDownMethod = m_EntryType.GetMethod("ShutDown");
            m_OnUpdateMethod = m_EntryType.GetMethod("OnUpdate");
            m_OnApplicationPauseMethod = m_EntryType.GetMethod("OnApplicationPause");
            m_OnApplicationFocusMethod = m_EntryType.GetMethod("OnApplicationFocus");
            m_OnApplicationQuitMethod = m_EntryType.GetMethod("OnApplicationQuit");
            m_EntryInstance = m_EntryType.Instantiate();
        }

        public override void OnEnter()
        {
            using InvocationContext ctx = m_AppDomain.BeginInvoke(m_OnEnterMethod);
            ctx.PushObject(m_EntryInstance);
            ctx.Invoke();
        }

        public override void OnShutDown()
        {
            using InvocationContext ctx = m_AppDomain.BeginInvoke(m_ShutDownMethod);
            ctx.PushObject(m_EntryInstance);
            ctx.Invoke();
        }

        public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            using var ctx = m_AppDomain.BeginInvoke(m_OnUpdateMethod);
            ctx.PushObject(m_EntryInstance);
            ctx.PushFloat(elapseSeconds);
            ctx.PushFloat(realElapseSeconds);
            ctx.Invoke();
        }

        public override void OnApplicationPause(bool pauseStatus)
        {
            if (m_OnApplicationPauseMethod == null)
                return;
            using var ctx = m_AppDomain.BeginInvoke(m_OnApplicationPauseMethod);
            ctx.PushObject(m_EntryInstance);
            ctx.PushBool(pauseStatus);
            ctx.Invoke();
        }

        public override void OnApplicationFocus(bool hasFocus)
        {
            if (m_OnApplicationFocusMethod == null)
                return;
            using var ctx = m_AppDomain.BeginInvoke(m_OnApplicationFocusMethod);
            ctx.PushObject(m_EntryInstance);
            ctx.PushBool(hasFocus);
            ctx.Invoke();
        }

        public override void OnApplicationQuit()
        {
            if (m_OnApplicationQuitMethod == null)
                return;
            using var ctx = m_AppDomain.BeginInvoke(m_OnApplicationQuitMethod);
            ctx.PushObject(m_EntryInstance);
            ctx.Invoke();
        }
    }
}
#endif
