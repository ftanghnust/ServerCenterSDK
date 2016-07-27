/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class SaleOrderTrack : BaseEntity
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public int WID { get; set; }
        public string Remark { get; set; }
        public Nullable<int> IsDisplayUser { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public string OrderStatusName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
