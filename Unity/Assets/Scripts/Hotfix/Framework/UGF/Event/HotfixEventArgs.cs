namespace Hotfix.Framework
{
    public abstract class HotfixEventArgs : IReference
    {
        public abstract int Id { get; }
        public abstract void Clear();
    }
}
