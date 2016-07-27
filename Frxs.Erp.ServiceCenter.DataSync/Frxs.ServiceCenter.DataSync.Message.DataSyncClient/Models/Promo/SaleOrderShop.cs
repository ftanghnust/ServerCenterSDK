using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class SaleOrderShop
    {
        public string OrderId { get; set; }
        public string SettleID { get; set; }
        public int WID { get; set; }
        public Nullable<int> SubWID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int OrderType { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public string SubWCode { get; set; }
        public string SubWName { get; set; }
        public int ShopID { get; set; }
        public int XSUserID { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public int Status { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public string RevLinkMan { get; set; }
        public string RevTelephone { get; set; }
        public Nullable<System.DateTime> ConfDate { get; set; }
        public System.DateTime SendDate { get; set; }
        public Nullable<int> LineID { get; set; }
        public string LineName { get; set; }
        public Nullable<int> StationNumber { get; set; }
        public Nullable<System.DateTime> PickingBeginDate { get; set; }
        public Nullable<System.DateTime> PickingEndDate { get; set; }
        public Nullable<int> PackingEmpID { get; set; }
        public string PackingEmpName { get; set; }
        public Nullable<System.DateTime> PackingTime { get; set; }
        public int IsPrinted { get; set; }
        public Nullable<System.DateTime> PrintDate { get; set; }
        public Nullable<int> PrintUserID { get; set; }
        public string PrintUserName { get; set; }
        public Nullable<System.DateTime> ShippingBeginDate { get; set; }
        public Nullable<int> ShippingUserID { get; set; }
        public string ShippingUserName { get; set; }
        public Nullable<System.DateTime> ShippingEndDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<System.DateTime> CancelDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public string CloseReason { get; set; }
        public string Remark { get; set; }
        public decimal TotalProductAmt { get; set; }
        public decimal CouponAmt { get; set; }
        public Nullable<decimal> TotalAddAmt { get; set; }
        public decimal PayAmount { get; set; }
        public decimal TotalPoint { get; set; }
        public Nullable<decimal> TotalBasePoint { get; set; }
        public int UserShowFlag { get; set; }
        public int ClientType { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
