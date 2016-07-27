using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto
{
    public class SaleCartQueryResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 总数量
        /// </summary>
        public decimal TotalCount { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 商品总金额
        /// </summary>
        public decimal ProductAmount { get; set; }

        /// <summary>
        /// 提点总费用
        /// </summary>
        public decimal TotalAddPerc{get; set; }

        /// <summary>
        /// 总积分
        /// </summary>
        public decimal TotalPoint { get; set; }

        /// <summary>
        /// 购物车数据
        /// </summary>
        public IList<SaleCartDetail> List { get; set; }
    }
}
