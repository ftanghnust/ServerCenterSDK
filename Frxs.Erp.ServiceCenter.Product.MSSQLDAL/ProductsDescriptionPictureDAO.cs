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
    /// ### 电商商品图文表ProductsDescriptionPicture数据库访问类
    /// </summary>
    public partial class ProductsDescriptionPictureDAO : BaseDAL, IProductsDescriptionPictureDAO
    {
        const string tableName = "ProductsDescriptionPicture";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证ProductsDescriptionPicture是否存在
        /// <summary>
        /// 根据主键验证ProductsDescriptionPicture是否存在
        /// </summary>
        /// <param name="model">ProductsDescriptionPicture对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ProductsDescriptionPicture model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 
};

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.Exists",
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


        #region 添加一个ProductsDescriptionPicture

        /// <summary>
        /// 添加一个 商品图文详情表
        /// </summary>
        /// <param name="model">ProductsDescriptionPicture对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        public int Save(ProductsDescriptionPicture model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@BaseProductId", SqlDbType.Int),
                    new SqlParameter("@ImageUrlOrg", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl400x400", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl200x200", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl120x120", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl60x60", SqlDbType.VarChar, 200),
                    new SqlParameter("@OrderNumber", SqlDbType.Int),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreateUserID", SqlDbType.Int),
                    new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)
                };
            sp[0].Value = model.BaseProductId;
            sp[1].Value = model.ImageUrlOrg;
            sp[2].Value = model.ImageUrl400x400;
            sp[3].Value = model.ImageUrl200x200;
            sp[4].Value = model.ImageUrl120x120;
            sp[5].Value = model.ImageUrl60x60;
            sp[6].Value = model.OrderNumber;
            sp[7].Value = model.CreateTime;
            sp[8].Value = model.CreateUserID;
            sp[9].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.Save",
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


        #region 更新一个ProductsDescriptionPicture
        /// <summary>
        /// 更新一个ProductsDescriptionPicture
        /// </summary>
        /// <param name="model">ProductsDescriptionPicture对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ProductsDescriptionPicture model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@BaseProductId", SqlDbType.Int),
                    new SqlParameter("@ImageUrlOrg", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl400x400", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl200x200", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl120x120", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl60x60", SqlDbType.VarChar, 200),
                    new SqlParameter("@OrderNumber", SqlDbType.Int)
                };
            sp[0].Value = model.BaseProductId;
            sp[1].Value = model.ImageUrlOrg;
            sp[2].Value = model.ImageUrl400x400;
            sp[3].Value = model.ImageUrl200x200;
            sp[4].Value = model.ImageUrl120x120;
            sp[5].Value = model.ImageUrl60x60;
            sp[6].Value = model.OrderNumber;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.Edit",
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


        #region 删除一个ProductsDescriptionPicture

        /// <summary>
        /// 删除一个 商品描述图片对象
        /// </summary>
        /// <param name="model">商品描述图片对象</param>
        /// <param name="conn"> 连接对象</param>
        /// <param name="trans"> 事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ProductsDescriptionPicture model, IDbConnection conn = null, IDbTransaction trans = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = { 
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.Delete",
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


        #region 根据字典获取ProductsDescriptionPicture对象
        /// <summary>
        /// 根据字典获取ProductsDescriptionPicture对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsDescriptionPicture对象</returns>
        public ProductsDescriptionPicture GetModel(IDictionary<string, object> conditionDict)
        {
            ProductsDescriptionPicture model = null;
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
                IList<ProductsDescriptionPicture> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ProductsDescriptionPicture对象
        /// <summary>
        /// 根据主键获取ProductsDescriptionPicture对象
        /// </summary>

        /// <returns>ProductsDescriptionPicture对象</returns>
        public ProductsDescriptionPicture GetModel()
        {
            DBHelper helper = DBHelper.GetInstance();
            ProductsDescriptionPicture model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 
};

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new ProductsDescriptionPicture
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            ImageUrlOrg = DataTypeHelper.GetString(sdr["ImageUrlOrg"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            ImageUrl120x120 = DataTypeHelper.GetString(sdr["ImageUrl120x120"], null),
                            ImageUrl60x60 = DataTypeHelper.GetString(sdr["ImageUrl60x60"], null),
                            OrderNumber = DataTypeHelper.GetInt(sdr["OrderNumber"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.GetModel",
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


        #region 根据字典获取ProductsDescriptionPicture集合
        /// <summary>
        /// 根据字典获取ProductsDescriptionPicture集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ProductsDescriptionPicture> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ProductsDescriptionPicture> list = null;
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


        #region 根据字典获取ProductsDescriptionPicture数据集
        /// <summary>
        /// 根据字典获取ProductsDescriptionPicture数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.GetDataSet",
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


        #region 分页获取ProductsDescriptionPicture集合
        /// <summary>
        /// 分页获取ProductsDescriptionPicture集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ProductsDescriptionPicture> GetPageList(PageListBySql<ProductsDescriptionPicture> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,BaseProductId,ImageUrlOrg,ImageUrl400x400,ImageUrl200x200,ImageUrl120x120,ImageUrl60x60,OrderNumber,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new ProductsDescriptionPicture
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            ImageUrlOrg = DataTypeHelper.GetString(sdr["ImageUrlOrg"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            ImageUrl120x120 = DataTypeHelper.GetString(sdr["ImageUrl120x120"], null),
                            ImageUrl60x60 = DataTypeHelper.GetString(sdr["ImageUrl60x60"], null),
                            OrderNumber = DataTypeHelper.GetInt(sdr["OrderNumber"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.UpdateField",
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
                return "";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取ProductsDescriptionPicture列表
        /// <summary>
        /// 根据条件获取ProductsDescriptionPicture列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ProductsDescriptionPicture> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsDescriptionPicture> list = new List<ProductsDescriptionPicture>();
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
                        list.Add(new ProductsDescriptionPicture
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            ImageUrlOrg = DataTypeHelper.GetString(sdr["ImageUrlOrg"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            ImageUrl120x120 = DataTypeHelper.GetString(sdr["ImageUrl120x120"], null),
                            ImageUrl60x60 = DataTypeHelper.GetString(sdr["ImageUrl60x60"], null),
                            OrderNumber = DataTypeHelper.GetInt(sdr["OrderNumber"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.GetList",
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


    public partial class ProductsDescriptionPictureDAO : BaseDAL, IProductsDescriptionPictureDAO
    {

        /// <summary>
        /// 获取商品图文详情列表
        /// </summary>
        /// <param name="baseProductId">母商品编号</param>
        /// <returns></returns>
        public IList<ProductsDescriptionPicture> ProductsDescriptionPictureGet(int baseProductId)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ProductsDescriptionPictureGet", this.AssemblyName, this.DatabaseName);
                SqlParameter[] sp = new[] { new SqlParameter("BaseProductId", SqlDbType.Int) };
                sp[0].Value = baseProductId;
                using (IDataReader dataReade = helper.GetIDataReader(sql, sp))
                {
                    return this.ExecuteTolist<ProductsDescriptionPicture>(dataReade);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsDescriptionPicture.ProductsDescriptionPictureGet",
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