
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
    /// ### 商品多规格属性值表ProductsAttributes数据库访问类
    /// </summary>
    public partial class ProductsAttributesDAO : BaseDAL, IProductsAttributesDAO
    {
        const string tableName = "ProductsAttributes";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证ProductsAttributes是否存在
        /// <summary>
        /// 根据主键验证ProductsAttributes是否存在
        /// </summary>
        /// <param name="model">ProductsAttributes对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ProductsAttributes model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.Exists",
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


        #region 添加一个ProductsAttributes

        /// <summary>
        /// 添加一个商品规格
        /// </summary>
        /// <param name="model">ProductsAttributes对象</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">执行事务对象 </param>
        /// <returns>数据库影响行数</returns>
        public int Save(ProductsAttributes model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@ProductId", SqlDbType.Int),
                                    new SqlParameter("@AttributeId", SqlDbType.Int),
                                    new SqlParameter("@ValuesId", SqlDbType.Int),
                                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                    new SqlParameter("@AttributeName", SqlDbType.NVarChar,20),
                                    new SqlParameter("@ValueStr", SqlDbType.NVarChar,20)
                                };
            sp[0].Value = model.ProductId;
            sp[1].Value = model.AttributeId;
            sp[2].Value = model.ValuesId;
            sp[3].Value = model.ModifyUserID;
            sp[4].Value = model.ModifyUserName;
            sp[5].Value = model.AttributeName;
            sp[6].Value = model.ValueStr;
            try
            {
                object o = (conn != null && trans != null) ? helper.GetSingle(conn, trans, sql, sp) : helper.GetSingle(sql, sp);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributesDAO.Save",
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


        #region 更新一个ProductsAttributes
        /// <summary>
        /// 更新一个ProductsAttributes
        /// </summary> 
        /// <param name="model">ProductsAttributes对象</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">执行事务对象 </param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ProductsAttributes model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@ProductId", SqlDbType.Int),
                                    new SqlParameter("@AttributeId", SqlDbType.Int),
                                    new SqlParameter("@ValuesId", SqlDbType.Int),
                                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                    new SqlParameter("@ID", SqlDbType.Int)
                                };
            sp[0].Value = model.ProductId;
            sp[1].Value = model.AttributeId;
            sp[2].Value = model.ValuesId;
            sp[3].Value = model.ModifyUserID;
            sp[4].Value = model.ModifyUserName;
            sp[5].Value = model.ID;

            try
            {
                result = (conn != null && trans != null) ? helper.ExecNonQuery(conn, trans, sql, sp) : helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributesDAO.Edit",
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


        #region 删除一个ProductsAttributes
        /// <summary>
        /// 删除一个ProductsAttributes
        /// </summary>
        /// <param name="model">ProductsAttributes对象</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">执行事务对象 </param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ProductsAttributes model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@ID", SqlDbType.Int)
                                };
            sp[0].Value = model.ID;

            try
            {
                result = (conn != null && trans != null) ? helper.ExecNonQuery(conn, trans, sql, sp) : helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.Delete",
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


        #region 根据主键逻辑删除一个ProductsAttributes
        /// <summary>
        /// 根据主键逻辑删除一个ProductsAttributes
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.LogicDelete",
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


        #region 根据字典获取ProductsAttributes对象
        /// <summary>
        /// 根据字典获取ProductsAttributes对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsAttributes对象</returns>
        public ProductsAttributes GetModel(IDictionary<string, object> conditionDict)
        {
            ProductsAttributes model = null;
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
                IList<ProductsAttributes> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ProductsAttributes对象
        /// <summary>
        /// 根据主键获取ProductsAttributes对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsAttributes对象</returns>
        public ProductsAttributes GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            ProductsAttributes model = null;
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
                        model = new ProductsAttributes
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            AttributeName = DataTypeHelper.GetString(sdr["AttributeName"], null),
                            ValuesId = DataTypeHelper.GetInt(sdr["ValuesId"]),
                            ValueStr = DataTypeHelper.GetString(sdr["ValueStr"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.GetModel",
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


        #region 根据字典获取ProductsAttributes集合
        /// <summary>
        /// 根据字典获取ProductsAttributes集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ProductsAttributes> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ProductsAttributes> list = null;
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


        #region 根据字典获取ProductsAttributes数据集
        /// <summary>
        /// 根据字典获取ProductsAttributes数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.GetDataSet",
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


        #region 分页获取ProductsAttributes集合
        /// <summary>
        /// 分页获取ProductsAttributes集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ProductsAttributes> GetPageList(PageListBySql<ProductsAttributes> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,ProductId,AttributeId,AttributeName,ValuesId,ValueStr,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new ProductsAttributes
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            AttributeName = DataTypeHelper.GetString(sdr["AttributeName"], null),
                            ValuesId = DataTypeHelper.GetInt(sdr["ValuesId"]),
                            ValueStr = DataTypeHelper.GetString(sdr["ValueStr"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.UpdateField",
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


        #region 根据条件获取ProductsAttributes列表
        /// <summary>
        /// 根据条件获取ProductsAttributes列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ProductsAttributes> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsAttributes> list = new List<ProductsAttributes>();
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
                        list.Add(new ProductsAttributes
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            AttributeName = DataTypeHelper.GetString(sdr["AttributeName"], null),
                            ValuesId = DataTypeHelper.GetInt(sdr["ValuesId"]),
                            ValueStr = DataTypeHelper.GetString(sdr["ValueStr"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.GetList",
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

    public partial class ProductsAttributesDAO : BaseDAL, IProductsAttributesDAO
    {

        /// <summary>
        /// 通过商品编号得到商品规格列表
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <returns>商品规格列表</returns>
        public IList<ProductsAttributes> ProductsAttributesGet(int productId)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsAttributes> list = new List<ProductsAttributes>();
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetProductsAttributesByProductId", this.AssemblyName, this.DatabaseName);
                SqlParameter[] sqlParameters = new SqlParamrterBuilder().Append("ProductId", SqlDbType.Int, productId).ToSqlParameters();
                using (IDataReader reader = helper.GetIDataReader(sql, sqlParameters))
                {
                    while (reader.Read())
                    {
                        list.Add(new ProductsAttributes()
                        {
                            AttributeId = DataTypeHelper.GetInt(reader["AttributeId"], 0),
                            AttributeName = DataTypeHelper.GetString(reader["AttributeName"], null),
                            ID = DataTypeHelper.GetInt(reader["Id"], 0),
                            ModifyTime = DataTypeHelper.GetDateTime(reader["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(reader["ModifyUserId"], 0),
                            ProductId = productId,
                            ValuesId = DataTypeHelper.GetInt(reader["ValuesId"], 0),
                            ValueStr = DataTypeHelper.GetString(reader["ValueStr"], null),
                            ModifyUserName = DataTypeHelper.GetString(reader["ModifyUserName"], null)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.ProductsAttributesGet",
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
        /// 通过商品编号删除商品规格列表
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">连接对象 </param>
        /// <param name="trans">事务对象 </param>
        public int ProductsAttributesDelete(int productId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = this.GetSQLScriptByTable("ProductsAttributesDeleteByProductId");
                var sqlParameters = new SqlParamrterBuilder().Append("ProductId", SqlDbType.Int, productId).ToSqlParameters();
                return (conn != null && trans != null) ? helper.ExecNonQuery(conn, trans, sql, sqlParameters) : helper.ExecNonQuery(sql, sqlParameters);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsAttributes.ProductsAttributesDelete",
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