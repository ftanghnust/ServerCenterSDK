
/*****************************
* Author:luojing
*
* Date:2016-03-10
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
    /// ### 供应商商品表ProductsVendor数据库访问类
    /// </summary>
    public partial class ProductsVendorDAO : BaseDAL, IProductsVendorDAO
    {
        const string tableName = "ProductsVendor";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证ProductsVendor是否存在
        /// <summary>
        /// 根据主键验证ProductsVendor是否存在
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ProductsVendor model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Exists",
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


        #region 添加一个ProductsVendor
        /// <summary>
        /// 添加一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(ProductsVendor model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 10),
new SqlParameter("@BuyPrice", SqlDbType.Money),
new SqlParameter("@IsMaster", SqlDbType.Int),
new SqlParameter("@LastBuyPrice", SqlDbType.Money),
new SqlParameter("@LastBuyTime", SqlDbType.DateTime),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ProductId;
            sp[2].Value = model.VendorID;
            sp[3].Value = model.Unit;
            sp[4].Value = model.BuyPrice;
            sp[5].Value = model.IsMaster;
            sp[6].Value = model.LastBuyPrice;
            sp[7].Value = model.LastBuyTime;
            sp[8].Value = model.CreateTime;
            sp[9].Value = model.CreateUserID;
            sp[10].Value = model.CreateUserName;
            sp[11].Value = model.ModifyTime;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Save",
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
        /// 添加一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(ProductsVendor model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 10),
new SqlParameter("@BuyPrice", SqlDbType.Money),
new SqlParameter("@IsMaster", SqlDbType.Int),
new SqlParameter("@LastBuyPrice", SqlDbType.Money),
new SqlParameter("@LastBuyTime", SqlDbType.DateTime),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ProductId;
            sp[2].Value = model.VendorID;
            sp[3].Value = model.Unit;
            sp[4].Value = model.BuyPrice;
            sp[5].Value = model.IsMaster;
            sp[6].Value = model.LastBuyPrice;
            sp[7].Value = model.LastBuyTime;
            sp[8].Value = model.CreateTime;
            sp[9].Value = model.CreateUserID;
            sp[10].Value = model.CreateUserName;
            sp[11].Value = model.ModifyTime;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Save",
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


        #region 更新一个ProductsVendor
        /// <summary>
        /// 更新一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ProductsVendor model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ProductId", SqlDbType.Int),
new SqlParameter("@VendorID", SqlDbType.Int),
new SqlParameter("@Unit", SqlDbType.VarChar, 10),
new SqlParameter("@BuyPrice", SqlDbType.Money),
new SqlParameter("@IsMaster", SqlDbType.Int),
new SqlParameter("@LastBuyPrice", SqlDbType.Money),
new SqlParameter("@LastBuyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.BigInt)

};
            sp[0].Value = model.WID;
            sp[1].Value = model.ProductId;
            sp[2].Value = model.VendorID;
            sp[3].Value = model.Unit;
            sp[4].Value = model.BuyPrice;
            sp[5].Value = model.IsMaster;
            sp[6].Value = model.LastBuyPrice;
            sp[7].Value = model.LastBuyTime;
            sp[8].Value = model.ModifyTime;
            sp[9].Value = model.ModifyUserID;
            sp[10].Value = model.ModifyUserName;
            sp[11].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Edit",
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
        /// 更新最后采购价（通过仓库编号，商品编号，更新上编号）
        /// </summary>
        /// <param name="model">要更新的字段和查询条件字段</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>返回值,1表示成功，0表示失败</returns>
        public int EditLastBuyPrice(ProductsVendor model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditLastBuyPrice", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@Unit", SqlDbType.VarChar, 10),
                    new SqlParameter("@BuyPrice", SqlDbType.Money),
                    new SqlParameter("@LastBuyPrice", SqlDbType.Money),
                    new SqlParameter("@LastBuyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@WID", SqlDbType.Int),
                    new SqlParameter("@ProductId", SqlDbType.Int),
                    new SqlParameter("@VendorID", SqlDbType.Int)
                };

            sp[0].Value = model.Unit;
            sp[1].Value = model.BuyPrice;
            sp[2].Value = model.LastBuyPrice;
            sp[3].Value = model.LastBuyTime;
            sp[4].Value = model.ModifyTime;
            sp[5].Value = model.ModifyUserID;
            sp[6].Value = model.ModifyUserName;
            sp[7].Value = model.WID;
            sp[8].Value = model.ProductId;
            sp[9].Value = model.VendorID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.EditLastBuyPrice",
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
        ///设置商品供应商为非主供应商
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>返回对象</returns>
        public int EditByProductId(int productId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditProductsVendorByProductId", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
new SqlParameter("@ProductId", SqlDbType.Int)
};
            sp[0].Value = productId;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.EditByProductId",
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
        ///设置商品供应商为主供应商
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="vendorId">供应商编号</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>返回对象</returns>
        public int EditByProductIdToMaster(int productId, int vendorId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditProductsVendorByProductIdToMaster", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
new SqlParameter("@ProductId", SqlDbType.Int),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.EditByProductIdToMaster",
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


        #region 删除一个ProductsVendor
        /// <summary>
        /// 删除一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ProductsVendor model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Delete",
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
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public int Delete(int vendorId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByVendorId", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@VendorID", SqlDbType.BigInt)
 };
            sp[0].Value = vendorId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Delete",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }


        public int Delete(int vendorId, int ProductId, int wid, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByVendorIdAndProductId", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@VendorID", SqlDbType.BigInt),
 new SqlParameter("@ProductID", SqlDbType.BigInt),
 new SqlParameter("@WID", SqlDbType.BigInt)
 };
            sp[0].Value = vendorId;
            sp[1].Value = ProductId;
            sp[2].Value = wid;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Delete",
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


        #region 根据主键逻辑删除一个ProductsVendor
        /// <summary>
        /// 根据主键逻辑删除一个ProductsVendor
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.LogicDelete",
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


        #region 根据字典获取ProductsVendor对象
        /// <summary>
        /// 根据字典获取ProductsVendor对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsVendor对象</returns>
        public ProductsVendor GetModel(IDictionary<string, object> conditionDict)
        {
            ProductsVendor model = null;
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
                IList<ProductsVendor> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ProductsVendor对象
        /// <summary>
        /// 根据主键获取ProductsVendor对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsVendor对象</returns>
        public ProductsVendor GetModel(long iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            ProductsVendor model = null;
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
                        model = new ProductsVendor
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            BuyPrice = DataTypeHelper.GetDouble(sdr["BuyPrice"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            LastBuyPrice = DataTypeHelper.GetDouble(sdr["LastBuyPrice"]),
                            LastBuyTime = DataTypeHelper.GetDateTime(sdr["LastBuyTime"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.GetModel",
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


        #region 根据字典获取ProductsVendor集合
        /// <summary>
        /// 根据字典获取ProductsVendor集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ProductsVendor> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ProductsVendor> list = null;
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


        #region 根据字典获取ProductsVendor数据集
        /// <summary>
        /// 根据字典获取ProductsVendor数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.GetDataSet",
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


        #region 分页获取ProductsVendor集合
        /// <summary>
        /// 分页获取ProductsVendor集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ProductsVendor> GetPageList(PageListBySql<ProductsVendor> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,WID,ProductId,VendorID,Unit,BuyPrice,IsMaster,LastBuyPrice,LastBuyTime,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new ProductsVendor
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            BuyPrice = DataTypeHelper.GetDouble(sdr["BuyPrice"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            LastBuyPrice = DataTypeHelper.GetDouble(sdr["LastBuyPrice"]),
                            LastBuyTime = DataTypeHelper.GetDateTime(sdr["LastBuyTime"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.GetPageList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return page;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetCount(string sql)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {

                string _sql = sql + " SELECT COUNT(*) FROM LIST ";
                SqlParamrterBuilder paramter = new SqlParamrterBuilder();
                return int.Parse(helper.GetSingle(_sql, paramter.ToSqlParameters()).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsVendor.GetCount",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IList<ProductsVendor> GetList(string sql, int pageIndex, int pageSize, string sortBy, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string _sql = sql + string.Format(" SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1} order by {2}", (pageIndex - 1) * pageSize + 1, pageIndex * pageSize, sortBy);
                SqlParamrterBuilder paramter = new SqlParamrterBuilder();

                return GetListData(_sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsVendor.GetList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }


        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        public IDictionary<string, object> GetListExtByPage(IDictionary<string, object> conditionDict)
        {
            IDictionary<string, object> returnObject = new Dictionary<string, object>();
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                #region 动态配置查询条件 及SQL

                StringBuilder whereStr = new StringBuilder();
                int pageIndex = int.Parse(conditionDict["PageIndex"].ToString());
                int pageSize = int.Parse(conditionDict["PageSize"].ToString());
                string sortBy = "";
                if (conditionDict.ContainsKey("SortBy"))
                {
                    sortBy = conditionDict["SortBy"].ToString();
                }
                else
                {
                    sortBy = " SKU asc ";
                }

                if (conditionDict.ContainsKey("WID"))
                {
                    whereStr.AppendFormat(" and pv.WID  = {0} ", conditionDict["WID"]);
                    whereStr.AppendFormat(" and WP.WID  = {0} ", conditionDict["WID"]);
                }
                if (conditionDict.ContainsKey("VendorID"))
                {
                    whereStr.AppendFormat("  and pv.VendorID = {0} ", conditionDict["VendorID"]);
                }
                if (conditionDict.ContainsKey("IsMaster"))
                {
                    whereStr.AppendFormat("  and pv.IsMaster = {0} ", conditionDict["IsMaster"]);
                }
                if (conditionDict.ContainsKey("KeyWord"))
                {
                    whereStr.AppendFormat(" and (  p.SKU like '%{0}%' or pbc.BarCode like '%{0}%' or p.ProductName like '%{0}%'  ) ", conditionDict["KeyWord"]);
                }

                sql.AppendFormat(@"WITH LIST AS (SELECT ROW_NUMBER() OVER (ORDER BY p.SKU asc) AS RowNum, pv.ID,pv.WID,pv.ProductId,pv.VendorID,pv.Unit,pv.BuyPrice,pv.IsMaster,pv.LastBuyPrice
                ,pv.LastBuyTime,pv.CreateTime,pv.CreateUserID,pv.CreateUserName,pv.ModifyTime
                ,pv.ModifyUserID,pv.ModifyUserName,
                C1.Name AS CategoryName,C2.Name AS CategoryName2,C3.Name AS CategoryName3,
                p.ProductName,p.SKU,pbc.BarCode,wpb.BigPackingQty
                FROM 
                ProductsVendor pv inner join 
                Products p on pv.ProductId=p.ProductId left join  
                WProducts WP on wp.ProductId = p.ProductId 
                LEFT JOIN WProductsBuy wpb ON wp.WProductID=wpb.WProductID
                INNER JOIN BaseProducts bp ON p.BaseProductId=bp.BaseProductId
                Left join Categories c1 on  c1.CategoryId=bp.CategoryId1
                Left join Categories c2 on  c2.CategoryId=bp.CategoryId2
                Left join Categories c3 on  c3.CategoryId=bp.CategoryId3
                LEFT JOIN ProductsBarCodes pbc on p.ProductId=pbc.ProductId and pbc.SerialNumber=1 where WP.WStatus=1 AND 1=1 {0}) ", whereStr.ToString());
                #endregion

                returnObject.Add("totalCount", GetCount(sql.ToString()));

                returnObject.Add("itemList", GetList(sql.ToString(), pageIndex, pageSize, sortBy, sp));

            }
            catch
            {
                throw;
            }
            return returnObject;
        }



        #region 取ProductsVendor集合
        /// <summary>
        /// 获取ProductsVendor集合
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        public IList<ProductsVendor> GetListNoPage(IDictionary<string, object> conditionDict)
        {
            IList<ProductsVendor> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"SELECT pv.ID,pv.WID,pv.ProductId,pv.VendorID,pv.Unit,pv.BuyPrice,pv.IsMaster,pv.LastBuyPrice
                ,pv.LastBuyTime,pv.CreateTime,pv.CreateUserID,pv.CreateUserName,pv.ModifyTime
                ,pv.ModifyUserID,pv.ModifyUserName,
                C1.Name AS CategoryName,C2.Name AS CategoryName2,C3.Name AS CategoryName3,
                p.ProductName,p.SKU,pbc.BarCode,wpb.BigPackingQty
                FROM 
                ProductsVendor pv inner join 
                Products P on pv.ProductId=p.ProductId left join  
                WProducts WP on wp.ProductId = p.ProductId
                LEFT JOIN WProductsBuy wpb ON wp.WProductID=wpb.WProductID
                INNER JOIN BaseProducts bp ON p.BaseProductId=bp.BaseProductId
                Left join Categories c1 on  c1.CategoryId=bp.CategoryId1
                Left join Categories c2 on  c2.CategoryId=bp.CategoryId2
                Left join Categories c3 on  c3.CategoryId=bp.CategoryId3
                LEFT JOIN ProductsBarCodes pbc on p.ProductId=pbc.ProductId and pbc.SerialNumber=1  WHERE WP.WID={0} and pv.WID ={0} AND pv.VendorID ={1};", conditionDict["WID"], conditionDict["VendorID"]);

                list = GetListData(sql.ToString(), sp);
            }
            catch
            {
                throw;
            }
            return list;
        }

        #endregion
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.UpdateField",
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

            if (conditionDict.ContainsKey("VendorID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "VendorID",
                        FieldValue = conditionDict["VendorID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("ProductId"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ProductId",
                        FieldValue = conditionDict["ProductId"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

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


        #region 根据条件获取ProductsVendor列表
        /// <summary>
        /// 根据条件获取WProducts列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<ProductsVendor> GetListData(string sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsVendor> list = new List<ProductsVendor>();
            try
            {

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new ProductsVendor
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            BuyPrice = DataTypeHelper.GetDouble(sdr["BuyPrice"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            LastBuyPrice = DataTypeHelper.GetDouble(sdr["LastBuyPrice"]),
                            LastBuyTime = DataTypeHelper.GetDateTime(sdr["LastBuyTime"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            CategoryName1 = DataTypeHelper.GetString(sdr["CategoryName"], null),
                            CategoryName2 = DataTypeHelper.GetString(sdr["CategoryName2"], null),
                            CategoryName3 = DataTypeHelper.GetString(sdr["CategoryName3"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            BigPackingQty = DataTypeHelper.GetString(sdr["BigPackingQty"], null)
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.WProducts.ProductsVendor",
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
        /// 根据条件获取ProductsVendor列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ProductsVendor> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsVendor> list = new List<ProductsVendor>();
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
                        list.Add(new ProductsVendor
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            VendorID = DataTypeHelper.GetInt(sdr["VendorID"]),
                            Unit = DataTypeHelper.GetString(sdr["Unit"], null),
                            BuyPrice = DataTypeHelper.GetDouble(sdr["BuyPrice"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
                            LastBuyPrice = DataTypeHelper.GetDouble(sdr["LastBuyPrice"]),
                            LastBuyTime = DataTypeHelper.GetDateTime(sdr["LastBuyTime"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.GetList",
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
    /// 
    /// </summary>
    public partial class ProductsVendorDAO : BaseDAL, IProductsVendorDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isMaster"></param>
        public void IsMasterUpdate(long id, int isMaster)
        {
            string sql = "update ProductsVendor set IsMaster=@IsMaster where [id]=@id";
            DBHelper helper = DBHelper.GetInstance();
            helper.ExecNonQuery(sql, new SqlParamrterBuilder().Append("id", id).Append("IsMaster", isMaster).ToSqlParameters());
        }


        /// <summary>
        /// 查询供应商查在记录数
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>是否存在</returns>
        public long GetVendProductsCount(int vendorID)
        {
            DBHelper helper = DBHelper.GetInstance();
            long result = 0;
            string sql = "select COUNT(1) from ProductsVendor where VendorID=@VendorID";
            SqlParameter[] sp = {
            new SqlParameter("@VendorID", SqlDbType.Int)
            };
            sp[0].Value = vendorID;
            try
            {
                result = long.Parse(helper.GetSingle(sql, sp).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsVendor.Exists",
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