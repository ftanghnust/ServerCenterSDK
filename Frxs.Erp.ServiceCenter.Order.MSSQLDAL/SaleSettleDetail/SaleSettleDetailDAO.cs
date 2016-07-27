
/*****************************
* Author:CR
*
* Date:2016-04-11
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
    /// ### SaleSettleDetail数据库访问类
    /// </summary>
    public partial class SaleSettleDetailDAO : BaseDAL, ISaleSettleDetailDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleSettleDetailDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleSettleDetailDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleSettleDetail";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleSettleDetail是否存在
        /// <summary>
        /// 根据主键验证SaleSettleDetail是否存在
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleSettleDetail model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.Exists",
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


        #region 添加一个SaleSettleDetail
        /// <summary>
        /// 添加一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleSettleDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@BillType", SqlDbType.Int),
new SqlParameter("@BillID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDetailsID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDate", SqlDbType.DateTime),
new SqlParameter("@BillAmt", SqlDbType.Money),
new SqlParameter("@BillAddAmt", SqlDbType.Money),
new SqlParameter("@BillPayAmt", SqlDbType.Money),
new SqlParameter("@FeeCode", SqlDbType.VarChar, 32),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Remark", SqlDbType.VarChar, 500),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.WID;
            sp[2].Value = model.BillType;
            sp[3].Value = model.BillID;
            sp[4].Value = model.BillDetailsID;
            sp[5].Value = model.BillDate;
            sp[6].Value = model.BillAmt;
            sp[7].Value = model.BillAddAmt;
            sp[8].Value = model.BillPayAmt;
            sp[9].Value = model.FeeCode;
            sp[10].Value = model.FeeName;
            sp[11].Value = model.Remark;
            sp[12].Value = model.ModifyTime;
            sp[13].Value = model.ModifyUserID;
            sp[14].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.Save",
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


        #region 添加一个SaleSettleDetail(事务处理)
        /// <summary>
        /// 添加一个SaleSettleDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleSettleDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@BillType", SqlDbType.Int),
new SqlParameter("@BillID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDetailsID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDate", SqlDbType.DateTime),
new SqlParameter("@BillAmt", SqlDbType.Money),
new SqlParameter("@BillAddAmt", SqlDbType.Money),
new SqlParameter("@BillPayAmt", SqlDbType.Money),
new SqlParameter("@FeeCode", SqlDbType.VarChar, 32),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Remark", SqlDbType.VarChar, 500),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@SettleID", SqlDbType.VarChar, 100)
};
            sp[0].Value = model.ID;
            sp[1].Value = model.WID;
            sp[2].Value = model.BillType;
            sp[3].Value = model.BillID;
            sp[4].Value = model.BillDetailsID;
            sp[5].Value = model.BillDate;
            sp[6].Value = model.BillAmt;
            sp[7].Value = model.BillAddAmt;
            sp[8].Value = model.BillPayAmt;
            sp[9].Value = model.FeeCode;
            sp[10].Value = model.FeeName;
            sp[11].Value = model.Remark;
            sp[12].Value = model.ModifyTime;
            sp[13].Value = model.ModifyUserID;
            sp[14].Value = model.ModifyUserName;
            sp[15].Value = model.SettleID;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.Save",
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


        #region 更新一个SaleSettleDetail
        /// <summary>
        /// 更新一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleSettleDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@BillType", SqlDbType.Int),
new SqlParameter("@BillID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDetailsID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDate", SqlDbType.DateTime),
new SqlParameter("@BillAmt", SqlDbType.Money),
new SqlParameter("@BillAddAmt", SqlDbType.Money),
new SqlParameter("@BillPayAmt", SqlDbType.Money),
new SqlParameter("@FeeCode", SqlDbType.VarChar, 32),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Remark", SqlDbType.VarChar, 500),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.BillType;
            sp[3].Value = model.BillID;
            sp[4].Value = model.BillDetailsID;
            sp[5].Value = model.BillDate;
            sp[6].Value = model.BillAmt;
            sp[7].Value = model.BillAddAmt;
            sp[8].Value = model.BillPayAmt;
            sp[9].Value = model.FeeCode;
            sp[10].Value = model.FeeName;
            sp[11].Value = model.Remark;
            sp[12].Value = model.ModifyTime;
            sp[13].Value = model.ModifyUserID;
            sp[14].Value = model.ModifyUserName;
            sp[14].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.Edit",
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


        #region 更新一个SaleSettleDetail(事务处理)
        /// <summary>
        /// 更新一个SaleSettleDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleSettleDetail model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@BillType", SqlDbType.Int),
new SqlParameter("@BillID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDetailsID", SqlDbType.VarChar, 50),
new SqlParameter("@BillDate", SqlDbType.DateTime),
new SqlParameter("@BillAmt", SqlDbType.Money),
new SqlParameter("@BillAddAmt", SqlDbType.Money),
new SqlParameter("@BillPayAmt", SqlDbType.Money),
new SqlParameter("@FeeCode", SqlDbType.VarChar, 32),
new SqlParameter("@FeeName", SqlDbType.VarChar, 100),
new SqlParameter("@Remark", SqlDbType.VarChar, 500),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.BillType;
            sp[3].Value = model.BillID;
            sp[4].Value = model.BillDetailsID;
            sp[5].Value = model.BillDate;
            sp[6].Value = model.BillAmt;
            sp[7].Value = model.BillAddAmt;
            sp[8].Value = model.BillPayAmt;
            sp[9].Value = model.FeeCode;
            sp[10].Value = model.FeeName;
            sp[11].Value = model.Remark;
            sp[12].Value = model.ModifyTime;
            sp[13].Value = model.ModifyUserID;
            sp[14].Value = model.ModifyUserName;
            sp[14].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.Edit",
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


        #region 删除一个SaleSettleDetail
        /// <summary>
        /// 删除一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleSettleDetail model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.Delete",
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


        #region 根据主键逻辑删除一个SaleSettleDetail
        /// <summary>
        /// 根据主键逻辑删除一个SaleSettleDetail
        /// </summary>
        /// <param name="iD">主键ID(WID+GUID)</param>
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.LogicDelete",
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


        #region 根据字典获取SaleSettleDetail对象
        /// <summary>
        /// 根据字典获取SaleSettleDetail对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SaleSettleDetail对象</returns>
        public SaleSettleDetail GetModel(IDictionary<string, object> query)
        {
            SaleSettleDetail model = null;
            try
            {
                IList<SaleSettleDetail> list = GetList(query);
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


        #region 根据主键获取SaleSettleDetail对象
        /// <summary>
        /// 根据主键获取SaleSettleDetail对象
        /// </summary>
        /// <param name="iD">主键ID(WID+GUID)</param>
        /// <returns>SaleSettleDetail对象</returns>
        public SaleSettleDetail GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleSettleDetail model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleSettleDetail>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.GetModel",
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


        #region 根据字典获取SaleSettleDetail集合
        /// <summary>
        /// 根据字典获取SaleSettleDetail集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SaleSettleDetail> GetList(IDictionary<string, object> query)
        {
            IList<SaleSettleDetail> list = null;
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


        #region 根据字典获取SaleSettleDetail数据集
        /// <summary>
        /// 根据字典获取SaleSettleDetail数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.GetDataSet",
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


        #region 分页获取SaleSettleDetail集合
        /// <summary>
        /// 分页获取SaleSettleDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleSettleDetail> GetPageList(PageListBySql<SaleSettleDetail> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,SettleID,WID,BillType,BillID,BillDetailsID,BillDate,BillAmt,BillAddAmt,BillPayAmt,FeeCode,FeeName,Remark,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleSettleDetail>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.UpdateField",
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
                return "ID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleSettleDetail列表
        /// <summary>
        /// 根据条件获取SaleSettleDetail列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleSettleDetail> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleSettleDetail> list = new List<SaleSettleDetail>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleSettleDetail>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.GetList",
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


        #region 删除一个SaleSettleDetail
        /// <summary>
        /// 删除一个SaleSettleDetail
        /// </summary>
        /// <param name="model">SaleSettleDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(IDbConnection conn, IDbTransaction tran, string SettleID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteS", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = SettleID;

            try
            {
                result = helper.ExecNonQuery(conn, tran,sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettleDetail.Delete",
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

        #endregion


    }
}