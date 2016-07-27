using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductAdjShelf
    {
        public string AdjID { get; set; }
        public int WID { get; set; }
        public int Status { get; set; }
        public int AdjType { get; set; }
        public Nullable<System.DateTime> ConfTime { get; set; }
        public Nullable<int> ConfUserID { get; set; }
        public string ConfUserName { get; set; }
        public Nullable<System.DateTime> PostingTime { get; set; }
        public Nullable<int> PostingUserID { get; set; }
        public string PostingUserName { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
