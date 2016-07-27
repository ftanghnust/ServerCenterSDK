/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 系统仓库参数 移除(Remove)事件
    /// </summary>
    [Serializable, EventGroup("Base","SysParamsWh.03")]
    public class SysParamsWhRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 系统仓库参数编号
        /// </summary>
        public int ID { get; set; }

    }
}
