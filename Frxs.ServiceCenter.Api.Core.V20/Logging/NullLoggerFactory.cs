/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// �յ�Ĭ����־����������
    /// </summary>
    public class NullLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILogger CreateLogger(Type type)
        {
            return NullLogger.Instance;
        }
    }
}