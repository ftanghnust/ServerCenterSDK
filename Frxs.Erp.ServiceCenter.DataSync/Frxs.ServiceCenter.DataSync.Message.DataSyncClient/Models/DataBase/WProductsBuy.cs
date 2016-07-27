using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductsBuy
    {
        public long WProductID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public decimal BuyPrice { get; set; }
        public int BigProductsUnitID { get; set; }
        public Nullable<decimal> BigPackingQty { get; set; }
        public string BigUnit { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
