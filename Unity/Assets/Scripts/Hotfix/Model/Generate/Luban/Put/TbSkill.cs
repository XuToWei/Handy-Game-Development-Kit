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
   
public partial class TbSkill
{
    private readonly Dictionary<int, Put.DRSkill> _dataMap;
    private readonly List<Put.DRSkill> _dataList;
    
    public TbSkill(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, Put.DRSkill>();
        _dataList = new List<Put.DRSkill>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Put.DRSkill _v;
            _v = Put.DRSkill.DeserializeDRSkill(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.ID, _v);
        }
        PostInit();
    }

    public Dictionary<int, Put.DRSkill> DataMap => _dataMap;
    public List<Put.DRSkill> DataList => _dataList;

    public Put.DRSkill GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Put.DRSkill Get(int key) => _dataMap[key];
    public Put.DRSkill this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        for(int i = 0 ; i < _dataList.Count ; i++)
        {
            _dataList[i].Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        for(int i = 0 ; i < _dataList.Count ; i++)
        {
            _dataList[i].TranslateText(translator);
        }
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}