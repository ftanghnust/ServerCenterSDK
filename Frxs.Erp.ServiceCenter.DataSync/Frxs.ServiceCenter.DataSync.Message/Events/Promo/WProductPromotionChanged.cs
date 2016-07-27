/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库商品促销 变更(Changed)事件
    /// 备注：在 仓库商品促销主表（WProductPromotion）变更 的时候（同步WProductPromotionDetails列表、WProductPromotionShops列表），需要发布此事件
    /// 使用范围：仓库商品促销主表（WProductPromotion）编辑,仓库商品促销信息（WProductPromotionDetails）列表增删改、
    /// 促销门店信息（WProductPromotionShops）列表增删改 操作中使用
    /// </summary>
    [Serializable, EventGroup("Promo", "WProductPromotion.02")]
    public class WProductPromotionChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库商品促销 编号
        /// </summary>
        public string PromotionID { get; set; }
    }
}
