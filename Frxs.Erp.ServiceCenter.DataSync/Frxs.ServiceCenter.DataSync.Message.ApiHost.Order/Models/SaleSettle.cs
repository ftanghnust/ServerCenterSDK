/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class SaleSettle : BaseEntity
    {
        public string SettleID { get; set; }
        public int WID { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public int Status { get; set; }
        public decimal SaleAmt { get; set; }
        public decimal BackAmt { get; set; }
        public decimal FeeAmt { get; set; }
        public decimal SettleAmt { get; set; }
        public Nullable<System.DateTime> SettleTime { get; set; }
        public string OrderID { get; set; }
        public int ShopID { get; set; }
        public string ShopCode { get; set; }
        public int ShopType { get; set; }
        public string ShopName { get; set; }
        public Nullable<decimal> CreditAmt { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountName { get; set; }
        public string BankType { get; set; }
        public string Remark { get; set; }
        public string SettleType { get; set; }
        public string SettleName { get; set; }
        public Nullable<System.DateTime> ConfTime { get; set; }
        public Nullable<int> ConfUserID { get; set; }
        public string ConfUserName { get; set; }
        public Nullable<System.DateTime> PostingTime { get; set; }
        public Nullable<int> PostingUserID { get; set; }
        public string PostingUserName { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
