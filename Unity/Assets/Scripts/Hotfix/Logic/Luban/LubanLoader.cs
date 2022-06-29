using System;
using System.Reflection;
using System.Threading.Tasks;
using Hotfix.Bright.Serialization;
using UGF;
using Hotfix.Model;
using Hotfix.SimpleJSON;
using UnityEngine;

namespace Hotfix.Logic
{
    public static class LubanLoader
    {
        public static async Task LoadHotfixLuban()
        {
            Type tablesType = typeof(Model.Tables);

            MethodInfo loadMethodInfo = tablesType.GetMethod("LoadAsync");
            
            Type loaderReturnType = loadMethodInfo.GetParameters()[0].ParameterType.GetGenericArguments()[1];
            
            Debug.Log($"{tablesType} : {loadMethodInfo} -- {loaderReturnType}");
            
            object tables = Activator.CreateInstance(tablesType);

            //HotfixEntry.Tables = (tables as Hotfix.Model.Tables);
            
            // 根据cfg.Tables的构造函数的Loader的返回值类型决定使用json还是ByteBuf Loader
            if (loaderReturnType == typeof(Task<ByteBuf>))
            {
                async Task<ByteBuf> LoadByteBuf(string file)
                {
                    TextAsset textAsset = await GameEntry.Resource.LoadAssetAsync<TextAsset>(AssetUtility.GetHotfixLubanAsset(file, true));
                    return new ByteBuf(textAsset.bytes);
                }
                Func<string, Task<ByteBuf>> func = LoadByteBuf;
                await (Task)loadMethodInfo.Invoke(tables, new object[] { func });
            }
            else
            {
                async Task<JSONNode> LoadJson(string file)
                {
                    TextAsset textAsset = await GameEntry.Resource.LoadAssetAsync<TextAsset>(AssetUtility.GetHotfixLubanAsset(file, false));
                    return JSON.Parse(textAsset.text);
                }
                Func<string, Task<JSONNode>> func = LoadJson;
                await (Task)loadMethodInfo.Invoke(tables, new object[] { func });
            }
        }
    }
}