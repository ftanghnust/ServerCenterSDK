using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Order.Actions.ResponseDto
{
   public class SaleEditGetResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 改单主表
        /// </summary>
       public SaleEditResponseDto SaleEdit { get; set; }

        /// <summary>
        /// 改单订单表
        /// </summary>
       public IList<SaleEditOrderResponseDto> Order { get; set; }

        /// <summary>
        /// 改单明细表
        /// </summary>
       public IList<SaleEditDetailResponseDto> Details { get; set; }

        /// <summary>
        /// 改单明细扩展表
        /// </summary>
       public IList<SaleEditDetailExtsResponseDto> DetailExts { get; set; } 
    }
}
