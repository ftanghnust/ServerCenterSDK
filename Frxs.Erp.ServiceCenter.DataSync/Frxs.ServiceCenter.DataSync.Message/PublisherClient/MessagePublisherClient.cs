/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/2/2016 5:16:38 PM
 * *******************************************************/
using System;
using RestSharp;

namespace Frxs.ServiceCenter.DataSync.Message.PublisherClient
{
    /// <summary>
    /// 消息发布客户端
    /// </summary>
    public class MessagePublisherClient
    {
        /// <summary>
        /// 初始化消息发布客户端
        /// </summary>
        /// <param name="messageServerUrl">消息中间件服务器地址</param>
        /// <param name="josnSerializer">JOSN格式化器</param>
        /// <param name="wid">如果为null，默认将仓库设置为0</param>
        public MessagePublisherClient(string messageServerUrl, IJosnSerializer josnSerializer, Func<int> wid = null)
        {
            if (string.IsNullOrEmpty(messageServerUrl))
                throw new ArgumentNullException("messageServerUrl");
            if (null == josnSerializer)
                throw new ArgumentNullException("objectJosnSerializer");
            this.ServerUrl = messageServerUrl;
            this.JosnSerializer = josnSerializer;
            this.WID = wid == null ? 0 : wid();
            this.Enabled = true;
        }

        /// <summary>
        /// 是否开启发布消息事件触发（当此值被设置为false的时候，系统将不会发布事件到消息中间件），默认true(开启事件发布)
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 消息中间件服务器地址
        /// </summary>
        internal string ServerUrl { get; private set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        internal int WID { get; private set; }

        /// <summary>
        /// JSON序列化接口
        /// </summary>
        internal IJosnSerializer JosnSerializer { get; private set; }

        /// <summary>
        /// 执行远程调用
        /// </summary>
        /// <param name="message">消息体</param>
        /// <param name="eventDegree">事件的重要度</param>
        /// <returns></returns>
        internal PublishResult Publish(object message, EventDegree eventDegree)
        {
            if (!this.Enabled)
            {
                //禁用了，也返回true，防止发布方做了成功判断，从而造成流程无法走下去
                return new PublishResult(true, "", "已禁用事件发布");
            }

            try
            {
                var restClient = new RestClient(this.ServerUrl);
                var request = new RestRequest(Method.POST);
                request.AddParameter("AppKey", "");
                request.AddParameter("Format", "JSON");
                request.AddParameter("Version", "");
                request.AddParameter("TimeStamp", DateTime.Now.ToString());
                request.AddParameter("ActionName", "Frxs.DataSync.MessagePublisher");
                request.AddParameter("Data", this.JosnSerializer.Serialize(message));
                request.AddParameter("Sign", "");
                var response = restClient.Execute(request);
                var content = response.Content;
                var result = this.JosnSerializer.Deserialize<ResponseResult>(content);
                return new PublishResult(result.Flag == 0, result.Data, result.Info);
            }
            catch (Exception ex)
            {
                return new PublishResult(false, null, ex.Message);
            }
        }
    }
}
