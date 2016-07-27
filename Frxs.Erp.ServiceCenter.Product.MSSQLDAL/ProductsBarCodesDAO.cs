
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
    /// ### 商品国际条码ProductsBarCodes数据库访问类
    /// </summary>
    public partial class ProductsBarCodesDAO : BaseDAL, IProductsBarCodesDAO
    {
        private const string tableName = "ProductsBarCodes";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }


        #region 成员方法

        #region 根据主键验证ProductsBarCodes是否存在

        /// <summary>
        /// 根据主键验证ProductsBarCodes是否存在
        /// </summary>
        /// <param name="model">ProductsBarCodes对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ProductsBarCodes model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@ID", SqlDbType.Int)
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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.Exists",
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


        #region 添加一个ProductsBarCodes

        /// <summary>
        /// 添加一个国际条码
        /// </summary>
        /// <param name="model">国际条码对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象 </param>
        /// <returns>数据库影响行数</returns>
        public int Save(ProductsBarCodes model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();

            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
            {
                new SqlParameter("@ProductId", SqlDbType.Int),
                new SqlParameter("@BarCode", SqlDbType.VarChar, 32),
                new SqlParameter("@SerialNumber", SqlDbType.Int),
                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                new SqlParameter("@CreateUserID", SqlDbType.Int),
                new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.ProductId;
            sp[1].Value = model.BarCode;
            sp[2].Value = model.SerialNumber;
            sp[3].Value = model.CreateTime;
            sp[4].Value = model.CreateUserID;
            sp[5].Value = model.CreateUserName;

            try
            {
                object o = (conn != null && trans != null) ? helper.GetSingle(conn, trans, sql, sp) : helper.GetSingle(sql, sp);
                if (o != null)
                {
                    int.TryParse(o.ToString(), out result);
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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.Save",
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


        #region 更新一个ProductsBarCodes
        /// <summary>
        /// 更新一个ProductsBarCodes
        /// </summary>
        /// <param name="model">ProductsBarCodes对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ProductsBarCodes model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@ProductId", SqlDbType.Int),
                    new SqlParameter("@BarCode", SqlDbType.VarChar, 32),
                    new SqlParameter("@SerialNumber", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int)
                };
            sp[0].Value = model.ProductId;
            sp[1].Value = model.BarCode;
            sp[2].Value = model.SerialNumber;
            sp[3].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.Edit",
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


        #region 删除一个ProductsBarCodes
        /// <summary>
        /// 删除一个ProductsBarCodes
        /// </summary>
        /// <param name="model">ProductsBarCodes对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ProductsBarCodes model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@ID", SqlDbType.Int)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.Delete",
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


        #region 根据主键逻辑删除一个ProductsBarCodes
        /// <summary>
        /// 根据主键逻辑删除一个ProductsBarCodes
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.Int)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.LogicDelete",
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


        #region 根据字典获取ProductsBarCodes对象
        /// <summary>
        /// 根据字典获取ProductsBarCodes对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsBarCodes对象</returns>
        public ProductsBarCodes GetModel(IDictionary<string, object> conditionDict)
        {
            ProductsBarCodes model = null;
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
                IList<ProductsBarCodes> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ProductsBarCodes对象
        /// <summary>
        /// 根据主键获取ProductsBarCodes对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsBarCodes对象</returns>
        public ProductsBarCodes GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            ProductsBarCodes model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp =
                    {
                        new SqlParameter("@ID", SqlDbType.Int)
                    };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new ProductsBarCodes
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.GetModel",
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


        #region 根据字典获取ProductsBarCodes集合
        /// <summary>
        /// 根据字典获取ProductsBarCodes集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ProductsBarCodes> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ProductsBarCodes> list = null;
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


        #region 根据字典获取ProductsBarCodes数据集
        /// <summary>
        /// 根据字典获取ProductsBarCodes数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.GetDataSet",
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


        #region 分页获取ProductsBarCodes集合
        /// <summary>
        /// 分页获取ProductsBarCodes集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ProductsBarCodes> GetPageList(PageListBySql<ProductsBarCodes> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,ProductId,BarCode,SerialNumber,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new ProductsBarCodes
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.UpdateField",
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
        /// <param name="order">分页辅助类</param>
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


        #region 根据条件获取ProductsBarCodes列表
        /// <summary>
        /// 根据条件获取ProductsBarCodes列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ProductsBarCodes> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsBarCodes> list = new List<ProductsBarCodes>();
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
                        list.Add(new ProductsBarCodes
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.GetList",
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
    /// ### 商品国际条码ProductsBarCodes数据库访问类
    /// </summary>
    public partial class ProductsBarCodesDAO : BaseDAL, IProductsBarCodesDAO
    {
        /// <summary>
        /// 商品国际条码是否存在
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="barCode">国际条码</param>
        /// <returns>是否存在</returns>
        public bool ProductsBarCodesIsExists(int productId, string barCode)
        {
            return this.ExecuteToInt("ProductsBarCodesIsExists", new SqlParamrterBuilder().Append("ProductId", SqlDbType.Int, productId).Append("BarCode", SqlDbType.NVarChar, 32, barCode)) > 0;
        }

        /// <summary>
        /// 通过商品编号查询国际条码列表
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <returns>国际条码列表</returns>
        public IList<ProductsBarCodes> GetProductsBarCodes(int productId)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsBarCodes> list = new List<ProductsBarCodes>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetProductsBarCodes", base.AssemblyName, base.DatabaseName));

                SqlParameter[] sp = { new SqlParameter("@ProductId", SqlDbType.Int) };
                sp[0].Value = productId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new ProductsBarCodes
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            SerialNumber = DataTypeHelper.GetInt(sdr["SerialNumber"]),
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.GetProductsBarCodes",
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
        /// 删除单条国际条码数据
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="barCode">国际条码</param>
        /// <returns>受影响的行数，一般都是一条</returns>
        public int DeleteByProductIdAndBarCode(int productId, string barCode)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByProductIdAndBarCode", base.AssemblyName, base.DatabaseName));
                SqlParameter[] sp = { new SqlParameter("@ProductId", SqlDbType.Int), new SqlParameter("@BarCode", SqlDbType.NVarChar, 32) };
                sp[0].Value = productId;
                sp[1].Value = barCode;
                return helper.ExecNonQuery(sql.ToString(), sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.DeleteByProductIdAndBarCode",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 清空所有的国际条码
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">连接数据库对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>受影响的行数（删除的行数）</returns>
        public int DeleteByProductId(int productId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = this.GetSQLScriptByTable("DeleteByProductId");
                SqlParameter[] sp = new SqlParamrterBuilder().Append("ProductId", productId).ToSqlParameters();
                return (conn != null && trans != null) ? helper.ExecNonQuery(conn, trans, sql, sp) : helper.ExecNonQuery(sql.ToString(), sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsBarCodes.DeleteByProductId",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }
    }
}