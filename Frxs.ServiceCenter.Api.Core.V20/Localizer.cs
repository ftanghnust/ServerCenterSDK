/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/12/28 21:44:40
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 语言包读取委托
    /// </summary>
    /// <param name="resourceKey">语言包键(key)</param>
    /// <param name="defaultValue">指定语言包键不存在，返回默认值</param>
    /// <returns>返回指定键的语言包</returns>
    public delegate string Localizer(string resourceKey, string defaultValue, params object[] args);
}
