/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     .NET CLR Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/27 10:41:11.963
 * **************************************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs
{
    /// <summary>
    /// 数据字典移除(Remove)事件
    /// 备注：在数据字典主表（SysDict）移除 数据的 同时 移除 相关数据字典明细（SysDictDetail）列表数据
    /// 使用范围：数据字典（SysDict）移除 操作中使用
    /// </summary>
    [Serializable]
    public class SysDictRemovedEventAgrs : EventArgsBase
    {
        /// <summary>
        /// 数据字典编码
        /// </summary>
        public string DictCode { get; set; }
    }
}
