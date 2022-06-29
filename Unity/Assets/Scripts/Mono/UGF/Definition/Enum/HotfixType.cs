namespace UGF
{
    public enum HotfixType : byte
    {
        Undefined = 0,
        
        /// <summary>
        /// Mono
        /// </summary>
        Mono = 1,
        
        /// <summary>
        /// ILRuntime
        /// </summary>
        ILRuntime = 2,
    }
}