/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 品牌创建(Created)事件
    /// 备注：在 品牌（BrandCategory）中的使用
    /// 使用范围：品牌（BrandCategory）创建 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "BrandCategory.01")]
    public class BrandCategoryCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        public int BrandId { get; set; }
    }
}
