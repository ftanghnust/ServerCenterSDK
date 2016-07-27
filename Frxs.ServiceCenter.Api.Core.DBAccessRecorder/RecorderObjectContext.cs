/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/24 14:47:12
 * *******************************************************/
using System.Reflection;
using Frxs.ServiceCenter.Data.Core;

namespace Frxs.ServiceCenter.Api.Core.AccessRecorder
{
    /// <summary>
    /// Object context
    /// </summary>
    public class RecorderObjectContext : DbContextBase
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 初始化数据库上下文
        /// </summary>
        /// <param name="nameOrConnectionString">数据库连接字符串</param>
        public RecorderObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            //初始化一个空的日志记录器
            this.Logger = NullLogger.Instance;

            //记录下SQL生成，方便进行调试
            //this.Database.Log = (sql) => { this.Logger.Debug(sql); };
        }

        /// <summary>
        /// 实体映射程序集
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