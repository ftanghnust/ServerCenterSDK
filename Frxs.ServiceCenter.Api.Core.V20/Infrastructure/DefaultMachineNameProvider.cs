/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/6/13 9:50:51
 * *******************************************************/
using System;

namespace Frxs.ServiceCenter.Api.Core.Infrastructure
{
    /// <summary>
    /// 系统框架默认的运行实例名称获取器实现
    /// </summary>
    public class DefaultMachineNameProvider : IMachineNameProvider
    {
        /// <summary>
        /// 同一IIS站点启动了多个工作线程，那么相当于不同的服务器
        /// </summary>
        private static string webFram = System.Guid.NewGuid().ToString("N");

        /// <summary>
        /// 获取当前应用实例的机器名称
        /// </summary>
        public string GetMachineName()
        {
            return "{0}".With(Environment.MachineName);
        }
    }
}
