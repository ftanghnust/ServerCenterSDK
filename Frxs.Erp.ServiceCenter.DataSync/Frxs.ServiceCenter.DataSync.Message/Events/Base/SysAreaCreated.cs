/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 系统区域创建(Created)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "SysArea.01")]
    public class SysAreaCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 系统区域编号
        /// </summary>
        public int AreaID { get; set; }
    }
}
