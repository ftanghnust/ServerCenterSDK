/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models
{
    public partial class WarehouseMessage : BaseEntity
    {
        public int ID { get; set; }
        public int WID { get; set; }
        public string Title { get; set; }
        public int MessageType { get; set; }
        public Nullable<int> RangType { get; set; }
        public System.DateTime BeginTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> ConfTime { get; set; }
        public Nullable<int> ConfUserID { get; set; }
        public string ConfUserName { get; set; }
        public int IsFirst { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModityTime { get; set; }
        public Nullable<int> ModityUserID { get; set; }
        public string ModityUserName { get; set; }
    }
}
