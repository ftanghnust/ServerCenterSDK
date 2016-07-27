using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class BuyPreAppDetailsExt
    {
        public string ID { get; set; }
        public string AppID { get; set; }
        public int CategoryId1 { get; set; }
        public string CategoryId1Name { get; set; }
        public int CategoryId2 { get; set; }
        public string CategoryId2Name { get; set; }
        public int CategoryId3 { get; set; }
        public string CategoryId3Name { get; set; }
        public int ShopCategoryId1 { get; set; }
        public string ShopCategoryId1Name { get; set; }
        public int ShopCategoryId2 { get; set; }
        public string ShopCategoryId2Name { get; set; }
        public int ShopCategoryId3 { get; set; }
        public string ShopCategoryId3Name { get; set; }
        public Nullable<int> BrandId1 { get; set; }
        public string BrandId1Name { get; set; }
        public Nullable<int> BrandId2 { get; set; }
        public string BrandId2Name { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
