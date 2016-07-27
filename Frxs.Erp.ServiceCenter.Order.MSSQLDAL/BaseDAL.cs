using Frxs.Platform.Cache.Provide;
using Frxs.Platform.Cache.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    public abstract class BaseDAL
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public virtual string WarehouseId { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public virtual string ConnectionString { get; private set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BaseDAL() { }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BaseDAL(string warehouseId)
        {
            if (warehouseId != this.WarehouseId && !string.IsNullOrWhiteSpace(warehouseId))
            {
                this.WarehouseId = warehouseId;
                if (!string.IsNullOrWhiteSpace(this.WarehouseId))
                {
                    //获以基础库数据数据字符串
                    //this.ConnectionString = DBConfigHelper.GetConnectionString(DBConfigHelper .ORDERDB_HEADER+ this.WarehouseId);
                    this.ConnectionString = GetMultiConnectionString(this.WarehouseId);
                }
            }
        }

        /// <summary>
        /// 数据库
        /// </summary>
        protected string DatabaseName
        {
            get
            {
                return "FRXS_ERP_ORDER_105";
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
        /// 将IDataReade转换成对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        protected IList<T> ExecuteTolist<T>(IDataReader dataReader)
        {
            IList<T> objectList = new List<T>();
            Type objType = typeof(T);
            if (dataReader != null && dataReader.FieldCount != 0)
            {
                while (dataReader.Read())
                {
                    T obj = (T)objType.Assembly.CreateInstance(objType.FullName);
                    objType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList().ForEach(p =>
                    {
                        if (p.CanWrite)
                        {
                            try
                            {
                                object value = dataReader[p.Name];
                                if (value != null)
                                {
                                    p.SetValue(obj, value, null);
                                }
                            }
                            catch
                            {
                            }
                        }
                    });
                    objectList.Add(obj);
                }
            }
            return objectList;
        }


        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns>连接对象</returns>
        public virtual IDbConnection GetConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// SQLScripts.xml 配置文件里对应于<TABLE>节点名称（有可能和真实的表对应，也有可能无真实表）
        /// 实现类必须要实现此方法；对于多表操作的情况；可以新建一个TABLE节点，然后自己命名
        /// 实现类里将TableName属性返回自己的定义的TableName即可
        /// </summary>
        protected virtual string TableName
        {
            get;
            private set;
        }

        #region 获取多数据库连接字符串 Add By 蔡睿

        /// <summary>
        /// 获取多数据库连接字符串
        /// </summary>
        /// <param name="conKey">连接串key</param>
        /// <returns>连接字符串</returns>
        protected string GetMultiConnectionString(string conKey)
        {
            string connectionString = string.Empty;

            conKey = string.Format("{0}{1}", ConstDefinition.ORDERDB_HEADER, conKey);
            IList<SysDbConfig> list = SysDbConfigDataProvide.GetSysDbConfigListByRedis();
            if (list == null || (list != null && list.Count == 0))
            {
                SysDbConfigDataProvide.SetSysDbConfigListByRedis();
                list = SysDbConfigDataProvide.GetSysDbConfigListByRedis();
                SysDbConfig model = list.SingleOrDefault(p => p.Con_Key == conKey);
                if (model != null)
                {
                    connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};pwd={3};", model.Db_Server, model.Db_Name, model.Db_User, model.Db_Pwd);
                }
            }
            else
            {
                SysDbConfig model = list.SingleOrDefault(p => p.Con_Key == conKey);
                if (model == null)
                {
                    SysDbConfigDataProvide.SetSysDbConfigListByRedis();
                    list = SysDbConfigDataProvide.GetSysDbConfigListByRedis();
                    model = list.SingleOrDefault(p => p.Con_Key == conKey);
                    if (model != null)
                    {
                        connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};pwd={3};", model.Db_Server, model.Db_Name, model.Db_User, model.Db_Pwd);
                    }
                }
                else
                {
                    connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};pwd={3};", model.Db_Server, model.Db_Name, model.Db_User, model.Db_Pwd);
                }
            }

            return connectionString;
        }

        #endregion
    }
}
