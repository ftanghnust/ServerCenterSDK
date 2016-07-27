using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Dynamic;
using System.Reflection;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    public abstract class BaseDAL
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        protected virtual string DatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings["baseData"];
            }
        }

        /// <summary>
        /// 程序集名称
        /// </summary>
        protected virtual string AssemblyName
        {
            get
            {
                return this.GetType().Assembly.GetName().Name;
            }
        }

        /// <summary>
        /// SQLScripts.xml 配置文件里对应于<TABLE>节点名称（有可能和真实的表对应，也有可能无真实表）
        /// 实现类必须要实现此方法；对于多表操作的情况；可以新建一个TABLE节点，然后自己命名
        /// 实现类里将TableName属性返回自己的定义的TableName即可
        /// </summary>
        protected abstract string TableName
        {
            get;
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns>连接对象</returns>
        public IDbConnection GetConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString());
        }

        /// <summary>
        /// 直接封装获取配置文件里的SQL语句
        /// </summary>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <returns></returns>
        protected string GetSQLScriptByTable(string xmlConfigSqlName)
        {
            return SQLConfigBuilder.GetSQLScriptByTable(this.TableName, xmlConfigSqlName, this.AssemblyName, this.DatabaseName);
        }

        /// <summary>
        /// 直接获取对象
        /// </summary>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParameters">SQL语句参数</param>
        /// <returns></returns>
        protected T ExecuteToEntity<T>(string xmlConfigSqlName, SqlParameter[] sqlParameters)
        {
            DBHelper helper = null;
            try
            {
                helper = DBHelper.GetInstance();
                string sql = this.GetSQLScriptByTable(xmlConfigSqlName);
                using (IDataReader dataReader = helper.GetIDataReader(sql, sqlParameters))
                {
                    return this.ExecuteToEntity<T>(dataReader);
                }
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseDAL.ExecuteToEntity",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 直接获取对象
        /// </summary>
        /// <typeparam name="T">获取的类型对象</typeparam>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParametersBuilder">SQL参数构造器</param>
        /// <returns></returns>
        protected T ExecuteToEntity<T>(string xmlConfigSqlName, SqlParamrterBuilder sqlParametersBuilder)
        {
            return this.ExecuteToEntity<T>(xmlConfigSqlName, sqlParametersBuilder.ToSqlParameters());
        }

        /// <summary>
        /// 直接获取列表
        /// </summary>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParameters">SQL语句参数</param>
        /// <returns></returns>
        protected IList<T> ExecuteTolist<T>(string xmlConfigSqlName, SqlParameter[] sqlParameters)
        {
            DBHelper helper = null;
            try
            {
                helper = DBHelper.GetInstance();
                string sql = this.GetSQLScriptByTable(xmlConfigSqlName);
                using (IDataReader dataReader = helper.GetIDataReader(sql, sqlParameters))
                {
                    return this.ExecuteTolist<T>(dataReader);
                }
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseDAL.ExecuteTolist",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 直接获取列表
        /// </summary>
        /// <typeparam name="T">获取实体对象</typeparam>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParametersBuilde">SQL参数构造器</param>
        /// <returns></returns>
        protected IList<T> ExecuteTolist<T>(string xmlConfigSqlName, SqlParamrterBuilder sqlParametersBuilde)
        {
            return this.ExecuteTolist<T>(xmlConfigSqlName, sqlParametersBuilde.ToSqlParameters());
        }

        /// <summary>
        /// 根据配置文件里的SQL语句，获取到唯一字段值
        /// select count(1) from table where name=@name
        /// </summary>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParameters">SQL语句参数</param>
        /// <returns></returns>
        protected object ExecuteToSingle(string xmlConfigSqlName, SqlParameter[] sqlParameters)
        {
            DBHelper helper = null;
            try
            {
                helper = DBHelper.GetInstance();
                string sql = this.GetSQLScriptByTable(xmlConfigSqlName);
                return helper.GetSingle(sql, sqlParameters);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseDAL.ExecuteToSingle",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 根据配置文件里的SQL语句，获取到唯一字段值
        /// select count(1) from table where name=@name
        /// </summary>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParametersBuilde">SQL参数构造器</param>
        /// <returns></returns>
        protected object ExecuteToSingle(string xmlConfigSqlName, SqlParamrterBuilder sqlParametersBuilde)
        {
            return this.ExecuteToSingle(xmlConfigSqlName, sqlParametersBuilde.ToSqlParameters());
        }

        /// <summary>
        /// 根据配置文件里的SQL语句，获取到唯一字段值，并且返回int类型;比如
        /// select count(1) from table where name=@name
        /// </summary>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParameters">SQL语句参数</param>
        /// <returns></returns>
        protected int ExecuteToInt(string xmlConfigSqlName, SqlParameter[] sqlParameters)
        {
            try
            {
                return int.Parse(this.ExecuteToSingle(xmlConfigSqlName, sqlParameters).ToString());
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 根据配置文件里的SQL语句，获取到唯一字段值，并且返回int类型;比如
        /// select count(1) from table where name=@name
        /// </summary>
        /// <param name="xmlConfigSqlName">SQL配置文件节点名称</param>
        /// <param name="sqlParametersBuilde">SQL参数构造器</param>
        /// <returns></returns>
        protected int ExecuteToInt(string xmlConfigSqlName, SqlParamrterBuilder sqlParametersBuilde)
        {
            return this.ExecuteToInt(xmlConfigSqlName, sqlParametersBuilde.ToSqlParameters());
        }

        /// <summary>
        /// 将IDataReade转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        protected T ExecuteToEntity<T>(IDataReader dataReader)
        {
            T obj = default(T);
            if (dataReader != null && dataReader.FieldCount != 0)
            {
                Type objType = typeof(T);
                if (dataReader.Read())
                {
                    obj = (T)objType.Assembly.CreateInstance(objType.FullName);
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
                }
            }
            return obj;
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
                var propList = objType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanWrite).ToList();
                while (dataReader.Read())
                {
                    T obj = (T)objType.Assembly.CreateInstance(objType.FullName);
                    propList.ForEach(p =>
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

                    });
                    objectList.Add(obj);
                }
            }
            return objectList;
        }

    }
}
