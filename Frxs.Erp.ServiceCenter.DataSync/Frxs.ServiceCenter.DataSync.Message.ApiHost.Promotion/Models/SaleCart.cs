/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion.Models
{
    public partial class SaleCart : BaseEntity
    {
        public long ID { get; set; }
        public int WID { get; set; }
        public int ShopID { get; set; }
        public int XSUserID { get; set; }
        public int ProductID { get; set; }
        public decimal PreQty { get; set; }
        public string Remark { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
