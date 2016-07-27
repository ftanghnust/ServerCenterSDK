/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using log4net;
using log4net.Config;
using System;

namespace Frxs.ServiceCenter.Api.Core.Logging
{
    /// <summary>
    /// Log4net��־������
    /// </summary>
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// Log4net��־������
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILogger CreateLogger(Type type)
        {
            //����������Ϣ
            XmlConfigurator.Configure();

            //������־��¼��
            return new Log4NetLogger(LogManager.GetLogger(type));
        }
    }
}
