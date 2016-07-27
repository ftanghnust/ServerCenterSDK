/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/4/2016 10:05:08 AM
 * *******************************************************/

namespace Frxs.ServiceCenter.DataSync.Message.PublisherClient
{
    /// <summary>
    /// 发布结果
    /// </summary>
    public class PublishResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess">是否发布成功</param>
        /// <param name="messageId">此次发布的消息ID</param>
        /// <param name="message">返回的消息</param>
        public PublishResult(bool isSuccess, string messageId, string message)
        {
            this.IsSuccess = isSuccess;
            this.MessageId = messageId;
            this.Message = message;
        }

        /// <summary>
        /// 是否发布成功
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 此次发布的消息ID
        /// </summary>
        public string MessageId { get; private set; }
    }
}
