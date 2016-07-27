/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.User.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class XSUserShop : BaseEntity
    {
        public int ID { get; set; }
        public int XSUserID { get; set; }
        public Nullable<int> ShopID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
