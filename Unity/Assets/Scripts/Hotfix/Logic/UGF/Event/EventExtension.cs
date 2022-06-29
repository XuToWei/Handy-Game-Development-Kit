using Hotfix.Framework;

namespace Hotfix.Logic
{
    public static class EventExtension
    {
        public static void SafeFire(this EventManager eventManager, HotfixEventArgs eventArgs)
        {
            if (eventManager.Count(eventArgs.Id) > 0)
            {
                eventManager.Fire(null, eventArgs);
            }
        }
        
        public static void SafeFire(this EventManager eventManager, int eventId, object userData = null)
        {
            if (eventManager.Count(eventId) > 0)
            {
                eventManager.Fire(null, CommonEventArgs.Create(eventId, userData));
            }
        }
    }
}