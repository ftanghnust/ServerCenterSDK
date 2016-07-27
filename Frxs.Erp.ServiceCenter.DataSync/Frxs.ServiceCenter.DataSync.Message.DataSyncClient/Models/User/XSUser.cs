using System;
using System.Collections.Generic;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient.Models
{
    public partial class XSUser
    {
        public int XSUserID { get; set; }
        public string XSUserName { get; set; }
        public string UserAccount { get; set; }
        public int UserType { get; set; }
        public string UserMobile { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int IsFrozen { get; set; }
        public int IsLocked { get; set; }
        public int IsDeleted { get; set; }
        public System.DateTime LastLoginTime { get; set; }
        public System.DateTime LastPasswordChangeTime { get; set; }
        public int FailedPasswordCount { get; set; }
        public Nullable<System.DateTime> FailedPasswordLockTime { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public string ModifyUserName { get; set; }
    }
}
