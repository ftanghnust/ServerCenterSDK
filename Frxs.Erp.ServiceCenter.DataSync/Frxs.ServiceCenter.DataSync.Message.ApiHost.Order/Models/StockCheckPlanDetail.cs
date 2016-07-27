/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class StockCheckPlanDetail : BaseEntity
    {
        public string ID { get; set; }
        public string PlanID { get; set; }
        public int BaseInfoID { get; set; }
        public string BaseInfoCode { get; set; }
        public string BaseInfoName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}
