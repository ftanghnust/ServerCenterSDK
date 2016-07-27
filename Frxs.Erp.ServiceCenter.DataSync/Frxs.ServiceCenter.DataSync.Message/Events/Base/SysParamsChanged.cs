/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 系统参数变更(Changed)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "SysParams.02")]
    public class SysParamsChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 系统参数编码
        /// </summary>
        public string ParamCode { get; set; }
    }
}
