using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SettlementDetail
    {
        public int ID { get; set; }
        public string RefSet_ID { get; set; }
        public string SKU { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> BuyPrice { get; set; }
        public Nullable<decimal> SalePrice { get; set; }
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
        public decimal SubBasePoint { get; set; }
        public decimal SubPoint { get; set; }
        public decimal SaleSubAddAmt { get; set; }
        public decimal SaleSubVendor1Amt { get; set; }
        public decimal SaleSubVendor2Amt { get; set; }
        public decimal BackSubAddAmt { get; set; }
        public decimal BackSubVendor1Amt { get; set; }
        public decimal BackSubVendor2Amt { get; set; }
        public int CategoryId1 { get; set; }
        public string CategoryId1Name { get; set; }
        public int CategoryId2 { get; set; }
        public string CategoryId2Name { get; set; }
        public int CategoryId3 { get; set; }
        public string CategoryId3Name { get; set; }
        public int ShopCategoryId1 { get; set; }
        public string ShopCategoryId1Name { get; set; }
        public int ShopCategoryId2 { get; set; }
        public string ShopCategoryId2Name { get; set; }
        public int ShopCategoryId3 { get; set; }
        public string ShopCategoryId3Name { get; set; }
        public Nullable<int> BrandId1 { get; set; }
        public string BrandId1Name { get; set; }
        public Nullable<int> BrandId2 { get; set; }
        public string BrandId2Name { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
