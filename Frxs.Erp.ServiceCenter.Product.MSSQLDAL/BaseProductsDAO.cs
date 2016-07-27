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
    /// ### BaseProducts数据库访问类
    /// </summary>
    public partial class BaseProductsDAO : BaseDAL, IBaseProductsDAO
    {
        const string tableName = "BaseProducts";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证BaseProducts是否存在
        /// <summary>
        /// 根据主键验证BaseProducts是否存在
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(BaseProducts model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.Exists",
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


        #region 添加一个BaseProducts
        /// <summary>
        /// 添加一个BaseProducts
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(BaseProducts model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@BaseProductId", SqlDbType.Int),
new SqlParameter("@CategoryId1", SqlDbType.Int),
new SqlParameter("@CategoryId2", SqlDbType.Int),
new SqlParameter("@CategoryId3", SqlDbType.Int),
new SqlParameter("@ShopCategoryId1", SqlDbType.Int),
new SqlParameter("@ShopCategoryId2", SqlDbType.Int),
new SqlParameter("@ShopCategoryId3", SqlDbType.Int),
new SqlParameter("@BrandId1", SqlDbType.Int),
new SqlParameter("@BrandId2", SqlDbType.Int),
new SqlParameter("@IsMutiAttribute", SqlDbType.Int),
new SqlParameter("@IsBaseProductId", SqlDbType.Int),
new SqlParameter("@ProductBaseName", SqlDbType.NVarChar, 100),
new SqlParameter("@IsVendor", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.BaseProductId;
            sp[1].Value = model.CategoryId1;
            sp[2].Value = model.CategoryId2;
            sp[3].Value = model.CategoryId3;
            sp[4].Value = model.ShopCategoryId1;
            sp[5].Value = model.ShopCategoryId2;
            sp[6].Value = model.ShopCategoryId3;
            sp[7].Value = model.BrandId1;
            sp[8].Value = model.BrandId2;
            sp[9].Value = model.IsMutiAttribute;
            sp[10].Value = model.IsBaseProductId;
            sp[11].Value = model.ProductBaseName;
            sp[12].Value = model.IsVendor;
            sp[13].Value = model.IsDeleted;
            sp[14].Value = model.CreateTime;
            sp[15].Value = model.CreateUserID;
            sp[16].Value = model.CreateUserName;
            sp[17].Value = model.ModifyTime;
            sp[18].Value = model.ModifyUserID;
            sp[19].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.Save",
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


        #region 更新一个BaseProducts
        /// <summary>
        /// 更新一个BaseProducts
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BaseProducts model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@CategoryId1", SqlDbType.Int),
new SqlParameter("@CategoryId2", SqlDbType.Int),
new SqlParameter("@CategoryId3", SqlDbType.Int),
new SqlParameter("@ShopCategoryId1", SqlDbType.Int),
new SqlParameter("@ShopCategoryId2", SqlDbType.Int),
new SqlParameter("@ShopCategoryId3", SqlDbType.Int),
new SqlParameter("@BrandId1", SqlDbType.Int),
new SqlParameter("@BrandId2", SqlDbType.Int),
new SqlParameter("@IsMutiAttribute", SqlDbType.Int),
new SqlParameter("@IsBaseProductId", SqlDbType.Int),
new SqlParameter("@ProductBaseName", SqlDbType.NVarChar, 100),
new SqlParameter("@IsVendor", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@BaseProductId", SqlDbType.Int)

};
            sp[0].Value = model.CategoryId1;
            sp[1].Value = model.CategoryId2;
            sp[2].Value = model.CategoryId3;
            sp[3].Value = model.ShopCategoryId1;
            sp[4].Value = model.ShopCategoryId2;
            sp[5].Value = model.ShopCategoryId3;
            sp[6].Value = model.BrandId1;
            sp[7].Value = model.BrandId2;
            sp[8].Value = model.IsMutiAttribute;
            sp[9].Value = model.IsBaseProductId;
            sp[10].Value = model.ProductBaseName;
            sp[11].Value = model.IsVendor;
            sp[12].Value = model.IsDeleted;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;
            sp[16].Value = model.BaseProductId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.Edit",
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


        #region 删除一个BaseProducts
        /// <summary>
        /// 删除一个BaseProducts
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BaseProducts model)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.Delete",
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


        #region 根据主键逻辑删除一个BaseProducts
        /// <summary>
        /// 根据主键逻辑删除一个BaseProducts
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和Product.productID一样)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int baseProductId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.LogicDelete",
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


        #region 根据字典获取BaseProducts对象
        /// <summary>
        /// 根据字典获取BaseProducts对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BaseProducts对象</returns>
        public BaseProducts GetModel(IDictionary<string, object> conditionDict)
        {
            BaseProducts model = null;
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
                IList<BaseProducts> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取BaseProducts对象
        /// <summary>
        /// 根据主键获取BaseProducts对象
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和Product.productID一样)</param>
        /// <returns>BaseProducts对象</returns>
        public BaseProducts GetModel(int baseProductId)
        {
            DBHelper helper = DBHelper.GetInstance();
            BaseProducts model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@BaseProductId", SqlDbType.Int)
 };
                sp[0].Value = baseProductId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new BaseProducts
                        {
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"]),
                            ShopCategoryId1 = DataTypeHelper.GetInt(sdr["ShopCategoryId1"]),
                            ShopCategoryId2 = DataTypeHelper.GetInt(sdr["ShopCategoryId2"]),
                            ShopCategoryId3 = DataTypeHelper.GetInt(sdr["ShopCategoryId3"]),
                            BrandId1 = DataTypeHelper.GetInt(sdr["BrandId1"]),
                            BrandId2 = DataTypeHelper.GetInt(sdr["BrandId2"]),
                            IsMutiAttribute = DataTypeHelper.GetInt(sdr["IsMutiAttribute"]),
                            IsBaseProductId = DataTypeHelper.GetInt(sdr["IsBaseProductId"]),
                            ProductBaseName = DataTypeHelper.GetString(sdr["ProductBaseName"], null),
                            IsVendor = DataTypeHelper.GetInt(sdr["IsVendor"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.GetModel",
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


        #region 根据字典获取BaseProducts集合
        /// <summary>
        /// 根据字典获取BaseProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<BaseProducts> GetList(IDictionary<string, object> conditionDict)
        {
            IList<BaseProducts> list = null;
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


        #region 根据字典获取BaseProducts数据集
        /// <summary>
        /// 根据字典获取BaseProducts数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.GetDataSet",
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


        #region 分页获取BaseProducts集合
        /// <summary>
        /// 分页获取BaseProducts集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<BaseProducts> GetPageList(PageListBySql<BaseProducts> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "BaseProductId,CategoryId1,CategoryId2,CategoryId3,ShopCategoryId1,ShopCategoryId2,ShopCategoryId3,BrandId1,BrandId2,IsMutiAttribute,IsBaseProductId,ProductBaseName,IsVendor,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new BaseProducts
                        {
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"]),
                            ShopCategoryId1 = DataTypeHelper.GetInt(sdr["ShopCategoryId1"]),
                            ShopCategoryId2 = DataTypeHelper.GetInt(sdr["ShopCategoryId2"]),
                            ShopCategoryId3 = DataTypeHelper.GetInt(sdr["ShopCategoryId3"]),
                            BrandId1 = DataTypeHelper.GetInt(sdr["BrandId1"]),
                            BrandId2 = DataTypeHelper.GetInt(sdr["BrandId2"]),
                            IsMutiAttribute = DataTypeHelper.GetInt(sdr["IsMutiAttribute"]),
                            IsBaseProductId = DataTypeHelper.GetInt(sdr["IsBaseProductId"]),
                            ProductBaseName = DataTypeHelper.GetString(sdr["ProductBaseName"], null),
                            IsVendor = DataTypeHelper.GetInt(sdr["IsVendor"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.UpdateField",
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
                return "BaseProductId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取BaseProducts列表
        /// <summary>
        /// 根据条件获取BaseProducts列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<BaseProducts> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<BaseProducts> list = new List<BaseProducts>();
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
                        list.Add(new BaseProducts
                        {
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            CategoryId1 = DataTypeHelper.GetInt(sdr["CategoryId1"]),
                            CategoryId2 = DataTypeHelper.GetInt(sdr["CategoryId2"]),
                            CategoryId3 = DataTypeHelper.GetInt(sdr["CategoryId3"]),
                            ShopCategoryId1 = DataTypeHelper.GetInt(sdr["ShopCategoryId1"]),
                            ShopCategoryId2 = DataTypeHelper.GetInt(sdr["ShopCategoryId2"]),
                            ShopCategoryId3 = DataTypeHelper.GetInt(sdr["ShopCategoryId3"]),
                            BrandId1 = DataTypeHelper.GetInt(sdr["BrandId1"]),
                            BrandId2 = DataTypeHelper.GetInt(sdr["BrandId2"]),
                            IsMutiAttribute = DataTypeHelper.GetInt(sdr["IsMutiAttribute"]),
                            IsBaseProductId = DataTypeHelper.GetInt(sdr["IsBaseProductId"]),
                            ProductBaseName = DataTypeHelper.GetString(sdr["ProductBaseName"], null),
                            IsVendor = DataTypeHelper.GetInt(sdr["IsVendor"]),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.GetList",
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


    public partial class BaseProductsDAO : BaseDAL, IBaseProductsDAO
    {





        #region 根据字典获取BaseProducts对象

        /// <summary>
        /// 根据字典获取BaseProducts对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="bGetAttachedInfo">是否获取除主表外的其他信息</param>
        /// <returns>BaseProducts对象</returns>
        public BaseProducts GetModel(Dictionary<string, object> conditionDict, bool bGetAttachedInfo = true)
        {
            BaseProducts model = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                where.Append(" WHERE IsDeleted=0 ");
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
                }
                IList<BaseProducts> list = GetList(where.ToString(), sp);
                if (list != null && list.Count > 0)
                {
                    model = list[0];
                    ////不是作为母商品的数据，名称全部改成空传出
                    //if (model.IsBaseProductId == 0)
                    //{
                    //    model.ProductBaseName = "";
                    //}
                    //if (bGetAttachedInfo)
                    //{
                    //    GetProductsDescription(model);
                    //    GetProductDescriptionPicture(model);
                    //    if (model.IsVendor > 0)
                    //    {
                    //        GetVendor(model);
                    //    }
                    //}
                }
            }
            catch
            {
                throw;
            }
            return model;
        }
        #endregion



        #region 删除一个BaseProducts

        /// <summary>
        /// 删除一个BaseProducts
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BaseProducts model, ref string msg, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            try
            {
                var productName = BaseProductReference(model.BaseProductId);
                if (!string.IsNullOrWhiteSpace(productName))
                {
                    msg = productName;
                    return (int)ProductCenterEnum.ReturnResultInfo.ExistReference;
                }

                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

                SqlParameter[] sp = {
                                    new SqlParameter("@BaseProductId", SqlDbType.Int),
                                    new SqlParameter("@IsDeleted",SqlDbType.Int), 
                                    new SqlParameter("@ModifyTime",SqlDbType.DateTime),
                                    new SqlParameter("@ModifyUserID",SqlDbType.Int),
                                    new SqlParameter("@ModifyUserName",SqlDbType.NVarChar)
                                    };
                sp[0].Value = model.BaseProductId;
                sp[1].Value = 1;
                sp[2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sp[3].Value = model.ModifyUserID;
                sp[4].Value = model.ModifyUserName;
                if (conn == null && tran == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
                }

                ////删除母商品文本详情
                //DeleteProductsDescription(model.BaseProductId);

                ////删除母商品图文详情
                //DeleteProductsDescriptionPicture(model.BaseProductId);

                ////删除第三方供应商
                //DeleteVendor(model.BaseProductId,null);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BaseProductsDAO.Delete",
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


        #region 添加一个BaseProducts



        /// <summary>
        /// 添加一个BaseProducts
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        public int Save(BaseProducts model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            try
            {
                if (model.IsBaseProductId == 1 && string.IsNullOrEmpty(model.ProductBaseName))
                {
                    throw new Exception("母商品名不能为空!");
                }

                //是否存在相同母商品名称
                if (ExistProductBaseName(model))
                {
                    return (int)ProductCenterEnum.ReturnResultInfo.ExistSameName;
                }

                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

                SqlParameter[] sp =
                    {
                        new SqlParameter("@BaseProductId", SqlDbType.Int),
                        new SqlParameter("@CategoryId1", SqlDbType.Int),
                        new SqlParameter("@CategoryId2", SqlDbType.Int),
                        new SqlParameter("@CategoryId3", SqlDbType.Int),
                        new SqlParameter("@ShopCategoryId1", SqlDbType.Int),
                        new SqlParameter("@ShopCategoryId2", SqlDbType.Int),
                        new SqlParameter("@ShopCategoryId3", SqlDbType.Int),
                        new SqlParameter("@BrandId1", SqlDbType.Int),
                        new SqlParameter("@BrandId2", SqlDbType.Int),
                        new SqlParameter("@IsMutiAttribute", SqlDbType.Int),
                        new SqlParameter("@IsBaseProductId", SqlDbType.Int),
                        new SqlParameter("@ProductBaseName", SqlDbType.NVarChar, 100),
                        new SqlParameter("@IsVendor", SqlDbType.Int),
                        new SqlParameter("@IsDeleted", SqlDbType.Int),
                        new SqlParameter("@CreateTime", SqlDbType.DateTime),
                        new SqlParameter("@CreateUserID", SqlDbType.Int),
                        new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                        new SqlParameter("@ModifyUserID", SqlDbType.Int),
                        new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)
                    };
                sp[0].Value = model.BaseProductId;
                sp[1].Value = model.CategoryId1;
                sp[2].Value = model.CategoryId2;
                sp[3].Value = model.CategoryId3;
                sp[4].Value = model.ShopCategoryId1;
                sp[5].Value = model.ShopCategoryId2;
                sp[6].Value = model.ShopCategoryId3;
                sp[7].Value = model.BrandId1;
                sp[8].Value = model.BrandId2;
                sp[9].Value = model.IsMutiAttribute;
                sp[10].Value = model.IsBaseProductId;
                sp[11].Value = model.ProductBaseName;
                sp[12].Value = model.IsVendor;
                sp[13].Value = model.IsDeleted;
                sp[14].Value = model.CreateTime;
                sp[15].Value = model.CreateUserID;
                sp[16].Value = model.CreateUserName;
                sp[17].Value = model.ModifyTime;
                sp[18].Value = model.ModifyUserID;
                sp[19].Value = model.ModifyUserName;

                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.GetSingle(sql, sp);
                }
                else
                {
                    o = helper.GetSingle(conn, tran, sql, sp);
                }
                if (o != null)
                {
                    bool isSuccess = int.TryParse(o.ToString(), out result);
                }

                return model.BaseProductId;
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BaseProductsDAO.Save",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }
        #endregion


        #region 更新一个BaseProducts

        /// <summary>
        /// 更新一个BaseProducts
        /// </summary>
        /// <param name="model">BaseProducts对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BaseProducts model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            if (model.IsBaseProductId == 1 && string.IsNullOrEmpty(model.ProductBaseName))
            {
                throw new Exception("母商品名不能为空!");
            }

            ////是否存在相同母商品名称
            //if (ExistProductBaseName(model))
            //{
            //    return (int)ProductCenterEnum.ReturnResultInfo.ExistSameName;
            //}

            int result = 0;
            try
            {
                //添加母商品主体
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp =
                    {
                        new SqlParameter("@CategoryId1", SqlDbType.Int),
                        new SqlParameter("@CategoryId2", SqlDbType.Int),
                        new SqlParameter("@CategoryId3", SqlDbType.Int),
                        new SqlParameter("@ShopCategoryId1", SqlDbType.Int),
                        new SqlParameter("@ShopCategoryId2", SqlDbType.Int),
                        new SqlParameter("@ShopCategoryId3", SqlDbType.Int),
                        new SqlParameter("@BrandId1", SqlDbType.Int),
                        new SqlParameter("@BrandId2", SqlDbType.Int),
                        new SqlParameter("@IsMutiAttribute", SqlDbType.Int),
                        new SqlParameter("@IsBaseProductId", SqlDbType.Int),
                        new SqlParameter("@ProductBaseName", SqlDbType.NVarChar, 100),
                        new SqlParameter("@IsVendor", SqlDbType.Int),
                        new SqlParameter("@IsDeleted", SqlDbType.Int),
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                        new SqlParameter("@ModifyUserID", SqlDbType.Int),
                        new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                        new SqlParameter("@BaseProductId", SqlDbType.Int)
                    };
                sp[0].Value = model.CategoryId1;
                sp[1].Value = model.CategoryId2;
                sp[2].Value = model.CategoryId3;
                sp[3].Value = model.ShopCategoryId1;
                sp[4].Value = model.ShopCategoryId2;
                sp[5].Value = model.ShopCategoryId3;
                sp[6].Value = model.BrandId1;
                sp[7].Value = model.BrandId2;
                sp[8].Value = model.IsMutiAttribute;
                sp[9].Value = model.IsBaseProductId;
                sp[10].Value = model.ProductBaseName;
                sp[11].Value = model.IsVendor;
                sp[12].Value = model.IsDeleted;
                sp[13].Value = model.ModifyTime;
                sp[14].Value = model.ModifyUserID;
                sp[15].Value = model.ModifyUserName;
                sp[16].Value = model.BaseProductId;

                if (conn == null && tran == null)
                {
                    result = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BaseProductsDAO.Edit",
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



        #region IBaseProductsDAO 成员

        /// <summary>
        /// 是否关联了商品（母商品被引用）
        /// 查找存在引用的条数
        /// </summary>
        /// <param name="baseProductId">母商品ID</param>
        /// <returns>关联的第一个商品名称</returns>
        public string BaseProductReference(int baseProductId)
        {
            string result;
            DBHelper helper = DBHelper.GetInstance();

            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "BaseProductReference", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                 new SqlParameter("@BaseProductId", SqlDbType.Int)
                                 };
            sp[0].Value = baseProductId;
            try
            {
                result = helper.GetSingle(sql, sp).ToString();
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BaseProducts.BaseProductReference",
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
        /// 母商品名称是否重复
        /// </summary>
        /// <param name="model">母商品模型</param>
        /// <returns>true or false</returns>
        public bool ExistProductBaseName(BaseProducts model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsProductBaseName", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                 new SqlParameter("@BaseProductId", SqlDbType.Int),
                                 new SqlParameter("@ProductBaseName",SqlDbType.NVarChar)
                                 };
            sp[0].Value = model.BaseProductId;
            sp[1].Value = model.@ProductBaseName;
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BaseProductsDAO.ExistName",
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

        #region IBaseProductsDAO 成员

        /// <summary>
        /// 取母商品
        /// </summary>
        /// <param name="baseProductsId">商品ID</param>
        /// <param name="bGetAttachedInfo">是否获取除主表外的其他信息 </param>
        /// <returns></returns>
        public BaseProducts GetModel(int baseProductsId, bool bGetAttachedInfo = true)
        {
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("BaseProductId", baseProductsId);
                return GetModel(dictionary);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion




    }
}