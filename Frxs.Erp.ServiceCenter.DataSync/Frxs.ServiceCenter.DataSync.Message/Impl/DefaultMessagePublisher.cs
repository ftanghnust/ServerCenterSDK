/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/1/2016 10:49:37 AM
 * *******************************************************/
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl
{
    /// <summary>
    /// 系统框架默认实现的发布器
    /// </summary>
    internal class DefaultMessagePublisher : IMessagePublisher<IMessageBody>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataSyncConfig _config;
        private readonly ILogger _logger;
        private readonly IMessageIdGenerator _messageIdGenerator;
        private readonly IMessageStoreManager _messageStoreManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageIdGenerator">消息ID生成器</param>
        /// <param name="config">具体实现类配置信息</param>
        /// <param name="logger">日志记录器</param>
        /// <param name="messageStoreManager">消息存储器</param>
        public DefaultMessagePublisher(
            IMessageIdGenerator messageIdGenerator,
            DataSyncConfig config,
            ILogger logger,
            IMessageStoreManager messageStoreManager)
        {
            config.CheckNullThrowArgumentNullException("config");
            messageIdGenerator.CheckNullThrowArgumentNullException("messageIdGenerator");
            messageStoreManager.CheckNullThrowArgumentNullException("messageStoreManager");

            this._config = config;
            this._logger = logger ?? NullLogger.Instance;
            this._messageIdGenerator = messageIdGenerator;
            this._messageStoreManager = messageStoreManager;
        }

        /// <summary>
        /// 默认的发布器，默认实现存储到MSMQ里面
        /// </summary>
        /// <param name="message">领域消息对象</param>
        /// <returns></returns>
        public bool Publish(Message<IMessageBody> message)
        {
            message.CheckNullThrowArgumentNullException("message");

            //未设置消息编号，就设置下
            if (message.Id.IsNullOrEmpty())
            {
                message.Id = this._messageIdGenerator.GetNextId();
            }

            //设置了使用消息队列来进行消息缓冲
            if (this._config.UseMSMQ)
            {
                //直接将消息抛给消息队列
                var messageQueue = new MSMQ(this._config.MSMQPath);
                //设置日志记录器
                messageQueue.Logger = this._logger;
                //返回是否发送成功
                return messageQueue.Send(message, message.Id);
            }
            else
            {
                //直接存储到存储介质
                return this._messageStoreManager.SaveMessageToStore(message);
            }
        }
    }
}