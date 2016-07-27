using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WarehouseEmpShelf
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public int ShelfAreaID { get; set; }
        public Nullable<int> ShelfID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
