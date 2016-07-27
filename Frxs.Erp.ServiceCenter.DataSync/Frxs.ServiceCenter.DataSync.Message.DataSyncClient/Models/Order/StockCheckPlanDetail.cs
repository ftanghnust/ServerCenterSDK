using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class StockCheckPlanDetail
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
