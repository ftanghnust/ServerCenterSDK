/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品规格变更(Changed)事件
    /// 备注：在规格（Attribute）、规格值（AttributeValue）中的使用
    /// 使用范围：规格（Attribute）编辑,规格值（AttributeValue）增删改 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Attribute.02"), EventArgsType(typeof(AttributeChanged))]
    public class AttributeChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 商品规格编号
        /// </summary>
        public int AttributeId { get; set; }
    }
}
