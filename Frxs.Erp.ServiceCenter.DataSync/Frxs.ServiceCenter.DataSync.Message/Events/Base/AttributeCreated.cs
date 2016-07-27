/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品规格创建(Created)事件
    /// 备注：在规格（Attribute）中的使用
    /// 使用范围：规格（Attribute）新增操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Attribute.01")]
    public class AttributeCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 商品规格编号
        /// </summary>
        public int AttributeId { get; set; }
    }
}
