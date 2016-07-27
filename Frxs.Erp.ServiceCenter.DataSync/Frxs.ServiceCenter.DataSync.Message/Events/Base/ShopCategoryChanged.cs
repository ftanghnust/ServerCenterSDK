/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 运营分类变更(Changed)事件
    /// 备注：在  运营分类（ShopCategory）中的使用
    /// 使用范围：运营分类（ShopCategory）编辑 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "ShopCategory.01")]
    public class ShopCategoryChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        ///  运营分类编号
        /// </summary>
        public int CategoryId { get; set; }
    }
}
