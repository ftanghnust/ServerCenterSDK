
/*****************************
* Author:CR
*
* Date:2016-06-20
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ### SysArea数据库访问类
    /// </summary>
    public partial class SysAreaDAO : BaseDAL, ISysAreaDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SysAreaDAO() { }

        const string tableName = "SysArea";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SysArea是否存在
        /// <summary>
        /// 根据主键验证SysArea是否存在
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SysArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
             new SqlParameter("@AreaID", SqlDbType.Int)
            };
            sp[0].Value = model.AreaID;

            try
            {
                result = int.Parse(helper.GetSingle(sql, sp).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.Exists",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result > 0;
        }
        #endregion


        #region 添加一个SysArea
        /// <summary>
        /// 添加一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SysArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<SysArea>(model, ref parameters);
            IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
            try
            {

                object o = helper.GetSingle(sql, sp);
                if (o != null)
                {
                    bool isSuccess = int.TryParse(o.ToString(), out result);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.Save",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        #endregion


        #region 添加一个SysArea(事务处理)
        /// <summary>
        /// 添加一个SysArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SysArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SysArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<SysArea>(model, ref parameters);
            IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
            try
            {

                object o = helper.GetSingle(conn, tran, sql, sp);
                if (o != null)
                {
                    bool isSuccess = int.TryParse(o.ToString(), out result);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.Save",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        #endregion


        #region 更新一个SysArea
        /// <summary>
        /// 更新一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SysArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<SysArea>(model, null, ref parameters);
            IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
            try
            {
                result = helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.Edit",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        #endregion


        #region 更新一个SysArea(事务处理)
        /// <summary>
        /// 更新一个SysArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SysArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<SysArea>(model, null, ref parameters);
            IDbDataParameter[] sp = (parameters as List<IDbDataParameter>).ToArray();
            try
            {
                result = helper.ExecNonQuery(conn, tran, sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.Edit",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        #endregion


        #region 删除一个SysArea
        /// <summary>
        /// 删除一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SysArea model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@AreaID", SqlDbType.Int)
            };
            sp[0].Value = model.AreaID;

            try
            {
                result = helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.Delete",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        #endregion


        #region 根据主键逻辑删除一个SysArea
        /// <summary>
        /// 根据主键逻辑删除一个SysArea
        /// </summary>
        /// <param name="areaID">主键ID(区域邮政编号)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int areaID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                new SqlParameter("@AreaID", SqlDbType.Int)
            };
            sp[0].Value = areaID;

            try
            {
                result = helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.LogicDelete",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }
        #endregion


        #region 根据字典获取SysArea对象
        /// <summary>
        /// 根据字典获取SysArea对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SysArea对象</returns>
        public SysArea GetModel(SysAreaQuery query)
        {
            SysArea model = null;
            try
            {
                IList<SysArea> list = GetList(query);
                if (list != null && list.Count > 0)
                {
                    model = list[0];
                }
            }
            catch
            {
                throw;
            }
            return model;
        }
        #endregion


        #region 根据主键获取SysArea对象
        /// <summary>
        /// 根据主键获取SysArea对象
        /// </summary>
        /// <param name="areaID">主键ID(区域邮政编号)</param>
        /// <returns>SysArea对象</returns>
        public SysArea GetModel(int areaID)
        {
            DBHelper helper = DBHelper.GetInstance();
            SysArea model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@AreaID", SqlDbType.Int)
            };
                sp[0].Value = areaID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SysArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.GetModel",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }
        #endregion


        #region 根据字典获取SysArea集合
        /// <summary>
        /// 根据字典获取SysArea集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SysArea> GetList(SysAreaQuery query)
        {
            IList<SysArea> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        if (s != null)
                        {
                            where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                        }
                    }
                }
                list = GetList(where.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion


        #region 根据字典获取SysArea数据集
        /// <summary>
        /// 根据字典获取SysArea数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            DBHelper helper = DBHelper.GetInstance();
            DataSet ds = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    { where.Append(string.Format(" AND {0}=@{0}", s.ParameterName)); }
                }
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, sqlConfigName, base.AssemblyName, base.DatabaseName);
                ds = helper.GetDataSet(sql + where, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.GetDataSet",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return ds;
        }
        #endregion


        #region 分页获取SysArea集合
        /// <summary>
        /// 分页获取SysArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SysArea> GetPageList(PageListBySql<SysArea> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "AreaID,AreaName,Level,ParentID,ModifyTime,ModifyUserID,ModifyUserName,SyncFale";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);
                page.Parameters = (parameters as List<IDbDataParameter>).ToArray();
                string getCountSql = page.GetCountsSql();
                object counts = helper.GetSingle(getCountSql, page.Parameters);
                if (counts != null)
                {
                    int.TryParse(counts.ToString(), out totalRecords);
                }
                page.TotalRecords = totalRecords;
                string sql = page.GetRecordsSql(ref totalPages);
                page.TotalPages = totalPages;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, page.Parameters) as SqlDataReader)
                {
                    page.ItemList = DataReaderHelper.ExecuteToList<SysArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.GetPageList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return page;
        }
        #endregion


        #region 构建Where条件
        /// <summary>
        /// 构建Where条件
        /// </summary>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>where 条件</returns>
        string CreateCondition(IDictionary<string, object> conditionDict, ref IList<IDbDataParameter> parameters)
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            IList<WhereCondition> whereConditionList = new List<WhereCondition>();//TODO
            string result = new WhereCondition().GetWhereCondition(whereConditionList, ref parameters);
            where.Append(result);
            return Regex.Replace(where.ToString(), "^ AND ", string.Empty);
        }
        #endregion


        #region 构建Sort条件
        /// <summary>
        /// 构建Sort条件
        /// </summary>
        /// <param name="order">排序字段</param>
        string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return "AreaID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SysArea列表
        /// <summary>
        /// 根据条件获取SysArea列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SysArea> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<SysArea> list = new List<SysArea>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SysArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.GetList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }
        #endregion

        #endregion


    }

    public partial class SysAreaDAO : BaseDAL, ISysAreaDAO
    {
        #region 根据ID集合取SysArea集合
        /// <summary>
        /// 根据ID集合获取SysArea集合
        /// </summary>
        /// <param name="query">ID集合</param>
        /// <returns>数据集合</returns>
        public IList<SysArea> GetListByIDs(IList<int> ids)
        {
            IList<SysArea> list = null;
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetListByAreaIDs", base.AssemblyName, base.DatabaseName);
                StringBuilder sb = new StringBuilder();
                if (ids == null || ids.Count <= 0)
                {
                    return null;
                }
                int i = 1;
                SqlParamrterBuilder sp = new SqlParamrterBuilder();
                foreach (var id in ids)
                {
                    sb.Append(string.Format(" @AreaID{0} ,", i));
                    sp.Add(string.Format("AreaID{0}", i), id);
                    i++;
                }
                sql += " And AreaID in (" + sb.ToString(0, sb.Length - 1) + " )";
                using (IDataReader dataReader = helper.GetIDataReader(sql, sp.ToSqlParameters()))
                {
                    list = ExecuteTolist<SysArea>(dataReader);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SysAreaDAO.GetListByAreaIDs",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }
        #endregion
    }
}