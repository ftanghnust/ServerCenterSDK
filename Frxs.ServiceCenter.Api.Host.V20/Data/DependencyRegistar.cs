using Autofac;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/20 18:49:15
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.ServiceCenter.Data.Core;
using Frxs.ServiceCenter.Api.Core;

namespace Frxs.ServiceCenter.Api.Host.Data
{
    /// <summary>
    /// 框架会自动检测到这里的注册类,自动完成注册
    /// </summary>
    public class DependencyRegistar : IDependencyRegistar
    {
        /// <summary>
        /// 系统框架默认的会被覆盖;
        /// </summary>
        /// <param name="containerBuilder"></param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="systemOptions"></param>
        public void Register(Autofac.ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            containerBuilder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            containerBuilder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            containerBuilder.Register<IDbContext>(c => new V20DbContext(() => c.Resolve<DataBaseAccessConfig>().ConnectionStringName)).InstancePerLifetimeScope();
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
