
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
    /// ### 商品图片明细表ProductsPictureDetail数据库访问类
    /// </summary>
    public partial class ProductsPictureDetailDAO : BaseDAL, IProductsPictureDetailDAO
    {
        const string tableName = "ProductsPictureDetail";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证ProductsPictureDetail是否存在
        /// <summary>
        /// 根据主键验证ProductsPictureDetail是否存在
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ProductsPictureDetail model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.Exists",
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


        #region 添加一个ProductsPictureDetail
        /// <summary>
        /// 添加一个ProductsPictureDetail
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(ProductsPictureDetail model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@ImageProductId", SqlDbType.Int),
                    new SqlParameter("@ImageUrlOrg", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl400x400", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl200x200", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl120x120", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl60x60", SqlDbType.VarChar, 200),
                    new SqlParameter("@OrderNumber", SqlDbType.Int),
                    new SqlParameter("@IsMaster", SqlDbType.Int),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreateUserID", SqlDbType.Int),
                    new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

                };
            sp[0].Value = model.ImageProductId;
            sp[1].Value = model.ImageUrlOrg;
            sp[2].Value = model.ImageUrl400x400;
            sp[3].Value = model.ImageUrl200x200;
            sp[4].Value = model.ImageUrl120x120;
            sp[5].Value = model.ImageUrl60x60;
            sp[6].Value = model.OrderNumber;
            sp[7].Value = model.IsMaster;
            sp[8].Value = model.CreateTime;
            sp[9].Value = model.CreateUserID;
            sp[10].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.Save",
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


        #region 更新一个ProductsPictureDetail
        /// <summary>
        /// 更新一个ProductsPictureDetail
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ProductsPictureDetail model, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@ImageProductId", SqlDbType.Int),
                    new SqlParameter("@ImageUrlOrg", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl400x400", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl200x200", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl120x120", SqlDbType.VarChar, 200),
                    new SqlParameter("@ImageUrl60x60", SqlDbType.VarChar, 200),
                    new SqlParameter("@OrderNumber", SqlDbType.Int),
                    new SqlParameter("@IsMaster", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int)
                };
            sp[0].Value = model.ImageProductId;
            sp[1].Value = model.ImageUrlOrg;
            sp[2].Value = model.ImageUrl400x400;
            sp[3].Value = model.ImageUrl200x200;
            sp[4].Value = model.ImageUrl120x120;
            sp[5].Value = model.ImageUrl60x60;
            sp[6].Value = model.OrderNumber;
            sp[7].Value = model.IsMaster;
            sp[8].Value = model.ID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.Edit",
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


        #region 删除一个ProductsPictureDetail

        /// <summary>
        /// 删除一个ProductsPictureDetail
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ProductsPictureDetail model, IDbConnection conn, IDbTransaction trans)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.Delete",
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


        #region 根据主键逻辑删除一个ProductsPictureDetail
        /// <summary>
        /// 根据主键逻辑删除一个ProductsPictureDetail
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.LogicDelete",
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


        #region 根据字典获取ProductsPictureDetail对象
        /// <summary>
        /// 根据字典获取ProductsPictureDetail对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsPictureDetail对象</returns>
        public ProductsPictureDetail GetModel(IDictionary<string, object> conditionDict)
        {
            ProductsPictureDetail model = null;
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
                IList<ProductsPictureDetail> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ProductsPictureDetail对象
        /// <summary>
        /// 根据主键获取ProductsPictureDetail对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsPictureDetail对象</returns>
        public ProductsPictureDetail GetModel(int iD)
        {
            DBHelper helper = DBHelper.GetInstance();
            ProductsPictureDetail model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.Int)
 };
                sp[0].Value = iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new ProductsPictureDetail
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ImageProductId = DataTypeHelper.GetInt(sdr["ImageProductId"]),
                            ImageUrlOrg = DataTypeHelper.GetString(sdr["ImageUrlOrg"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            ImageUrl120x120 = DataTypeHelper.GetString(sdr["ImageUrl120x120"], null),
                            ImageUrl60x60 = DataTypeHelper.GetString(sdr["ImageUrl60x60"], null),
                            OrderNumber = DataTypeHelper.GetInt(sdr["OrderNumber"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.GetModel",
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


        #region 根据字典获取ProductsPictureDetail集合
        /// <summary>
        /// 根据字典获取ProductsPictureDetail集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ProductsPictureDetail> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ProductsPictureDetail> list = null;
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


        #region 根据字典获取ProductsPictureDetail数据集
        /// <summary>
        /// 根据字典获取ProductsPictureDetail数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.GetDataSet",
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


        #region 分页获取ProductsPictureDetail集合
        /// <summary>
        /// 分页获取ProductsPictureDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ProductsPictureDetail> GetPageList(PageListBySql<ProductsPictureDetail> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,ImageProductId,ImageUrlOrg,ImageUrl400x400,ImageUrl200x200,ImageUrl120x120,ImageUrl60x60,OrderNumber,IsMaster,CreateTime,CreateUserID,CreateUserName";
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
                        page.ItemList.Add(new ProductsPictureDetail
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ImageProductId = DataTypeHelper.GetInt(sdr["ImageProductId"]),
                            ImageUrlOrg = DataTypeHelper.GetString(sdr["ImageUrlOrg"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            ImageUrl120x120 = DataTypeHelper.GetString(sdr["ImageUrl120x120"], null),
                            ImageUrl60x60 = DataTypeHelper.GetString(sdr["ImageUrl60x60"], null),
                            OrderNumber = DataTypeHelper.GetInt(sdr["OrderNumber"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.UpdateField",
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


        #region 根据条件获取ProductsPictureDetail列表
        /// <summary>
        /// 根据条件获取ProductsPictureDetail列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ProductsPictureDetail> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ProductsPictureDetail> list = new List<ProductsPictureDetail>();
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
                        list.Add(new ProductsPictureDetail
                        {
                            ID = DataTypeHelper.GetInt(sdr["ID"]),
                            ImageProductId = DataTypeHelper.GetInt(sdr["ImageProductId"]),
                            ImageUrlOrg = DataTypeHelper.GetString(sdr["ImageUrlOrg"], null),
                            ImageUrl400x400 = DataTypeHelper.GetString(sdr["ImageUrl400x400"], null),
                            ImageUrl200x200 = DataTypeHelper.GetString(sdr["ImageUrl200x200"], null),
                            ImageUrl120x120 = DataTypeHelper.GetString(sdr["ImageUrl120x120"], null),
                            ImageUrl60x60 = DataTypeHelper.GetString(sdr["ImageUrl60x60"], null),
                            OrderNumber = DataTypeHelper.GetInt(sdr["OrderNumber"]),
                            IsMaster = DataTypeHelper.GetInt(sdr["IsMaster"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetail.GetList",
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
    public partial class ProductsPictureDetailDAO : BaseDAL, IProductsPictureDetailDAO
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pics"></param>
        /// <returns></returns>
        public int ProductsPictureDetailAdd(IEnumerable<ProductsPictureDetail> pics, IDbConnection conn, IDbTransaction trans)
        {
            foreach (var pic in pics)
            {
                this.Save(pic, conn, trans);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int ProductsPictureDetailDelete(int productId, IDbConnection conn, IDbTransaction trans)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = this.GetSQLScriptByTable("ProductsPictureDetailDelete");
                var sp = new SqlParamrterBuilder().Append("ProductId", productId).ToSqlParameters();
                return (conn != null && trans != null) ? helper.ExecNonQuery(conn, trans, sql, sp) : helper.ExecNonQuery(sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsPictureDetailDAO.ProductsPictureDetailDelete",
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
        /// <param name="imageProductId"></param>
        /// <returns></returns>
        public IList<ProductsPictureDetail> ProductsPictureDetailsGet(int imageProductId)
        {
            return this.ExecuteTolist<ProductsPictureDetail>("ProductsPictureDetailsGet",
                new SqlParamrterBuilder().Append("ImageProductId", SqlDbType.Int, imageProductId));
        }
    }
}