using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class Shelf
    {
        public int ShelfID { get; set; }
        public string ShelfCode { get; set; }
        public int ShelfAreaID { get; set; }
        public string ShelfType { get; set; }
        public int WID { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
