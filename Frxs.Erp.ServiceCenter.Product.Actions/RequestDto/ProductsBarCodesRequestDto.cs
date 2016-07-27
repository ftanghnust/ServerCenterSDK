using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 国际条码请求参数
    /// </summary>
    public class ProductsBarCodesRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 商品ID(product.ProductId)
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 排序(固定从1开始;1就是主条码)
        /// </summary>
        public int SerialNumber { get; set; }
    }
}
