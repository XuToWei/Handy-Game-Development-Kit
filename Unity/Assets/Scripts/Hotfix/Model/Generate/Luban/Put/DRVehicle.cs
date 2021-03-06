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

public sealed partial class DRVehicle :  Bright.Config.BeanBase 
{
    public DRVehicle(ByteBuf _buf) 
    {
        ID = _buf.ReadInt();
        Quality = _buf.ReadInt();
        Speed = _buf.ReadFloat();
        Volume = _buf.ReadInt();
        Weight = _buf.ReadInt();
        AssetName = _buf.ReadString();
        PostInit();
    }

    public static DRVehicle DeserializeDRVehicle(ByteBuf _buf)
    {
        return new Put.DRVehicle(_buf);
    }

    /// <summary>
    /// 技能ID
    /// </summary>
    public int ID { get; private set; }
    /// <summary>
    /// 载具品级
    /// </summary>
    public int Quality { get; private set; }
    /// <summary>
    /// 移动速度加成
    /// </summary>
    public float Speed { get; private set; }
    /// <summary>
    /// 装置体积
    /// </summary>
    public int Volume { get; private set; }
    /// <summary>
    /// 装载重量
    /// </summary>
    public int Weight { get; private set; }
    /// <summary>
    /// 模型
    /// </summary>
    public string AssetName { get; private set; }

    public const int __ID__ = -1981812097;
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
        + "Quality:" + Quality + ","
        + "Speed:" + Speed + ","
        + "Volume:" + Volume + ","
        + "Weight:" + Weight + ","
        + "AssetName:" + AssetName + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}
