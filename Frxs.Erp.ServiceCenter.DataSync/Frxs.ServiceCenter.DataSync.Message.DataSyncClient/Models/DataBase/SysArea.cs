using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SysArea
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int Level { get; set; }
        public Nullable<int> ParentID { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<int> SyncFale { get; set; }
    }
}
