using Autofac;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/26 11:59:37
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.Redis.StackExchange
{
    /// <summary>
    /// 注册新的Redis缓存服务器实现
    /// </summary>
    public class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 注册缓存实现
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <param name="typeFinder"></param>
        /// <param name="systemOptions">系统框架配置信息</param>
        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            containerBuilder.RegisterType<RedisCacheManager>()
                .As<ICacheManager>()
                .Named<ICacheManager>("RedisServiceStack")
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<NewtonsoftSerializer>()
                .As<ISerializer>()
                .SingleInstance();

            containerBuilder.RegisterType<StackExchangeRedisCacheClient>()
                .As<ICacheClient>()
                .SingleInstance();
        }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Order
        {
            get { return 3; }
        }
    }
}
