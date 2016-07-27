/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class StockAdjDetail : BaseEntity
    {
        public string ID { get; set; }
        public int WID { get; set; }
        public string AdjID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public string AdjUnit { get; set; }
        public Nullable<decimal> AdjPackingQty { get; set; }
        public decimal AdjQty { get; set; }
        public string Unit { get; set; }
        public decimal UnitQty { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal AdjAmt { get; set; }
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public decimal StockQty { get; set; }
        public string Remark { get; set; }
        public int SerialNumber { get; set; }
        public string StockCheckID { get; set; }
        public string StockCheckDetailsID { get; set; }
        public Nullable<int> CheckUserID { get; set; }
        public string CheckUserName { get; set; }
        public Nullable<decimal> CheckUnitQty { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
