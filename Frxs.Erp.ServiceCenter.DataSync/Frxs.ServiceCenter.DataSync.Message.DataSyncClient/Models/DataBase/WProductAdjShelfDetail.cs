using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductAdjShelfDetail
    {
        public long ID { get; set; }
        public string AdjID { get; set; }
        public int WID { get; set; }
        public int WProductID { get; set; }
        public int ProductId { get; set; }
        public string Unit { get; set; }
        public int OldShelfID { get; set; }
        public string OldShelfCode { get; set; }
        public int ShelfID { get; set; }
        public string ShelfCode { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
