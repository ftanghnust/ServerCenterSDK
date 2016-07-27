/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class ProductsAttribute : BaseEntity
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
