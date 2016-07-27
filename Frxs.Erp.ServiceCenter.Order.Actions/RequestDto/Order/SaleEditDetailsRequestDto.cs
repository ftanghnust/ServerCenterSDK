using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Actions.RequestDto
{
    public class SaleEditDetailsRequestDto : RequestDtoParent
    {
        #region 模型
        /// <summary>
        /// 编号(仓库ID+GUID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 改单ID
        /// </summary>
        public string EditID { get; set; }

        /// <summary>
        /// 订单编号(SaleEdit.OrderID)
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 仓库ID(Warehouse.WID)
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 商品编号(Prouct.ProductID)
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 商品SKU(ERP编码)
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 描述商品名称(Product.ProductName)
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品的国际条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 商品图片用于移动端(Products.ImageUrl200*200)
        /// </summary>
        public string ProductImageUrl200 { get; set; }

        /// <summary>
        /// 商品图片用于PC端(Products.ImageUrl400*400)
        /// </summary>
        public string ProductImageUrl400 { get; set; }

        /// <summary>
        /// 仓库商品主键ID（WCProduct.WCProductID）
        /// </summary>
        public int WCProductID { get; set; }

        /// <summary>
        /// 配送(销售)单位
        /// </summary>
        public string SaleUnit { get; set; }

        /// <summary>
        /// 配送(销售)单位包装数
        /// </summary>
        public decimal SalePackingQty { get; set; }

        /// <summary>
        /// 配送(销售)单位价格(UnitPrice*SalePackingQty)
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 推荐数量
        /// </summary>
        public decimal? SaleQty { get; set; }

        /// <summary>
        /// 库存单位(WProducts.Unit)
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存单位实发数量=SalePackingQty*SaleQty
        /// </summary>
        public decimal UnitQty { get; set; }

        /// <summary>
        /// 库存单位价格(WProduct.SalePrice 四舍五入到4位小数)
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 库存单位促销价格(WProductPromotionDetails.PromotionPrice 预留)
        /// </summary>
        public decimal? PromotionUnitPrice { get; set; }

        /// <summary>
        /// 调整后的最终金额(=ifnull(PromotionPrice,UnitPrice) *UnitQty)
        /// </summary>
        public decimal? SubAmt { get; set; }

        /// <summary>
        /// 门店库存单位平台率(%)(=WProducts.ShopAddPerc)
        /// </summary>
        public decimal? ShopAddPerc { get; set; }

        /// <summary>
        /// 门店库存单位积分(=WProducts.ShopPoint)
        /// </summary>
        public decimal? ShopPoint { get; set; }

        /// <summary>
        /// 门店库存单位促销积分(=WProductPromotionDetails.PromotionShopPoint)
        /// </summary>
        public decimal? PromotionShopPoint { get; set; }

        /// <summary>
        /// 库存单位绩效积分(=WProducts.BasePoint)
        /// </summary>
        public decimal? BasePoint { get; set; }

        /// <summary>
        /// 库存单位物流费率(=WProducts.VendorPerc1)
        /// </summary>
        public decimal? VendorPerc1 { get; set; }

        /// <summary>
        /// 库存单位仓储费率(=WProducts.VendorPerc2)
        /// </summary>
        public decimal? VendorPerc2 { get; set; }

        /// <summary>
        /// 小计门店提点金额,平台费用(=ShopAddPerc*SubAmt)
        /// </summary>
        public decimal? SubAddAmt { get; set; }

        /// <summary>
        /// 小计门店积分(=ifnull(PromotionShopPoint,ShopPoint)*UnitQty)
        /// </summary>
        public decimal? SubPoint { get; set; }

        /// <summary>
        /// 小计绩效积分(=BasePoint*UnitQty)
        /// </summary>
        public decimal? SubBasePoint { get; set; }

        /// <summary>
        /// 小计供应商物流费(=VendorPerc1*SubAmt)
        /// </summary>
        public decimal? SubVendor1Amt { get; set; }

        /// <summary>
        /// 小计供应商仓储费(=VendorPerc2*SubAmt)
        /// </summary>
        public decimal? SubVendor2Amt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 序号(输入的序号,每一个单据从1开始)(推荐到订单明细时固定为 9999)
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// 货架号区号
        /// </summary>
        public int? ShelfAreaID { get; set; }

        /// <summary>
        /// 仓库货区编号(数据字典：ShelfAreaCode)
        /// </summary>
        public string ShelfAreaCode { get; set; }

        /// <summary>
        /// 货区名称
        /// </summary>
        public string ShelfAreaName { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        public int? ShelfID { get; set; }

        /// <summary>
        /// 货位编号
        /// </summary>
        public string ShelfCode { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal? StockQty { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public int? ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改用户名称
        /// </summary>
        public string ModifyUserName { get; set; }

        #endregion
    }
}
