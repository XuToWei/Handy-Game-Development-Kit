using UnityEngine;
using UGF;
using ProcedureOwner = Hotfix.Framework.IFsm<Hotfix.Framework.ProcedureManager>;

namespace Hotfix.Logic
{
    /// <summary>
    /// 等待断点进入下一流程
    /// </summary>
    public class ProcedureWaitForDebug : Framework.ProcedureBase
    {
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            ChangeState<ProcedurePreload>(procedureOwner);
        }
    }
}