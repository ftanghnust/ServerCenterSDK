/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class Shop : BaseEntity
    {
        public int ShopID { get; set; }
        public string ShopCode { get; set; }
        public int ShopType { get; set; }
        public string ShopName { get; set; }
        public string ShopAccount { get; set; }
        public string SettleType { get; set; }
        public int WID { get; set; }
        public string LinkMan { get; set; }
        public string Telephone { get; set; }
        public int Status { get; set; }
        public string LegalPerson { get; set; }
        public string SettleTimeType { get; set; }
        public string CreditLevel { get; set; }
        public decimal CreditAmt { get; set; }
        public string AreaPrincipal { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public decimal ShopArea { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal TotalPoint { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountName { get; set; }
        public string BankType { get; set; }
        public string CardID { get; set; }
        public string RegionMaster { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public Nullable<int> SyncFale { get; set; }
    }
}
