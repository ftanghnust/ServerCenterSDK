/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;
using System.Runtime.Serialization;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// API系统框架定义的错误类，系统错误，尽量使用此类来抛出异常，
    /// 便于框架捕捉框架错误消息
    /// </summary>
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiException()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ApiException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="args"></param>
        public ApiException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
