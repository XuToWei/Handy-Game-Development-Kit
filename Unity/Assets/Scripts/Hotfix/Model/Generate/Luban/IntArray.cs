//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Hotfix.Bright.Serialization;
using System.Collections.Generic;



namespace Hotfix.Model
{

public sealed partial class IntArray :  Bright.Config.BeanBase 
{
    public IntArray(ByteBuf _buf) 
    {
        {int n = System.Math.Min(_buf.ReadSize(), _buf.Size);Ints = new System.Collections.Generic.List<int>(n);for(var i = 0 ; i < n ; i++) { int _e;  _e = _buf.ReadInt(); Ints.Add(_e);}}
        PostInit();
    }

    public static IntArray DeserializeIntArray(ByteBuf _buf)
    {
        return new IntArray(_buf);
    }

    public System.Collections.Generic.List<int> Ints { get; private set; }

    public const int __ID__ = 601811914;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Ints:" + Bright.Common.StringUtil.CollectionToString(Ints) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}