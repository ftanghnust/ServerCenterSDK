/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models
{
    public partial class WProductPromotionDetail : BaseEntity
    {
        public int ID { get; set; }
        public string PromotionID { get; set; }
        public int WID { get; set; }
        public int WProductID { get; set; }
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> PackingQty { get; set; }
        public string SaleUnit { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
        public Nullable<decimal> OldPoint { get; set; }
        public decimal Point { get; set; }
        public decimal MaxOrderQty { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
