/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 7/6/2016 11:33:02 AM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.DataSync.Message.ConsumerClient
{
    /// <summary>
    /// 请求消费消息接口错误参数
    /// </summary>
    [Serializable]
    public class MessageRequestErrorEventArgs : System.EventArgs
    {
        /// <summary>
        /// 错误消息详情
        /// </summary>
        public string ErrorMessage { get; set; }

    }
}
