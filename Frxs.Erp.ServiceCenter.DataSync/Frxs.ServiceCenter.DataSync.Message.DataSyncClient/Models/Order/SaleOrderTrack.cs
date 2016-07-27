using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleOrderTrack
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public int WID { get; set; }
        public string Remark { get; set; }
        public Nullable<int> IsDisplayUser { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public string OrderStatusName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
