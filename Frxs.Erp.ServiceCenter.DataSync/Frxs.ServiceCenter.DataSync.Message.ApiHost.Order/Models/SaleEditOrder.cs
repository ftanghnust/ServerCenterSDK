/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class SaleEditOrder : BaseEntity
    {
        public string ID { get; set; }
        public string EditID { get; set; }
        public int WID { get; set; }
        public string OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime SendDate { get; set; }
        public int ShopID { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public int ProcFlag { get; set; }
        public string ProcRemark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
