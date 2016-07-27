using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleOrderDetail
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public int WCProductID { get; set; }
        public decimal PreQty { get; set; }
        public string SaleUnit { get; set; }
        public Nullable<decimal> SalePackingQty { get; set; }
        public decimal SalePrice { get; set; }
        public Nullable<decimal> SaleQty { get; set; }
        public string Unit { get; set; }
        public decimal UnitQty { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<decimal> PromotionUnitPrice { get; set; }
        public Nullable<decimal> SubAmt { get; set; }
        public Nullable<decimal> ShopAddPerc { get; set; }
        public Nullable<decimal> ShopPoint { get; set; }
        public Nullable<decimal> PromotionShopPoint { get; set; }
        public Nullable<decimal> BasePoint { get; set; }
        public Nullable<decimal> VendorPerc1 { get; set; }
        public Nullable<decimal> VendorPerc2 { get; set; }
        public Nullable<decimal> SubAddAmt { get; set; }
        public Nullable<decimal> SubPoint { get; set; }
        public Nullable<decimal> SubBasePoint { get; set; }
        public Nullable<decimal> SubVendor1Amt { get; set; }
        public Nullable<decimal> SubVendor2Amt { get; set; }
        public int IsAppend { get; set; }
        public string EditID { get; set; }
        public int IsStockOut { get; set; }
        public string PromotionID { get; set; }
        public string PromotionName { get; set; }
        public string Remark { get; set; }
        public int SerialNumber { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
