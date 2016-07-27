using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 获取商品详情接口
    /// </summary>
    public class ProductGetRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int? ProductId { get; set; }
    }
}
