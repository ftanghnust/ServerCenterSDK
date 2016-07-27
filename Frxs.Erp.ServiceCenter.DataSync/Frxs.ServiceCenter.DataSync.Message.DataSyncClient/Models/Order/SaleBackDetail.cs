using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleBackDetail
    {
        public string ID { get; set; }
        public string BackID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public string BackUnit { get; set; }
        public Nullable<decimal> BackPackingQty { get; set; }
        public decimal BackQty { get; set; }
        public decimal BackPrice { get; set; }
        public string Unit { get; set; }
        public decimal UnitQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubAmt { get; set; }
        public decimal BasePoint { get; set; }
        public decimal SubBasePoint { get; set; }
        public string Remark { get; set; }
        public int SerialNumber { get; set; }
        public Nullable<decimal> ShopAddPerc { get; set; }
        public Nullable<decimal> VendorPerc1 { get; set; }
        public Nullable<decimal> VendorPerc2 { get; set; }
        public Nullable<decimal> SubAddAmt { get; set; }
        public Nullable<decimal> SubVendor1Amt { get; set; }
        public Nullable<decimal> SubVendor2Amt { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
