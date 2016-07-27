using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class StockCheckDetail
    {
        public string ID { get; set; }
        public int WID { get; set; }
        public string CheckStockID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public string Unit { get; set; }
        public Nullable<int> ShelfID { get; set; }
        public string ShleftCode { get; set; }
        public string SaleUnit { get; set; }
        public Nullable<decimal> SalePackingQty { get; set; }
        public decimal CheckUnitQty { get; set; }
        public decimal StockUnitQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubAmt { get; set; }
        public Nullable<int> CheckUserID { get; set; }
        public string CheckUserName { get; set; }
        public string Remark { get; set; }
        public int SerialNumber { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public int ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
