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
    public partial class BaseProduct : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int BaseProductId { get; set; }
        public Nullable<int> CategoryId1 { get; set; }
        public Nullable<int> CategoryId2 { get; set; }
        public Nullable<int> CategoryId3 { get; set; }
        public Nullable<int> ShopCategoryId1 { get; set; }
        public Nullable<int> ShopCategoryId2 { get; set; }
        public Nullable<int> ShopCategoryId3 { get; set; }
        public Nullable<int> BrandId1 { get; set; }
        public Nullable<int> BrandId2 { get; set; }
        public Nullable<int> IsMutiAttribute { get; set; }
        public int IsBaseProductId { get; set; }
        public string ProductBaseName { get; set; }
        public int IsVendor { get; set; }
        public int IsDeleted { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
