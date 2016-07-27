/*********************************************************
 * 盘点商品详情
 * FRXS(ISC) wangrui@frxs.cn 2016/4/21 10:40:00 
 * *******************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 盘点商品详情对象
    /// </summary>
    public class WProductsStockCheckModel
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 仓库商品ID(WProducts.WProductID)
        /// </summary>
        public long WProductId { get; set; }

        /// <summary>
        /// ERP编码
        /// </summary>
        public string SKU { get; set; }

        
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName2 { get; set; }

        /// <summary>
        /// 规格属性 由3个规格属性拼接而成
        /// </summary>
        public string Attributes
        {
            get;
            set;
        }

        /// <summary>
        /// 商品图片用于移动端(Products.ImageUrl200*200)
        /// </summary>    

        public string ProductImageUrl200 { get; set; }

        /// <summary>
        /// 商品图片用于PC端(Products.ImageUrl400*400)
        /// </summary>

        public string ProductImageUrl400 { get; set; }


        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 库存单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 平台费率
        /// </summary>
        public decimal ShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位原积分
        /// </summary>
        public decimal ShopPoint { get; set; }

        /// <summary>
        /// 货架ID(WProducts.ShelfID、Shelf.ShelfID)
        /// </summary>       
        public int? ShelfID { get; set; }

        /// <summary>
        /// 大(配送)单位(冗余设计 选中配送单位时,同步该表,没有时该值为1)
        /// </summary>
        public string BigUnit { get; set; }

        /// <summary>
        /// 货位编号(同一个仓库不能重复)
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 价格 (最小单位配送价*包装数)
        /// </summary>      
        public decimal? Price
        {
            get { return this.SalePrice; }
        }

        /// <summary>
        /// 配送价格
        /// </summary>      
        public decimal? SalePrice { get; set; }

        /// <summary>
        /// 采购价格
        /// </summary>      
        public decimal? BuyPrice { get; set; }

        /// <summary>
        /// 主供应商ID
        /// </summary>
        public int? VendorID { get; set; }

        /// <summary>
        /// 主供应商编号
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 主供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 库存数量 这个值需要掉专门的接口查出来，暂时取不到
        /// </summary>
        public decimal? StockQty { get; set; }

        /// <summary>
        /// 包装数 2016-6-20 按照会议要求，类型统一由int改成decimal
        /// </summary>
        public decimal? BigPackingQty { get; set; }

        /// <summary>
        /// 仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常
        /// </summary>       
        public int WStatus { get; set; }


        #region 盘盈盘亏调整明细扩展表 基本分类、运营分类、品牌信息
        /// <summary>
        /// 基本分类一级分类ID(Category.CategoryId)
        /// </summary>
        public int? CategoryId1 { get; set; }

        /// <summary>
        /// 基本分类一级分类名称
        /// </summary>
        public string CategoryId1Name { get; set; }

        /// <summary>
        /// 基本分类二级分类ID(Category.CategoryId)
        /// </summary>
        public int? CategoryId2 { get; set; }

        /// <summary>
        /// 基本分类二级分类名称
        /// </summary>
        public string CategoryId2Name { get; set; }

        /// <summary>
        /// 基本分类三级分类ID(Category.CategoryId)
        /// </summary>
        public int? CategoryId3 { get; set; }

        /// <summary>
        /// 基本分类三级分类名称
        /// </summary>
        public string CategoryId3Name { get; set; }

        /// <summary>
        /// 运营一级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int? ShopCategoryId1 { get; set; }

        /// <summary>
        /// 运营一级分类名称
        /// </summary>
        public string ShopCategoryId1Name { get; set; }

        /// <summary>
        /// 运营二级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int? ShopCategoryId2 { get; set; }

        /// <summary>
        /// 运营二级分类名称
        /// </summary>
        public string ShopCategoryId2Name { get; set; }

        /// <summary>
        /// 运营三级分类ID(ShopCategory.ShopCategoryId)
        /// </summary>
        public int? ShopCategoryId3 { get; set; }

        /// <summary>
        /// 运营三级分类名称
        /// </summary>
        public string ShopCategoryId3Name { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        public int? BrandId1 { get; set; }

        /// <summary>
        /// 品牌ID名称
        /// </summary>

        public string BrandId1Name { get; set; }

        /// <summary>
        /// 子品牌ID
        /// </summary>
        public int? BrandId2 { get; set; }

        /// <summary>
        /// 子品牌名称
        /// </summary>

        public string BrandId2Name { get; set; }
                
        #endregion
        
        /// <summary>
        /// 仓库商品状态的文本描述
        /// </summary>
        public string WStatusStr
        {
            get
            {
                if (WStatus == 0)
                {
                    return "已移除";
                }
                else if (WStatus == 1)
                {
                    return "正常";
                }
                else if (WStatus == 2)
                {
                    return "淘汰";
                }
                else
                {
                    return "冻结";
                }
            }
        }
    }
}
