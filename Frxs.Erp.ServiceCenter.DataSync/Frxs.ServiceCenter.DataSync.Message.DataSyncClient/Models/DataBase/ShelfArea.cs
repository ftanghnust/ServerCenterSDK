using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class ShelfArea
    {
        public int ShelfAreaID { get; set; }
        public int WID { get; set; }
        public string ShelfAreaCode { get; set; }
        public string ShelfAreaName { get; set; }
        public int PickingMaxRecord { get; set; }
        public int SerialNumber { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
