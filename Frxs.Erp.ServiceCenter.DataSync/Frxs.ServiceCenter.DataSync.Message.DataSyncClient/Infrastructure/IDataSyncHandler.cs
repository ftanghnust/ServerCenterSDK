/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/21/2016 1:35:05 PM
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 全量同步接口
    /// </summary>
    public interface IDataSyncHandler
    {
        /// <summary>
        /// 开始同步
        /// </summary>
        Action<ExecutingEventArgs> OnExecuting { get; set; }

        /// <summary>
        /// 同步完成
        /// </summary>
        Action<ExecutedEventArgs> OnExecuted { get; set; }

        /// <summary>
        /// 单个项目同步完成
        /// </summary>
        Action<ItemSyncCompleteEventArgs> OnItemSyncComplete { get; set; }

        /// <summary>
        /// 同步
        /// </summary>
        void Execute();
    }
}
