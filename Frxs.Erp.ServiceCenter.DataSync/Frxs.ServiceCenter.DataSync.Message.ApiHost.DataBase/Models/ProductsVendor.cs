/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProductsVendor : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int WID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int VendorID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        public decimal BuyPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsMaster { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<decimal> LastBuyPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> LastBuyTime { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        public System.DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> CreateUserID { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        public string CreateUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> ModifyTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> ModifyUserID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ModifyUserName { get; set; }
    }
}
