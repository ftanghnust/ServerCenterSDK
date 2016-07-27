/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    ///  兴盛客户门店关系 变更(Changed)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("User", "XsUserShop.02")]
    public class XsUserShopChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 兴盛客户门店关系 编号
        /// </summary>
        public int ID { get; set; }
    }
}
