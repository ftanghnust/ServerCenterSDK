using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.ResponseDto
{
    public class SaleCartGetByShopIdResponseDto
    {
        /// <summary>
        /// 购物车数据列表
        /// </summary>
        public IList<SaleCartBaseResponseDto> Carts { get; set; } 
    }
}
