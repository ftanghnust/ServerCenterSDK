/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/3/9 13:47:34
 * *******************************************************/
using System;
using System.Reflection;
using Frxs.ServiceCenter.Api.Core;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.DataSync.Message.ApiHost.DataBase.Data
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class BaseDataContext : DbContextBase
    {
        /// <summary>
        /// 初始化一个日志记录器
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 初始化数据访问上下文对象
        /// </summary>
        /// <param name="getNameOrConnectionString">数据库连接名</param>
        public BaseDataContext(Func<string> getNameOrConnectionString)
            : base(nameOrConnectionString: getNameOrConnectionString())
        {
            //方便调试查看SQL语句
            //DbInterception.Add(new EFIntercepterLogging());
            //初始化一个空的日志记录器
            this.Logger = NullLogger.Instance;
            //记录下SQL生成，方便进行调试
            //this.Database.Log = (sql) => { this.Logger.Information(sql); };
        }

        /// <summary>
        /// 映射程序集改成当前程序集
        /// </summary>
        protected override Assembly EntityTypeConfigurationMapAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }
    }
}