using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class ShopGroup
    {
        public int GroupID { get; set; }
        public string GroupCode { get; set; }
        public int WID { get; set; }
        public string GroupName { get; set; }
        public int IsDeleted { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
