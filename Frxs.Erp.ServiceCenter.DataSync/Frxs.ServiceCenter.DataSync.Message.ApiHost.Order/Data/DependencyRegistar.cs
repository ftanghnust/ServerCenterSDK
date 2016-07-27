using Autofac;
using Frxs.ServiceCenter.Api.Core;
/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/20 18:49:15
 * *******************************************************/
using Frxs.ServiceCenter.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.Order.Data
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
        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, SystemOptions systemOptions)
        {
            containerBuilder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType(typeof(UnitOfWork))
                .As(typeof(IUnitOfWork))
                .InstancePerLifetimeScope();

            containerBuilder.Register<IDbContext>(c => new OrderContext(() =>
            {
                //在当前上下文里查找是否设置了当前请求的仓库编号，然后才能依据仓库编号来自动创建指定数据库上下文
                var currentWID = HttpContext.Current.Items["WID"];
                if (currentWID.IsNull())
                {
                    //正式环境里这里要注释掉
                    throw new Exception(Resource.Resource.DependencyRegistar_WID_NotExists);
                }

                //系统数据库配置信息
                var sysDbConfigs = systemOptions.AdditionDatas["sysDbConfig"] as IEnumerable<DbConfig>;

                //找出当前仓库数据存储介质服务器
                var dbConfig = sysDbConfigs.FirstOrDefault(o => o.CON_KEY.Equals("ORDER_{0}".With(currentWID), StringComparison.OrdinalIgnoreCase));
                if (dbConfig.IsNull())
                {
                    throw new Exception(Resource.Resource.DependencyRegistar_DB_NotExists);
                }

                //返回数据库连接
                return "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True"
                        .With(dbConfig.DB_SERVER, dbConfig.DB_NAME, dbConfig.DB_USER, dbConfig.DB_PWD);

            })).InstancePerLifetimeScope();
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
