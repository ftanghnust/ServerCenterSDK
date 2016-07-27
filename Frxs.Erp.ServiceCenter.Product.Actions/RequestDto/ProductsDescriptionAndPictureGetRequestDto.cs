using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 商品图文详情列表
    /// </summary>
    public class ProductsDescriptionAndPictureGetRequestDto : RequestDtoBase
    {
        #region 模型

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 母商品编号
        /// </summary>
        public int BaseProductId { get; set; }

        #endregion
    }
}
