using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    /// <summary>
    /// 取消订单
    /// </summary>
    public class OrderCancelRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID的List
        /// </summary>
        public IList<string> OrderIdList { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 取消订单原因
        /// </summary>
        public string CloseReason { get; set; }
    }
}
