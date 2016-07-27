using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class ProductsAttribute
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public int ValuesId { get; set; }
        public string ValueStr { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
