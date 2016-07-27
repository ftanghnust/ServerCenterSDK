/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 供应商类型移除(Remove)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "VendorType.03")]
    public class VendorTypeRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        ///  供应商类型编号
        /// </summary>
        public int VendorTypeID { get; set; }
    }
}
