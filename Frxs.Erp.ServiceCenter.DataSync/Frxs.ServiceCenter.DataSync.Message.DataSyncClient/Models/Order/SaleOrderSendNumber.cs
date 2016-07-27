using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleOrderSendNumber
    {
        public string OrderID { get; set; }
        public int WID { get; set; }
        public int LineSerialNumber { get; set; }
        public int ShopSerialNumber { get; set; }
        public int SendNumber { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
