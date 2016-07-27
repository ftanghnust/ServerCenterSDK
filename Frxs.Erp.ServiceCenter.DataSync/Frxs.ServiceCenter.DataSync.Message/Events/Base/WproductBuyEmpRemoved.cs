/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 商品采购员 移除(Remove)事件
    /// 备注：当商品采购员移除 的时候，需要发布此事件
    /// 使用范围：商品采购员（WproductBuyEmp）移除 操作中使用
    /// </summary>
    [Serializable, EventGroup("Base", "WproductBuyEmp.03")]
    public class WproductBuyEmpRemoved : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 商品采购员编号
        /// </summary>
        public int ID { get; set; }

    }
}
