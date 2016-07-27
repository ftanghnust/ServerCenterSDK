/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/22/2016 5:21:13 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 开始同步
    /// </summary>
    public class ExecutingEventArgs : EventArgs
    {
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页码数
        /// </summary>
        public int TotalPages { get; set; }
    }
}
