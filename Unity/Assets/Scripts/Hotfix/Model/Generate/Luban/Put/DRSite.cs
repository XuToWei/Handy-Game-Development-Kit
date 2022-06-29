//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Hotfix.Bright.Serialization;
using System.Collections.Generic;



namespace Hotfix.Model.Put
{

public sealed partial class DRSite :  Bright.Config.BeanBase 
{
    public DRSite(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        UpgradePrice = _buf.ReadDouble();
        AddEmployee = _buf.ReadInt();
        BuildingCount = _buf.ReadInt();
        CapitalGenerating = _buf.ReadFloat();
        CapitalExtract = _buf.ReadFloat();
        BuildingEffect = _buf.ReadInt();
        PostInit();
    }

    public static DRSite DeserializeDRSite(ByteBuf _buf)
    {
        return new Put.DRSite(_buf);
    }

    /// <summary>
    /// 站点等级
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 升级消耗站点资金
    /// </summary>
    public double UpgradePrice { get; private set; }
    /// <summary>
    /// 员工
    /// </summary>
    public int AddEmployee { get; private set; }
    /// <summary>
    /// 业务规模<br/>（解锁几个建筑）
    /// </summary>
    public int BuildingCount { get; private set; }
    /// <summary>
    /// 资金产生规模
    /// </summary>
    public float CapitalGenerating { get; private set; }
    /// <summary>
    /// 资金提取规模
    /// </summary>
    public float CapitalExtract { get; private set; }
    /// <summary>
    /// 对建筑影响
    /// </summary>
    public int BuildingEffect { get; private set; }

    public const int __ID__ = 643134676;
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
        + "Id:" + Id + ","
        + "UpgradePrice:" + UpgradePrice + ","
        + "AddEmployee:" + AddEmployee + ","
        + "BuildingCount:" + BuildingCount + ","
        + "CapitalGenerating:" + CapitalGenerating + ","
        + "CapitalExtract:" + CapitalExtract + ","
        + "BuildingEffect:" + BuildingEffect + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}