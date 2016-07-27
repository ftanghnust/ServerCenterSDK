/*********************************************************
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
    /// 商品单位 变更(Changed)事件
    /// </summary>
    [Serializable, GlobalEventMessage]
    public class ProductUnitChangedMessageBody : IMessageBody
    {
        /// <summary>
        /// 商品单位 编号
        /// </summary>
        public int ProductsUnitID { get; set; }
    }
}
