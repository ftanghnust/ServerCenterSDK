/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class StockFIFOOut : BaseEntity
    {
        public long OutID { get; set; }
        public long InID { get; set; }
        public int WID { get; set; }
        public int SubWID { get; set; }
        public int ProductID { get; set; }
        public decimal StockQty { get; set; }
        public int BillType { get; set; }
        public string BillID { get; set; }
        public string BillDetailID { get; set; }
        public decimal OutQty { get; set; }
        public int VendorID { get; set; }
        public System.DateTime StockTime { get; set; }
    }
}
