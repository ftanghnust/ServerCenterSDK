using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WProductPromotionShop
    {
        public int ID { get; set; }
        public string PromotionID { get; set; }
        public int WID { get; set; }
        public int ShopID { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public int ShopType { get; set; }
        public string FullAddress { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
