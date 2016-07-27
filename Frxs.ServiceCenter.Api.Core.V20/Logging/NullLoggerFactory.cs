/*********************************************************
 * FRXS zhangliang@frxs.com 10/23/2015 5:04:21 PM
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core
{
    /// <summary>
    /// 空的默认日志创建工厂类
    /// </summary>
    public class NullLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// 创建日志
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILogger CreateLogger(Type type)
        {
            return NullLogger.Instance;
        }
    }
}