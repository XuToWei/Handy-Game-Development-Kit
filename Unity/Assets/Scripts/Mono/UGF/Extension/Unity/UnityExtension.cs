using UnityEngine;
using UnityEngine.Events;

namespace UGF
{
    public static class UnityExtension
    {
        public static void Set(this UnityEvent unityEvent, UnityAction unityAction)
        {
            unityEvent.RemoveAllListeners();
            unityEvent.AddListener(unityAction);
        }

        public static void Set<T>(this UnityEvent<T> unityEvent, UnityAction<T> unityAction) where T : Object
        {
            unityEvent.RemoveAllListeners();
            unityEvent.AddListener(unityAction);
        }
    }
}