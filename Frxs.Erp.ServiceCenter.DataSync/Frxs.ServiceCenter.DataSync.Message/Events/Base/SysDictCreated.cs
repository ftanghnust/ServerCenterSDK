/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 数据字典创建(Created)事件
    /// 备注：在数据字典主表（SysDict）中的使用，同时同步 相关数据字典明细（SysDictDetail）列表数据
    /// 使用范围：数据字典（SysDict）创建 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "SysDict.01")]
    public class SysDictCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 数据字典编码
        /// </summary>
        public string DictCode { get; set; }
    }
}
