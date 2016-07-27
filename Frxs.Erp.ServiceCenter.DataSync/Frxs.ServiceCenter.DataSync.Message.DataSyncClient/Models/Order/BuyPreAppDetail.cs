using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class BuyPreAppDetail
    {
        public string ID { get; set; }
        public string AppID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public string AppUnit { get; set; }
        public Nullable<decimal> AppPackingQty { get; set; }
        public decimal AppQty { get; set; }
        public decimal AppPrice { get; set; }
        public string Unit { get; set; }
        public decimal UnitQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubAmt { get; set; }
        public string Remark { get; set; }
        public int SerialNumber { get; set; }
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<int> BuyEmpID { get; set; }
        public string BuyEmpName { get; set; }
    }
}
