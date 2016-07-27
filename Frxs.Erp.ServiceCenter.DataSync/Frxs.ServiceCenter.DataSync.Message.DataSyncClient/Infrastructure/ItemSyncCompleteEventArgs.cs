/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/22/2016 5:21:48 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemSyncCompleteEventArgs : EventArgs
    {
        /// <summary>
        /// 当前同步记录在总记录数索引号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 同步状态
        /// </summary>
        public SyncStatus Status { get; set; }

        /// <summary>
        /// 同步后返回的消息
        /// </summary>
        public string Message { get; set; }

    }
}
