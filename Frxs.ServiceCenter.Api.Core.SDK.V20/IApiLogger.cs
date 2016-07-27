/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 11/2/2015 8:32:16 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core.SDK
{
    /// <summary>
    /// 日志打点接口。
    /// </summary>
    public interface IApiLogger {

        /// <summary>
        /// 记录错误类型日志
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// 记录警告类型日志
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);

        /// <summary>
        /// 记录消息类型日志
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);
    }
}
