/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class WProductsBuy : BaseEntity
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
