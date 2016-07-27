﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售退货单 移除(Remove)事件
    /// 备注：当 销售退货单（SaleBack）在移除的时候，需要发布此事件
    /// 使用范围：销售退货单（SaleBack）移除操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleBack.03")]
    public class SaleBackRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        ///销售退货单 编号
        /// </summary>
        public string BackID { get; set; }
    }
}
