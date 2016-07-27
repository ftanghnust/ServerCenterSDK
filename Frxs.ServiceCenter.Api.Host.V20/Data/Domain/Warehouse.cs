/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/9 14:29:53
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Host.Data.Domain
{
    /// <summary>
    ///  仓库信息
    /// </summary>
    [Serializable]
    public class Warehouse : BaseEntity
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WHID { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WHName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Warehouse Parent { get; set; }

    }
}