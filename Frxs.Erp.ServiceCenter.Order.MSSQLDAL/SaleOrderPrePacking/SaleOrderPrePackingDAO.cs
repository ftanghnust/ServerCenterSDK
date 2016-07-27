
/*****************************
* Author:CR
*
* Date:2016-04-13
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
    /// ### SaleOrderPrePacking数据库访问类
    /// </summary>
    public partial class SaleOrderPrePackingDAO : BaseDAL, ISaleOrderPrePackingDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleOrderPrePackingDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleOrderPrePackingDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleOrderPrePacking";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleOrderPrePacking是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPrePacking是否存在
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderPrePacking model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.Exists",
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


        #region 添加一个SaleOrderPrePacking
        /// <summary>
        /// 添加一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleOrderPrePacking model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar,200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.Package1Qty;
            sp[3].Value = model.Package2Qty;
            sp[4].Value = model.Package3Qty;
            sp[5].Value = model.Remark;
            sp[6].Value = model.ModifyTime;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.Save",
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


        #region 添加一个SaleOrderPrePacking(事务处理)
        /// <summary>
        /// 添加一个SaleOrderPrePacking(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleOrderPrePacking model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar,200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.Package1Qty;
            sp[3].Value = model.Package2Qty;
            sp[4].Value = model.Package3Qty;
            sp[5].Value = model.Remark;
            sp[6].Value = model.ModifyTime;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.Save",
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


        #region 更新一个SaleOrderPrePacking
        /// <summary>
        /// 更新一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderPrePacking model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar,200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Package1Qty;
            sp[2].Value = model.Package2Qty;
            sp[3].Value = model.Package3Qty;
            sp[4].Value = model.Remark;
            sp[5].Value = model.ModifyTime;
            sp[6].Value = model.ModifyUserID;
            sp[7].Value = model.ModifyUserName;
            sp[8].Value = model.OrderID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.Edit",
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


        #region 更新一个SaleOrderPrePacking(事务处理)
        /// <summary>
        /// 更新一个SaleOrderPrePacking(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderPrePacking model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar,200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Package1Qty;
            sp[2].Value = model.Package2Qty;
            sp[3].Value = model.Package3Qty;
            sp[4].Value = model.Remark;
            sp[5].Value = model.ModifyTime;
            sp[6].Value = model.ModifyUserID;
            sp[7].Value = model.ModifyUserName;
            sp[8].Value = model.OrderID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.Edit",
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


        #region 删除一个SaleOrderPrePacking
        /// <summary>
        /// 删除一个SaleOrderPrePacking
        /// </summary>
        /// <param name="model">SaleOrderPrePacking对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderPrePacking model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderPrePacking
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPrePacking
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string orderID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = orderID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.LogicDelete",
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


        #region 根据字典获取SaleOrderPrePacking对象
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SaleOrderPrePacking对象</returns>
        public SaleOrderPrePacking GetModel(IDictionary<string, object> query)
        {
            SaleOrderPrePacking model = null;
            try
            {
                IList<SaleOrderPrePacking> list = GetList(query);
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


        #region 根据主键获取SaleOrderPrePacking对象
        /// <summary>
        /// 根据主键获取SaleOrderPrePacking对象
        /// </summary>
        /// <param name="orderID">订单编号(SaleOrder.OrderID)</param>
        /// <returns>SaleOrderPrePacking对象</returns>
        public SaleOrderPrePacking GetModel(string orderID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderPrePacking model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = orderID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderPrePacking>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.GetModel",
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


        #region 根据字典获取SaleOrderPrePacking集合
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SaleOrderPrePacking> GetList(IDictionary<string, object> query)
        {
            IList<SaleOrderPrePacking> list = null;
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


        #region 根据字典获取SaleOrderPrePacking数据集
        /// <summary>
        /// 根据字典获取SaleOrderPrePacking数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.GetDataSet",
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


        #region 分页获取SaleOrderPrePacking集合
        /// <summary>
        /// 分页获取SaleOrderPrePacking集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderPrePacking> GetPageList(PageListBySql<SaleOrderPrePacking> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "OrderID,WID,Package1Qty,Package2Qty,Package3Qty,Remark,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderPrePacking>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.GetPageList",
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


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            try
            {
                IDbDataParameter[] parameters = null;
                string sql = new FieldUpdater().UpdateField(fieldList, whereConditionList, tableName, ref parameters);
                result = helper.ExecNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.UpdateField",
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
                return "OrderID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleOrderPrePacking列表
        /// <summary>
        /// 根据条件获取SaleOrderPrePacking列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPrePacking> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderPrePacking> list = new List<SaleOrderPrePacking>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrderPrePacking>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPrePacking.GetList",
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


    public partial class SaleOrderPrePackingDAO : BaseDAL, ISaleOrderPrePackingDAO
    {
         /// <summary>
         /// 根据OrderId删除商品明细
         /// </summary>
         /// <param name="orderId">订单ID</param>
         /// <param name="conn">连接</param>
         /// <param name="tran">事务</param>
         /// <returns></returns>
         public int DeleteByOrderId(string orderId, IDbConnection conn = null, IDbTransaction tran = null)
         {
             DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
             int result = 0;
             string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByOrderId", base.AssemblyName, base.DatabaseName);
             SqlParamrterBuilder sp = new SqlParamrterBuilder();
             sp.Add("OrderID", SqlDbType.VarChar, 50, orderId);
             try
             {
                 object o = new object();
                 if (conn != null && tran != null)
                 {
                     o = helper.ExecNonQuery(conn, tran, sql, sp.ToSqlParameters());
                 }
                 else
                 {
                     o = helper.ExecNonQuery(sql, sp.ToSqlParameters());
                 }
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
                     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPreShelfAreaDAO.DeleteByOrderId",
                     LogContent = exceptionSql,
                     LogTime = DateTime.Now
                 },
                 ex
                 );
                 throw;
             }
             return result;
         }

    }
}