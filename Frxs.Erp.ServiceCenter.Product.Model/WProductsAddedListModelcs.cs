
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 已加入商品查询结果对象
    /// </summary>
    public class WProductsAddedListModel
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
        /// 分类
        /// </summary>
        public int CategoryId1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName1 { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName2 { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public int CategoryId3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName3 { get; set; }

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
        public decimal Price
        {
            get { return this.SalePrice; }
        }

        /// <summary>
        /// 配送价格
        /// </summary>      
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 采购价格
        /// </summary>      
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 主供应商ID
        /// </summary>
        public int VendorID { get; set; }

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
        public decimal StockQty { get; set; }

        /// <summary>
        /// 包装数
        /// </summary>
        public decimal BigPackingQty { get; set; }

        /// <summary>
        /// 仓库商品状态(0:已移除1:正常;2:淘汰;3:冻结;) ;淘汰商品和冻结商品不能销售;加入或重新加入时为正常；移除后再加入时为正常
        /// </summary>       
        public int WStatus { get; set; }

        /// <summary>
        /// 最小库存单位销售价
        /// </summary>
        public decimal UnitSalePrice { get; set; }

        /// <summary>
        /// 销售单位包装数
        /// </summary>
        public decimal SaleBigPackingQty { get; set; }

        /// <summary>
        /// 最小库存单位采购价
        /// </summary>
        public decimal UnitBuyPrice { get; set; }

        /// <summary>
        /// 采购单位包装数
        /// </summary>
        public decimal BuyBigPackingQty { get; set; }

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
