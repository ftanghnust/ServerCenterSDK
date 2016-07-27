﻿/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 10:58:06 AM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Events
{
    /// <summary>
    /// 母商品创建(Created)事件消息体
    /// </summary>
    [Serializable, GlobalEventMessage]
    public class BaseProductCreatedMessageBody : MessageBodyBase
    {
        /// <summary>
        /// 母商品编号
        /// </summary>
        public int BaseProductId { get; set; }
    }
}
