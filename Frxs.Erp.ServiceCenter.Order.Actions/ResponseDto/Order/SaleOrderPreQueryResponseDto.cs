using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
    /// <summary>
    /// 订单返回结果
    /// </summary>
    public class SaleOrderPreQueryResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 订单集合
        /// </summary>
        public IList<SaleOrderPreResponseDto> Orders { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal? TotalAmt { get; set; }
    }
}
