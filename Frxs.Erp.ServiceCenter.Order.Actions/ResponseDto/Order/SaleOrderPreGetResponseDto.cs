using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    /// <summary>
    /// Get返回
    /// </summary>
    public class SaleOrderPreGetResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 订单
        /// </summary>
        public SaleOrderPreResponseDto Order { get; set; }

        /// <summary>
        /// 订单商品明细
        /// </summary>
        public IList<SaleOrderPreDetailRequestDto> Details { get; set; }

        /// <summary>
        /// 订单商品明细扩展
        /// </summary>
        public IList<SaleOrderPreDetailExtsRequestDto> DetailExts { get; set; }
    }
}
