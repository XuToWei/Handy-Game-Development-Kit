using GameEntry = UGF.GameEntry;
using ProcedureOwner = Hotfix.Framework.IFsm<Hotfix.Framework.ProcedureManager>;

namespace Hotfix.Logic
{
    public class ProcedureEnterGame : Framework.ProcedureBase
    {
        protected override async void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            
            await GameEntry.UI.OpenUIFormAsync(HotfixUIFormId.LoginForm);
            ChangeState<ProcedureGame>(procedureOwner);
        }
    }
}