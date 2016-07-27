
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
    /// ### BuyPreAppDetails数据库访问类
    /// </summary>
    public partial class BuyPreAppDetailsDAO : BaseDAL, IBuyPreAppDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyPreAppDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyPreAppDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "BuyPreAppDetails";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证BuyPreAppDetails是否存在
        /// <summary>
        /// 根据主键验证BuyPreAppDetails是否存在
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(BuyPreAppDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.Exists",
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


        #region 添加一个BuyPreAppDetails
        /// <summary>
        /// 添加一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(BuyPreAppDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@AppID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@AppUnit", SqlDbType.VarChar, 32),
new SqlParameter("@AppPackingQty", SqlDbType.Int),
new SqlParameter("@AppQty", SqlDbType.Decimal, 4),
new SqlParameter("@AppPrice", SqlDbType.Money),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.AppID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.AppUnit;
            sp[10].Value = model.AppPackingQty;
            sp[11].Value = model.AppQty;
            sp[12].Value = model.AppPrice;
            sp[13].Value = model.Unit;
            sp[14].Value = model.UnitQty;
            sp[15].Value = model.UnitPrice;
            sp[16].Value = model.SubAmt;
            sp[17].Value = model.Remark;
            sp[18].Value = model.SerialNumber;
            sp[19].Value = model.VendorID;
            sp[20].Value = model.VendorCode;
            sp[21].Value = model.VendorName;
            sp[22].Value = model.ModifyTime;
            sp[23].Value = model.ModifyUserID;
            sp[24].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.Save",
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


        #region 添加一个BuyPreAppDetails(事务处理)
        /// <summary>
        /// 添加一个BuyPreAppDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, BuyPreAppDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@AppID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@AppUnit", SqlDbType.VarChar, 32),
new SqlParameter("@AppPackingQty", SqlDbType.Int),
new SqlParameter("@AppQty", SqlDbType.Decimal, 4),
new SqlParameter("@AppPrice", SqlDbType.Money),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BuyEmpID", SqlDbType.Int),
new SqlParameter("@BuyEmpName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.AppID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.AppUnit;
            sp[10].Value = model.AppPackingQty;
            sp[11].Value = model.AppQty;
            sp[12].Value = model.AppPrice;
            sp[13].Value = model.Unit;
            sp[14].Value = model.UnitQty;
            sp[15].Value = model.UnitPrice;
            sp[16].Value = model.SubAmt;
            sp[17].Value = model.Remark;
            sp[18].Value = model.SerialNumber;
            sp[19].Value = model.VendorID;
            sp[20].Value = model.VendorCode;
            sp[21].Value = model.VendorName;
            sp[22].Value = model.ModifyTime;
            sp[23].Value = model.ModifyUserID;
            sp[24].Value = model.ModifyUserName;
            sp[25].Value = model.BuyEmpID;
            sp[26].Value = model.BuyEmpName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.Save",
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


        #region 更新一个BuyPreAppDetails
        /// <summary>
        /// 更新一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BuyPreAppDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@AppUnit", SqlDbType.VarChar, 32),
new SqlParameter("@AppPackingQty", SqlDbType.Int),
new SqlParameter("@AppQty", SqlDbType.Decimal, 4),
new SqlParameter("@AppPrice", SqlDbType.Money),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.AppID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ProductId;
            sp[3].Value = model.SKU;
            sp[4].Value = model.ProductName;
            sp[5].Value = model.BarCode;
            sp[6].Value = model.ProductImageUrl200;
            sp[7].Value = model.ProductImageUrl400;
            sp[8].Value = model.AppUnit;
            sp[9].Value = model.AppPackingQty;
            sp[10].Value = model.AppQty;
            sp[11].Value = model.AppPrice;
            sp[12].Value = model.Unit;
            sp[13].Value = model.UnitQty;
            sp[14].Value = model.UnitPrice;
            sp[15].Value = model.SubAmt;
            sp[16].Value = model.Remark;
            sp[17].Value = model.SerialNumber;
            sp[18].Value = model.VendorID;
            sp[19].Value = model.VendorCode;
            sp[20].Value = model.VendorName;
            sp[21].Value = model.ModifyTime;
            sp[22].Value = model.ModifyUserID;
            sp[23].Value = model.ModifyUserName;
            sp[24].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.Edit",
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


        #region 更新一个BuyPreAppDetails(事务处理)
        /// <summary>
        /// 更新一个BuyPreAppDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, BuyPreAppDetails model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@AppID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@AppUnit", SqlDbType.VarChar, 32),
new SqlParameter("@AppPackingQty", SqlDbType.Int),
new SqlParameter("@AppQty", SqlDbType.Decimal, 4),
new SqlParameter("@AppPrice", SqlDbType.Money),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@VendorCode", SqlDbType.VarChar, 32),
new SqlParameter("@VendorName", SqlDbType.NVarChar, 50),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@BuyEmpID", SqlDbType.Int),
new SqlParameter("@BuyEmpName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.AppID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ProductId;
            sp[3].Value = model.SKU;
            sp[4].Value = model.ProductName;
            sp[5].Value = model.BarCode;
            sp[6].Value = model.ProductImageUrl200;
            sp[7].Value = model.ProductImageUrl400;
            sp[8].Value = model.AppUnit;
            sp[9].Value = model.AppPackingQty;
            sp[10].Value = model.AppQty;
            sp[11].Value = model.AppPrice;
            sp[12].Value = model.Unit;
            sp[13].Value = model.UnitQty;
            sp[14].Value = model.UnitPrice;
            sp[15].Value = model.SubAmt;
            sp[16].Value = model.Remark;
            sp[17].Value = model.SerialNumber;
            sp[18].Value = model.VendorID;
            sp[19].Value = model.VendorCode;
            sp[20].Value = model.VendorName;
            sp[21].Value = model.ModifyTime;
            sp[22].Value = model.ModifyUserID;
            sp[23].Value = model.ModifyUserName;
            sp[24].Value = model.ID;
            sp[25].Value = model.BuyEmpID;
            sp[26].Value = model.BuyEmpName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.Edit",
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


        #region 删除一个BuyPreAppDetails
        /// <summary>
        /// 删除一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BuyPreAppDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.Delete",
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
        /// Delete一个BuyPreAppDetails(事务处理)
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public int Delete(IDbConnection conn, IDbTransaction tran, string appId)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreApDetailsDAO.Delete",
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


        #region 根据主键逻辑删除一个BuyPreAppDetails
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreAppDetails
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.LogicDelete",
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



        #region 根据主键获取BuyPreAppDetails对象
        /// <summary>
        /// 根据主键获取BuyPreAppDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>BuyPreAppDetails对象</returns>
        public BuyPreAppDetails GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            BuyPreAppDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<BuyPreAppDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.GetModel",
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


        #region 根据字典获取BuyPreAppDetails数据集
        /// <summary>
        /// 根据字典获取BuyPreAppDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.GetDataSet",
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


        #region 分页获取BuyPreAppDetails集合
        /// <summary>
        /// 分页获取BuyPreAppDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<BuyPreAppDetails> GetPageList(PageListBySql<BuyPreAppDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,AppID,WID,ProductId,SKU,ProductName,BarCode,ProductImageUrl200,ProductImageUrl400,AppUnit,AppPackingQty,AppQty,AppPrice,Unit,UnitQty,UnitPrice,SubAmt,Remark,SerialNumber,VendorID,VendorCode,VendorName,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<BuyPreAppDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.GetPageList",
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


        #region 根据条件获取BuyPreAppDetails列表


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public IList<BuyPreAppDetails> GetModelList(string appId) 
        {
            IList<BuyPreAppDetails> list = null;
            try
            {
                IDictionary<string, object> conditionDict = new Dictionary<string, object>();
                conditionDict.Add("AppID", appId);

                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
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

        /// <summary>
        /// 根据条件获取BuyPreAppDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<BuyPreAppDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<BuyPreAppDetails> list = new List<BuyPreAppDetails>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<BuyPreAppDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyPreAppDetails.GetList",
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