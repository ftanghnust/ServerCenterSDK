using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleBackPre
    {
        public string BackID { get; set; }
        public int WID { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public int SubWID { get; set; }
        public string SubWCode { get; set; }
        public string SubWName { get; set; }
        public System.DateTime BackDate { get; set; }
        public Nullable<long> XSUserID { get; set; }
        public int ShopID { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public int Status { get; set; }
        public decimal TotalBackQty { get; set; }
        public decimal TotalBackAmt { get; set; }
        public decimal TotalBasePoint { get; set; }
        public Nullable<decimal> TotalAddAmt { get; set; }
        public decimal PayAmount { get; set; }
        public Nullable<System.DateTime> ConfTime { get; set; }
        public Nullable<int> ConfUserID { get; set; }
        public string ConfUserName { get; set; }
        public Nullable<System.DateTime> PostingTime { get; set; }
        public Nullable<int> PostingUserID { get; set; }
        public string PostingUserName { get; set; }
        public Nullable<System.DateTime> SettleTime { get; set; }
        public Nullable<int> SettleUserID { get; set; }
        public string SettleUserName { get; set; }
        public string SettleID { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
