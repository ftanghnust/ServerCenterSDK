﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    ///  门店创建(Created)事件
    /// </summary>
    [Serializable, GlobalEvent, EventGroup("Base","Shop.01")]
    public class ShopCreated : MessageBodyBase, IEvent
    {
        /// <summary>
        /// 门店编号
        /// </summary>
        public int ShopID { get; set; }
    }
}
