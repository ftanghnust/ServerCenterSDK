/*********************************************************
 * FRXS(ISC) zhangliang@frxs.com 10/27/2015 2:29:27 PM
 * *******************************************************/

using System.Runtime.Remoting.Messaging;
using Autofac;
using Autofac.Core;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.Api.Host
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
            //接口加密解密器
            containerBuilder.RegisterType<DES3ApiSecurity>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //接口独立缓存
            containerBuilder.RegisterType(typeof(Actions.CacheTestAction))
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("MemoryCacheManager"))
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
        }
    }
}