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
   
public partial class TbStaffLevelUp
{
    private readonly Dictionary<int, Put.DRStaffLevelUp> _dataMap;
    private readonly List<Put.DRStaffLevelUp> _dataList;
    
    public TbStaffLevelUp(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, Put.DRStaffLevelUp>();
        _dataList = new List<Put.DRStaffLevelUp>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Put.DRStaffLevelUp _v;
            _v = Put.DRStaffLevelUp.DeserializeDRStaffLevelUp(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Level, _v);
        }
        PostInit();
    }

    public Dictionary<int, Put.DRStaffLevelUp> DataMap => _dataMap;
    public List<Put.DRStaffLevelUp> DataList => _dataList;

    public Put.DRStaffLevelUp GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Put.DRStaffLevelUp Get(int key) => _dataMap[key];
    public Put.DRStaffLevelUp this[int key] => _dataMap[key];

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