/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 10:52:57 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 基本分类变更(Changed)事件
    /// 备注：在 基本分类（Category）中的使用
    /// 使用范围：基本分类（Category）编辑 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Category.02")]
    public class CategoryChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 基本分类编号
        /// </summary>
        public int CategoryId { get; set; }
    }
}