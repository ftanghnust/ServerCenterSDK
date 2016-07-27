/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class ProductsDescription : BaseEntity
    {
        public int BaseProductId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
