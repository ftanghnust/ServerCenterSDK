/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class Settlement : BaseEntity
    {
        public string ID { get; set; }
        public string SettleNo { get; set; }
        public int Status { get; set; }
        public int WID { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public int SubWID { get; set; }
        public string SubWCode { get; set; }
        public string SubWName { get; set; }
        public System.DateTime SettleDate { get; set; }
        public System.DateTime SettleStartTime { get; set; }
        public System.DateTime SettleEndTime { get; set; }
        public decimal BeginQty { get; set; }
        public decimal BeginAmt { get; set; }
        public decimal BuyQty { get; set; }
        public decimal BuyAmt { get; set; }
        public decimal BuyBackQty { get; set; }
        public decimal BuyBackAmt { get; set; }
        public decimal SaleQty { get; set; }
        public decimal SaleAmt { get; set; }
        public decimal SaleBackQty { get; set; }
        public decimal SaleBackAmt { get; set; }
        public decimal AdjGainQty { get; set; }
        public decimal AjgGginAmt { get; set; }
        public decimal AdjLossQty { get; set; }
        public decimal AjgLosssAmt { get; set; }
        public decimal StockQty { get; set; }
        public decimal StockAmt { get; set; }
        public decimal EndQty { get; set; }
        public decimal EndStockAmt { get; set; }
        public decimal EndDiffQty { get; set; }
        public decimal EndDiffStockAmt { get; set; }
        public decimal SaleSubBasePoint { get; set; }
        public decimal SaleSubPoint { get; set; }
        public decimal SaleSubAddAmt { get; set; }
        public decimal SaleSubVendor1Amt { get; set; }
        public decimal SaleSubVendor2Amt { get; set; }
        public decimal BackSubAddAmt { get; set; }
        public decimal BackSubVendor1Amt { get; set; }
        public decimal BackSubVendor2Amt { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public string Remark { get; set; }
    }
}
