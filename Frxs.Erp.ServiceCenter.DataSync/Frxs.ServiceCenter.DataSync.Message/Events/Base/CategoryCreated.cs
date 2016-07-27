/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 10:52:57 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 基本分类创建(Created)事件
    /// 备注：当基本分类在创建的时候，需要发布此事件
    /// 使用范围：基本分类（Category）创建 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "Category.01"), EventDegree(Degree.High)]
    public class CategoryCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 基本分类编号
        /// </summary>
        public int CategoryId { get; set; }
    }
}