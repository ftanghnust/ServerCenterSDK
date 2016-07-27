/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;
namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Models
{
    public partial class SaleOrderDetailsPick : BaseEntity
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public int ProductID { get; set; }
        public int WCProductID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string ProductImageUrl200 { get; set; }
        public string ProductImageUrl400 { get; set; }
        public Nullable<int> ShelfAreaID { get; set; }
        public Nullable<int> ShelfID { get; set; }
        public string ShelfCode { get; set; }
        public decimal SaleQty { get; set; }
        public string SaleUnit { get; set; }
        public Nullable<decimal> SalePackingQty { get; set; }
        public Nullable<decimal> PickQty { get; set; }
        public Nullable<int> PickUserID { get; set; }
        public string PickUserName { get; set; }
        public Nullable<System.DateTime> PickTime { get; set; }
        public Nullable<System.DateTime> CheckTime { get; set; }
        public Nullable<int> CheckUserID { get; set; }
        public string CheckUserName { get; set; }
        public Nullable<int> IsCheckRight { get; set; }
        public Nullable<int> IsAppend { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<decimal> CheckQty { get; set; }
    }
}
