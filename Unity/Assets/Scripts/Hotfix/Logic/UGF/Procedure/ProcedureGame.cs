using Hotfix.Framework;
using ProcedureOwner = Hotfix.Framework.IFsm<Hotfix.Framework.ProcedureManager>;

namespace Hotfix.Logic
{
    public class ProcedureGame : Framework.ProcedureBase
    {
        private const int SettingSaveInterval = 120;//秒
        private float m_SettingSaveTime = SettingSaveInterval;
        
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            UpdateGameManager(elapseSeconds);
            UpdateSaveSetting(realElapseSeconds);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            if (!isShutdown)
            {
                
            }
            base.OnLeave(procedureOwner, isShutdown);
        }

        private void UpdateGameManager(float elapseSeconds)
        {
            
        }

        private void UpdateSaveSetting(float elapseSeconds)
        {
            m_SettingSaveTime -= elapseSeconds;
            if (m_SettingSaveTime <= 0)
            {
                m_SettingSaveTime = SettingSaveInterval;
                
            }
        }

        private void OnSettingSave(object sender, HotfixEventArgs eventArgs)
        {
            m_SettingSaveTime = SettingSaveInterval;
        }
    }
}