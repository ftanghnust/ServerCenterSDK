using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleOrderPacking
    {
        public string OrderID { get; set; }
        public int WID { get; set; }
        public int Package1Qty { get; set; }
        public int Package2Qty { get; set; }
        public Nullable<int> Package3Qty { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
