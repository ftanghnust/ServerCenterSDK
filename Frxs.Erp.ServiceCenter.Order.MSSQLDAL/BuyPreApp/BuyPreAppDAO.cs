
/*****************************
* Author:CR
*
* Date:2016-04-25
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
    /// ### BuyPreApp数据库访问类
    /// </summary>
    public partial class BuyPreAppDAO : BaseDAL, IBuyPreAppDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyPreAppDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyPreAppDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "BuyPreApp";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证BuyPreApp是否存在
        /// <summary>
        /// 根据主键验证BuyPreApp是否存在
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(BuyPreApp model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.AppID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.Exists",
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


        #region 添加一个BuyPreApp
        /// <summary>
        /// 添加一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(BuyPreApp model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36),
new SqlParameter("@AppType", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@AppDate", SqlDbType.DateTime),
new SqlParameter("@BuyEmpID", SqlDbType.Int),
new SqlParameter("@BuyEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.AppID;
            sp[1].Value = model.AppType;
            sp[2].Value = model.WID;
            sp[3].Value = model.WCode;
            sp[4].Value = model.WName;
            sp[5].Value = model.SubWID;
            sp[6].Value = model.SubWCode;
            sp[7].Value = model.SubWName;
            sp[8].Value = model.AppDate;
            sp[9].Value = model.BuyEmpID;
            sp[10].Value = model.BuyEmpName;
            sp[11].Value = model.Status;
            sp[12].Value = model.TotalAmt;
            sp[13].Value = model.Remark;
            sp[14].Value = model.CreateTime;
            sp[15].Value = model.CreateUserID;
            sp[16].Value = model.CreateUserName;
            sp[17].Value = model.ModifyTime;
            sp[18].Value = model.ModifyUserID;
            sp[19].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.Save",
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


        #region 添加一个BuyPreApp(事务处理)
        /// <summary>
        /// 添加一个BuyPreApp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, BuyPreApp model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36),
new SqlParameter("@AppType", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@AppDate", SqlDbType.DateTime),
new SqlParameter("@BuyEmpID", SqlDbType.Int),
new SqlParameter("@BuyEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 64),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.AppID;
            sp[1].Value = model.AppType;
            sp[2].Value = model.WID;
            sp[3].Value = model.WCode;
            sp[4].Value = model.WName;
            sp[5].Value = model.SubWID;
            sp[6].Value = model.SubWCode;
            sp[7].Value = model.SubWName;
            sp[8].Value = model.AppDate;
            sp[9].Value = model.BuyEmpID;
            sp[10].Value = model.BuyEmpName;
            sp[11].Value = model.Status;
            sp[12].Value = model.TotalAmt;
            sp[13].Value = model.Remark;
            sp[14].Value = model.CreateTime;
            sp[15].Value = model.CreateUserID;
            sp[16].Value = model.CreateUserName;
            sp[17].Value = model.ModifyTime;
            sp[18].Value = model.ModifyUserID;
            sp[19].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.Save",
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


        #region 更新一个BuyPreApp
        /// <summary>
        /// 更新一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BuyPreApp model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppType", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@AppDate", SqlDbType.DateTime),
new SqlParameter("@BuyEmpID", SqlDbType.Int),
new SqlParameter("@BuyEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AppID", SqlDbType.VarChar, 36)

};
            sp[0].Value = model.AppType;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.SubWID;
            sp[5].Value = model.SubWCode;
            sp[6].Value = model.SubWName;
            sp[7].Value = model.AppDate;
            sp[8].Value = model.BuyEmpID;
            sp[9].Value = model.BuyEmpName;
            sp[10].Value = model.Status;
            sp[11].Value = model.TotalAmt;
            sp[12].Value = model.Remark;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.AppID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.Edit",
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

        #region 更新修改状态

       public int EditStatus(BuyPreApp model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditStatus", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ConfTime", SqlDbType.DateTime),
new SqlParameter("@ConfUserID", SqlDbType.Int),
new SqlParameter("@ConfUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PostingTime", SqlDbType.DateTime),
new SqlParameter("@PostingUserID", SqlDbType.Int),
new SqlParameter("@PostingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AppID", SqlDbType.VarChar, 36)
};

            sp[0].Value = model.Status;
            sp[1].Value = model.ConfTime;
            sp[2].Value = model.ConfUserID;
            sp[3].Value = model.ConfUserName;
            sp[4].Value = model.PostingTime;
            sp[5].Value = model.PostingUserID;
            sp[6].Value = model.PostingUserName;
            sp[7].Value = model.ModifyTime;
            sp[8].Value = model.ModifyUserID;
            sp[9].Value = model.ModifyUserName;
            sp[10].Value = model.AppID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.Edit",
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

        #region 更新一个BuyPreApp(事务处理)
        /// <summary>
        /// 更新一个BuyPreApp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, BuyPreApp model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppType", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@AppDate", SqlDbType.DateTime),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@TotalAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AppID", SqlDbType.VarChar, 36)

};
            sp[0].Value = model.AppType;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.SubWID;
            sp[5].Value = model.SubWCode;
            sp[6].Value = model.SubWName;
            sp[7].Value = model.AppDate;
            sp[8].Value = model.Status;
            sp[9].Value = model.TotalAmt;
            sp[10].Value = model.Remark;
            sp[11].Value = model.ModifyTime;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;
            sp[14].Value = model.AppID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.Edit",
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


        #region 删除一个BuyPreApp
        /// <summary>
        /// 删除一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BuyPreApp model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = model.AppID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.Delete",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }


        /// <summary>
        /// 删除一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string appId, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = appId;

            try
            {

                if (conn == null && tran == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDAO.Delete",
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


        #region 根据主键逻辑删除一个BuyPreApp
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreApp
        /// </summary>
        /// <param name="appID">申请ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string appID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36)
 };
            sp[0].Value = appID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.LogicDelete",
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




        #region 根据主键获取BuyPreApp对象
        /// <summary>
        /// 根据主键获取BuyPreApp对象
        /// </summary>
        /// <param name="appID">申请ID</param>
        /// <returns>BuyPreApp对象</returns>
        public BuyPreApp GetModel(string appID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            BuyPreApp model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36)
 };
                sp[0].Value = appID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<BuyPreApp>(sdr);
                }
                model.StatusStr =model.Status==0 ?"录单": (model.Status==1 ?"已确认": "已对账");
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.GetModel",
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



        #region 根据字典获取BuyPreApp数据集
        /// <summary>
        /// 根据字典获取BuyPreApp数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.GetDataSet",
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


        #region 分页获取BuyPreApp集合
        /// <summary>
        /// 分页获取BuyPreApp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<BuyPreApp> GetPageList(PageListBySql<BuyPreApp> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "AppID,AppType,WID,WCode,WName,SubWID,SubWCode,SubWName,AppDate,BuyEmpID,BuyEmpName,Status,TotalAmt,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);
                StringBuilder sb = new StringBuilder();
                if (conditionDict.ContainsKey("AppDateStart"))
                {
                    sb.AppendFormat(" and AppDate  >='{0}' ", conditionDict["AppDateStart"]);
                }
                if (conditionDict.ContainsKey("AppDateEnd"))
                {
                    sb.AppendFormat("  and AppDate <='{0}' ", conditionDict["AppDateEnd"]);
                }
                if (conditionDict.ContainsKey("PostingTimeStart"))
                {
                    sb.AppendFormat(" and PostingTime  >='{0}' ", conditionDict["PostingTimeStart"]);
                }
                if (conditionDict.ContainsKey("PostingTimeEnd"))
                {
                    sb.AppendFormat("  and PostingTime <='{0}' ", conditionDict["PostingTimeEnd"]);
                }
                page.Where = page.Where + sb.ToString();
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
                    page.ItemList = DataReaderHelper.ExecuteToList<BuyPreApp>(sdr);
                }
                if (page.ItemList != null && page.ItemList.Count>0 )
                {
                    foreach (BuyPreApp obj in page.ItemList)
                    {
                        obj.StatusStr = obj.Status == 0 ? "录单" : (obj.Status == 1 ? "已确认" : "已对账");
                    }
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.GetPageList",
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
            IList<WhereCondition> whereConditionList = new List<WhereCondition>();
            #region
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

            if (conditionDict.ContainsKey("AppType"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "AppType",
                        FieldValue = conditionDict["AppType"],
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
            if (conditionDict.ContainsKey("SubWID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "SubWID",
                        FieldValue = conditionDict["SubWID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }
            if (conditionDict.ContainsKey("AppID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "AppID",
                        FieldValue = conditionDict["AppID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }

            #endregion

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
                return "AppID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取BuyPreApp列表
        /// <summary>
        /// 根据条件获取BuyPreApp列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<BuyPreApp> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<BuyPreApp> list = new List<BuyPreApp>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<BuyPreApp>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApp.GetList",
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
}