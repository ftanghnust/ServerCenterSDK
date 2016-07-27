using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductAddPercDetail
    {
        public int ID { get; set; }
        public string PercID { get; set; }
        public int WID { get; set; }
        public int WProductID { get; set; }
        public int ProductID { get; set; }
        public decimal ShopAddPerc { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
