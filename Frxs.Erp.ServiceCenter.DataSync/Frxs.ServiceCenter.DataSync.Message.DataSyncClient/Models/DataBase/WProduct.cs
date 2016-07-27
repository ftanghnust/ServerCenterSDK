using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProduct
    {
        public long WProductID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public string ProductName2 { get; set; }
        public int WStatus { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public string MarketUnit { get; set; }
        public Nullable<int> BigProductsUnitID { get; set; }
        public Nullable<decimal> BigPackingQty { get; set; }
        public string BigUnit { get; set; }
        public Nullable<int> ShelfID { get; set; }
        public Nullable<decimal> ShopAddPerc { get; set; }
        public Nullable<decimal> ShopPoint { get; set; }
        public Nullable<decimal> BasePoint { get; set; }
        public Nullable<decimal> VendorPerc1 { get; set; }
        public Nullable<decimal> VendorPerc2 { get; set; }
        public string SaleBackFlag { get; set; }
        public Nullable<int> BackDays { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
