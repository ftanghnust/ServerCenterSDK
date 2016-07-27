using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductNoSaleShop
    {
        public int ID { get; set; }
        public string NoSaleID { get; set; }
        public int WID { get; set; }
        public int GroupID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
