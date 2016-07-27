
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
    /// ### SaleSettle数据库访问类
    /// </summary>
    public partial class SaleSettleDAO : BaseDAL, ISaleSettleDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleSettleDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleSettleDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleSettle";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleSettle是否存在
        /// <summary>
        /// 根据主键验证SaleSettle是否存在
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleSettle model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.SettleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Exists",
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


        #region 添加一个SaleSettle
        /// <summary>
        /// 添加一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleSettle model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@SaleAmt", SqlDbType.Money),
new SqlParameter("@BackAmt", SqlDbType.Money),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleAmt", SqlDbType.Money),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopName", SqlDbType.NVarChar, 50),
new SqlParameter("@CreditAmt", SqlDbType.Money),
new SqlParameter("@BankAccount", SqlDbType.NVarChar, 50),
new SqlParameter("@BankAccountName", SqlDbType.NVarChar, 100),
new SqlParameter("@BankType", SqlDbType.VarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@SettleType", SqlDbType.VarChar, 32),
new SqlParameter("@SettleName", SqlDbType.VarChar, 32),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@SettleTime", SqlDbType.DateTime)
};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.SaleAmt;
            sp[3].Value = model.BackAmt;
            sp[4].Value = model.FeeAmt;
            sp[5].Value = model.SettleAmt;
            sp[6].Value = model.OrderID;
            sp[7].Value = model.ShopID;
            sp[8].Value = model.ShopCode;
            sp[9].Value = model.ShopType;
            sp[10].Value = model.ShopName;
            sp[11].Value = model.CreditAmt;
            sp[12].Value = model.BankAccount;
            sp[13].Value = model.BankAccountName;
            sp[14].Value = model.BankType;
            sp[15].Value = model.Remark;
            sp[16].Value = model.SettleType;
            sp[17].Value = model.SettleName;
            sp[18].Value = model.CreateTime;
            sp[19].Value = model.CreateUserID;
            sp[20].Value = model.CreateUserName;
            sp[21].Value = model.ModifyTime;
            sp[22].Value = model.ModifyUserID;
            sp[23].Value = model.ModifyUserName;
            sp[24].Value = model.SettleTime;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Save",
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


        #region 添加一个SaleSettle(事务处理)
        /// <summary>
        /// 添加一个SaleSettle(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleSettle model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@SaleAmt", SqlDbType.Money),
new SqlParameter("@BackAmt", SqlDbType.Money),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleAmt", SqlDbType.Money),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopName", SqlDbType.NVarChar, 50),
new SqlParameter("@CreditAmt", SqlDbType.Money),
new SqlParameter("@BankAccount", SqlDbType.NVarChar, 50),
new SqlParameter("@BankAccountName", SqlDbType.NVarChar, 100),
new SqlParameter("@BankType", SqlDbType.VarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@SettleType", SqlDbType.VarChar, 32),
new SqlParameter("@SettleName", SqlDbType.VarChar, 32),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@SettleTime", SqlDbType.VarChar, 40),
new SqlParameter("@SettleID", SqlDbType.VarChar, 40),
new SqlParameter("@WName", SqlDbType.VarChar, 50),
new SqlParameter("@WCode", SqlDbType.VarChar, 50)
};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.SaleAmt;
            sp[3].Value = model.BackAmt;
            sp[4].Value = model.FeeAmt;
            sp[5].Value = model.SettleAmt;
            sp[6].Value = model.OrderID;
            sp[7].Value = model.ShopID;
            sp[8].Value = model.ShopCode;
            sp[9].Value = model.ShopType;
            sp[10].Value = model.ShopName;
            sp[11].Value = model.CreditAmt;
            sp[12].Value = model.BankAccount;
            sp[13].Value = model.BankAccountName;
            sp[14].Value = model.BankType;
            sp[15].Value = model.Remark;
            sp[16].Value = model.SettleType;
            sp[17].Value = model.SettleName;
            sp[18].Value = model.CreateTime;
            sp[19].Value = model.CreateUserID;
            sp[20].Value = model.CreateUserName;
            sp[21].Value = model.ModifyTime;
            sp[22].Value = model.ModifyUserID;
            sp[23].Value = model.ModifyUserName;
            sp[24].Value = model.SettleTime;
            sp[25].Value = model.SettleID;
            sp[26].Value = model.WName;
            sp[27].Value = model.WCode;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Save",
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


        #region 更新一个SaleSettle
        /// <summary>
        /// 更新一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleSettle model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@SaleAmt", SqlDbType.Money),
