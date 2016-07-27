/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// Ĭ�ϵĿյļ�¼��
    /// </summary>
    public class NullLogger : ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly ILogger _instance = new NullLogger();

        /// <summary>
        /// 
        /// </summary>
        private NullLogger() { }

        /// <summary>
        /// 
        /// </summary>
        public static ILogger Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// ��־��¼����
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel level)
        {
            return false;
        }

        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
        }
    }
}