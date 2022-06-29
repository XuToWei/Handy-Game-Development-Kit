using System;
using System.Threading;
using ET;
using UnityEngine;

namespace UGF
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        private void Awake()
        {
            System.AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Debug.LogError(e.ExceptionObject.ToString());
            };
            //SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
            ETTask.ExceptionHandler += delegate(Exception exception)
            {
                Debug.LogError(exception.ToString());
            };
        }

        private void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();
        }
    }
}