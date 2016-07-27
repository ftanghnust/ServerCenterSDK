/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class StockQty : BaseEntity
    {
        public int ID { get; set; }
        public int WID { get; set; }
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public Nullable<long> WProductID { get; set; }
        public int SubWID { get; set; }
        public decimal StockQty1 { get; set; }
        public decimal SaleTranQty { get; set; }
        public decimal BuyTranQty { get; set; }
        public System.DateTime UpdateStockTime { get; set; }
        public Nullable<decimal> LastCheckQty { get; set; }
        public Nullable<System.DateTime> LastCheckTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
