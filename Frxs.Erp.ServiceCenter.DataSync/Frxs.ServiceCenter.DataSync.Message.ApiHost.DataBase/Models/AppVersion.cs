/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/5 09:30:46
 * *******************************************************/
using System;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AppVersion : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SysType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AppType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CurVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DownUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UpdateFlag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UpdateRemark { get; set; }

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
