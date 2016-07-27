using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Product
{
    /// <summary>
    ///获取产品返回对象
    /// </summary>
    public class ProductGetResponseDto : ResponseDtoBase
    {
        /// <summary>
        /// 母商品返回集合
        /// </summary>
        public BaseProductResponseDto BaseProduct { get; set; }

        /// <summary>
        /// 商品返回集合
        /// </summary>
        public ProductResponseDto Product { get; set; }

    }
}
