/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using System.Collections.Generic;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    public partial class WarehouseLine : BaseEntity
    {
        public int LineID { get; set; }
        public string LineCode { get; set; }
        public int WID { get; set; }
        public string LineName { get; set; }
        public int EmpID { get; set; }
        public int SendW1 { get; set; }
        public int SendW2 { get; set; }
        public int SendW6 { get; set; }
        public int SendW5 { get; set; }
        public int SendW4 { get; set; }
        public int SendW3 { get; set; }
        public int SendW7 { get; set; }
        public System.TimeSpan OrderEndTime { get; set; }
        public int Distance { get; set; }
        public Nullable<int> SendNeedTime { get; set; }
        public Nullable<int> SerialNumber { get; set; }
        public string Remark { get; set; }
        public int IsLocked { get; set; }
        public int IsDeleted { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
