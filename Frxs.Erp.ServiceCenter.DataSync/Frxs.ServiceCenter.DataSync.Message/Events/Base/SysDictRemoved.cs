/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 数据字典移除(Remove)事件
    /// 备注：在数据字典主表（SysDict）移除 数据的 同时 移除 相关数据字典明细（SysDictDetail）列表数据
    /// 使用范围：数据字典（SysDict）移除 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "SysDict.03")]
    public class SysDictRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 数据字典编码
        /// </summary>
        public string DictCode { get; set; }
    }
}
