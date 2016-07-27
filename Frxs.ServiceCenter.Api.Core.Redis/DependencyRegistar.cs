using Autofac;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/26 11:59:37
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.Redis
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
        }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
