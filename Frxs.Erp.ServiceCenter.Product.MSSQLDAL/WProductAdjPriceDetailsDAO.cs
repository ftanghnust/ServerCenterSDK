
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// ### 仓库商品价格调整明细表WProductAdjPriceDetails数据库访问类
    /// </summary>
    public partial class WProductAdjPriceDetailsDAO : BaseDAL, IWProductAdjPriceDetailsDAO
    {
        const string tableName = "WProductAdjPriceDetails";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductAdjPriceDetails是否存在
        /// <summary>
        /// 根据主键验证WProductAdjPriceDetails是否存在
        /// </summary>
        /// <param name="model">WProductAdjPriceDetails对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductAdjPriceDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.Exists",
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


        #region 添加一个WProductAdjPriceDetails
        /// <summary>
        /// 添加一个WProductAdjPriceDetails
        /// </summary>
        /// <param name="model">WProductAdjPriceDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductAdjPriceDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@AdjID", SqlDbType.Int),
new SqlParameter("@WProductID", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 10),
new SqlParameter("@OldPrice", SqlDbType.Money),
new SqlParameter("@Price", SqlDbType.Money),
new SqlParameter("@OldMarketPrice", SqlDbType.Money),
new SqlParameter("@MarketPrice", SqlDbType.Money),
new SqlParameter("@OldShopPoint", SqlDbType.Money),
new SqlParameter("@OldShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@ShopPerc", SqlDbType.Money),
new SqlParameter("@OldBasePoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@OldVendorPerc1", SqlDbType.Money),
new SqlParameter("@OldVendorPerc2", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),


};
            sp[0].Value = model.CreateUserName;
            sp[1].Value = model.AdjID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.WID;
            sp[4].Value = model.ProductID;
            sp[5].Value = model.Unit;
            sp[6].Value = model.OldPrice;
            sp[7].Value = model.Price;
            sp[8].Value = model.OldMarketPrice;
            sp[9].Value = model.MarketPrice;
            sp[10].Value = model.OldShopPoint;
            sp[11].Value = model.OldShopAddPerc;
            sp[12].Value = model.ShopPoint;
            sp[13].Value = model.ShopPerc;
            sp[14].Value = model.OldBasePoint;
            sp[15].Value = model.BasePoint;
            sp[16].Value = model.OldVendorPerc1;
            sp[17].Value = model.OldVendorPerc2;
            sp[18].Value = model.VendorPerc1;
            sp[19].Value = model.VendorPerc2;
            sp[20].Value = model.CreateTime;
            sp[21].Value = model.CreateUserID;

            try
            {
                object o = helper.GetSingle(sql, sp);
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.Save",
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


        #region 更新一个WProductAdjPriceDetails
        /// <summary>
        /// 更新一个WProductAdjPriceDetails
        /// </summary>
        /// <param name="model">WProductAdjPriceDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductAdjPriceDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
new SqlParameter("@ID", SqlDbType.BigInt),
new SqlParameter("@AdjID", SqlDbType.Int),
new SqlParameter("@WProductID", SqlDbType.Int),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 10),
new SqlParameter("@OldPrice", SqlDbType.Money),
new SqlParameter("@Price", SqlDbType.Money),
new SqlParameter("@OldMarketPrice", SqlDbType.Money),
new SqlParameter("@MarketPrice", SqlDbType.Money),
new SqlParameter("@OldShopPoint", SqlDbType.Money),
new SqlParameter("@OldShopAddPerc", SqlDbType.Money),
new SqlParameter("@ShopPoint", SqlDbType.Money),
new SqlParameter("@ShopPerc", SqlDbType.Money),
new SqlParameter("@OldBasePoint", SqlDbType.Money),
new SqlParameter("@BasePoint", SqlDbType.Money),
new SqlParameter("@OldVendorPerc1", SqlDbType.Money),
new SqlParameter("@OldVendorPerc2", SqlDbType.Money),
new SqlParameter("@VendorPerc1", SqlDbType.Money),
new SqlParameter("@VendorPerc2", SqlDbType.Money)
};
            sp[0].Value = model.ID;
            sp[1].Value = model.AdjID;
            sp[2].Value = model.WProductID;
            sp[3].Value = model.WID;
            sp[4].Value = model.ProductID;
            sp[5].Value = model.Unit;
            sp[6].Value = model.OldPrice;
            sp[7].Value = model.Price;
            sp[8].Value = model.OldMarketPrice;
            sp[9].Value = model.MarketPrice;
            sp[10].Value = model.OldShopPoint;
            sp[11].Value = model.OldShopAddPerc;
            sp[12].Value = model.ShopPoint;
            sp[13].Value = model.ShopPerc;
            sp[14].Value = model.OldBasePoint;
            sp[15].Value = model.BasePoint;
            sp[16].Value = model.OldVendorPerc1;
            sp[17].Value = model.OldVendorPerc2;
            sp[18].Value = model.VendorPerc1;
            sp[19].Value = model.VendorPerc2;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.Edit",
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


        #region 删除一个WProductAdjPriceDetails
        /// <summary>
        /// 删除一个WProductAdjPriceDetails
        /// </summary>
        /// <param name="model">WProductAdjPriceDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductAdjPriceDetails model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.Delete",
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


        #region 根据主键逻辑删除一个WProductAdjPriceDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjPriceDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(long iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.LogicDelete",
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


        #region 根据字典获取WProductAdjPriceDetails对象
        /// <summary>
        /// 根据字典获取WProductAdjPriceDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductAdjPriceDetails对象</returns>
        public WProductAdjPriceDetails GetModel(IDictionary<string, object> conditionDict)
        {
            WProductAdjPriceDetails model = null;
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
                IList<WProductAdjPriceDetails> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductAdjPriceDetails对象
        /// <summary>
        /// 根据主键获取WProductAdjPriceDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductAdjPriceDetails对象</returns>
        public WProductAdjPriceDetails GetModel(long iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductAdjPriceDetails model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProductAdjPriceDetails
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            AdjID = DataTypeHelper.GetInt(sdr["AdjID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductId"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            OldPrice = DataTypeHelper.GetDecimalNull(sdr["OldPrice"]),
                            Price = DataTypeHelper.GetDecimalNull(sdr["Price"]),
                            OldMarketPrice = DataTypeHelper.GetDecimalNull(sdr["OldMarketPrice"]),
                            MarketPrice = DataTypeHelper.GetDecimalNull(sdr["MarketPrice"]),
                            OldShopPoint = DataTypeHelper.GetDecimalNull(sdr["OldShopPoint"]),
                            OldShopAddPerc = DataTypeHelper.GetDecimalNull(sdr["OldShopAddPerc"]),
                            ShopPoint = DataTypeHelper.GetDecimalNull(sdr["ShopPoint"]),
                            ShopPerc = DataTypeHelper.GetDecimalNull(sdr["ShopPerc"]),
                            OldBasePoint = DataTypeHelper.GetDecimalNull(sdr["OldBasePoint"]),
                            BasePoint = DataTypeHelper.GetDecimalNull(sdr["BasePoint"]),
                            OldVendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["OldVendorPerc1"]),
                            OldVendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["OldVendorPerc2"]),
                            VendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc1"]),
                            VendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc2"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetIntNull(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
                        };
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.GetModel",
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


        #region 根据字典获取WProductAdjPriceDetails集合
        /// <summary>
        /// 根据字典获取WProductAdjPriceDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductAdjPriceDetails> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductAdjPriceDetails> list = null;
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


        #region 根据字典获取WProductAdjPriceDetails数据集
        /// <summary>
        /// 根据字典获取WProductAdjPriceDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            DBHelper helper = DBHelper.GetInstance();
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.GetDataSet",
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


        #region 分页获取WProductAdjPriceDetails集合
        /// <summary>
        /// 分页获取WProductAdjPriceDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductAdjPriceDetails> GetPageList(PageListBySql<WProductAdjPriceDetails> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,AdjID,WProductID,WID,ProductId,Unit,OldPrice,Price,OldMarketPrice,MarketPrice,OldShopPoint,OldShopAddPerc,ShopPoint,ShopPerc,OldBasePoint,BasePoint,OldVendorPerc1,OldVendorPerc2,VendorPerc1,VendorPerc2,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new WProductAdjPriceDetails
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            AdjID = DataTypeHelper.GetInt(sdr["AdjID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductId"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            OldPrice = DataTypeHelper.GetDecimalNull(sdr["OldPrice"]),
                            Price = DataTypeHelper.GetDecimalNull(sdr["Price"]),
                            OldMarketPrice = DataTypeHelper.GetDecimalNull(sdr["OldMarketPrice"]),
                            MarketPrice = DataTypeHelper.GetDecimalNull(sdr["MarketPrice"]),
                            OldShopPoint = DataTypeHelper.GetDecimalNull(sdr["OldShopPoint"]),
                            OldShopAddPerc = DataTypeHelper.GetDecimalNull(sdr["OldShopAddPerc"]),
                            ShopPoint = DataTypeHelper.GetDecimalNull(sdr["ShopPoint"]),
                            ShopPerc = DataTypeHelper.GetDecimalNull(sdr["ShopPerc"]),
                            OldBasePoint = DataTypeHelper.GetDecimalNull(sdr["OldBasePoint"]),
                            BasePoint = DataTypeHelper.GetDecimalNull(sdr["BasePoint"]),
                            OldVendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["OldVendorPerc1"]),
                            OldVendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["OldVendorPerc2"]),
                            VendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc1"]),
                            VendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc2"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.GetPageList",
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
            DBHelper helper = DBHelper.GetInstance();
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.UpdateField",
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


        #region 根据条件获取WProductAdjPriceDetails列表
        /// <summary>
        /// 根据条件获取WProductAdjPriceDetails列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WProductAdjPriceDetails> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductAdjPriceDetails> list = new List<WProductAdjPriceDetails>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new WProductAdjPriceDetails
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            AdjID = DataTypeHelper.GetInt(sdr["AdjID"]),
                            WProductID = DataTypeHelper.GetInt(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductId"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            OldPrice = DataTypeHelper.GetDecimalNull(sdr["OldPrice"]),
                            Price = DataTypeHelper.GetDecimalNull(sdr["Price"]),
                            OldMarketPrice = DataTypeHelper.GetDecimalNull(sdr["OldMarketPrice"]),
                            MarketPrice = DataTypeHelper.GetDecimalNull(sdr["MarketPrice"]),
                            OldShopPoint = DataTypeHelper.GetDecimalNull(sdr["OldShopPoint"]),
                            OldShopAddPerc = DataTypeHelper.GetDecimalNull(sdr["OldShopAddPerc"]),
                            ShopPoint = DataTypeHelper.GetDecimalNull(sdr["ShopPoint"]),
                            ShopPerc = DataTypeHelper.GetDecimalNull(sdr["ShopPerc"]),
                            OldBasePoint = DataTypeHelper.GetDecimalNull(sdr["OldBasePoint"]),
                            BasePoint = DataTypeHelper.GetDecimalNull(sdr["BasePoint"]),
                            OldVendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["OldVendorPerc1"]),
                            OldVendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["OldVendorPerc2"]),
                            VendorPerc1 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc1"]),
                            VendorPerc2 = DataTypeHelper.GetDecimalNull(sdr["VendorPerc2"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductAdjPriceDetails.GetList",
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

    public partial class WProductAdjPriceDetailsDAO : BaseDAL, IWProductAdjPriceDetailsDAO
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjID"></param>
        public void DeleteByAdjId(int adjID)
        {
            string sql = "delete from WProductAdjPriceDetails where AdjID=@AdjID";
            DBHelper helper = DBHelper.GetInstance();
            helper.ExecNonQuery(sql, new SqlParamrterBuilder().Append("AdjID", adjID).ToSqlParameters());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjID"></param>
        /// <returns></returns>
        public IList<WProductAdjPriceDetailsExt> GetWProductAdjPriceDetails(int adjID)
        {
            return this.ExecuteTolist<WProductAdjPriceDetailsExt>("GetWProductAdjPriceDetails", new SqlParamrterBuilder().Append("AdjID", adjID));
        }
    }
}