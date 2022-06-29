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

public sealed partial class DRItem :  Bright.Config.BeanBase 
{
    public DRItem(ByteBuf _buf) 
    {
        ID = _buf.ReadInt();
        Name = _buf.ReadString();
        Volume = _buf.ReadFloat();
        Weight = _buf.ReadInt();
        Cost = _buf.ReadInt();
        Price = _buf.ReadInt();
        Type = _buf.ReadInt();
        NeedSkill = _buf.ReadInt();
        Icon = _buf.ReadString();
        PostInit();
    }

    public static DRItem DeserializeDRItem(ByteBuf _buf)
    {
        return new Put.DRItem(_buf);
    }

    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; private set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 体积
    /// </summary>
    public float Volume { get; private set; }
    /// <summary>
    /// 重量
    /// </summary>
    public int Weight { get; private set; }
    /// <summary>
    /// 处理费用
    /// </summary>
    public int Cost { get; private set; }
    /// <summary>
    /// 回收价格
    /// </summary>
    public int Price { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public int Type { get; private set; }
    /// <summary>
    /// 需要技能
    /// </summary>
    public int NeedSkill { get; private set; }
    /// <summary>
    /// 道具图标
    /// </summary>
    public string Icon { get; private set; }

    public const int __ID__ = 642846880;
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
        + "ID:" + ID + ","
        + "Name:" + Name + ","
        + "Volume:" + Volume + ","
        + "Weight:" + Weight + ","
        + "Cost:" + Cost + ","
        + "Price:" + Price + ","
        + "Type:" + Type + ","
        + "NeedSkill:" + NeedSkill + ","
        + "Icon:" + Icon + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}