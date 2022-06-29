//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Hotfix.Bright.Serialization;
using System.Collections.Generic;



namespace Hotfix.Model.SanXiao
{

public sealed partial class DRSanXiaoLevel :  Bright.Config.BeanBase 
{
    public DRSanXiaoLevel(ByteBuf _buf) 
    {
        ID = _buf.ReadInt();
        Name = _buf.ReadString();
        MapAssetName = _buf.ReadString();
        Theme = _buf.ReadInt();
        {int n = System.Math.Min(_buf.ReadSize(), _buf.Size);RobotCat = new System.Collections.Generic.List<int>(n);for(var i = 0 ; i < n ; i++) { int _e;  _e = _buf.ReadInt(); RobotCat.Add(_e);}}
        {int n = System.Math.Min(_buf.ReadSize(), _buf.Size);RandomGroup = new System.Collections.Generic.List<Int2>(n);for(var i = 0 ; i < n ; i++) { Int2 _e;  _e = Int2.DeserializeInt2(_buf); RandomGroup.Add(_e);}}
        {int n = System.Math.Min(_buf.ReadSize(), _buf.Size);Global = new System.Collections.Generic.List<int>(n);for(var i = 0 ; i < n ; i++) { int _e;  _e = _buf.ReadInt(); Global.Add(_e);}}
        {int n = System.Math.Min(_buf.ReadSize(), _buf.Size);CloDict = new System.Collections.Generic.Dictionary<int, IntArray>(n * 3 / 2);for(var i = 0 ; i < n ; i++) { int _k;  _k = _buf.ReadInt(); IntArray _v;  _v = IntArray.DeserializeIntArray(_buf);     CloDict.Add(_k, _v);}}
        PostInit();
    }

    public static DRSanXiaoLevel DeserializeDRSanXiaoLevel(ByteBuf _buf)
    {
        return new SanXiao.DRSanXiaoLevel(_buf);
    }

    /// <summary>
    /// 关卡ID
    /// </summary>
    public int ID { get; private set; }
    /// <summary>
    /// 关卡名称
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 地图资源名
    /// </summary>
    public string MapAssetName { get; private set; }
    /// <summary>
    /// 关卡主题包
    /// </summary>
    public int Theme { get; private set; }
    /// <summary>
    /// 守关机器人
    /// </summary>
    public System.Collections.Generic.List<int> RobotCat { get; private set; }
    /// <summary>
    /// 全局随机配置
    /// </summary>
    public System.Collections.Generic.List<Int2> RandomGroup { get; private set; }
    /// <summary>
    /// 全局块配置
    /// </summary>
    public System.Collections.Generic.List<int> Global { get; private set; }
    public System.Collections.Generic.Dictionary<int, IntArray> CloDict { get; private set; }

    public const int __ID__ = 1726126754;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var _e in RandomGroup) { _e?.Resolve(_tables); }
        foreach(var _e in CloDict.Values) { _e?.Resolve(_tables); }
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var _e in RandomGroup) { _e?.TranslateText(translator); }
        foreach(var _e in CloDict.Values) { _e?.TranslateText(translator); }
    }

    public override string ToString()
    {
        return "{ "
        + "ID:" + ID + ","
        + "Name:" + Name + ","
        + "MapAssetName:" + MapAssetName + ","
        + "Theme:" + Theme + ","
        + "RobotCat:" + Bright.Common.StringUtil.CollectionToString(RobotCat) + ","
        + "RandomGroup:" + Bright.Common.StringUtil.CollectionToString(RandomGroup) + ","
        + "Global:" + Bright.Common.StringUtil.CollectionToString(Global) + ","
        + "CloDict:" + Bright.Common.StringUtil.CollectionToString(CloDict) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}
