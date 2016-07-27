/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 系统仓库参数 创建(Created)事件
    /// </summary>
    [Serializable, EventGroup("Base", "SysParamsWh.01")]
    public class SysParamsWhCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 系统仓库参数编号
        /// </summary>
        public int ID { get; set; }

    }
}
