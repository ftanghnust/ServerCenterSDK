using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto
{
    /// <summary>
    /// 订单查询返回结果
    /// </summary>
    public class OrderShopQueryResponseDto:ResponseDtoBase
    {
        /// <summary>
        /// 订单集合
        /// </summary>
        public IList<OrderShopResponseDto> Orders { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
    }
}
