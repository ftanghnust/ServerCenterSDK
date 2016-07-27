/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class SaleOrderPrePacking : BaseEntity
    {
        public string OrderID { get; set; }
        public int WID { get; set; }
        public int Package1Qty { get; set; }
        public int Package2Qty { get; set; }
        public Nullable<int> Package3Qty { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
