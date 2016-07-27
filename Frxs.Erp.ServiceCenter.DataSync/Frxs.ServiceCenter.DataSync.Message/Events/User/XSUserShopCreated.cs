/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 兴盛客户门店关系 创建(Created)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("User", "XsUserShop.01")]
    public class XsUserShopCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 兴盛客户门店关系 编号
        /// </summary>
        public int ID { get; set; }
    }
}
