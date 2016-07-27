using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 查询商品参数
    /// </summary>
    public class ProductQuerySearchParams
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public IList<int> ProductIds { get; set; }

        /// <summary>
        /// 母商品编码
        /// </summary>
        public int? BaseProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 母商品名称
        /// </summary>
        public string ProductBaseName { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string BarCode { get; set; }

        ///// <summary>
        ///// ERP编码
        ///// </summary>
        //public string ErpCode { get; set; }

        /// <summary>
        /// 一级基本分类
        /// </summary>
        public int? CategoriesID1 { get; set; }

        /// <summary>
        ///二级基本分类
        /// </summary>
        public int? CategoriesID2 { get; set; }

        /// <summary>
        ///三级基本分类
        /// </summary>
        public int? CategoriesID3 { get; set; }

        /// <summary>
        /// 一级运营分类
        /// </summary>
        public int? ShopCategoriesID1 { get; set; }

        /// <summary>
        /// 二级运营分类
        /// </summary>
        public int? ShopCategoriesID2 { get; set; }

        /// <summary>
        /// 三级运营分类
        /// </summary>
        public int? ShopCategoriesID3 { get; set; }

        /// <summary>
        /// 品牌ID1
        /// </summary>
        public int? BrandId1 { get; set; }

        /// <summary>
        /// 品牌ID2
        /// </summary>
        public int? BrandId2 { get; set; }

        /// <summary>
        /// 品牌名称关键词
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 是否多规格属性 0/1
        /// </summary>
        public int? IsMutiAttribute { get; set; }

        /// <summary>
        /// 是否是母商品 0/1
        /// </summary>
        public int? IsBaseProductId { get; set; }

        ///// <summary>
        ///// 第三方商品 0/1
        ///// </summary>
        //public int? IsVendor { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public int? Status { get; set; }


        /// <summary>
        /// 仅查询母商品true
        /// </summary>
        public bool IsOnlyBaseProduct { get; set; }

        /// <summary>
        /// 规格属性ID串
        /// </summary>
        public string MutAttributes { get; set; }


        /// <summary>
        /// 图片库里的商品ID
        /// </summary>
        public int? ImageProductId { get; set; }
    }
}
