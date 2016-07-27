using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class ProductsVendor
    {
        public long ID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public int VendorID { get; set; }
        public string Unit { get; set; }
        public decimal BuyPrice { get; set; }
        public int IsMaster { get; set; }
        public Nullable<decimal> LastBuyPrice { get; set; }
        public Nullable<System.DateTime> LastBuyTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
