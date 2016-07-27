using Autofac;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/20 18:49:15
 * *******************************************************/

namespace Frxs.ServiceCenter.Api.Core.Memcached
{
    /// <summary>
    /// API框架会自动检测到这里的注册类,自动完成注册
    /// </summary>
    public class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 系统框架默认的会被覆盖
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="systemOptions">系统框架配置信息</param>
        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            containerBuilder.RegisterType<MemcachedManager>()
                .As<ICacheManager>()
                .Named<ICacheManager>("MemcachedManager")
                .SingleInstance();
        }

        /// <summary>
        /// 数字越大越后注册
        /// </summary>
        public int Order
        {
            get { return 2; }
        }
    }
}
