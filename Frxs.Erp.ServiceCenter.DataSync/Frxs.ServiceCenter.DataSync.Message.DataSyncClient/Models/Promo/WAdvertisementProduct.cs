using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WAdvertisementProduct
    {
        public int ID { get; set; }
        public Nullable<int> WID { get; set; }
        public int AdvertisementID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
