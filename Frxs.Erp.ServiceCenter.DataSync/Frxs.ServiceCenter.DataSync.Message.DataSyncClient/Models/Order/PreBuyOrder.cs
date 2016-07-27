using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class PreBuyOrder
    {
        public string PreBuyID { get; set; }
        public int WID { get; set; }
        public int SubWID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<int> BuyEmpID { get; set; }
        public string BuyEmpName { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public string SubWCode { get; set; }
        public string SubWName { get; set; }
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public int Status { get; set; }
        public decimal TotalOrderAmt { get; set; }
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
        public string Sett_ID { get; set; }
        public Nullable<System.DateTime> Sett_Date { get; set; }
        public int Sett_Flag { get; set; }
        public string Ref_BuyID { get; set; }
    }
}
