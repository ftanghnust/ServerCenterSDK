using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductAdjPriceDetail
    {
        public int ID { get; set; }
        public int AdjID { get; set; }
        public int WProductID { get; set; }
        public int WID { get; set; }
        public int ProductID { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> OldMarketPrice { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public Nullable<decimal> OldShopPoint { get; set; }
        public Nullable<decimal> OldShopAddPerc { get; set; }
        public Nullable<decimal> ShopPoint { get; set; }
        public Nullable<decimal> ShopPerc { get; set; }
        public Nullable<decimal> OldBasePoint { get; set; }
        public Nullable<decimal> BasePoint { get; set; }
        public Nullable<decimal> OldVendorPerc1 { get; set; }
        public Nullable<decimal> OldVendorPerc2 { get; set; }
        public Nullable<decimal> VendorPerc1 { get; set; }
        public Nullable<decimal> VendorPerc2 { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
