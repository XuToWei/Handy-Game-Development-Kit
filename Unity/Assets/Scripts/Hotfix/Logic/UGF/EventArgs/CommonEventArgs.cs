using Hotfix.Framework;

namespace Hotfix.Logic
{
    public class CommonEventArgs : HotfixEventArgs
    {
        public int EventId
        {
            get;
            private set;
        }
        public override int Id => EventId;

        public object UserData
        {
            get;
            private set;
        }
        public override void Clear()
        {
            EventId = default;
            UserData = default;
        }

        public static CommonEventArgs Create(int eventId, object userData = null)
        {
            CommonEventArgs eventArgs = ReferencePool.Acquire<CommonEventArgs>();
            eventArgs.EventId = eventId;
            eventArgs.UserData = userData;
            return eventArgs;
        }
    }
}
