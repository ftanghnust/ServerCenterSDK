/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2016/7/12 10:12:08
 * *******************************************************/
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;

namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    /// <summary>
    /// 数据访问上下文创建
    /// </summary>
    internal class DbContextFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static string _connectionString = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True";

        /// <summary>
        /// 创建基础库数据访问上下文
        /// </summary>
        public static BaseDataContext CreateBaseDataContext()
        {
            return new BaseDataContext("Name=FRXS_ERP_BASEDATAContext");
        }

        /// <summary>
        /// 创建用户库数据访问上下文
        /// </summary>
        /// <returns></returns>
        public static UserContext CreateUserContext()
        {
            return new UserContext("Name=FRXS_ERP_USERContext");
        }

        /// <summary>
        /// 创建订单库数据访问上下文
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static OrderContext CreateOrderContext(int wid)
        {
            //数据配置
            string conKey = string.Format("ORDER_{0}", wid);

            //获取数据配置(暂时先不优化，直接读取基础数据库)
            var dbConfig = CreateBaseDataContext().SYS_DB_CONFIG.FirstOrDefault(o => o.CON_KEY == conKey);

            //未找到配置文件
            if (dbConfig == null)
            {
                throw new Exception("仓库未配置数据库连接");
            }

            //获取数据库连接字符串
            string connectionString = string.Format(_connectionString, dbConfig.DB_SERVER, dbConfig.DB_NAME, dbConfig.DB_USER, dbConfig.DB_PWD);

            //返回访问上下文
            return new OrderContext(connectionString);
        }

        /// <summary>
        /// 促销库数据访问上下文
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static PromoContext CreatePromoContext(int wid)
        {
            //数据配置
            string conKey = string.Format("PROMOTION_{0}", wid);

            //获取数据配置(暂时先不优化，直接读取基础数据库)
            var dbConfig = CreateBaseDataContext().SYS_DB_CONFIG.FirstOrDefault(o => o.CON_KEY == conKey);

            //未找到配置文件
            if (dbConfig == null)
            {
                throw new Exception("仓库未配置数据库连接");
            }

            //获取数据库连接字符串
            string connectionString = string.Format(_connectionString, dbConfig.DB_SERVER, dbConfig.DB_NAME, dbConfig.DB_USER, dbConfig.DB_PWD);

            //返回访问上下文
            return new PromoContext(connectionString);
        }
    }
}
