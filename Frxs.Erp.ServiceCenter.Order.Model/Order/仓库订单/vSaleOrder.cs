/*********************************************************
 * FRXS 小马哥 2016/4/20 19:28:53
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.Model.Order
{
    public class vSaleOrder
    {
        public string OrderId { get; set; }
        public string SettleID { get; set; }
        public int WID { get; set; }
        public int SubWID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderType { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public string SubWCode { get; set; }
        public string SubWName { get; set; }
        public int ShopID { get; set; }
        public int XSUserID { get; set; }
        public int ShopType { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public int Status { get; set; }
        public int ProvinceID { get; set; }
        public int CityID { get; set; }
        public int RegionID { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public string RevLinkMan { get; set; }
        public string RevTelephone { get; set; }
        public DateTime ConfDate { get; set; }
        public DateTime SendDate { get; set; }
        public int LineID { get; set; }
        public string LineName { get; set; }
        public int StationNumber { get; set; }
        public DateTime PickingBeginDate { get; set; }
        public DateTime PickingEndDate { get; set; }
        public double StockOutRate { get; set; }
        public int PackingEmpID { get; set; }
        public string PackingEmpName { get; set; }
        public DateTime PackingTime { get; set; }
        public int IsPrinted { get; set; }
        public DateTime PrintDate { get; set; }
        public int PrintUserID { get; set; }
        public string PrintUserName { get; set; }
        public DateTime ShippingBeginDate { get; set; }
        public int ShippingUserID { get; set; }
        public string ShippingUserName { get; set; }
        public DateTime ShippingEndDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string CloseReason { get; set; }
        public string Remark { get; set; }
        public double TotalProductAmt { get; set; }
        public double CouponAmt { get; set; }
        public double TotalAddAmt { get; set; }
        public double PayAmount { get; set; }
        public double TotalPoint { get; set; }
        public int TotalBasePoint { get; set; }
        public int UserShowFlag { get; set; }
        public int ClientType { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public DateTime ModifyTime { get; set; }
        public int ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }

    public class SaleOrderExt 
    {

        /// <summary>
        /// 门店ID
        /// </summary>
        public int ShopID { get; set; }

        /// <summary>
        /// OrderId
        /// </summary>
        public string OrderId { get; set; }


        

    }
}
