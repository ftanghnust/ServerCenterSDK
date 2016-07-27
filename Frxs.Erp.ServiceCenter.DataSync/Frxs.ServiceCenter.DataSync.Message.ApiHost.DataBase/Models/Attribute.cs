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
    public partial class Attribute : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int AttributeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AttributeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsDeleted { get; set; }
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
        public System.DateTime ModifyTime { get; set; }
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
