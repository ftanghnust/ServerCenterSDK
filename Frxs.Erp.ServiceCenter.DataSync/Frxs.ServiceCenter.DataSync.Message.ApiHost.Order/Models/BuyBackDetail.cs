/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class BuyBackDetail : BaseEntity
    {
        public string ID { get; set; }
        public string BackID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public string BackUnit { get; set; }
        public Nullable<decimal> BackPackingQty { get; set; }
        public decimal BackQty { get; set; }
        public decimal BackPrice { get; set; }
        public string Unit { get; set; }
        public decimal UnitQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubAmt { get; set; }
        public string Remark { get; set; }
        public int SerialNumber { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
    }
}
