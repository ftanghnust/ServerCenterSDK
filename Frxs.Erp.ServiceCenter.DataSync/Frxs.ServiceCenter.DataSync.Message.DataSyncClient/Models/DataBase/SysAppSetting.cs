using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SysAppSetting
    {
        public int ID { get; set; }
        public int WID { get; set; }
        public string SKey { get; set; }
        public string SVal1 { get; set; }
        public string SVal2 { get; set; }
        public string SVal3 { get; set; }
        public string SVal4 { get; set; }
        public string SVal5 { get; set; }
        public string SVal6 { get; set; }
        public string SVal7 { get; set; }
        public string SVal8 { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
