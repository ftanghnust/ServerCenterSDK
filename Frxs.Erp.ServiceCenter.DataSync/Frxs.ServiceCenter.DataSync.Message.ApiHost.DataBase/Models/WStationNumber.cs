/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class WStationNumber : BaseEntity
    {
        public int ID { get; set; }
        public int WID { get; set; }
        public int StationNumber { get; set; }
        public int Status { get; set; }
        public Nullable<int> ShopID { get; set; }
        public string OrderID { get; set; }
        public Nullable<System.DateTime> OrderConfDate { get; set; }
        public Nullable<int> LineID { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
