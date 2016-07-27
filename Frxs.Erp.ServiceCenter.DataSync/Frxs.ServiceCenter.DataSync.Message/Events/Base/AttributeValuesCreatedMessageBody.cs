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
    /// 规格属性值 创建(Created)事件消息体
    /// </summary>
    [Serializable,GlobalEventMessage]
    public class AttributeValuesCreatedMessageBody : MessageBodyBase
    {
        /// <summary>
        /// 规格属性值编号
        /// </summary>
        public int ValuesId { get; set; }
    }
}
