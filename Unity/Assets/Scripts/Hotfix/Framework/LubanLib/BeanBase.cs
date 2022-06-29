using Hotfix.Bright.Serialization;

namespace Hotfix.Bright.Config
{
    public abstract class BeanBase : ITypeId
    {
        public abstract int GetTypeId();
    }
}
