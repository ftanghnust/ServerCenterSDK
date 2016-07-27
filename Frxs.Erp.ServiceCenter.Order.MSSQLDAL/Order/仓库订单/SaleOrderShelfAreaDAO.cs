
/*****************************
* Author:leidong
*
* Date:2016-04-18
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
    /// ### SaleOrderShelfArea数据库访问类
    /// </summary>
    public partial class SaleOrderShelfAreaDAO : BaseDAL, ISaleOrderShelfAreaDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleOrderShelfAreaDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleOrderShelfAreaDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleOrderShelfArea";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleOrderShelfArea是否存在
        /// <summary>
        /// 根据主键验证SaleOrderShelfArea是否存在
        /// </summary>
        /// <param name="model">SaleOrderShelfArea对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.Exists",
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


        #region 添加一个SaleOrderShelfArea
        /// <summary>
        /// 添加一个SaleOrderShelfArea
        /// </summary>
        /// <param name="model">SaleOrderShelfArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleOrderShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.Package1Qty;
            sp[4].Value = model.Package2Qty;
            sp[5].Value = model.Package3Qty;
            sp[6].Value = model.Remark;
            sp[7].Value = model.ShelfAreaID;
            sp[8].Value = model.ShelfAreaCode;
            sp[9].Value = model.ShelfAreaName;
            sp[10].Value = model.PickUserID;
            sp[11].Value = model.PickUserName;
            sp[12].Value = model.BeginTime;
            sp[13].Value = model.EndTime;
            sp[14].Value = model.ModifyTime;
            sp[15].Value = model.ModifyUserID;
            sp[16].Value = model.ModifyUserName;
            sp[17].Value = model.CheckTime;
            sp[18].Value = model.CheckUserID;
            sp[19].Value = model.CheckUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.Save",
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


        #region 添加一个SaleOrderShelfArea(事务处理)
        /// <summary>
        /// 添加一个SaleOrderShelfArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderShelfArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleOrderShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32)
};
            sp[0].Value = model.ID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.Package1Qty;
            sp[4].Value = model.Package2Qty;
            sp[5].Value = model.Package3Qty;
            sp[6].Value = model.Remark;
            sp[7].Value = model.ShelfAreaID;
            sp[8].Value = model.ShelfAreaCode;
            sp[9].Value = model.ShelfAreaName;
            sp[10].Value = model.PickUserID;
            sp[11].Value = model.PickUserName;
            sp[12].Value = model.BeginTime;
            sp[13].Value = model.EndTime;
            sp[14].Value = model.ModifyTime;
            sp[15].Value = model.ModifyUserID;
            sp[16].Value = model.ModifyUserName;
            sp[17].Value = model.CheckTime;
            sp[18].Value = model.CheckUserID;
            sp[19].Value = model.CheckUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.Save",
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


        #region 更新一个SaleOrderShelfArea
        /// <summary>
        /// 更新一个SaleOrderShelfArea
        /// </summary>
        /// <param name="model">SaleOrderShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.Package1Qty;
            sp[3].Value = model.Package2Qty;
            sp[4].Value = model.Package3Qty;
            sp[5].Value = model.Remark;
            sp[6].Value = model.ShelfAreaID;
            sp[7].Value = model.ShelfAreaCode;
            sp[8].Value = model.ShelfAreaName;
            sp[9].Value = model.PickUserID;
            sp[10].Value = model.PickUserName;
            sp[11].Value = model.BeginTime;
            sp[12].Value = model.EndTime;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.ID;
            sp[17].Value = model.CheckTime;
            sp[18].Value = model.CheckUserID;
            sp[19].Value = model.CheckUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.Edit",
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


        #region 更新一个SaleOrderShelfArea(事务处理)
        /// <summary>
        /// 更新一个SaleOrderShelfArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderShelfArea model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@Package1Qty", SqlDbType.Int),
new SqlParameter("@Package2Qty", SqlDbType.Int),
new SqlParameter("@Package3Qty", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.Int),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfAreaCode", SqlDbType.VarChar, 32),
new SqlParameter("@ShelfAreaName", SqlDbType.NVarChar, 50),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BeginTime", SqlDbType.DateTime),
new SqlParameter("@EndTime", SqlDbType.DateTime),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32)
};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.Package1Qty;
            sp[3].Value = model.Package2Qty;
            sp[4].Value = model.Package3Qty;
            sp[5].Value = model.Remark;
            sp[6].Value = model.ShelfAreaID;
            sp[7].Value = model.ShelfAreaCode;
            sp[8].Value = model.ShelfAreaName;
            sp[9].Value = model.PickUserID;
            sp[10].Value = model.PickUserName;
            sp[11].Value = model.BeginTime;
            sp[12].Value = model.EndTime;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.ID;
            sp[17].Value = model.CheckTime;
            sp[18].Value = model.CheckUserID;
            sp[19].Value = model.CheckUserName;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.Edit",
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


        #region 删除一个SaleOrderShelfArea
        /// <summary>
        /// 删除一个SaleOrderShelfArea
        /// </summary>
        /// <param name="model">SaleOrderShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderShelfArea
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderShelfArea
        /// </summary>
        /// <param name="iD">主键ID(WID + GUID)</param>
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.LogicDelete",
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





        #region 根据主键获取SaleOrderShelfArea对象
        /// <summary>
        /// 根据主键获取SaleOrderShelfArea对象
        /// </summary>
        /// <param name="iD">主键ID(WID + GUID)</param>
        /// <returns>SaleOrderShelfArea对象</returns>
        public SaleOrderShelfArea GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderShelfArea model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderShelfArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.GetModel",
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





        #region 根据字典获取SaleOrderShelfArea数据集
        /// <summary>
        /// 根据字典获取SaleOrderShelfArea数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.GetDataSet",
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


        #region 分页获取SaleOrderShelfArea集合
        /// <summary>
        /// 分页获取SaleOrderShelfArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderShelfArea> GetPageList(PageListBySql<SaleOrderShelfArea> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = " * ";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderShelfArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.GetPageList",
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


        #region 根据条件获取SaleOrderShelfArea列表
        /// <summary>
        /// 根据条件获取SaleOrderShelfArea列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderShelfArea> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderShelfArea> list = new List<SaleOrderShelfArea>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrderShelfArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShelfArea.GetList",
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