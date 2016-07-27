using Autofac;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/20 18:49:15
 * *******************************************************/
using Autofac.Core;
using Frxs.ServiceCenter.Data.Core;
using System.Reflection;
using Autofac.Integration.Mvc;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// API框架会自动检测到这里的注册类,自动完成注册
    /// </summary>
    public class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 系统框架默认的会被覆盖;
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="systemOptions">系统框架配置信息</param>
        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            //dbcontext named
            string dbContextName = "ServiceCenter_Api_Core_AccessRecorder_DbContext";

            //data context
            containerBuilder.Register<IDbContext>(c => new RecorderObjectContext(c.Resolve<IDataBaseAccessRecorderConfig>().ConnectionStringName))
                .Named<IDbContext>(dbContextName)
                .InstancePerLifetimeScope();

            //override required repository with our custom context
            containerBuilder.RegisterType<EfRepository<Domain.AccessRecorder>>()
                .As<IRepository<Domain.AccessRecorder>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(dbContextName))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<EfRepository<Domain.ActionDescriptor>>()
                .As<IRepository<Domain.ActionDescriptor>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(dbContextName))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<EfRepository<Domain.Response>>()
                .As<IRepository<Domain.Response>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(dbContextName))
                .InstancePerLifetimeScope();

            //services
            containerBuilder.RegisterType<DataBaseAccessRecorder>()
                .As<IApiAccessRecorder>()
                .InstancePerLifetimeScope();

            //all controller
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }

        /// <summary>
        /// 数字越大越后注册
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
