using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class BuyOrderPreDetail
    {
        public string ID { get; set; }
        public string BuyID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public string BuyUnit { get; set; }
        public Nullable<decimal> BuyPackingQty { get; set; }
        public decimal BuyQty { get; set; }
        public decimal BuyPrice { get; set; }
        public string Unit { get; set; }
        public decimal UnitQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubAmt { get; set; }
        public string Remark { get; set; }
        public int SerialNumber { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public int ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
    }
}
