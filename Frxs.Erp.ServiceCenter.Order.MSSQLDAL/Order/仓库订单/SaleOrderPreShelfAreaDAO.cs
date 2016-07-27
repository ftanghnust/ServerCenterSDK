/*********************************************************
 * FRXS 小马哥 2016/4/12 17:40:42
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.IDAL.Order;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// 销售订单待拣货区_待处理单据
    /// </summary>
    public partial class SaleOrderPreShelfAreaDAO : BaseDAL, ISaleOrderPreShelfAreaDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleOrderPreShelfAreaDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleOrderPreShelfAreaDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "SaleOrderPreShelfArea";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleOrderPreShelfArea是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreShelfArea是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderPreShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.Exists",
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


        #region 添加一个SaleOrderPreShelfArea
        /// <summary>
        /// 添加一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleOrderPreShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.Save",
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


        #region 添加一个SaleOrderPreShelfArea(事务处理)
        /// <summary>
        /// 添加一个SaleOrderPreShelfArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleOrderPreShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.Save",
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


        #region 更新一个SaleOrderPreShelfArea
        /// <summary>
        /// 更新一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderPreShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.Edit",
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


        #region 更新一个SaleOrderPreShelfArea(事务处理)
        /// <summary>
        /// 更新一个SaleOrderPreShelfArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderPreShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.Edit",
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


        #region 删除一个SaleOrderPreShelfArea
        /// <summary>
        /// 删除一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderPreShelfArea model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderPreShelfArea
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreShelfArea
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.LogicDelete",
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


        #region 根据字典获取SaleOrderPreShelfArea对象
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        public SaleOrderPreShelfArea GetModel(IDictionary<string, object> query)
        {
            SaleOrderPreShelfArea model = null;
            try
            {
                IList<SaleOrderPreShelfArea> list = GetList(query);
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


        #region 根据主键获取SaleOrderPreShelfArea对象
        /// <summary>
        /// 根据主键获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">主键ID(WID + GUID)</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        public SaleOrderPreShelfArea GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderPreShelfArea model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderPreShelfArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.GetModel",
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


        #region 根据字典获取SaleOrderPreShelfArea集合
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public IList<SaleOrderPreShelfArea> GetList(IDictionary<string, object> query)
        {
            IList<SaleOrderPreShelfArea> list = null;
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


        #region 根据字典获取SaleOrderPreShelfArea数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.GetDataSet",
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


        #region 分页获取SaleOrderPreShelfArea集合
        /// <summary>
        /// 分页获取SaleOrderPreShelfArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderPreShelfArea> GetPageList(PageListBySql<SaleOrderPreShelfArea> page, IDictionary<string, object> conditionDict)
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderPreShelfArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.UpdateField",
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


        #region 根据条件获取SaleOrderPreShelfArea列表
        /// <summary>
        /// 根据条件获取SaleOrderPreShelfArea列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPreShelfArea> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderPreShelfArea> list = new List<SaleOrderPreShelfArea>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrderPreShelfArea>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.GetList",
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
    /// 销售订单待拣货区_待处理单据
    /// 龙武
    /// </summary>
    public partial class SaleOrderPreShelfAreaDAO : BaseDAL, ISaleOrderPreShelfAreaDAO
    {
        /// <summary>
        /// 根据订单编号获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">订单编号</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        public List<SaleOrderPreShelfArea> GetModelByOrderId(string orderId, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            List<SaleOrderPreShelfArea> listModel = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByOrderId", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
                 };
                sp[0].Value = orderId;
                DataSet ds = new DataSet();
                if (conn == null || tran == null)
                {
                    ds = helper.GetDataSet(sql, sp);
                }
                else
                {
                    ds = helper.GetDataSet(conn, tran, sql, sp);
                }

                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    listModel = Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SaleOrderPreShelfArea>(ds.Tables[0]).ToList();
                }
                else
                {
                    return null;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.GetModelByOrderId",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return listModel;
        }


        /// <summary>
        /// 根据订单编号获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">订单编号</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        public List<SaleOrderPreShelfArea> GetModelByOrderIdAndAreaID(string orderId, string shelfAreaID, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            List<SaleOrderPreShelfArea> listModel = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByOrderIdAndAreaID", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
                    new SqlParameter("@ShelfAreaID",SqlDbType.Int)
                 };
                sp[0].Value = orderId;
                sp[1].Value = shelfAreaID;
                DataSet ds = helper.GetDataSet(conn, tran, sql, sp);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    listModel = Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SaleOrderPreShelfArea>(ds.Tables[0]).ToList();
                }
                else
                {
                    return null;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreShelfArea.GetModelByOrderId",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return listModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int EditByAreaID(SaleOrderPreShelfArea model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditByAreaID", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sParam = new SqlParameter[] { 
                new SqlParameter("@ModifyUserID",model.ModifyUserID),
                new SqlParameter("@ModifyUserName",model.ModifyUserName),
                new SqlParameter("@OrderId",model.OrderID),
                new SqlParameter("@ShelfAreaID",model.ShelfAreaID)
            };
            return helper.ExecNonQuery(conn, tran, sql, sParam);
        }
    }

    /// <summary>
    /// by leidong
    /// </summary>
    public partial class SaleOrderPreShelfAreaDAO : BaseDAL, ISaleOrderPreShelfAreaDAO
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
