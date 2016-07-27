/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class StockFIFOIn : BaseEntity
    {
        public long InID { get; set; }
        public string BatchNO { get; set; }
        public int WID { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public int SubWID { get; set; }
        public string SubWName { get; set; }
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public decimal StockQty { get; set; }
        public int BillType { get; set; }
        public string BillID { get; set; }
        public string BillDetailID { get; set; }
        public string Unit { get; set; }
        public decimal Qty { get; set; }
        public decimal TotalOutQty { get; set; }
        public int Flag { get; set; }
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public decimal InPrice { get; set; }
        public System.DateTime StockTime { get; set; }
        public System.DateTime ModifyTime { get; set; }
    }
}
