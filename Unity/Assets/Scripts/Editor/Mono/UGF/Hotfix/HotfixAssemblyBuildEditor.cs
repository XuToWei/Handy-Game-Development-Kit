using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using GameFramework;
using GameFramework.Resource;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace UGF.Editor.Hotfix
{
    [InitializeOnLoad]
    public static class HotfixAssemblyBuildEditor
    {
        /// <summary>
        /// 最原始的程序集路径
        /// </summary>
        private static readonly string s_OriginDllPath = "Library/ScriptAssemblies/";

        private static string GetOriginDllFullPath(string fileName)
        {
            return Utility.Text.Format("{0}{1}", s_OriginDllPath, fileName);
        }

        static HotfixAssemblyBuildEditor()
        {
            foreach (var dllName in HotfixConfig.DllNames)
            {
                SyncHotfixDllPdb(dllName);
            }
        }

        private static void SyncHotfixDllPdb(string dllName)
        {
            string dllOriPath = GetOriginDllFullPath(Utility.Text.Format("{0}.dll", dllName));
            string dllDesPath = AssetUtility.GetHotfixDllAsset(dllName);
            string pdbOriPath = GetOriginDllFullPath(Utility.Text.Format("{0}.pdb", dllName));
            string pdbDesPath = AssetUtility.GetHotfixPdbAsset(dllName);

            if (File.Exists(dllOriPath))
            {
                File.Copy(dllOriPath, dllDesPath, true);
                AssetDatabase.ImportAsset(dllDesPath);
            }
            if (File.Exists(pdbOriPath))
            {
                File.Copy(pdbOriPath, pdbDesPath, true);
                AssetDatabase.ImportAsset(pdbDesPath);
            }
            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/Hotfix/Reload _R", false, 30)]
        public static void HotfixReload()
        {
            if (!EditorApplication.isPlaying)
            {
                Debug.LogError("Reload can only run when editor is playing!");
                return;
            }

            if (!GameEntry.Base.EditorResourceMode)
            {
                Debug.LogError("Reload can only use by EditorResourceMode!");
                return;
            }

            if (GameEntry.Hotfix.HotfixType != HotfixType.Mono)
            {
                Debug.LogError("Reload can only use by Game.MonoHelper!");
                return;
            }
            BuildHotfixAssembly("Hotfix.Framework2", GetScriptPaths("Assets/HotfixScripts/Framework/"));
            BuildHotfixAssembly("Hotfix.Logic2", GetScriptPaths("Assets/HotfixScripts/Logic/"));
            BuildHotfixAssembly("Hotfix.LogicView2", GetScriptPaths("Assets/HotfixScripts/LogicView/"));
            GameEntry.Hotfix.Reload();
            Debug.Log("Hotfix reload completed!");
        }

        private static string[] GetScriptPaths(string path)
        {
            List<string> scripts = new List<string>();
            DirectoryInfo dti = new DirectoryInfo(path);
            FileInfo[] fileInfos = dti.GetFiles("*.cs", SearchOption.AllDirectories);
            foreach (var t in fileInfos)
            {
                scripts.Add(t.FullName);
            }

            return scripts.ToArray();
        }

        private static void BuildHotfixAssembly(string dllName, string[] scripts)
        {
            if (scripts == null || scripts.Length < 1)
            {
                return;
            }
            string dllFullName = Utility.Text.Format("Temp/{0}.dll", dllName);
            if (File.Exists(dllFullName))
            {
                File.Delete(dllFullName);
            }
            AssemblyBuilder assemblyBuilder = new AssemblyBuilder(dllFullName, scripts);
            assemblyBuilder.buildStarted += Debug.Log;
            assemblyBuilder.buildFinished += (s, messages) =>
            {
                foreach (CompilerMessage message in messages)
                {
                    if (message.type == CompilerMessageType.Error)
                    {
                        Debug.LogError(message.message);
                    }
                    else if (message.type == CompilerMessageType.Warning)
                    {
                        Debug.LogWarning(message.message);
                    }
                    else if (message.type == CompilerMessageType.Info)
                    {
                        Debug.Log(message.message);
                    }
                }
            };
            if (assemblyBuilder.Build())
            {
                while (EditorApplication.isCompiling)
                {
                    // 主线程sleep并不影响编译线程
                    Thread.Sleep(20);
                }
                string dllDesFullName = AssetUtility.GetHotfixDllAsset(dllName);
                File.Copy(dllFullName, dllDesFullName, true);
                File.Delete(dllFullName);
                AssetDatabase.ImportAsset(dllDesFullName);
                AssetDatabase.Refresh();
                Debug.LogFormat("{0} build success!", dllName);
            }
            else
            {
                Debug.LogErrorFormat("Build {0} Error!", dllName);
            }
        }
    }
}