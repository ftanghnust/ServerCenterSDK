

/*****************************
* Author:leidong
*
* Date:2016-04-08
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL
{
    /// <summary>
    /// ### SaleOrderShop数据库访问类
    /// </summary>
    public partial class SaleOrderShopDAO : BaseDAL, ISaleOrderShopDAO
    {
        const string tableName = "SaleOrderShop";


        public SaleOrderShopDAO(string warehouseId)
            : base(warehouseId)
        {

        }

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证SaleOrderShop是否存在
        /// <summary>
        /// 根据主键验证SaleOrderShop是否存在
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderShop model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleOrderShop.Exists",
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

        #region 根据主键逻辑删除一个SaleOrderShop
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderShop
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = orderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleOrderShop.LogicDelete",
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


        #region 根据字典获取SaleOrderShop对象
        /// <summary>
        /// 根据字典获取SaleOrderShop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderShop对象</returns>
        public SaleOrderShop GetModel(IDictionary<string, object> conditionDict)
        {
            SaleOrderShop model = null;
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
                IList<SaleOrderShop> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleOrderShop对象
        /// <summary>
        /// 根据主键获取SaleOrderShop对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderShop对象</returns>
        public SaleOrderShop GetModel(string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderShop model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
                sp[0].Value = orderId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderShop>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleOrderShop.GetModel",
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


        #region 根据字典获取SaleOrderShop集合
        /// <summary>
        /// 根据字典获取SaleOrderShop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleOrderShop> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleOrderShop> list = null;
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
                list = GetList(where.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }
        #endregion


        #region 根据字典获取SaleOrderShop数据集
        /// <summary>
        /// 根据字典获取SaleOrderShop数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleOrderShop.GetDataSet",
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


        #region 分页获取SaleOrderShop集合
        /// <summary>
        /// 分页获取SaleOrderShop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderShop> GetPageList(PageListBySql<SaleOrderShop> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "OrderId,SettleID,WID,SubWID,OrderDate,OrderType,WCode,WName,ShopType,SubWCode,SubWName,ShopID,XSUserID,ShopCode,ShopName,Status,ProvinceID,CityID,RegionID,ProvinceName,CityName,RegionName,Address,FullAddress,RevLinkMan,RevTelephone,ConfDate,SendDate,LineID,StationNumber,PickingBeginDate,PickingEndDate,PackingEmpID,PackingEmpName,PackingTime,IsPrinted,PrintDate,PrintUserID,PrintUserName,ShippingBeginDate,ShippingUserID,ShippingUserName,ShippingEndDate,FinishDate,CancelDate,CloseDate,CloseReason,Remark,TotalProductAmt,CouponAmt,TotalAddAmt,PayAmount,TotalPoint,TotalBasePoint,UserShowFlag,ClientType,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,LineName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderShop>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleOrderShop.GetPageList",
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
        public int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            try
            {
                IDbDataParameter[] parameters = null;
                string sql = new FieldUpdater().UpdateField(fieldList, whereConditionList, tableName, ref parameters);
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, parameters);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleOrderShop.UpdateField",
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
                return "OrderId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleOrderShop列表
        /// <summary>
        /// 根据条件获取SaleOrderShop列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderShop> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderShop> list = new List<SaleOrderShop>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrderShop>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleOrderShop.GetList",
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

    public partial class SaleOrderShopDAO : BaseDAL, ISaleOrderShopDAO
    {
        #region 添加一个SaleOrderShop
        /// <summary>
        /// 添加一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleOrderShop model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar, 100),
new SqlParameter("@CityName", SqlDbType.VarChar, 100),
new SqlParameter("@RegionName", SqlDbType.VarChar, 100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@LineName",SqlDbType.NVarChar,200), 

};
            sp[0].Value = model.OrderId;
            sp[1].Value = model.SettleID;
            sp[2].Value = model.WID;
            sp[3].Value = model.SubWID;
            //sp[4].Value = model.OrderDate;
            setTimeNull(model.OrderDate, sp[4]);
            sp[5].Value = model.OrderType;
            sp[6].Value = model.WCode;
            sp[7].Value = model.WName;
            sp[8].Value = model.ShopType;
            sp[9].Value = model.SubWCode;
            sp[10].Value = model.SubWName;
            sp[11].Value = model.ShopID;
            sp[12].Value = model.XSUserID;
            sp[13].Value = model.ShopCode;
            sp[14].Value = model.ShopName;
            sp[15].Value = model.Status;
            sp[16].Value = model.ProvinceID;
            sp[17].Value = model.CityID;
            sp[18].Value = model.RegionID;
            sp[19].Value = model.ProvinceName;
            sp[20].Value = model.CityName;
            sp[21].Value = model.RegionName;
            sp[22].Value = model.Address;
            sp[23].Value = model.FullAddress;
            sp[24].Value = model.RevLinkMan;
            sp[25].Value = model.RevTelephone;
            //sp[26].Value = model.ConfDate;
            setTimeNull(model.ConfDate, sp[26]);
            //sp[27].Value = model.SendDate;
            setTimeNull(model.SendDate, sp[27]);
            sp[28].Value = model.LineID;
            sp[29].Value = model.StationNumber;
            //sp[30].Value = model.PickingBeginDate;
            setTimeNull(model.PickingBeginDate, sp[30]);
            //sp[31].Value = model.PickingEndDate;
            setTimeNull(model.PickingEndDate, sp[31]);
            sp[32].Value = model.PackingEmpID;
            sp[33].Value = model.PackingEmpName;
            //sp[34].Value = model.PackingTime;
            setTimeNull(model.PackingTime, sp[34]);
            sp[35].Value = model.IsPrinted;
            //sp[36].Value = model.PrintDate;
            setTimeNull(model.PrintDate, sp[36]);
            sp[37].Value = model.PrintUserID;
            sp[38].Value = model.PrintUserName;
            //sp[39].Value = model.ShippingBeginDate;
            setTimeNull(model.ShippingBeginDate, sp[39]);
            sp[40].Value = model.ShippingUserID;
            sp[41].Value = model.ShippingUserName;
            //sp[42].Value = model.ShippingEndDate;
            setTimeNull(model.ShippingEndDate, sp[42]);
            //sp[43].Value = model.FinishDate;
            setTimeNull(model.FinishDate, sp[43]);
            //sp[44].Value = model.CancelDate;
            setTimeNull(model.CancelDate, sp[44]);
            //sp[45].Value = model.CloseDate;
            setTimeNull(model.CloseDate, sp[45]);
            sp[46].Value = model.CloseReason;
            sp[47].Value = model.Remark;
            sp[48].Value = model.TotalProductAmt;
            sp[49].Value = model.CouponAmt;
            sp[50].Value = model.TotalAddAmt;
            sp[51].Value = model.PayAmount;
            sp[52].Value = model.TotalPoint;
            sp[53].Value = model.TotalBasePoint;
            sp[54].Value = model.UserShowFlag;
            sp[55].Value = model.ClientType;
            //sp[56].Value = model.CreateTime;
            setTimeNull(model.CreateTime, sp[56]);
            sp[57].Value = model.CreateUserID;
            sp[58].Value = model.CreateUserName;
            //sp[59].Value = model.ModifyTime;
            setTimeNull(model.ModifyTime, sp[59]);
            sp[60].Value = model.ModifyUserID;
            sp[61].Value = model.ModifyUserName;
            sp[62].Value = model.LineName;

            try
            {
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShop.Save",
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


        #region 更新一个SaleOrderShop
        /// <summary>
        /// 更新一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderShop model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar, 100),
new SqlParameter("@CityName", SqlDbType.VarChar, 100),
new SqlParameter("@RegionName", SqlDbType.VarChar, 100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
new SqlParameter("@LineName",SqlDbType.NVarChar,200), 

};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            //sp[3].Value = model.OrderDate;
            setTimeNull(model.OrderDate, sp[3]);
            sp[4].Value = model.OrderType;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.ShopType;
            sp[8].Value = model.SubWCode;
            sp[9].Value = model.SubWName;
            sp[10].Value = model.ShopID;
            sp[11].Value = model.XSUserID;
            sp[12].Value = model.ShopCode;
            sp[13].Value = model.ShopName;
            sp[14].Value = model.Status;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.ProvinceName;
            sp[19].Value = model.CityName;
            sp[20].Value = model.RegionName;
            sp[21].Value = model.Address;
            sp[22].Value = model.FullAddress;
            sp[23].Value = model.RevLinkMan;
            sp[24].Value = model.RevTelephone;
            //sp[25].Value = model.ConfDate;
            setTimeNull(model.ConfDate, sp[25]);
            //sp[26].Value = model.SendDate;
            setTimeNull(model.SendDate, sp[26]);
            sp[27].Value = model.LineID;
            sp[28].Value = model.StationNumber;
            //sp[29].Value = model.PickingBeginDate;
            setTimeNull(model.PickingBeginDate, sp[29]);
            //sp[31].Value = model.PickingEndDate;
            setTimeNull(model.PickingEndDate, sp[30]);
            sp[31].Value = model.PackingEmpID;
            sp[32].Value = model.PackingEmpName;
            //sp[33].Value = model.PackingTime;
            setTimeNull(model.PackingTime, sp[33]);
            sp[34].Value = model.IsPrinted;
            //sp[35].Value = model.PrintDate;
            setTimeNull(model.PrintDate, sp[35]);
            sp[36].Value = model.PrintUserID;
            sp[37].Value = model.PrintUserName;
            //sp[38].Value = model.ShippingBeginDate;
            setTimeNull(model.ShippingBeginDate, sp[38]);
            sp[39].Value = model.ShippingUserID;
            sp[40].Value = model.ShippingUserName;
            //sp[41].Value = model.ShippingEndDate;
            setTimeNull(model.ShippingEndDate, sp[41]);
            //sp[42].Value = model.FinishDate;
            setTimeNull(model.FinishDate, sp[42]);
            //sp[43].Value = model.CancelDate;
            setTimeNull(model.CancelDate, sp[43]);
            //sp[44].Value = model.CloseDate;
            setTimeNull(model.CloseDate, sp[44]);
            sp[45].Value = model.CloseReason;
            sp[46].Value = model.Remark;
            sp[47].Value = model.TotalProductAmt;
            sp[48].Value = model.CouponAmt;
            sp[49].Value = model.TotalAddAmt;
            sp[50].Value = model.PayAmount;
            sp[51].Value = model.TotalPoint;
            sp[52].Value = model.TotalBasePoint;
            sp[53].Value = model.UserShowFlag;
            sp[54].Value = model.ClientType;
            //sp[55].Value = model.ModifyTime;
            setTimeNull(model.ModifyTime, sp[55]);
            sp[56].Value = model.ModifyUserID;
            sp[57].Value = model.ModifyUserName;
            sp[58].Value = model.OrderId;
            sp[59].Value = model.LineName;

            try
            {
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShop.Edit",
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


        #region 删除一个SaleOrderShop
        /// <summary>
        /// 删除一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderShop model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderId;

            try
            {
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShop.Delete",
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



        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="searchDate"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public IList<ShopOrder> GetShopOrder(string searchDate, int wid)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<ShopOrder> list = new List<ShopOrder>();
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadShopOrder", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                 new SqlParameter("@SendDate", SqlDbType.VarChar, 50),
                 new SqlParameter("@WID", SqlDbType.VarChar, 50)
                 };
            sp[0].Value = searchDate ;
            sp[1].Value = wid;

            try
            {
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new ShopOrder
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"])

                        });
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShop.GetShopOrder",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }
        /// <summary>
        /// 获得未确认订单
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <returns></returns>
        public SaleOrderShop GetUnConfirmOrder(int shopId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UnConfirmOrder", base.AssemblyName, base.DatabaseName);
            var sp = new SqlParamrterBuilder();
            sp.Add("ShopId", SqlDbType.Int, 4, shopId);
            try
            {
                using (IDataReader dataReader = helper.GetIDataReader(sql, sp.ToSqlParameters()))
                {
                    return this.ExecuteToEntity<SaleOrderShop>(dataReader);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShop.Exists",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public IList<SaleOrderShop> Query(OrderQuery query, out int total)
        {
            string sql = "WITH LIST AS (" + SQLConfigBuilder.GetSQLScriptByTable(tableName, "Query", base.AssemblyName, base.DatabaseName);
            StringBuilder sWhere = new StringBuilder(" where 1=1 ");
            SqlParamrterBuilder sp = new SqlParamrterBuilder();

            sql = string.Format(sql, query.SortBy);
            if (!string.IsNullOrEmpty(query.OrderId))
            {
                sWhere.Append(" And OrderId like @OrderId");
                sp.Add("OrderId", SqlDbType.VarChar, 55, "%" + query.OrderId + "%");
            }
            if (!string.IsNullOrEmpty(query.SettleID))
            {
                sWhere.Append(" And SettleID like @SettleID");
                sp.Add("SettleID", SqlDbType.VarChar, 40, "%" + query.SettleID + "%");
            }
            if (query.OrderDateBegin.HasValue)
            {
                sWhere.Append(" And OrderDate>=@OrderDateBegin");
                sp.Add("OrderDateBegin", SqlDbType.DateTime, query.OrderDateBegin.Value);
            }
            if (query.OrderDateEnd.HasValue)
            {
                sWhere.Append(" And OrderDate<=@OrderDateEnd");
                sp.Add("OrderDateEnd", SqlDbType.DateTime, query.OrderDateEnd.Value);
            }
            if (query.Status.HasValue)
            {
                if (query.Status.Value != OrderStatus.Cancel)
                {
                    sWhere.Append(" And Status=@Status");
                    sp.Add("Status", SqlDbType.Int, 4, (int)query.Status.Value);
                }
                else
                {
                    sWhere.Append(" And (Status=8 or Status=9)");
                }
            }
            if (query.ShopId.HasValue)
            {
                sWhere.Append(" And ShopId=@ShopId");
                sp.Add("ShopId", SqlDbType.Int, 4, query.ShopId.Value);
            }
            if (!string.IsNullOrEmpty(query.ShopName))
            {
                sWhere.Append(" And ( ShopName like @ShopName or ShopCode like @ShopName)");
                sp.Add("ShopName", SqlDbType.VarChar, 40, "%" + query.ShopName + "%");
            }
            if (query.WID.HasValue)
            {
                sWhere.Append(" And WID=@WID");
                sp.Add("WID", SqlDbType.Int, 4, query.WID.Value);
            }
            if (query.LineID.HasValue)
            {
                sWhere.Append(" And LineID=@LineID");
                sp.Add("LineID", SqlDbType.Int, 4, query.LineID.Value);
            }
            if (!string.IsNullOrEmpty(query.ShopCode))
            {
                sWhere.Append(" And ShopCode like @ShopCode");
                sp.Add("ShopCode", SqlDbType.VarChar, 40, "%" + query.ShopCode + "%");
            }
            if (query.ShopType.HasValue)
            {
                sWhere.Append(" And ShopType=@ShopType");
                sp.Add("ShopType", SqlDbType.Int, 4, query.ShopType.Value);
            }
            if (query.SendDateBegin.HasValue)
            {
                sWhere.Append(" And SendDate>=@SendDateBegin");
                sp.Add("SendDateBegin", SqlDbType.DateTime, query.SendDateBegin.Value);
            }
            if (query.SendDateEnd.HasValue)
            {
                sWhere.Append(" And SendDate<=@SendDateEnd");
                sp.Add("SendDateEnd", SqlDbType.DateTime, query.SendDateEnd.Value);
            }
            if (query.SubID.HasValue)
            {
                sWhere.Append(" And SubWID=@SubWID");
                sp.Add("SubWID", SqlDbType.Int, query.SubID.Value);
            }

            string sqlCount = "";
            sqlCount += sql + sWhere.ToString() + ") select Count(*) from LIST ";
            total = GetCount(sqlCount, sp.ToSqlParameters());
            if (query.PageIndex > 1 && query.PageSize >= total)
            {
                query.PageIndex = 1;
            }
            sql += sWhere.ToString() + string.Format(") SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (query.PageIndex - 1) * query.PageSize + 1, query.PageIndex * query.PageSize);

            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            using (IDataReader dataReader = helper.GetIDataReader(sql, sp.ToSqlParameters()))
            {
                return this.ExecuteTolist<SaleOrderShop>(dataReader);
            }
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        private int GetCount(string sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            var result = helper.GetSingle(sql, sp);
            if (result != null)
            {
                return int.Parse(result.ToString());
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="sp">传参</param>
        private void setTimeNull(DateTime? time, SqlParameter sp)
        {
            //sp=new SqlParameter();
            if (!time.HasValue)
            {
                sp.Value = DBNull.Value;
                return;
            }
            if (time.Value.Year < 1975)
            {
                sp.Value = DBNull.Value;
                return;
            }
            sp.Value = time.Value;
        }
    }
}