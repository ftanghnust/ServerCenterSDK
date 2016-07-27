using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 商品绑入母商品对象输入参数
    /// </summary>
    public class ProductsBindToBaseProductRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 子商品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 加入到母商品的下属子商品ID,解绑时传null
        /// </summary>
        public int? ProductIdAddto { get; set; }
    }
}