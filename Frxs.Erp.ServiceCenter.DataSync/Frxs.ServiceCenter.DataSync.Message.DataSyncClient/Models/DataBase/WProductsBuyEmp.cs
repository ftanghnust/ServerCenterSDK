using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductsBuyEmp
    {
        public int ID { get; set; }
        public long WProductID { get; set; }
        public int WID { get; set; }
        public int EmpID { get; set; }
        public int SerialNumber { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
