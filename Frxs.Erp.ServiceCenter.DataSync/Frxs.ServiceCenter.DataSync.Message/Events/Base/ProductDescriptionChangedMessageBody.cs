/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    ///  母商品文字描述(图文详情之文字详情)  变更(Changed)事件消息体
    /// </summary>
    [Serializable, GlobalEventMessage]
    public class ProductDescriptionChangedMessageBody : MessageBodyBase
    {
        /// <summary>
        /// 母商品 编号
        /// </summary>
        public int BaseProductId { get; set; }
    }
}
