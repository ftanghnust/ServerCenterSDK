using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class ProductsDescriptionPicture
    {
        public int ID { get; set; }
        public Nullable<int> BaseProductId { get; set; }
        public string ImageUrlOrg { get; set; }
        public string ImageUrl400x400 { get; set; }
        public string ImageUrl200x200 { get; set; }
        public string ImageUrl120x120 { get; set; }
        public string ImageUrl60x60 { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
