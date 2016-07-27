/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 品牌变更(Changed)事件
    /// 备注：在 品牌（BrandCategory）中的使用
    /// 使用范围：品牌（BrandCategory）编辑 操作中使用
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base", "BrandCategory.02")]
    public class BrandCategoryChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 品牌编号
        /// </summary>
        public int BrandId { get; set; }
    }
}
