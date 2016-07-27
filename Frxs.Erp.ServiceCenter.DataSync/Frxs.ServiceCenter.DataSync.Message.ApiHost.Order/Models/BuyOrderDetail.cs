/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class BuyOrderDetail : BaseEntity
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
        public int SerialNumber { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public int ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
    }
}
