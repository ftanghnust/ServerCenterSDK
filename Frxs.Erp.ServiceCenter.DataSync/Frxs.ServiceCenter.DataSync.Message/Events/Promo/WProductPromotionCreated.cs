/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库商品促销 创建(Created)事件
    /// 备注：当 仓库商品促销 (WProductPromotion)在创建的时候（同步WProductPromotionDetails列表、WProductPromotionShops列表），需要发布此事件
    /// 使用范围：仓库商品促销（WProductPromotion）创建操作中使用
    /// </summary>
    [Serializable, EventGroup("Promo", "WProductPromotion.01")]
    public class WProductPromotionCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库商品促销 编号
        /// </summary>
        public string PromotionID { get; set; }
    }
}
