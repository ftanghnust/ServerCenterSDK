/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 日志记录器
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 是否启用日志记录器(针对某一级别的)
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="level">记录等级</param>
        /// <param name="exception">错误异常</param>
        /// <param name="format">格式化字符串，如：服务器错误{0}......</param>
        /// <param name="args">格式化字符参数值</param>
        void Log(LogLevel level, Exception exception, string format, params object[] args);
    }

    /// <summary>
    /// 泛型日志记录器，可以省略掉ILoggerFactory接口实现
    /// </summary>
    /// <typeparam name="TServiceType"></typeparam>
    public interface ILogger<TServiceType> : ILogger
        where TServiceType : class
    {
    }
}
