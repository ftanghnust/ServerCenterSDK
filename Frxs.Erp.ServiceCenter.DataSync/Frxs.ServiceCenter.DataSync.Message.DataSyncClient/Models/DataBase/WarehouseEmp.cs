using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class WarehouseEmp
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string UserAccount { get; set; }
        public int UserType { get; set; }
        public Nullable<int> IsMaster { get; set; }
        public int WID { get; set; }
        public string UserMobile { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int IsFrozen { get; set; }
        public int IsLocked { get; set; }
        public int IsDeleted { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public Nullable<System.DateTime> LastPasswordChangeTime { get; set; }
        public Nullable<int> FailedPasswordCount { get; set; }
        public Nullable<System.DateTime> FailedPasswordLockTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
