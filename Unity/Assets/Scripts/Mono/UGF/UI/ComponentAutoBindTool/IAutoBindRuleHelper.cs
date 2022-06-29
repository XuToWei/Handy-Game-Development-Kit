using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自动绑定规则辅助器接口
/// </summary>
public interface IAutoBindRuleHelper
{
    /// <summary>
    /// 是否为有效绑定
    /// </summary>
    bool IsValidBind(string keyName,List<string> filedNames,List<string> componentTypeNames);
}
