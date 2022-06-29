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

public sealed partial class DRTask :  Bright.Config.BeanBase 
{
    public DRTask(ByteBuf _buf) 
    {
        ID = _buf.ReadInt();
        TaskType = _buf.ReadInt();
        Name = _buf.ReadString();
        Desc = _buf.ReadString();
        Condition = _buf.ReadString();
        Finish = _buf.ReadString();
        Reward = _buf.ReadString();
        Event = _buf.ReadString();
        PostInit();
    }

    public static DRTask DeserializeDRTask(ByteBuf _buf)
    {
        return new Put.DRTask(_buf);
    }

    /// <summary>
    /// 任务ID
    /// </summary>
    public int ID { get; private set; }
    /// <summary>
    /// 任务类型
    /// </summary>
    public int TaskType { get; private set; }
    /// <summary>
    /// 任务名称
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 任务描述信息
    /// </summary>
    public string Desc { get; private set; }
    /// <summary>
    /// 任务开启条件
    /// </summary>
    public string Condition { get; private set; }
    /// <summary>
    /// 任务完成条件
    /// </summary>
    public string Finish { get; private set; }
    /// <summary>
    /// 任务奖励
    /// </summary>
    public string Reward { get; private set; }
    /// <summary>
    /// 奖励事件
    /// </summary>
    public string Event { get; private set; }

    public const int __ID__ = 643156754;
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
        + "TaskType:" + TaskType + ","
        + "Name:" + Name + ","
        + "Desc:" + Desc + ","
        + "Condition:" + Condition + ","
        + "Finish:" + Finish + ","
        + "Reward:" + Reward + ","
        + "Event:" + Event + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}
