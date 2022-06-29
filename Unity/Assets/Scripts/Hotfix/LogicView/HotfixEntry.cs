using Hotfix.Framework;
using Hotfix.Model;

namespace Hotfix.Logic
{
    public partial class HotfixEntry
    {
        /// <summary>
        /// 获取事件组件。
        /// </summary>
        public static EventManager Event { get; private set; }
        
        /// <summary>
        /// 获取有限状态机组件。
        /// </summary>
        public static FsmManager Fsm { get; private set; }
        
        /// <summary>
        /// 获取流程组件。
        /// </summary>
        public static ProcedureManager Procedure { get; private set; }
        
        public static Tables Tables { get; set; }

        public void OnEnter()
        {
            Event = new EventManager();
            Fsm = new FsmManager();
            Procedure = new ProcedureManager();
            
            Procedure.Initialize(Fsm,
                new ProcedurePreload(),
                new ProcedureEnterGame(),
                new ProcedureGame());
            
            Procedure.StartProcedure<ProcedurePreload>();
        }

        public void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            Event.Update(elapseSeconds, realElapseSeconds);
            Fsm.Update(elapseSeconds, realElapseSeconds);
            Procedure.Update(elapseSeconds, realElapseSeconds);
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            
        }
        
        public void OnApplicationFocus(bool hasFocus)
        {
            
        }

        public void OnApplicationQuit()
        {
           
        }

        public void OnShutDown()
        {
            Event.Shutdown();
            Fsm.Shutdown();
            Procedure.Shutdown();
        }
    }
}
