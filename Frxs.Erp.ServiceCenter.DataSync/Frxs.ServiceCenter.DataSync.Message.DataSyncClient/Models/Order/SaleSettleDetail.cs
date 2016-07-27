using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleSettleDetail
    {
        public string ID { get; set; }
        public string SettleID { get; set; }
        public int WID { get; set; }
        public int BillType { get; set; }
        public string BillID { get; set; }
        public string BillDetailsID { get; set; }
        public System.DateTime BillDate { get; set; }
        public decimal BillAmt { get; set; }
        public decimal BillAddAmt { get; set; }
        public decimal BillPayAmt { get; set; }
        public string FeeCode { get; set; }
        public string FeeName { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
