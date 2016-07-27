/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class Warehouse : BaseEntity
    {
        public int WID { get; set; }
        public string WCode { get; set; }
        public string WName { get; set; }
        public int WLevel { get; set; }
        public Nullable<int> WSubType { get; set; }
        public Nullable<int> ParentWID { get; set; }
        public string WTel { get; set; }
        public string WContact { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string WAddress { get; set; }
        public string WFullAddress { get; set; }
        public string WCustomerServiceTel { get; set; }
        public string THBTel { get; set; }
        public string CWTel { get; set; }
        public string YW1Tel { get; set; }
        public string YW2Tel { get; set; }
        public string Remark { get; set; }
        public int IsFreeze { get; set; }
        public int IsDeleted { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModityTime { get; set; }
        public int ModityUserID { get; set; }
        public string ModityUserName { get; set; }
        public Nullable<int> SyncFale { get; set; }
    }
}
