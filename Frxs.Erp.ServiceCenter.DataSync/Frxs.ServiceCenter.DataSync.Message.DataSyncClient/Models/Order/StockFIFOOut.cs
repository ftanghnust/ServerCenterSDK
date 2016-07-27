using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class StockFIFOOut
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
