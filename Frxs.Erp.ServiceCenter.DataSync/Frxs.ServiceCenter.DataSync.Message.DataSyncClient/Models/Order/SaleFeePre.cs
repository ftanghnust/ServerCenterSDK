using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleFeePre
    {
        public string FeeID { get; set; }
        public System.DateTime FeeDate { get; set; }
        public int WID { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public int SubWID { get; set; }
        public string SubWCode { get; set; }
        public string SubWName { get; set; }
        public int Status { get; set; }
        public decimal TotalFeeAmt { get; set; }
        public Nullable<System.DateTime> ConfTime { get; set; }
        public Nullable<int> ConfUserID { get; set; }
        public string ConfUserName { get; set; }
        public Nullable<System.DateTime> PostingTime { get; set; }
        public Nullable<int> PostingUserID { get; set; }
        public string PostingUserName { get; set; }
        public Nullable<System.DateTime> SettleTime { get; set; }
        public Nullable<int> SettleUserID { get; set; }
        public string SettleUserName { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
