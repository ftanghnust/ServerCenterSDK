using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Promotion.Actions.RequestDto
{
    public class SaleCartDeleteRequestDto : RequestDtoParent
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int ShopID{ get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        public IList<int> ProductIds { get; set; }
    }
}
