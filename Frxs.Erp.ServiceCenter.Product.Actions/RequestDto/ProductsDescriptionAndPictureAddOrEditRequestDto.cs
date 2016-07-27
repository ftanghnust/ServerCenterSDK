using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 母商品文字描述和图文详情功能的新增和删除
    /// </summary>
    public class ProductsDescriptionAndPictureAddOrEditRequestDto : RequestDtoBase
    {
        #region 模型

        /// <summary>
        /// 母商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 母商品编号
        /// </summary>
        public int BaseProductId { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        ///电商商品图文详情列表
        /// </summary>
        public IList<ProductsDescriptionPictureRequestDto> ProductsDescriptionPicture { get; set; }


  

        #endregion
    }
}
