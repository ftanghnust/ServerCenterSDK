using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WAdvertisement
    {
        public int AdvertisementID { get; set; }
        public Nullable<int> WID { get; set; }
        public Nullable<int> AdvertisementPosition { get; set; }
        public string AdvertisementName { get; set; }
        public int Sort { get; set; }
        public string ImagesSrc { get; set; }
        public string SelectImagesSrc { get; set; }
        public int AdvertisementType { get; set; }
        public int IsDelete { get; set; }
        public int IsLocked { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModityTime { get; set; }
        public int ModityUserID { get; set; }
        public string ModityUserName { get; set; }
    }
}
