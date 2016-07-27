using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 网仓商品信息获取
    /// </summary>
    public class WProductsBaseQueryModel : BaseModel
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 最小单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// （销售价格）最小单位价格
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 采购价格
        /// </summary>
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 一级基本分类
        /// </summary>
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 一级基本分类名称
        /// </summary>
        public string CategoryId1Name { get; set; }

        /// <summary>
        /// 二级基本分类
        /// </summary>
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 二级基本分类名称
        /// </summary>
        public string CategoryId2Name { get; set; }

        /// <summary>
        /// 三级基本分类
        /// </summary>
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 三级基本分类名称
        /// </summary>
        public string CategoryId3Name { get; set; }

        /// <summary>
        /// 一级运营分类
        /// </summary>
        public int ShopCategoryId1 { get; set; }

        /// <summary>
        /// 一级运营分类名称
        /// </summary>
        public string ShopCategoryId1Name { get; set; }

        /// <summary>
        /// 二级运营分类
        /// </summary>
        public int ShopCategoryId2 { get; set; }

        /// <summary>
        /// 二级运营分类名称
        /// </summary>
        public string ShopCategoryId2Name { get; set; }

        /// <summary>
        /// 三级运营分类
        /// </summary>
        public int ShopCategoryId3 { get; set; }

        /// <summary>
        /// 三级运营分类名称
        /// </summary>
        public string ShopCategoryId3Name { get; set; }

        /// <summary>
        /// 第一品牌
        /// </summary>
        public int BrandId1 { get; set; }

        /// <summary>
        /// 第一品牌名称
        /// </summary>
        public string BrandId1Name { get; set; }

        /// <summary>
        /// 第二品牌
        /// </summary>
        public int BrandId2 { get; set; }

        /// <summary>
        /// 第二品牌名称
        /// </summary>
        public string BrandId2Name { get; set; }

    }
}
