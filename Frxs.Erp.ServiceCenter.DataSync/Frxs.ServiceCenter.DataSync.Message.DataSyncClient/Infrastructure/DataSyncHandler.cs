/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/21/2016 1:35:05 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 全量同步接口
    /// </summary>
    public abstract class DataSyncHandler : IDataSyncHandler
    {
        /// <summary>
        /// 同步完成
        /// </summary>
        public Action<ExecutedEventArgs> OnExecuted { get; set; }

        /// <summary>
        /// 开始同步
        /// </summary>
        public Action<ExecutingEventArgs> OnExecuting { get; set; }

        /// <summary>
        /// 单个项目同步完成
        /// </summary>
        public Action<ItemSyncCompleteEventArgs> OnItemSyncComplete { get; set; }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public virtual int PageSize { get { return 500; } }

        /// <summary>
        /// 
        /// </summary>
        public DataSyncHandler()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Execute();
    }
}
