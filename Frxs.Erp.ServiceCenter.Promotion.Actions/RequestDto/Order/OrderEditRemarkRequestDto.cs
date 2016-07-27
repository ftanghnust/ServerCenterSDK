using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class OrderEditRemarkRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单商品明细ID
        /// </summary>
        public string DetailId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 修改类型 0:整单备注 1：单行备注
        /// </summary>
        public int EditType { get; set; }
    }
}
