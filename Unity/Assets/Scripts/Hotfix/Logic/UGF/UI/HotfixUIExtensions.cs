using System.Threading.Tasks;
using UGF;
using UnityGameFramework.Runtime;

namespace Hotfix.Logic
{
    public static class HotfixUIExtensions
    {
        /// <summary>
        /// 打开界面
        /// </summary>
        public static int? OpenUIForm(this UIComponent uiComponent, HotfixUIFormId uiFormId, object userData = null)
        {
            return uiComponent.OpenUIForm((int) uiFormId, userData);
        }
        
        /// <summary>
        /// 打开界面（可等待）
        /// </summary>
        public static Task<UIForm> OpenUIFormAsync(this UIComponent uiComponent, HotfixUIFormId uiFormId, object userData = null)
        {
            return uiComponent.OpenUIFormAsync((int) uiFormId, userData);
        }
        
        public static void CloseUIForm(this UIComponent uiComponent, HotfixUIFormId uiFormId)
        {
            UGuiForm uiForm = uiComponent.GetUIForm((int)uiFormId, null);
            if (uiForm != null)
            {
                uiComponent.CloseUIForm(uiForm); 
            }
        }
    }
}