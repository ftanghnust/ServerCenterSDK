using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string ProductName2 { get; set; }
        public int BaseProductId { get; set; }
        public Nullable<int> ImageProductId { get; set; }
        public string Mnemonic { get; set; }
        public string Keywords { get; set; }
        public int IsDeleted { get; set; }
        public int Status { get; set; }
        public string TXTKID { get; set; }
        public string MutAttributes { get; set; }
        public string MutValues { get; set; }
        public string SaleBackFlag { get; set; }
        public Nullable<int> BackDays { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<int> SyncFale { get; set; }
        public string SyncSM { get; set; }
        public string VExt1 { get; set; }
        public string VExt2 { get; set; }
    }
}