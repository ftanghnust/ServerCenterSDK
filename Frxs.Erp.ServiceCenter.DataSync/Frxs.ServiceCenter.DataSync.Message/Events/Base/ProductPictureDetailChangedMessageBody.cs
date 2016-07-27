/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品主图 变更(Changed)事件消息体
    /// </summary>
    [Serializable, GlobalEventMessage]
    public class ProductPictureDetailChangedMessageBody : MessageBodyBase
    {
        /// <summary>
        ///商品主图编号
        /// </summary>
        public int ID { get; set; }


    }
}
