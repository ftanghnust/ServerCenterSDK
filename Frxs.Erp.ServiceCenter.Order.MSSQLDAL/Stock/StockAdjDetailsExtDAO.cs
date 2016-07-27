
/*****************************
* Author:CR
*
* Date:2016-04-15
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### StockAdjDetailsExt数据库访问类
    /// </summary>
    public partial class StockAdjDetailsExtDAO : BaseDAL, IStockAdjDetailsExtDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public StockAdjDetailsExtDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public StockAdjDetailsExtDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "StockAdjDetailsExt";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证StockAdjDetailsExt是否存在
        /// <summary>
        /// 根据主键验证StockAdjDetailsExt是否存在
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(StockAdjDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Exists",
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


        #region 添加一个StockAdjDetailsExt
        /// <summary>
        /// 添加一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(StockAdjDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<StockAdjDetailsExt>(model, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Save",
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


        #region 添加一个StockAdjDetailsExt(事务处理)
        /// <summary>
        /// 添加一个StockAdjDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, StockAdjDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetInsertSql<StockAdjDetailsExt>(model, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Save",
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


        #region 更新一个StockAdjDetailsExt
        /// <summary>
        /// 更新一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(StockAdjDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<StockAdjDetailsExt>(model, null, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Edit",
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


        #region 更新一个StockAdjDetailsExt(事务处理)
        /// <summary>
        /// 更新一个StockAdjDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, StockAdjDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            string sql = AddOrEditSqlBuilder.GetUpdateSql<StockAdjDetailsExt>(model, null, ref parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Edit",
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


        #region 删除一个StockAdjDetailsExt
        /// <summary>
        /// 删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="model">StockAdjDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(StockAdjDetailsExt model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Delete",
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


        #region 根据主键逻辑删除一个StockAdjDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="iD">编号(StockAdjDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = iD;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.LogicDelete",
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


        #region 根据字典获取StockAdjDetailsExt对象
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>StockAdjDetailsExt对象</returns>
        public StockAdjDetailsExt GetModel(StockAdjDetailsExtQuery query)
        {
            StockAdjDetailsExt model = null;
            try
            {
                IList<StockAdjDetailsExt> list = GetList(query);
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


        #region 根据主键获取StockAdjDetailsExt对象
        /// <summary>
        /// 根据主键获取StockAdjDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(StockAdjDetails.ID)</param>
        /// <returns>StockAdjDetailsExt对象</returns>
        public StockAdjDetailsExt GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            StockAdjDetailsExt model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<StockAdjDetailsExt>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.GetModel",
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


        #region 根据字典获取StockAdjDetailsExt集合
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<StockAdjDetailsExt> GetList(StockAdjDetailsExtQuery query)
        {
            IList<StockAdjDetailsExt> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(query);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    { where.Append(string.Format(" AND {0}=@{0}", s.ParameterName)); }
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


        #region 根据字典获取StockAdjDetailsExt数据集
        /// <summary>
        /// 根据字典获取StockAdjDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.GetDataSet",
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


        #region 分页获取StockAdjDetailsExt集合
        /// <summary>
        /// 分页获取StockAdjDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<StockAdjDetailsExt> GetPageList(PageListBySql<StockAdjDetailsExt> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,AdjID,CategoryId1,CategoryId1Name,CategoryId2,CategoryId2Name,CategoryId3,CategoryId3Name,ShopCategoryId1,ShopCategoryId1Name,ShopCategoryId2,ShopCategoryId2Name,ShopCategoryId3,ShopCategoryId3Name,BrandId1,BrandId1Name,BrandId2,BrandId2Name,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<StockAdjDetailsExt>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.GetPageList",
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
        /// <param name="page">分页辅助类</param>
        string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return "ID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取StockAdjDetailsExt列表
        /// <summary>
        /// 根据条件获取StockAdjDetailsExt列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<StockAdjDetailsExt> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<StockAdjDetailsExt> list = new List<StockAdjDetailsExt>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<StockAdjDetailsExt>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.GetList",
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

    /// <summary>
    /// 
    /// </summary>
    public partial class StockAdjDetailsExtDAO : BaseDAL, IStockAdjDetailsExtDAO
    {
        #region 删除一个StockAdjDetailsExt
        /// <summary>
        /// 删除一个StockAdjDetailsExt
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string id)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@ID", SqlDbType.VarChar, 50)
            };
            sp[0].Value = id;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Delete",
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

        #region 删除一个StockAdjDetailsExt 事务处理
        /// <summary>
        /// 删除一个StockAdjDetailsExt 事务处理
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="id">主键</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(IDbConnection conn, IDbTransaction tran, string id)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@ID", SqlDbType.VarChar, 50)
            };
            sp[0].Value = id;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.Delete",
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

        #region 删除一个StockAdjDetailsExt 事务处理
        /// <summary>
        /// 删除一个StockAdjDetailsExt 事务处理
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>        
        /// <returns>数据库影响行数</returns>
        public int Delete(string adjID, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByAdjID", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@AdjID", SqlDbType.VarChar, 50)
            };
            sp[0].Value = adjID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.StockAdjDetailsExt.DeleteByAdjID",
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
    }
}