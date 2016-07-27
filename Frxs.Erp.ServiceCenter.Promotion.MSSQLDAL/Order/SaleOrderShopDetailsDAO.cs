
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;
/*****************************
* Author:leidong
*
* Date:2016-04-06
******************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;


namespace Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL
{
    /// <summary>
    /// ### SaleOrderShopDetails数据库访问类
    /// </summary>
    public partial class SaleOrderShopDetailsDAO : BaseDAL, ISaleOrderShopDetailsDAO
    {
        const string tableName = "SaleOrderShopDetails";

        public SaleOrderShopDetailsDAO(string warehouseId)
            : base(warehouseId)
        {

        }

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }

        #region 成员方法
        #region 根据主键验证SaleOrderShopDetails是否存在
        /// <summary>
        /// 根据主键验证SaleOrderShopDetails是否存在
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderShopDetails model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.Exists",
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


        #region 添加一个SaleOrderShopDetails
        /// <summary>
        /// 添加一个SaleOrderShopDetails
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleOrderShopDetails model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@PromotionUnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@PromotionShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SubAddAmt", SqlDbType.Money),
new SqlParameter("@SubPoint", SqlDbType.Money),
new SqlParameter("@SubBasePoint", SqlDbType.Money),
new SqlParameter("@SubVendor1Amt", SqlDbType.Money),
new SqlParameter("@SubVendor2Amt", SqlDbType.Money),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@IsStockOut", SqlDbType.Int),
new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
new SqlParameter("@PromotionName", SqlDbType.NVarChar, 100),
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.ID;
            sp[1].Value = model.OrderID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.WCProductID;
            sp[10].Value = model.PreQty;
            sp[11].Value = model.SaleUnit;
            sp[12].Value = model.SalePackingQty;
            sp[13].Value = model.SalePrice;
            sp[14].Value = model.SaleQty;
            sp[15].Value = model.Unit;
            sp[16].Value = model.UnitQty;
            sp[17].Value = model.UnitPrice;
            sp[18].Value = model.PromotionUnitPrice;
            sp[19].Value = model.SubAmt;
            sp[20].Value = model.ShopAddPerc;
            sp[21].Value = model.ShopPoint;
            sp[22].Value = model.PromotionShopPoint;
            sp[23].Value = model.BasePoint;
            sp[24].Value = model.VendorPerc1;
            sp[25].Value = model.VendorPerc2;
            sp[26].Value = model.SubAddAmt;
            sp[27].Value = model.SubPoint;
            sp[28].Value = model.SubBasePoint;
            sp[29].Value = model.SubVendor1Amt;
            sp[30].Value = model.SubVendor2Amt;
            sp[31].Value = model.IsAppend;
            sp[32].Value = model.EditID;
            sp[33].Value = model.IsStockOut;
            sp[34].Value = model.PromotionID;
            sp[35].Value = model.PromotionName;
            sp[36].Value = model.Remark;
            sp[37].Value = model.SerialNumber;
            sp[38].Value = model.ModifyTime;
            sp[39].Value = model.ModifyUserID;
            sp[40].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.Save",
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


        #region 更新一个SaleOrderShopDetails
        /// <summary>
        /// 更新一个SaleOrderShopDetails
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderShopDetails model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.VarChar, 32),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@SalePrice", SqlDbType.Money),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@Unit", SqlDbType.VarChar, 32),
new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
new SqlParameter("@UnitPrice", SqlDbType.Money),
new SqlParameter("@PromotionUnitPrice", SqlDbType.Money),
new SqlParameter("@SubAmt", SqlDbType.Money),
new SqlParameter("@ShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@PromotionShopPoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@SubAddAmt", SqlDbType.Money),
new SqlParameter("@SubPoint", SqlDbType.Money),
new SqlParameter("@SubBasePoint", SqlDbType.Money),
new SqlParameter("@SubVendor1Amt", SqlDbType.Money),
new SqlParameter("@SubVendor2Amt", SqlDbType.Money),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@EditID", SqlDbType.VarChar, 36),
new SqlParameter("@IsStockOut", SqlDbType.Int),
new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
new SqlParameter("@PromotionName", SqlDbType.NVarChar, 100),
new SqlParameter("@Remark", SqlDbType.NVarChar, 50),
new SqlParameter("@SerialNumber", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

};
            sp[0].Value = model.OrderID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ProductId;
            sp[3].Value = model.SKU;
            sp[4].Value = model.ProductName;
            sp[5].Value = model.BarCode;
            sp[6].Value = model.ProductImageUrl200;
            sp[7].Value = model.ProductImageUrl400;
            sp[8].Value = model.WCProductID;
            sp[9].Value = model.PreQty;
            sp[10].Value = model.SaleUnit;
            sp[11].Value = model.SalePackingQty;
            sp[12].Value = model.SalePrice;
            sp[13].Value = model.SaleQty;
            sp[14].Value = model.Unit;
            sp[15].Value = model.UnitQty;
            sp[16].Value = model.UnitPrice;
            sp[17].Value = model.PromotionUnitPrice;
            sp[18].Value = model.SubAmt;
            sp[19].Value = model.ShopAddPerc;
            sp[20].Value = model.ShopPoint;
            sp[21].Value = model.PromotionShopPoint;
            sp[22].Value = model.BasePoint;
            sp[23].Value = model.VendorPerc1;
            sp[24].Value = model.VendorPerc2;
            sp[25].Value = model.SubAddAmt;
            sp[26].Value = model.SubPoint;
            sp[27].Value = model.SubBasePoint;
            sp[28].Value = model.SubVendor1Amt;
            sp[29].Value = model.SubVendor2Amt;
            sp[30].Value = model.IsAppend;
            sp[31].Value = model.EditID;
            sp[32].Value = model.IsStockOut;
            sp[33].Value = model.PromotionID;
            sp[34].Value = model.PromotionName;
            sp[35].Value = model.Remark;
            sp[36].Value = model.SerialNumber;
            sp[37].Value = model.ModifyTime;
            sp[38].Value = model.ModifyUserID;
            sp[39].Value = model.ModifyUserName;
            sp[40].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.Edit",
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


        #region 删除一个SaleOrderShopDetails
        /// <summary>
        /// 删除一个SaleOrderShopDetails
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderShopDetails model, IDbConnection conn = null, IDbTransaction tran = null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderShopDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderShopDetails
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.LogicDelete",
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


        #region 根据字典获取SaleOrderShopDetails对象
        /// <summary>
        /// 根据字典获取SaleOrderShopDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderShopDetails对象</returns>
        public SaleOrderShopDetails GetModel(IDictionary<string, object> conditionDict)
        {
            SaleOrderShopDetails model = null;
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
                IList<SaleOrderShopDetails> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleOrderShopDetails对象
        /// <summary>
        /// 根据主键获取SaleOrderShopDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleOrderShopDetails对象</returns>
        public SaleOrderShopDetails GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderShopDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.VarChar, 50)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderShopDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.GetModel",
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


        #region 根据字典获取SaleOrderShopDetails集合
        /// <summary>
        /// 根据字典获取SaleOrderShopDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleOrderShopDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleOrderShopDetails> list = null;
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


        #region 根据字典获取SaleOrderShopDetails数据集
        /// <summary>
        /// 根据字典获取SaleOrderShopDetails数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.GetDataSet",
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


        #region 分页获取SaleOrderShopDetails集合
        /// <summary>
        /// 分页获取SaleOrderShopDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderShopDetails> GetPageList(PageListBySql<SaleOrderShopDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,OrderID,WID,ProductId,SKU,ProductName,BarCode,ProductImageUrl200,ProductImageUrl400,WCProductID,PreQty,SaleUnit,SalePackingQty,SalePrice,SaleQty,Unit,UnitQty,UnitPrice,PromotionUnitPrice,SubAmt,ShopAddPerc,ShopPoint,PromotionShopPoint,BasePoint,VendorPerc1,VendorPerc2,SubAddAmt,SubPoint,SubBasePoint,SubVendor1Amt,SubVendor2Amt,IsAppend,EditID,IsStockOut,PromotionID,PromotionName,Remark,SerialNumber,ModifyTime,ModifyUserID,ModifyUserName";
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
                    while (sdr.Read())
                    {
                        page.ItemList.Add(new SaleOrderShopDetails
                        {
                            ID = DataTypeHelper.GetString(sdr["ID"], null),
                            OrderID = DataTypeHelper.GetString(sdr["OrderID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            ProductImageUrl200 = DataTypeHelper.GetString(sdr["ProductImageUrl200"], null),
                            ProductImageUrl400 = DataTypeHelper.GetString(sdr["ProductImageUrl400"], null),
                            WCProductID = DataTypeHelper.GetInt(sdr["WCProductID"]),
                            PreQty = DataTypeHelper.GetDecimal(sdr["PreQty"]),
                            SaleUnit = DataTypeHelper.GetString(sdr["SaleUnit"], null),
                            SalePackingQty = DataTypeHelper.GetDecimal(sdr["SalePackingQty"]),
                            SalePrice = DataTypeHelper.GetDecimal(sdr["SalePrice"]),
                            SaleQty = DataTypeHelper.GetDecimal(sdr["SaleQty"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            UnitQty = DataTypeHelper.GetDecimal(sdr["UnitQty"]),
                            UnitPrice = DataTypeHelper.GetDecimal(sdr["UnitPrice"]),
                            PromotionUnitPrice = DataTypeHelper.GetDecimal(sdr["PromotionUnitPrice"]),
                            SubAmt = DataTypeHelper.GetDecimal(sdr["SubAmt"]),
                            ShopAddPerc = DataTypeHelper.GetDecimal(sdr["ShopAddPerc"]),
                            ShopPoint = DataTypeHelper.GetDecimal(sdr["ShopPoint"]),
                            PromotionShopPoint = DataTypeHelper.GetDecimal(sdr["PromotionShopPoint"]),
                            BasePoint = DataTypeHelper.GetDecimal(sdr["BasePoint"]),
                            VendorPerc1 = DataTypeHelper.GetDecimal(sdr["VendorPerc1"]),
                            VendorPerc2 = DataTypeHelper.GetDecimal(sdr["VendorPerc2"]),
                            SubAddAmt = DataTypeHelper.GetDecimal(sdr["SubAddAmt"]),
                            SubPoint = DataTypeHelper.GetDecimal(sdr["SubPoint"]),
                            SubBasePoint = DataTypeHelper.GetDecimal(sdr["SubBasePoint"]),
                            SubVendor1Amt = DataTypeHelper.GetDecimal(sdr["SubVendor1Amt"]),
                            SubVendor2Amt = DataTypeHelper.GetDecimal(sdr["SubVendor2Amt"]),
                            IsAppend = DataTypeHelper.GetInt(sdr["IsAppend"]),
                            EditID = DataTypeHelper.GetString(sdr["EditID"], null),
                            IsStockOut = DataTypeHelper.GetInt(sdr["IsStockOut"]),
                            PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                            PromotionName = DataTypeHelper.GetString(sdr["PromotionName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.UpdateField",
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


        #region 根据条件获取SaleOrderShopDetails列表
        /// <summary>
        /// 根据条件获取SaleOrderShopDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderShopDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderShopDetails> list = new List<SaleOrderShopDetails>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<SaleOrderShopDetails>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShopDetails.GetList",
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
    public partial class SaleOrderShopDetailsDAO : BaseDAL, ISaleOrderShopDetailsDAO
    {

        #region ISaleOrderShopDetailsDAO 成员


        /// <summary>
        /// 根据OrderId删除商品明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public bool DeleteByOrderId(string orderId, IDbConnection conn = null, IDbTransaction tran = null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderShopDetails.DeleteByOrderId",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result>=0;
        }


        #endregion
    }
}