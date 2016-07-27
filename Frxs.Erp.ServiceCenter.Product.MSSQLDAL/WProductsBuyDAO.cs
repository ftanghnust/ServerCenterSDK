
/*****************************
* Author:CR
*
* Date:2016-04-02
******************************/
using System;
using System.Linq;
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
    /// ### WProductsBuy数据库访问类
    /// </summary>
    public partial class WProductsBuyDAO : BaseDAL, IWProductsBuyDAO
    {
        const string tableName = "WProductsBuy";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductsBuy是否存在
        /// <summary>
        /// 根据主键验证WProductsBuy是否存在
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductsBuy model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt)
 };
            sp[0].Value = model.WProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.Exists",
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


        #region 添加一个WProductsBuy
        /// <summary>
        /// 添加一个WProductsBuy
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductsBuy model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@BuyPrice", SqlDbType.Money),
new SqlParameter("@BigProductsUnitID", SqlDbType.Int),
new SqlParameter("@BigPackingQty", SqlDbType.Decimal),
new SqlParameter("@BigUnit", SqlDbType.VarChar, 32),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WProductID;
            sp[1].Value = model.WID;
            sp[2].Value = model.ProductId;
            sp[3].Value = model.BuyPrice;
            sp[4].Value = model.BigProductsUnitID;
            sp[5].Value = model.BigPackingQty;
            sp[6].Value = model.BigUnit;
            sp[7].Value = model.VendorID;
            sp[8].Value = model.ModifyTime;
            sp[9].Value = model.ModifyUserID;
            sp[10].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.Save",
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


        #region 更新一个WProductsBuy
        /// <summary>
        /// 更新一个WProductsBuy
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductsBuy model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@BuyPrice", SqlDbType.Money),
new SqlParameter("@BigProductsUnitID", SqlDbType.Int),
new SqlParameter("@BigPackingQty", SqlDbType.Decimal),
new SqlParameter("@BigUnit", SqlDbType.VarChar, 32),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@WProductID", SqlDbType.BigInt)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ProductId;
            sp[2].Value = model.BuyPrice;
            sp[3].Value = model.BigProductsUnitID;
            sp[4].Value = model.BigPackingQty;
            sp[5].Value = model.BigUnit;
            sp[6].Value = model.VendorID;
            sp[7].Value = model.ModifyTime;
            sp[8].Value = model.ModifyUserID;
            sp[9].Value = model.ModifyUserName;
            sp[10].Value = model.WProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.Edit",
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
        /// 更新一个WProductsBuy
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>数据库影响行数</returns>
        public int EditByProductID(int vendorId, int productId,  IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditByProductID", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int)
};
            sp[0].Value = productId;
            sp[1].Value = vendorId;

            try
            {
                if (conn == null && trans == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, trans, sql, sp);
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.EditByProductID",
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


        #region 删除一个WProductsBuy
        /// <summary>
        /// 删除一个WProductsBuy
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductsBuy model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt)
 };
            sp[0].Value = model.WProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.Delete",
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


        #region 根据主键逻辑删除一个WProductsBuy
        /// <summary>
        /// 根据主键逻辑删除一个WProductsBuy
        /// </summary>
        /// <param name="wProductID">主键ID(WProduct.WProductID 1对1的关系)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(long wProductID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WProductID", SqlDbType.BigInt)
 };
            sp[0].Value = wProductID;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.LogicDelete",
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


        #region 根据字典获取WProductsBuy对象
        /// <summary>
        /// 根据字典获取WProductsBuy对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductsBuy对象</returns>
        public WProductsBuy GetModel(IDictionary<string, object> conditionDict)
        {
            WProductsBuy model = null;
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
                IList<WProductsBuy> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductsBuy对象
        /// <summary>
        /// 根据主键获取WProductsBuy对象
        /// </summary>
        /// <param name="wProductID">主键ID(WProduct.WProductID 1对1的关系)</param>
        /// <returns>WProductsBuy对象</returns>
        public WProductsBuy GetModel(long wProductID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductsBuy model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp =
                    {
                        new SqlParameter("@WProductID", SqlDbType.BigInt)
                    };
                sp[0].Value = wProductID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProductsBuy
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            BuyPrice = DataTypeHelper.GetDecimal(sdr["BuyPrice"]),
                            BigProductsUnitID = DataTypeHelper.GetInt(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimal(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.GetModel",
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


        #region 根据字典获取WProductsBuy集合
        /// <summary>
        /// 根据字典获取WProductsBuy集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductsBuy> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductsBuy> list = null;
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


        #region 根据字典获取WProductsBuy数据集
        /// <summary>
        /// 根据字典获取WProductsBuy数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.GetDataSet",
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


        #region 分页获取WProductsBuy集合
        /// <summary>
        /// 分页获取WProductsBuy集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductsBuy> GetPageList(PageListBySql<WProductsBuy> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "WProductID,WID,ProductId,BuyPrice,BigProductsUnitID,BigPackingQty,BigUnit,VendorID,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new WProductsBuy
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            BuyPrice = DataTypeHelper.GetDecimal(sdr["BuyPrice"]),
                            BigProductsUnitID = DataTypeHelper.GetInt(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimal(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.UpdateField",
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
                return "WProductID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WProductsBuy列表
        /// <summary>
        /// 根据条件获取WProductsBuy列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProductsBuy> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductsBuy> list = new List<WProductsBuy>();
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
                        list.Add(new WProductsBuy
                        {
                            WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            BuyPrice = DataTypeHelper.GetDecimal(sdr["BuyPrice"]),
                            BigProductsUnitID = DataTypeHelper.GetInt(sdr["BigProductsUnitID"]),
                            BigPackingQty = DataTypeHelper.GetDecimal(sdr["BigPackingQty"]),
                            BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProductsBuy.GetList",
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


    public partial class WProductsBuyDAO : BaseDAL, IWProductsBuyDAO
    {
        /// <summary>
        /// 搜索采购价格数据
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="pdList"></param>
        /// <returns></returns>
        public IList<WProductsBuyQModel> GetWProductsBuyList(int wid, IList<int> pdList)
        {
            IList<WProductsBuyQModel> list = new List<WProductsBuyQModel>();
            DBHelper helper = DBHelper.GetInstance();
            IList<WarehouseSelectModel> ilist = new List<WarehouseSelectModel>();
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = null;
            string ids = "";
            for (int i = 0; i < pdList.Count; i++)
            {
                if (i == 0)
                {
                    ids = pdList[i].ToString();
                }
                else
                {
                    ids += "," + pdList[i].ToString();
                }
            }
            strSql.Append(@"select WProductID,WID,ProductId,BuyPrice,BigProductsUnitID,BigPackingQty,BigUnit,v.VendorID,v.VendorCode,v.VendorName from WProductsBuy w join Vendor v on w.VendorID=v.VendorID  where ");
            strSql.Append("ProductId in(" + ids + ")");
            strSql.Append(" and WID=@WID ");
            parameters = new SqlParameter[]{
					new SqlParameter("@WID", SqlDbType.Int,4)};
            parameters[0].Value = wid;

            using (SqlDataReader sdr = helper.GetIDataReader(strSql.ToString(), parameters) as SqlDataReader)
            {
                while (sdr.Read())
                {
                    list.Add(new WProductsBuyQModel
                    {
                        WProductID = DataTypeHelper.GetLong(sdr["WProductID"]),
                        WID = DataTypeHelper.GetInt(sdr["WID"]),
                        ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                        BuyPrice = DataTypeHelper.GetDecimal(sdr["BuyPrice"]),
                        BigProductsUnitID = DataTypeHelper.GetInt(sdr["BigProductsUnitID"]),
                        BigPackingQty = DataTypeHelper.GetDecimal(sdr["BigPackingQty"]),
                        BigUnit = DataTypeHelper.GetString(sdr["BigUnit"], null),
                        VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                        VendorCode = DataTypeHelper.GetString(sdr["VendorCode"], null),
                        VendorName = DataTypeHelper.GetString(sdr["VendorName"], null)
                    });
                }
            }
            return list;
        }
    }
}