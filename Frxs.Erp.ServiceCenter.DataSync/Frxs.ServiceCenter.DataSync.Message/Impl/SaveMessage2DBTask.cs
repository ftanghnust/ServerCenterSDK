/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/6/12 17:51:30
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
using System;
using System.Threading;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 作业任务，将消息队列里的数据移到数据库;
    /// 注意此专业任务在注册到调度器的时候，不能和其他任意的作业任务归组。因为此专业任务属于线程阻塞
    /// </summary>
    //[TaskScheduler("sys", seconds: 1, enabled: true)]
    internal class SaveMessage2DBTask : ITask
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;
        private readonly DataSyncConfig _config;
        private readonly IMessageBodyFormatter _messageBodyFormatter;
        private readonly IEvenSelector _evenSelector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageBodyFormatter">消息摘要格式化器</param>
        /// <param name="logger">日志记录器</param>
        /// <param name="config">具体实现类配置信息</param>
        /// <param name="evenSelector">事件查找器</param>
        public SaveMessage2DBTask(
            ILogger logger,
            DataSyncConfig config,
            IMessageBodyFormatter messageBodyFormatter,
            IEvenSelector evenSelector)
        {
            config.CheckNullThrowArgumentNullException("config");
            messageBodyFormatter.CheckNullThrowArgumentNullException("messageBodyFormatter");
            evenSelector.CheckNullThrowArgumentNullException("evenSelector");

            this._messageBodyFormatter = messageBodyFormatter;
            this._evenSelector = evenSelector;
            this._config = config;
            this._logger = logger ?? NullLogger.Instance;
        }

        /// <summary>
        /// 将消息队列里的消息分发到存储介质
        /// </summary>
        /// <param name="taskExecuteContext"></param>
        public void Execute(TaskExecuteContext taskExecuteContext)
        {
            //初始化消息队列
            var messageQueue = new MSMQ(this._config.MSMQPath);

            //设置日志记录器
            messageQueue.Logger = this._logger;

            //同步接收消息
            messageQueue.Receive<Message<IMessageBody>>(message =>
            {
                try
                {
                    using (var lifeTimeScope = ServicesContainer.Current.Scope())
                    {
                        //重新获取到操作上下文
                        var dbContext = ServicesContainer.Current.Resolver<IDbContext>(lifeTimeScope);

                        //消息存储管理
                        var messageStoreManager = new DefaultMessageStoreManager(dbContext,
                                                                                this._logger,
                                                                                this._messageBodyFormatter,
                                                                                this._evenSelector);
                        //保存消息到数据库
                        messageStoreManager.SaveMessageToStore(message);

                        //限流
                        Thread.Sleep(this._config.ConsumeSpeed);
                    }
                }
                //记录下日志消息
                catch (Exception ex)
                {
                    this._logger.Error(ex);
                }
            });
        }
    }
}
