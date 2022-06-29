#if ILRuntime
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UGF.Editor
{
    [System.Reflection.Obfuscation(Exclude = true)]
    public static class ILRuntimeCLRBinding
    {
        [MenuItem("Tools/ILRuntime/Generate CLR Binding By Analysis")]
        public static void GenerateCLRBindingByAnalysis()
        {
            //用新的分析热更dll调用引用来生成绑定代码
            ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
            foreach (var dllName in HotfixConfig.DllNames)
            {
                using System.IO.FileStream fs = new System.IO.FileStream(AssetUtility.GetHotfixDllAsset(dllName), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                domain.LoadAssembly(fs);
                ILRuntimeUtility.RegisterCrossBindingAdaptor(domain);
                ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, "Assets/Scripts/Game/Generate/ILRuntime/");
            }
            
            AssetDatabase.Refresh();
            Debug.Log("生成CLR绑定文件完成");
        }
        
        [MenuItem("Tools/ILRuntime/生成跨域继承适配器")]
        private static void GenerateCrossbindAdapter()
        {
            //由于跨域继承特殊性太多，自动生成无法实现完全无副作用生成，所以这里提供的代码自动生成主要是给大家生成个初始模版，简化大家的工作
            //大多数情况直接使用自动生成的模版即可，如果遇到问题可以手动去修改生成后的文件，因此这里需要大家自行处理是否覆盖的问题
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Assets/Scripts/Game/ILRuntime/Adaptor/KeyValuePairAdaptor.cs"))
            {
                sw.WriteLine(ILRuntime.Runtime.Enviorment.CrossBindingCodeGenerator.GenerateCrossBindingAdapterCode(
                    typeof (KeyValuePair<string,System.Object>), "Game"));
            }

            AssetDatabase.Refresh();

            Debug.Log("生成适配器完成");
        }
    }
}
#endif
