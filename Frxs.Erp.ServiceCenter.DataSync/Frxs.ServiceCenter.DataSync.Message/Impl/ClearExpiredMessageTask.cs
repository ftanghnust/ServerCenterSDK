using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 8:42:42 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 定期清理过期的消息数据（根据系统配置设置，发布的消息在存储
    /// 介质里保存N天后，自动被清理）
    /// </summary>
    internal class ClearExpiredMessageTask : ITask
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;
        private readonly IDbContext _dbContext;
        private readonly DataSyncConfig _config;
        private readonly IMessageStoreManager _messageStoreManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageStoreManager">消息存储管理器</param>
        /// <param name="dbContext">数据库操作上下文</param>
        /// <param name="logger">日志记录器</param>
        /// <param name="config">具体实现类配置信息</param>
        public ClearExpiredMessageTask(
            IMessageStoreManager messageStoreManager,
            IDbContext dbContext,
            ILogger logger,
            DataSyncConfig config)
        {
            messageStoreManager.CheckNullThrowArgumentNullException("messageStoreManager");
            dbContext.CheckNullThrowArgumentNullException("dbContext");
            config.CheckNullThrowArgumentNullException("config");

            this._messageStoreManager = messageStoreManager;
            this._dbContext = dbContext;
            this._config = config;
            this._logger = logger ?? NullLogger.Instance;
        }

        /// <summary>
        /// 作业任务开始
        /// </summary>
        /// <param name="taskExecuteContext">当前执行任务上下文对象</param>
        public void Execute(TaskExecuteContext taskExecuteContext)
        {
            //过期的截止时间
            DateTime expiredDateTime = DateTime.Now.AddDays(-this._config.MessageExpriedDays);

            //删除过期消息sql
            string sql = "DELETE FROM [{0}] WHERE Created < @p0";

            try
            {
                //先清理主消息表数据
                int result = this._dbContext.ExecuteSqlCommand(sql
                    .With(this._messageStoreManager.GetGlobalMessageStoreName()),
                       false, null, new object[] { expiredDateTime });

                //日志
                this._logger.Information(Resource.Resource.ClearExpiredMessageTask_DeleteMessage
                    .With(this._messageStoreManager.GetGlobalMessageStoreName(), result, expiredDateTime));

                //在清理所有的分发表
                foreach (var item in this._messageStoreManager.GetMessageStores())
                {
                    result = this._dbContext.ExecuteSqlCommand(sql.With(item.StorageName),
                         false, null, new object[] { expiredDateTime });

                    //日志
                    this._logger.Information(Resource.Resource.ClearExpiredMessageTask_DeleteMessage
                        .With(item.StorageName, result, expiredDateTime));
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex);
            }
        }
    }
}
