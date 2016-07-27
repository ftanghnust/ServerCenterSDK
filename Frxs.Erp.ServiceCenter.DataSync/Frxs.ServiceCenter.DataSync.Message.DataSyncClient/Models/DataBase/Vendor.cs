using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class Vendor
    {
        public int VendorID { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorShortName { get; set; }
        public int VendorTypeID { get; set; }
        public string LinkMan { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public int Status { get; set; }
        public string LegalPerson { get; set; }
        public string Email { get; set; }
        public string WebUrl { get; set; }
        public string Region { get; set; }
        public string SettleTimeType { get; set; }
        public string CreditLevel { get; set; }
        public string AreaPrincipal { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public int IsDeleted { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
        public string PaymentDateType { get; set; }
        public Nullable<int> SyncFale { get; set; }
        public string SyncSM { get; set; }
        public string VExt1 { get; set; }
        public string VExt2 { get; set; }
    }
}
