﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 销售退货单 变更(Changed)事件
    /// 备注：当销售退货单（SaleBack）在变更的时候（同步所有关联数据SaleBackDetails、SaleBackDetailsExt），需要发布此事件
    /// 使用范围：销售退货单（SaleBack）变更、销售退货单明细（SaleBackDetails）增删改、销售退货单扩展（SaleBackDetailsExt）增删改操作中使用
    /// </summary>
    [Serializable, EventGroup("Order", "SaleBack.02")]
    public class SaleBackChanged : MessageBodyBase, IEvent
    {
        /// <summary>
        ///销售退货单 编号 
        /// </summary>
        public string BackID { get; set; }
    }
}