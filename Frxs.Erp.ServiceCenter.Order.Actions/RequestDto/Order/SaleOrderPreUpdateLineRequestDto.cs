using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleOrderPreUpdateLineRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 路线ID
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
    }
}
