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
    /// ### ProductsDescription数据库访问类
    /// </summary>
    public partial class ProductsDescriptionDAO : BaseDAL, IProductsDescriptionDAO
    {
        private const string tableName = "ProductsDescription";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }


        #region 成员方法

        #region 根据主键验证ProductsDescription是否存在

        /// <summary>
        /// 根据主键验证ProductsDescription是否存在
        /// </summary>
        /// <param name="model">ProductsDescription对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ProductsDescription model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@BaseProductId", SqlDbType.Int)
                };
            sp[0].Value = model.BaseProductId;

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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.Exists",
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


        #region 添加一个ProductsDescription

        /// <summary>
        /// 添加一个ProductsDescription
        /// </summary>
        /// <param name="model">ProductsDescription对象</param>
        /// <param name="conn">连接数据对象</param>
        /// <param name="trans">事务对象 </param>
        /// <returns>数据库影响行数</returns>
        public int Save(ProductsDescription model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@BaseProductId", SqlDbType.Int),
                    new SqlParameter("@Description", SqlDbType.NText),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)
                };
            sp[0].Value = model.BaseProductId;
            sp[1].Value = model.Description;
            sp[2].Value = model.ModifyTime;
            sp[3].Value = model.ModifyUserID;
            sp[4].Value = model.ModifyUserName;

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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.Save",
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


        #region 更新一个ProductsDescription

        /// <summary>
        /// 更新一个ProductsDescription
        /// </summary>
        /// <param name="model">ProductsDescription对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ProductsDescription model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@Description", SqlDbType.NText),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@BaseProductId", SqlDbType.Int)
                };
            sp[0].Value = model.Description;
            sp[1].Value = model.ModifyTime;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.BaseProductId;

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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.Edit",
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


        #region 删除一个ProductsDescription

        /// <summary>
        /// 删除一个ProductsDescription
        /// </summary>
        /// <param name="model">ProductsDescription对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ProductsDescription model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@BaseProductId", SqlDbType.Int)
                };
            sp[0].Value = model.BaseProductId;

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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.Delete",
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


        #region 根据主键逻辑删除一个ProductsDescription

        /// <summary>
        /// 根据主键逻辑删除一个ProductsDescription
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和BaseProduct.BaseProductID一样)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int baseProductId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName,
                                                              base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@BaseProductId", SqlDbType.Int)
                };
            sp[0].Value = baseProductId;

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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.LogicDelete",
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


        #region 根据字典获取ProductsDescription对象

        /// <summary>
        /// 根据字典获取ProductsDescription对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsDescription对象</returns>
        public ProductsDescription GetModel(IDictionary<string, object> conditionDict)
        {
            ProductsDescription model = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
                }
                IList<ProductsDescription> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ProductsDescription对象

        /// <summary>
        /// 通过商品母表编号读取商品描述对象
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和BaseProduct.BaseProductID一样)</param>
        /// <returns>商品描述对象</returns>
        public ProductsDescription GetModel(int baseProductId)
        {
            DBHelper helper = DBHelper.GetInstance();
            ProductsDescription model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetProductsDescriptionByBaseProductId", base.AssemblyName,
                                                                  base.DatabaseName);
                SqlParameter[] sp =
                    {
                        new SqlParameter("@BaseProductId", SqlDbType.Int)
                    };
                sp[0].Value = baseProductId;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new ProductsDescription
                                    {
                                        BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                                        Description = DataTypeHelper.GetString(sdr["Description"], null),
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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.GetModel",
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


        #region 根据字典获取ProductsDescription集合

        /// <summary>
        /// 根据字典获取ProductsDescription集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ProductsDescription> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ProductsDescription> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
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


        #region 根据字典获取ProductsDescription数据集

        /// <summary>
        /// 根据字典获取ProductsDescription数据集
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
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
                }
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, sqlConfigName, base.AssemblyName,
                                                                  base.DatabaseName);
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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.GetDataSet",
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


        #region 分页获取ProductsDescription集合

        /// <summary>
        /// 分页获取ProductsDescription集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ProductsDescription> GetPageList(PageListBySql<ProductsDescription> page,
                                                              IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "BaseProductId,Description,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new ProductsDescription
                                              {
                                                  BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                                                  Description = DataTypeHelper.GetString(sdr["Description"], null),
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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.GetPageList",
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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.UpdateField",
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
        private string CreateCondition(IDictionary<string, object> conditionDict, ref IList<IDbDataParameter> parameters)
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            IList<WhereCondition> whereConditionList = new List<WhereCondition>(); //TODO
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
        private string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return "BaseProductId";
            }
            else
            {
                return order;
            }
        }

        #endregion


        #region 根据条件获取ProductsDescription列表

        /// <summary>
        /// 根据条件获取ProductsDescription列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        private IList<ProductsDescription> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsDescription> list = new List<ProductsDescription>();
            try
            {
                StringBuilder sql =
                    new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName,
                                                                           base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new ProductsDescription
                                     {
                                         BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                                         Description = DataTypeHelper.GetString(sdr["Description"], null),
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
                                LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescription.GetList",
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
