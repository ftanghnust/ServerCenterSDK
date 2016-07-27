using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SysParamsWH
    {
        public int ID { get; set; }
        public int WID { get; set; }
        public string ParamCode { get; set; }
        public string ParamValue { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
