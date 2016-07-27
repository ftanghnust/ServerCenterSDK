using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 商品查询需要返回的字段值
    /// </summary>
    public class ProductQueryModel
    {
        /// <summary>
        /// 母商品ID
        /// </summary>
        public int BaseProductId { get; set; }

        /// <summary>
        /// 商品分类1
        /// </summary>
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 商品分类2
        /// </summary>
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 商品分类2
        /// </summary>
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 运营分类1
        /// </summary>
        public int ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营分类2
        /// </summary>
        public int ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营分类2
        /// </summary>
        public int ShopCategoryId3 { get; set; }

        /// <summary>
        /// 品牌分类1
        /// </summary>
        public int BrandId1 { get; set; }

        /// <summary>
        /// 品牌分类2
        /// </summary>
        public int BrandId2 { get; set; }

        /// <summary>
        /// 是否多属性商品
        /// </summary>
        public int IsMutiAttribute { get; set; }

        /// <summary>
        /// 是否母商品
        /// </summary>
        public int IsBaseProductId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ERP编码
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }


        /// <summary>
        /// 商品助记码（多加）
        /// </summary>
        public string Mnemonic { get; set; }


        /// <summary>
        /// 商品规格
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// 母商品名称
        /// </summary>
        public string ProductBaseName { get; set; }

        ///// <summary>
        ///// 建议零售价
        ///// </summary>
        //public decimal SalePrice { get; set; }

        ///// <summary>
        ///// 零售价上限
        ///// </summary>
        //public decimal MarketPrice { get; set; }

        /// <summary>
        /// 第三方商品
        /// </summary>
        public int IsVendor { get; set; }

        /// <summary>
        /// 商品图片集合编码
        /// </summary>
        public int ImageProductId { get; set; }

        /// <summary>
        /// 天下图片ID
        /// </summary>
        public string TXTKID { get; set; }

        /// <summary>
        /// 规格属性ID串
        /// </summary>
        public string MutAttributes { get; set; }


    }
}
