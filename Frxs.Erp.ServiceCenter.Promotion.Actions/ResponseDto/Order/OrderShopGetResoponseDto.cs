using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto
{
    /// <summary>
    /// Get返回
    /// </summary>
    public class OrderShopGetResoponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 订单
        /// </summary>
        public OrderShopResponseDto Order { get; set; }

        /// <summary>
        /// 订单商品明细
        /// </summary>
        public IList<OrderDetailRequestDto> Details { get; set; }

        /// <summary>
        /// 订单商品明细扩展
        /// </summary>
        public IList<OrderDetailExtsRequestDto> DetailExts { get; set; }
    }
}
