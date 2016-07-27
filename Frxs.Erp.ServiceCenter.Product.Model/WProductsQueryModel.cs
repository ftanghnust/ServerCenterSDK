/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Frxs.Erp.ServiceCenter.Product.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class WProductsQueryModel
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
        /// 购买单位
        /// </summary>
        public string BuyUnit { get; set; }

        /// <summary>
        /// 包装数量
        /// </summary>
        public decimal PackingQty { get; set; }

        /// <summary>
        /// 购买价格
        /// </summary>
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 最小单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 最小单位价格
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 门店库存单位提点率(%)
        /// </summary>
        public decimal ShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位积分
        /// </summary>
        public decimal ShopPoint { get; set; }

        /// <summary>
        /// 库存单位绩效积分（司机及门店绩效分)
        /// </summary>
        public decimal BasePoint { get; set; }

        /// <summary>
        /// 库存单位物流费率(供应商) (%)
        /// </summary>
        public decimal VendorPerc1 { get; set; }

        /// <summary>
        /// 库存单位仓储费率(供应商)(%)
        /// </summary>
        public decimal VendorPerc2 { get; set; }

        /// <summary>
        /// 销售库存单位销售价  wp.SalePrice AS SaleUnitPrice,
        /// </summary>
        public decimal SaleUnitPrice { get; set; }

        /// <summary>
        /// 销售价格()  wp.SalePrice*wbuy.BigPackingQty
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public int WStatus { get; set; }
    }
}
