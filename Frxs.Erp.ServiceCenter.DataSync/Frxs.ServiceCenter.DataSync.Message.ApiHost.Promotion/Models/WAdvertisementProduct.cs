/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models
{
    public partial class WAdvertisementProduct : BaseEntity
    {
        public int ID { get; set; }
        public Nullable<int> WID { get; set; }
        public int AdvertisementID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
