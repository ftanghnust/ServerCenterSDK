using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class ProductsBarCode
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string BarCode { get; set; }
        public int SerialNumber { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
