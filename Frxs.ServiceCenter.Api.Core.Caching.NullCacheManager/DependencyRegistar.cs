/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/26 11:59:37
 * *******************************************************/
using Autofac;

namespace Frxs.ServiceCenter.Api.Core.Caching.NullCacheManager
{
    /// <summary>
    /// 空实现，不使用缓存
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
            containerBuilder.RegisterType<NullCacheManager>()
                .As<ICacheManager>()
                .Named<ICacheManager>("NullCacheManager")
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// 优先级注册为最大，方便调试
        /// </summary>
        public int Order
        {
            get { return int.MaxValue; }
        }
    }
}
