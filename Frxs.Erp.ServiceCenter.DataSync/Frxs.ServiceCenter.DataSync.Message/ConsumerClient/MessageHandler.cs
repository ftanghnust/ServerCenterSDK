/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 5:16:38 PM
 * *******************************************************/
using System;
using System.Linq;
using RestSharp;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 消息消费客户端
    /// </summary>
    public partial class MessageHandler
    {
        /// <summary>
        /// 初始化消息消费客户端
        /// </summary>
        /// <param name="messageServerUrl">消息中间件服务器地址</param>
        /// <param name="josnSerializer">JOSN格式化器</param>
        /// <param name="wid">如果为null，默认将仓库设置为0</param>
        public MessageHandler(string messageServerUrl, IJosnSerializer josnSerializer, Func<int> wid = null)
        {
            if (string.IsNullOrEmpty(messageServerUrl))
                throw new ArgumentNullException(messageServerUrl);
            if (null == josnSerializer)
                throw new ArgumentNullException("objectJosnSerializer");

            this.MessageServerUrl = messageServerUrl;
            this.JosnSerializer = josnSerializer;
            this.WID = wid == null ? 0 : wid();
            this.MaxRetries = 3;
        }

        /// <summary>
        /// 消息中间件服务器地址
        /// </summary>
        public string MessageServerUrl { get; private set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public int WID { get; private set; }

        /// <summary>
        /// JSON序列化接口
        /// </summary>
        public IJosnSerializer JosnSerializer { get; private set; }

        /// <summary>
        /// 消息处理的出现错误，重试次数，默认3次
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// 执行远程调用
        /// </summary>
        /// <param name="startMessageId"></param>
        /// <param name="number"></param>
        private ResponseResult<dynamic> Execute(string startMessageId, int number)
        {
            try
            {
                var client = new RestClient(this.MessageServerUrl);
                var request = new RestRequest(Method.POST);
                request.AddParameter("AppKey", "");
                request.AddParameter("Format", "JSON");
                request.AddParameter("Version", "");
                request.AddParameter("TimeStamp", DateTime.Now.ToString());
                request.AddParameter("ActionName", "Frxs.DataSync.MessageConsumer");
                request.AddParameter("Data", this.JosnSerializer.Serialize(new
                {
                    WID = this.WID,
                    StartMessageId = startMessageId,
                    Number = number
                }));
                request.AddParameter("Sign", "");
                var response = client.Execute(request);
                var content = response.Content;
                return this.JosnSerializer.Deserialize<ResponseResult<dynamic>>(content);
            }
            catch (Exception ex)
            {
                return new ResponseResult<dynamic>
                {
                    Flag = -1,
                    Info = ex.Message,
                    Data = null
                };
            }
        }

        /// <summary>
        /// 动态数据转型成指定的类型
        /// </summary>
        /// <param name="message">消息摘要数据</param>
        /// <returns></returns>
        private T ConvertToEventArgs<T>(Message<dynamic> message) where T : EventArgsBase
        {
            //因为body事件参数是可变的，所以先使用动态类型将其转换成JSON，然后再进行反序列化出事件参数对象
            var bodyJson = this.JosnSerializer.Serialize(message.Body);
            //再进行反序列
            var eventArgs = (EventArgsBase)this.JosnSerializer.Deserialize(bodyJson, typeof(T));
            //将原始的消息对象挂靠在事件参数上，方便触发事件的时候客户端调用
            eventArgs.Message = message;
            //返回事件参数
            return (T)eventArgs;
        }

        #region system event

        /// <summary>
        /// 请求消息接口错误
        /// </summary>
        public event EventHandler<MessageRequestErrorEventArgs> OnMessageRequestError;

        /// <summary>
        /// 请求消息接口成功
        /// </summary>
        public event EventHandler<MessageRequestSuccessEventArgs> OnMessageRequestSuccess;

        /// <summary>
        /// 消费一批消息完成
        /// </summary>
        public event EventHandler<MessageConsumeCompleteEventArgs> OnMessageConsumeComplete;

        #endregion

        /// <summary>
        /// 消费消息出现错误的时候触发
        /// </summary>
        public event Action<object, EventArgsBase, Exception> OnMessageExecutedException;

        /// <summary>
        /// 消磁消费成功
        /// </summary>
        public event EventHandler<EventArgsBase> OnMessageExecutedSuccess;

        /// <summary>
        /// 消费消息，并触发事件
        /// </summary>
        /// <param name="startMessageId">起始消息编号(不含)</param>
        /// <param name="number">每次消费多少条消息</param>
        internal void Start(string startMessageId, int number)
        {
            //获取消费的消息列表
            var responseResult = this.Execute(startMessageId, number);

            //请求消息接口失败
            if (responseResult.Flag != 0 || null == responseResult.Data && null != this.OnMessageRequestError)
            {
                this.OnMessageRequestError(this, new MessageRequestErrorEventArgs() { ErrorMessage = responseResult.Info });
                return;
            }

            //请求消息接口成功事件
            if (responseResult.Flag == 0 && null != this.OnMessageRequestSuccess)
            {
                this.OnMessageRequestSuccess(this, new MessageRequestSuccessEventArgs() { MessageConsumeResult = responseResult.Data });
            }

            //循环消费消息，触发事件，先排下序，因为消息消费必须串行化消费
            if (responseResult.Data.Messages.Any())
            {
                this.Start(responseResult.Data.Messages.OrderBy(o => o.Id).ToList());
            }

            //消费消息完成
            if (null != this.OnMessageConsumeComplete && responseResult.Data.Messages.Any())
            {
                this.OnMessageConsumeComplete(this, new MessageConsumeCompleteEventArgs() { MessageConsumeResult = responseResult.Data });
            }
        }
    }
}
