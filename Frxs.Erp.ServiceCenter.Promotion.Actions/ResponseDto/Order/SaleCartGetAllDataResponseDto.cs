using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto.Order
{
    public class SaleCartGetAllDataResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 购物车数据列表
        /// </summary>
        public IList<SaleCartBaseResponseDto> Carts { get; set; }

        /// <summary>
        /// 门店返点列表
        /// </summary>
        public IList<WProductPromotionDetails> RebateData { get; set; }

        /// <summary>
        /// 促销费率信息
        /// </summary>
        public IList<WProductPromotionDetails> ReteData { get; set; }
    }
}
