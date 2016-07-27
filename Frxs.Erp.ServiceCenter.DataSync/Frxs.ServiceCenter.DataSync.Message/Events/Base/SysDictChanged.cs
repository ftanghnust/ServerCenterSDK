/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 数据字典 变更(Changed)事件
    /// 备注：在数据字典主表（SysDict）、数据字典明细表（SysDictDetail）中的使用
    /// 使用范围：数据字典（SysDict）编辑,数据字典明细表（SysDictDetail）增删改 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "SysDict.02")]
    public class SysDictChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 数据字典编码
        /// </summary>
        public string DictCode { get; set; }
    }
}
