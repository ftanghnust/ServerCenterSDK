using System;

using System.Configuration;

namespace Frxs.Erp.ServiceCenter.ID.MSSQLDAL
{
    public class BaseDAL
    {
        /// <summary>
        /// 数据库
        /// </summary>
        protected string DatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings["id"];
            }
        }

        /// <summary>
        /// 程序集名称
        /// </summary>
        protected string AssemblyName
        {
            get
            {
                return this.GetType().Assembly.GetName().Name;
            }
        }

        /// <summary>
        /// 数据库
        /// </summary>
        protected string OpLogDatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings["idSercice"];
            }
        }
    }
}
