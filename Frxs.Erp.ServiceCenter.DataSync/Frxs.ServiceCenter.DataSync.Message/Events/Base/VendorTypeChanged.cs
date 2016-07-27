/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 供应商类型变更(Changed)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "VendorType.02")]
    public class VendorTypeChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        ///  供应商类型编号
        /// </summary>
        public int VendorTypeID { get; set; }
    }
}
