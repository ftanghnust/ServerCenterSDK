/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品规格移除(Remove)事件
    /// 备注：在 规格（Attribute）中的使用
    /// 使用范围：规格（Attribute）移除操作中使用
    /// </summary>
    [Serializable, EventGroup("Base", "Attribute.03")]
    public class AttributeRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        ///商品规格编号
        /// </summary>
        public int AttributeId { get; set; }
    }
}
