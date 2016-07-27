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
    /// 商品主图 创建(Created)事件消息体
    /// </summary>
    [Serializable, GlobalEventMessage]
    public class ProductPictureDetailCreatedMessageBody : MessageBodyBase
    {
        /// <summary>
        /// 商品主图编号
        /// </summary>
        public int ID { get; set; }

    }
}
