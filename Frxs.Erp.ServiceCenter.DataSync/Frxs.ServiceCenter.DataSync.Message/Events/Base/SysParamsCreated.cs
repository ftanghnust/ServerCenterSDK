/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 系统参数创建(Created)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "SysParams.01")]
    public class SysParamsCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 系统参数编码
        /// </summary>
        public string ParamCode { get; set; }
    }
}
