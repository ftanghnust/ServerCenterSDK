using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Product.Model;

namespace Frxs.Erp.ServiceCenter.Product.Actions.ResponseDto.Product
{
    /// <summary>
    /// 母商品返回对象
    /// </summary>
    public partial class BaseProductResponseDto
    {
        #region 模型
        /// <summary>
        /// 商品母表ID（初始值和Product.productID一样)
        /// </summary>
        public int BaseProductId { get; set; }

        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int ShopCategoryId3 { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        public int BrandId1 { get; set; }

        /// <summary>
        /// 子品牌ID
        /// </summary>
        public int BrandId2 { get; set; }

        /// <summary>
        /// 是否为多规格属性商品(0:不是;1:是)
        /// </summary>
        public int IsMutiAttribute { get; set; }

        /// <summary>
        /// 是否为母商品(0:不是;1:是)
        /// </summary>
        public int IsBaseProductId { get; set; }

        /// <summary>
        /// 母表商品名称（只有为母商品时才会有值)
        /// </summary>
        public string ProductBaseName { get; set; }

        /// <summary>
        /// 是否为第三方商品(0:不是;1:是 B2B固定为0)
        /// </summary>
        public int IsVendor { get; set; }

        /// <summary>
        /// 删除状态(0:未删除;1:已删除;2:子商品另外挂到其它商品)
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int CreateUserID { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 最新修改删除时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 最后修改删除用户ID
        /// </summary>
        public int ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改删除用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion
    }

    public partial class BaseProductResponseDto
    {
        /// <summary>
        /// 母商品的ERP编码
        /// </summary>
        public string BaseProductBSKU { get; set; }

        /// <summary>
        /// 母商品编号
        /// </summary>
        public int BaseProductBId { get; set; }


        /// <summary>
        /// 第一品牌名称
        /// </summary>
        public string BrandName1 { get; set; }


        /// <summary>
        /// 第二品牌名称
        /// </summary>
        public string BrandName2 { get; set; }

        /// <summary>
        /// 母商品文字详情
        /// </summary>
        public ProductsDescription ProductsDescription { get; set; }

        /// <summary>
        /// 母商品图片详情
        /// </summary>
        public IEnumerable<ProductsDescriptionPicture> ProductsDescriptionPictureList { get; set; }

        /// <summary>
        /// 母商品第三方供应商
        /// </summary>
        public IEnumerable<ProductsVendor> ProductsVendorList { get; set; }

    }
}
