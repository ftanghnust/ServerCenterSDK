using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SysParam
    {
        public string ParamCode { get; set; }
        public string ParamName { get; set; }
        public string ParamValue { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public int IsDisEdit { get; set; }
    }
}
