/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 仓库商品促销 移除(Remove)事件
    /// 备注：当 仓库商品促销（WProductPromotion）在移除的时候，需要发布此事件
    /// 使用范围：仓库商品促销（WProductPromotion）移除操作中使用 
    /// </summary>
    [Serializable, EventGroup("Promo", "WProductPromotion.03")]
    public class WProductPromotionRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 仓库商品促销 编号
        /// </summary>
        public string PromotionID { get; set; }

    }
}
