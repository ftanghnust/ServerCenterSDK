/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/2/2015 8:32:16 PM
 * *******************************************************/
using System;
using System.Runtime.Serialization;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 客户端异常。
    /// </summary>
    public class ApiException : Exception
    {
        private string errorCode;
        private string errorMsg;

        /// <summary>
        /// 
        /// </summary>
        public ApiException()
            : base()
        {
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMsg"></param>
        public ApiException(string errorCode, string errorMsg)
            : base(errorCode + ":" + errorMsg)
        {
            this.errorCode = errorCode;
            this.errorMsg = errorMsg;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorCode
        {
            get { return this.errorCode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMsg
        {
            get { return this.errorMsg; }
        }
    }
}
