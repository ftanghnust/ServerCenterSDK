/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class SaleFeeDetail : BaseEntity
    {
        public string ID { get; set; }
        public int WID { get; set; }
        public string FeeID { get; set; }
        public int ShopID { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string FeeCode { get; set; }
        public string FeeName { get; set; }
        public string Reason { get; set; }
        public string OrderId { get; set; }
        public decimal FeeAmt { get; set; }
        public string SettleID { get; set; }
        public Nullable<System.DateTime> SettleTime { get; set; }
        public int SerialNumber { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
