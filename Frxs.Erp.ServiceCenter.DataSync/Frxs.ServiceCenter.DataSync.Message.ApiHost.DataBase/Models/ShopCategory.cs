/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class ShopCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public string PageHomeImage { get; set; }
        public Nullable<int> ParentCategoryId { get; set; }
        public int Depth { get; set; }
        public int DisplaySequence { get; set; }
        public int IsDeleted { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
