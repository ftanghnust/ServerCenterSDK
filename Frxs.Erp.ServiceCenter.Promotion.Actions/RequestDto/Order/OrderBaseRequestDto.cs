using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    /// <summary>
    /// 简单的订单基础访问模型
    /// </summary>
    public class OrderBaseRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int? ShopId { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int? WID { get; set; } 

        /// <summary>
        /// 查询日期(yyyyMMdd)
        /// </summary>
        public string SearchDate { get; set; }


    }
}
