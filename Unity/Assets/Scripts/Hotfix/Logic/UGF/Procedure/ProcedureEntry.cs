using UnityEngine;
using ProcedureOwner = Hotfix.Framework.IFsm<Hotfix.Framework.ProcedureManager>;

namespace Hotfix.Logic
{
    public class ProcedureEntry : Framework.ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            // 编辑器下进入断点调试等待流程
            if (Application.platform == RuntimePlatform.WindowsEditor
                || Application.platform == RuntimePlatform.OSXEditor
                || Application.platform == RuntimePlatform.LinuxEditor)
            {
                //ChangeState<ProcedureWaitForDebug>(procedureOwner);
                ChangeState<ProcedurePreload>(procedureOwner);
            }
            else
            {
                ChangeState<ProcedurePreload>(procedureOwner);
            }
        }
    }
}