/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using log4net;
using log4net.Config;
using System;

namespace Frxs.ServiceCenter.Api.Core.Logging
{
    /// <summary>
    /// Log4net日志创建器
    /// </summary>
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// Log4net日志创建器
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILogger CreateLogger(Type type)
        {
            //构建配置信息
            XmlConfigurator.Configure();

            //创建日志记录器
            return new Log4NetLogger(LogManager.GetLogger(type));
        }
    }
}
