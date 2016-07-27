/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 供应商变更(Changed)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Vendor.02")]
    public class VendorChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public int VendorID { get; set; }

    }
}
