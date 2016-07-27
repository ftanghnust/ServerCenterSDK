/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/27/2015 2:29:27 PM
 * *******************************************************/
using Autofac;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Promotion
{
    /// <summary>
    /// 注册系统默认实现的接口服务类
    /// </summary>
    public class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 优先级最低，方便外部程序重写框架里的实现，覆盖掉系统默认的实现
        /// </summary>
        public int Order
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 注册特定的类型到容器
        /// </summary>
        /// <param name="containerBuilder">注册容器</param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="systemOptions">系统框架配置信息</param>
        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
        }
    }
}