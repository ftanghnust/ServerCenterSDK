using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class ProductsUnit
    {
        public int ProductsUnitID { get; set; }
        public int ProductID { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> PackingQty { get; set; }
        public string Spec { get; set; }
        public int IsUnit { get; set; }
        public Nullable<int> IsSaleUnit { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
