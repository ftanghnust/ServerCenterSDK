using Autofac;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/20 18:49:15
 * *******************************************************/

namespace Frxs.ServiceCenter.DataSync.Message.Server.Impl.Data
{
    /// <summary>
    /// 框架会自动检测到这里的注册类,自动完成注册
    /// </summary>
    internal class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 系统框架默认的会被覆盖;
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="systemOptions"></param>
        public void Register(Autofac.ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            containerBuilder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType(typeof(UnitOfWork))
                .As(typeof(IUnitOfWork))
                .InstancePerLifetimeScope();

            containerBuilder.Register<IDbContext>(c => new MessageDbContext(() => c.Resolve<DataSyncConfig>().ConnectionStringName))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// 数字越大越后注册
        /// </summary>
        public int Order
        {
            get { return int.MaxValue; }
        }

    }
}
