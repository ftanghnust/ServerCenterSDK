
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.Erp.ServiceCenter.Product.Actions.RequestDto
{
    /// <summary>
    /// 添加商品的全部信息类
    /// </summary>
    public class ProductsAddPackageRequestDto : RequestDtoBase
    {
        /// <summary>
        /// 新增标志(0不关联母商品，1创建母商品，2选择母商品)
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 是否为商品主图
        /// 0表示商品主图，1表示直接读取（从天下图库读取)
        /// </summary>
        public int IsBaseProductPicture { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 母商品编号
        /// </summary>
        public int BaseProductId { get; set; }

        /// <summary>
        /// 商品规格图片
        /// </summary>
        public ProductsAttributesPictureAddRequestDto ProductsAttributesPicture { get; set; }

        /// <summary>
        /// 商品国际条码集合
        /// </summary>
        public ICollection<ProductsBarCodesRequestDto> ProductsBarCodes { get; set; }


        /// <summary>
        /// 商品单位集合
        /// </summary>
        public ICollection<ProductsUnitRequestDto> ProductsUnits { get; set; }

        /// <summary>
        /// 母商品信息
        /// </summary>
        public BaseProductAddRequestDto BaseProduct { get; set; }

        /// <summary>
        /// 商品基本信息
        /// </summary>
        public ProductAddRequestDto Product { get; set; }

        /// <summary>
        /// 商品属性集合
        /// </summary>
        public IList<ProductsAttributesAddRequestDto> ProductsAttributes { get; set; }

        /// <summary>
        /// 商品主图集合
        /// </summary>
        public IList<ProductsPictureDetailAddRequestDto> ProductsPictureDetails { get; set; }
    }
}
