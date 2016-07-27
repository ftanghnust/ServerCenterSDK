/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class SaleOrderShelfArea : BaseEntity
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public int WID { get; set; }
        public Nullable<int> Package1Qty { get; set; }
        public Nullable<int> Package2Qty { get; set; }
        public Nullable<int> Package3Qty { get; set; }
        public Nullable<int> Remark { get; set; }
        public int ShelfAreaID { get; set; }
        public string ShelfAreaCode { get; set; }
        public string ShelfAreaName { get; set; }
        public Nullable<int> PickUserID { get; set; }
        public string PickUserName { get; set; }
        public Nullable<System.DateTime> BeginTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public Nullable<int> CheckUserID { get; set; }
        public string CheckUserName { get; set; }
    }
}
