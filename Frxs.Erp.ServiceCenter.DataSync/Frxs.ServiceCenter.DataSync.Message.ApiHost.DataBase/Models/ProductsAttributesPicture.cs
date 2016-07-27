/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class ProductsAttributesPicture : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageUrlOrg { get; set; }
        public string ImageUrl400x400 { get; set; }
        public string ImageUrl200x200 { get; set; }
        public string ImageUrl120x120 { get; set; }
        public string ImageUrl60x60 { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
