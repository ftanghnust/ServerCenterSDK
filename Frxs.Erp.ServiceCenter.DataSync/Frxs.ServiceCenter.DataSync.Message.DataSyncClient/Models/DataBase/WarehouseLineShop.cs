using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WarehouseLineShop
    {
        public int ID { get; set; }
        public int LineID { get; set; }
        public int ShopID { get; set; }
        public Nullable<int> SerialNumber { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
