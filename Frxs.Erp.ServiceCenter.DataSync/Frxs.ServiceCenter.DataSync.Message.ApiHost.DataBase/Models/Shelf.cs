/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class Shelf : BaseEntity
    {
        public int ShelfID { get; set; }
        public string ShelfCode { get; set; }
        public int ShelfAreaID { get; set; }
        public string ShelfType { get; set; }
        public int WID { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
