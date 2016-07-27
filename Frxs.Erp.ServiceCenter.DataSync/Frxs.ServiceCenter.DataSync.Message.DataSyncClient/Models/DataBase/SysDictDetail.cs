using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SysDictDetail
    {
        public int ID { get; set; }
        public string DictCode { get; set; }
        public string DictValue { get; set; }
        public string DictLabel { get; set; }
        public int SerialNumber { get; set; }
        public string Remark { get; set; }
        public int IsDeleted { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
