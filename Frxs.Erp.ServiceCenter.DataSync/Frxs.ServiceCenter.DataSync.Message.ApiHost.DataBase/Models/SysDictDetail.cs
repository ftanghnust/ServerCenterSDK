/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;
namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class SysDictDetail : BaseEntity
    {
        public int ID { get; set; }
        public string DictCode { get; set; }
        public string DictValue { get; set; }
        public string DictLabel { get; set; }
        public int SerialNumber { get; set; }
        public string Remark { get; set; }
        public int IsDeleted { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