new SqlParameter("@BackAmt", SqlDbType.Money),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleAmt", SqlDbType.Money),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopName", SqlDbType.NVarChar, 50),
new SqlParameter("@CreditAmt", SqlDbType.Money),
new SqlParameter("@BankAccount", SqlDbType.NVarChar, 50),
new SqlParameter("@BankAccountName", SqlDbType.NVarChar, 100),
new SqlParameter("@BankType", SqlDbType.VarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@SettleType", SqlDbType.VarChar, 32),
new SqlParameter("@SettleName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@SettleID", SqlDbType.VarChar, 36)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.SaleAmt;
            sp[3].Value = model.BackAmt;
            sp[4].Value = model.FeeAmt;
            sp[5].Value = model.SettleAmt;
            sp[6].Value = model.OrderID;
            sp[7].Value = model.ShopID;
            sp[8].Value = model.ShopCode;
            sp[9].Value = model.ShopType;
            sp[10].Value = model.ShopName;
            sp[11].Value = model.CreditAmt;
            sp[12].Value = model.BankAccount;
            sp[13].Value = model.BankAccountName;
            sp[14].Value = model.BankType;
            sp[15].Value = model.Remark;
            sp[16].Value = model.SettleType;
            sp[17].Value = model.SettleName;
            sp[18].Value = model.ModifyTime;
            sp[19].Value = model.ModifyUserID;
            sp[20].Value = model.ModifyUserName;
            sp[21].Value = model.SettleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Edit",
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


        #region 更新一个SaleSettle(事务处理)
        /// <summary>
        /// 更新一个SaleSettle(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleSettle model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@SaleAmt", SqlDbType.Money),
new SqlParameter("@BackAmt", SqlDbType.Money),
new SqlParameter("@FeeAmt", SqlDbType.Money),
new SqlParameter("@SettleAmt", SqlDbType.Money),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopName", SqlDbType.NVarChar, 50),
new SqlParameter("@CreditAmt", SqlDbType.Money),
new SqlParameter("@BankAccount", SqlDbType.NVarChar, 50),
new SqlParameter("@BankAccountName", SqlDbType.NVarChar, 100),
new SqlParameter("@BankType", SqlDbType.VarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@SettleType", SqlDbType.VarChar, 32),
new SqlParameter("@SettleName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@SettleID", SqlDbType.VarChar, 36)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.Status;
            sp[2].Value = model.SaleAmt;
            sp[3].Value = model.BackAmt;
            sp[4].Value = model.FeeAmt;
            sp[5].Value = model.SettleAmt;
            sp[6].Value = model.OrderID;
            sp[7].Value = model.ShopID;
            sp[8].Value = model.ShopCode;
            sp[9].Value = model.ShopType;
            sp[10].Value = model.ShopName;
            sp[11].Value = model.CreditAmt;
            sp[12].Value = model.BankAccount;
            sp[13].Value = model.BankAccountName;
            sp[14].Value = model.BankType;
            sp[15].Value = model.Remark;
            sp[16].Value = model.SettleType;
            sp[17].Value = model.SettleName;
            sp[18].Value = model.ModifyTime;
            sp[19].Value = model.ModifyUserID;
            sp[20].Value = model.ModifyUserName;
            sp[21].Value = model.SettleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Edit",
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


        #region 删除一个SaleSettle
        /// <summary>
        /// 删除一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleSettle model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.SettleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Delete",
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


        #region 根据主键逻辑删除一个SaleSettle
        /// <summary>
        /// 根据主键逻辑删除一个SaleSettle
        /// </summary>
        /// <param name="settleID">结算ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string settleID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = settleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.LogicDelete",
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


        #region 根据字典获取SaleSettle对象
        /// <summary>
        /// 根据字典获取SaleSettle对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SaleSettle对象</returns>
        public SaleSettle GetModel(IDictionary<string, object> query)
        {
            SaleSettle model = null;
            try
            {
                IList<SaleSettle> list = GetList(query);
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


        #region 根据主键获取SaleSettle对象
        /// <summary>
        /// 根据主键获取SaleSettle对象
        /// </summary>
        /// <param name="settleID">结算ID</param>
        /// <returns>SaleSettle对象</returns>
        public SaleSettle GetModel(string settleID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleSettle model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36)
 };
                sp[0].Value = settleID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleSettle>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.GetModel",
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


        #region 根据字典获取SaleSettle集合
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SaleSettle> GetList(IDictionary<string, object> query)
        {
            IList<SaleSettle> list = null;
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


        #region 根据字典获取SaleSettle数据集
        /// <summary>
        /// 根据字典获取SaleSettle数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.GetDataSet",
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


        #region 分页获取SaleSettle集合

        /// <summary>
        /// 分页获取SaleSettle集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="totalAmt">添加 总页面合计字段</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleSettle> GetPageList(PageListBySql<SaleSettle> page, IDictionary<string, object> conditionDict,out decimal totalAmt)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            totalAmt = 0.0m;
            try
            {
                page.TableName = tableName;
                page.Fields = "WCode,WName,SettleID,WID,Status,SaleAmt,BackAmt,FeeAmt,SettleAmt,SettleTime,OrderID,ShopID,ShopCode,ShopType,ShopName,CreditAmt,BankAccount,BankAccountName,BankType,Remark,SettleType,SettleName,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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

                //添加 总页面合计字段
                string getSumAmt = string.Format("SELECT SUM(SettleAmt) FROM {0} Where {1};", page.TableName, page.Where);
                object SumAmt = helper.GetSingle(getSumAmt, page.Parameters);
                if (SumAmt != null)
                {
                    decimal.TryParse(SumAmt.ToString(), out totalAmt);
                }

                page.TotalRecords = totalRecords;
                string sql = page.GetRecordsSql(ref totalPages);
                page.TotalPages = totalPages;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, page.Parameters) as SqlDataReader)
                {
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleSettle>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.UpdateField",
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

            if (conditionDict.ContainsKey("WID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "WID",
                        FieldValue = conditionDict["WID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("ShopID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ShopID",
                        FieldValue = conditionDict["ShopID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("Status"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "Status",
                        FieldValue = conditionDict["Status"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("SettleID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "SettleID",
                        FieldValue = conditionDict["SettleID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("StartTime"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.MoreThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "SettleTime",
                        FieldValue = conditionDict["StartTime"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            if(conditionDict.ContainsKey("EndTime"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.LessThanOrEquals,
                    FieldObj = new Field
                    {
                        FieldName = "SettleTime",
                        FieldValue = conditionDict["EndTime"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50,
                        ParamterName = "SettleEndTime"
                    }
                });
            }


            if (conditionDict.ContainsKey("SettleType"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "SettleType",
                        FieldValue = conditionDict["SettleType"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("ShopCode"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShopCode",
                        FieldValue = conditionDict["ShopCode"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            if (conditionDict.ContainsKey("ShopName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ShopName",
                        FieldValue = conditionDict["ShopName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

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
                return "SettleID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleSettle列表
        /// <summary>
        /// 根据条件获取SaleSettle列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleSettle> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleSettle> list = new List<SaleSettle>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleSettle>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.GetList",
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
    /// 扩展
    /// </summary>
    public partial class SaleSettleDAO : BaseDAL, ISaleSettleDAO
    {

        #region 获取零时表
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SaleSettleTemp> GetList(IDbConnection conn, IDbTransaction tran, int ShopID, int WID)
        {
            IList<SaleSettleTemp> list = new List<SaleSettleTemp>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"select * from (
SELECT '' OrderId, BackID as BillID,'' BillDetailsID,BackDate as BillDate,1 as BillType,0-TotalBackAmt BillAmt,0-TotalAddAmt BillAddAmt,0-PayAmount BillPayAmt,'' FeeCode,'' FeeName,Remark  
FROM SaleBack Where Status=2 AND ShopID={1} AND WID={0} 
UNION ALL
SELECT '' OrderId,h.FeeID BillID,d.ID as BillDetailsID, h.FeeDate as BillDate,2 as BillTyped,FeeAmt BillAmt,0 BillAddAmt,FeeAmt BillPayAmt,FeeCode,d.FeeName,Reason as Remark from SaleFee H
INNER JOIN SaleFeeDetails D ON h.FeeID=d.FeeID
WHERE h.WID={0} AND h.status=2 AND d.ShopID={1} AND d.SettleID IS NULL 
) a  order by BillDate asc ,BillPayAmt desc", WID, ShopID);

                list = GetList(conn, tran, sql.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion

        #region 根据条件获取SaleSettle列表(事物)
        IList<SaleSettleTemp> GetList(IDbConnection conn, IDbTransaction tran, string sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleSettleTemp> list = new List<SaleSettleTemp>();
            try
            {
                
                DataSet ds = helper.GetDataSet(conn, tran, sql, sp);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    list = Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SaleSettleTemp>(ds.Tables[0]);
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetList",
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

        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public int UpdateField(IDbConnection conn, IDbTransaction tran, IList<Field> fieldList, IList<WhereCondition> whereConditionList,string sqlTableName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;

            try
            {
                IDbDataParameter[] parameters = null;
                string sql = new FieldUpdater().UpdateField(fieldList, whereConditionList, sqlTableName, ref parameters);
                result = helper.ExecNonQuery(conn, tran, sql, parameters);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.InternalAPI.MSSQLDAL.SaleSettleDAO.UpdateField",
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

        #region 更新SaleFee结算状态
        /// <summary>
        /// 更新SaleFee结算状态
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int SaveSaleFeeStatus(IDbConnection conn, IDbTransaction tran, string SettleID, int WID,int UserID,string UserName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            try
            {
                IDbDataParameter[] parameters = null;                
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"UPDATE SaleFee SET Status=3,SettleTime=GETDATE(),SettleUserID='{2}',SettleUserName='{3}'
FROM SaleFee H
INNER JOIN 
(SELECT sd.BillID,SUM(CASE WHEN sfd.SettleID IS NULL THEN 1 ELSE 0 END)  CNT 
  FROM SaleSettleDetail sd
  INNER JOIN SaleFee sf ON sd.BillID=sf.FeeID
  INNER JOIN SaleFeeDetails sfd ON sf.FeeID=sfd.FeeID
  WHERE sd.BillType=2 AND sd.SettleID='{1}' AND Sd.WID={0}
  GROUP BY sd.BillID) N ON h.FeeID=n.BillID
  WHERE H.Status=2 AND n.CNT=0", WID, SettleID, UserID, UserName);

                result = helper.ExecNonQuery(conn, tran, sql.ToString(), parameters);
            }
            catch
            {
                throw;
            }
            return result;
        }
        #endregion


        #region 获取零时表
        /// <summary>
        /// 根据字典获取SaleSettle集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SaleSettleTemp> GetList(int ShopID, int WID)
        {
            IList<SaleSettleTemp> list = new List<SaleSettleTemp>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"select * from (
SELECT '' OrderId, BackID as BillID,'' BillDetailsID,BackDate as BillDate,1 as BillType,0-TotalBackAmt BillAmt,0-TotalAddAmt BillAddAmt,0-PayAmount BillPayAmt,'' FeeCode,'' FeeName,Remark  
FROM SaleBack Where Status=2 AND ShopID={1} AND WID={0} 
UNION ALL
SELECT '' OrderId,h.FeeID BillID,d.ID as BillDetailsID, h.FeeDate as BillDate,2 as BillTyped,FeeAmt BillAmt,0 BillAddAmt,FeeAmt BillPayAmt,FeeCode,d.FeeName,Reason as Remark from SaleFee H
INNER JOIN SaleFeeDetails D ON h.FeeID=d.FeeID
WHERE h.WID={0} AND h.status=2 AND d.ShopID={1} AND d.SettleID IS NULL 
) a  order by BillDate asc ,BillPayAmt desc", WID, ShopID);

                list = GetList(sql.ToString(),sp,true);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion

        #region 根据条件获取SaleSettle列表()
        IList<SaleSettleTemp> GetList( string sql, SqlParameter[] sp,bool falg)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleSettleTemp> list = new List<SaleSettleTemp>();
            try
            {

                DataSet ds = helper.GetDataSet(sql, sp);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    list = Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SaleSettleTemp>(ds.Tables[0]);
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.GetList",
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

        #region 删除一个SaleSettle
        /// <summary>
        /// 删除一个SaleSettle
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>数据库影响行数</returns>
        public string Delete(IDbConnection conn, IDbTransaction tran, string SettleID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = SettleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Delete",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result.ToString();
        }
        #endregion


        #region 根据主键获取SaleOrderPre对象(事物)
        /// <summary>
        /// 根据主键获取SaleOrderPre对象(事物)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        public SaleSettle GetModel(IDbConnection conn, IDbTransaction tran, string settleID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleSettle model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@settleID", SqlDbType.VarChar, 50)
                };
                sp[0].Value = settleID;
                DataSet ds = helper.GetDataSet(conn, tran, sql, sp);
                model = Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SaleSettle>(ds.Tables[0])[0];


            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetModel",
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

        #region 根据主键验证SaleSettle是否存在(事物)
        /// <summary>
        /// 根据主键验证SaleSettle是否存在
        /// </summary>
        /// <param name="model">SaleSettle对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(IDbConnection conn, IDbTransaction tran, SaleSettle model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.SettleID;

            try
            {
                result = int.Parse(helper.GetSingle(conn, tran,sql, sp).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleSettle.Exists",
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
    }
}