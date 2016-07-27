using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class SaleCartBaseRequestDto:RequestDtoParent
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int ShopID{ get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int? ProductId { get; set; }

    }
}
