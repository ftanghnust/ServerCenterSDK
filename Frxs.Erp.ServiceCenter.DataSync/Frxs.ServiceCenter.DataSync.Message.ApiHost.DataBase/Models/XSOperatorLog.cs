/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class XSOperatorLog : BaseEntity
    {
        public long ID { get; set; }
        public Nullable<int> WID { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string Action { get; set; }
        public string Remark { get; set; }
        public int OperatorID { get; set; }
        public string OperatorName { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
