using GameFramework.Fsm;
using GameFramework.Procedure;

namespace UGF
{
    public class ProcedureLoadHotfix : ProcedureBase
    {
        private bool m_IsLoaded;
        
        protected override async void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_IsLoaded = false;
            await GameEntry.Hotfix.Load();
            GameEntry.Hotfix.Init();
            m_IsLoaded = true;
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_IsLoaded)
            {
                ChangeState<ProcedureHotfix>(procedureOwner);
            }
        }
    }
}
