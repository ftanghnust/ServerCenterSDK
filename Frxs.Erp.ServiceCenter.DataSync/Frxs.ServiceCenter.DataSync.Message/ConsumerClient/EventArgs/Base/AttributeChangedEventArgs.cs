/* ***************************************************************************
 * <auto-generated>
 *     This code was generated by a tool.
 *     .NET CLR Runtime Version:4.0.30319.42000
 *     Changes to this file may cause incorrect behavior and will be lost if
 *     the code is regenerated.
 * </auto-generated>
 * ***************************************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/07/27 10:41:11.931
 * **************************************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient.EventArgs
{
    /// <summary>
    /// 商品规格变更(Changed)事件
    /// 备注：在规格（Attribute）、规格值（AttributeValue）中的使用
    /// 使用范围：规格（Attribute）编辑,规格值（AttributeValue）增删改 操作中使用
    /// </summary>
    [Serializable]
    public class AttributeChangedEventAgrs : EventArgsBase
    {
        /// <summary>
        /// 商品规格编号
        /// </summary>
        public int AttributeId { get; set; }
    }
}
