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
    /// 仓库商品采购信息 移除(Remove)事件
    /// </summary>
    [Serializable]
    public class WproductBuyRemoved : MessageBodyBase
    {
        /// <summary>
        /// 仓库商品编号
        /// </summary>
        public long WProductID { get; set; }

    }
}
