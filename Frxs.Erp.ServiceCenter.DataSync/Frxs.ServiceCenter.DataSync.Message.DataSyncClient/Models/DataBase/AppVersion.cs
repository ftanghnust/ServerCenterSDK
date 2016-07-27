using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class AppVersion
    {
        public int ID { get; set; }
        public int SysType { get; set; }
        public int AppType { get; set; }
        public string CurVersion { get; set; }
        public string DownUrl { get; set; }
        public int UpdateFlag { get; set; }
        public string UpdateRemark { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
