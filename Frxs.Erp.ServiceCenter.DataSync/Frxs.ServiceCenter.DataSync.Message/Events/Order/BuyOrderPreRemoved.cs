﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 预采购收货单移除(Remove)事件
    /// 备注：当预采购收货单（BuyOrderPre）在移除的时候，需要发布此事件
    /// 使用范围：预采购收货单（BuyOrderPre）移除操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "BuyOrderPre.03")]
    public class BuyOrderPreRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 预采购收货单编号
        /// </summary>
        public string BuyID { get; set; }
    }
}
