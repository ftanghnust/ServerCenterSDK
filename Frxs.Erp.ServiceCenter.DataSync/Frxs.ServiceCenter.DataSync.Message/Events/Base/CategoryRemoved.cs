/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 基本分类移除(Remove)事件
    /// 备注：在 基本分类（Category）中的使用
    /// 使用范围：基本分类（Category）移除 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Category.03")]
    public class CategoryRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 基本分类编号
        /// </summary>
        public int CategoryId { get; set; }
    }
}
