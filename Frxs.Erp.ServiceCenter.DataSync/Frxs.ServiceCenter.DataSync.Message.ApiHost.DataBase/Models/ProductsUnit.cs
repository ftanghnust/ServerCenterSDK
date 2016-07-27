/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class ProductsUnit : BaseEntity
    {
        public int ProductsUnitID { get; set; }
        public int ProductID { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> PackingQty { get; set; }
        public string Spec { get; set; }
        public int IsUnit { get; set; }
        public Nullable<int> IsSaleUnit { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
