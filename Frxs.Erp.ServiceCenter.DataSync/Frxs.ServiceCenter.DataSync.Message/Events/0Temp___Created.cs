/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// Temp___ 创建(Created)事件
    /// </summary>
    [Serializable, EventGroup("")]
    public class Temp__Created : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 
        /// </summary>
        public int TempId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TempString { get; set; }
    }
}
