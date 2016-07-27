
/*****************************
* Author:CR
*
* Date:2016-03-14
******************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
    /// ### 产品运营分类(直接用)ShopCategories数据库访问类
    /// </summary>
    public partial class ShopCategoriesDAO : BaseDAL, IShopCategoriesDAO
    {
        const string tableName = "ShopCategories";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证ShopCategories是否存在
        /// <summary>
        /// 根据主键验证ShopCategories是否存在
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ShopCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@CategoryId", SqlDbType.Int)
 };
            sp[0].Value = model.CategoryId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.Exists",
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


        #region 添加一个ShopCategories
        /// <summary>
        /// 添加一个ShopCategories
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(ShopCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@CategoryName", SqlDbType.NVarChar, 100),
new SqlParameter("@CategoryImage", SqlDbType.VarChar, 500),
new SqlParameter("@PageHomeImage", SqlDbType.VarChar, 500),
new SqlParameter("@ParentCategoryId", SqlDbType.Int),
new SqlParameter("@Depth", SqlDbType.Int),
new SqlParameter("@DisplaySequence", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@CategoryId", SqlDbType.Int)

};
            sp[0].Value = model.CategoryName;
            sp[1].Value = model.CategoryImage;
            sp[2].Value = model.PageHomeImage;
            sp[3].Value = model.ParentCategoryId;
            sp[4].Value = model.Depth;
            sp[5].Value = model.DisplaySequence;
            sp[6].Value = model.IsDeleted;
            sp[7].Value = model.CreateTime;
            sp[8].Value = model.CreateUserID;
            sp[9].Value = model.CreateUserName;
            sp[10].Value = model.ModifyTime;
            sp[11].Value = model.ModifyUserID;
            sp[12].Value = model.ModifyUserName;
            sp[13].Value = model.CategoryId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.Save",
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


        #region 更新一个ShopCategories
        /// <summary>
        /// 更新一个ShopCategories
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ShopCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@CategoryName", SqlDbType.NVarChar, 100),
new SqlParameter("@CategoryImage", SqlDbType.VarChar, 500),
new SqlParameter("@PageHomeImage", SqlDbType.VarChar, 500),
new SqlParameter("@ParentCategoryId", SqlDbType.Int),
new SqlParameter("@Depth", SqlDbType.Int),
new SqlParameter("@DisplaySequence", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@CategoryId", SqlDbType.Int)

};
            sp[0].Value = model.CategoryName;
            sp[1].Value = model.CategoryImage;
            sp[2].Value = model.PageHomeImage;
            sp[3].Value = model.ParentCategoryId;
            sp[4].Value = model.Depth;
            sp[5].Value = model.DisplaySequence;
            sp[6].Value = model.IsDeleted;
            sp[7].Value = model.ModifyTime;
            sp[8].Value = model.ModifyUserID;
            sp[9].Value = model.ModifyUserName;
            sp[10].Value = model.CategoryId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.Edit",
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


        #region 删除一个ShopCategories
        /// <summary>
        /// 删除一个ShopCategories
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ShopCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@CategoryId", SqlDbType.Int)
 };
            sp[0].Value = model.CategoryId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.Delete",
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


        #region 根据主键逻辑删除一个ShopCategories
        /// <summary>
        /// 根据主键逻辑删除一个ShopCategories
        /// </summary>
        /// <param name="categoryId">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int categoryId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@CategoryId", SqlDbType.Int)
 };
            sp[0].Value = categoryId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.LogicDelete",
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


        #region 根据字典获取ShopCategories对象
        /// <summary>
        /// 根据字典获取ShopCategories对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShopCategories对象</returns>
        public ShopCategories GetModel(IDictionary<string, object> conditionDict)
        {
            ShopCategories model = null;
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
                IList<ShopCategories> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ShopCategories对象
        /// <summary>
        /// 根据主键获取ShopCategories对象
        /// </summary>
        /// <param name="categoryId">主键ID</param>
        /// <returns>ShopCategories对象</returns>
        public ShopCategories GetModel(int categoryId)
        {
            DBHelper helper = DBHelper.GetInstance();
            ShopCategories model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@CategoryId", SqlDbType.Int)
 };
                sp[0].Value = categoryId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new ShopCategories
                        {
                            CategoryId = DataTypeHelper.GetInt(sdr["CategoryId"]),
                            CategoryName = DataTypeHelper.GetString(sdr["CategoryName"], null),
                            CategoryImage = DataTypeHelper.GetString(sdr["CategoryImage"], null),
                            PageHomeImage = DataTypeHelper.GetString(sdr["PageHomeImage"], null),
                            ParentCategoryId = DataTypeHelper.GetInt(sdr["ParentCategoryId"]),
                            Depth = DataTypeHelper.GetInt(sdr["Depth"]),
                            DisplaySequence = DataTypeHelper.GetInt(sdr["DisplaySequence"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.GetModel",
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


        #region 根据字典获取ShopCategories集合
        /// <summary>
        /// 根据字典获取ShopCategories集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ShopCategories> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ShopCategories> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE IsDeleted=0  ");
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


        #region 根据字典获取ShopCategories数据集
        /// <summary>
        /// 根据字典获取ShopCategories数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.GetDataSet",
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


        #region 分页获取ShopCategories集合
        /// <summary>
        /// 分页获取ShopCategories集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ShopCategories> GetPageList(PageListBySql<ShopCategories> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "CategoryId,CategoryName,CategoryImage,PageHomeImage,ParentCategoryId,Depth,DisplaySequence,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new ShopCategories
                        {
                            CategoryId = DataTypeHelper.GetInt(sdr["CategoryId"]),
                            CategoryName = DataTypeHelper.GetString(sdr["CategoryName"], null),
                            CategoryImage = DataTypeHelper.GetString(sdr["CategoryImage"], null),
                            PageHomeImage = DataTypeHelper.GetString(sdr["PageHomeImage"], null),
                            ParentCategoryId = DataTypeHelper.GetInt(sdr["ParentCategoryId"]),
                            Depth = DataTypeHelper.GetInt(sdr["Depth"]),
                            DisplaySequence = DataTypeHelper.GetInt(sdr["DisplaySequence"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.UpdateField",
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
                return "CategoryId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取ShopCategories列表
        /// <summary>
        /// 根据条件获取ShopCategories列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ShopCategories> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ShopCategories> list = new List<ShopCategories>();
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
                        list.Add(new ShopCategories
                        {
                            CategoryId = DataTypeHelper.GetInt(sdr["CategoryId"]),
                            CategoryName = DataTypeHelper.GetString(sdr["CategoryName"], null),
                            CategoryImage = DataTypeHelper.GetString(sdr["CategoryImage"], null),
                            PageHomeImage = DataTypeHelper.GetString(sdr["PageHomeImage"], null),
                            ParentCategoryId = DataTypeHelper.GetInt(sdr["ParentCategoryId"]),
                            Depth = DataTypeHelper.GetInt(sdr["Depth"]),
                            DisplaySequence = DataTypeHelper.GetInt(sdr["DisplaySequence"]),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ShopCategories.GetList",
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IList<ShopCategories> GetChilds(int categoryId)
        {
            IDictionary<string, object> dit = new Dictionary<string, object>();
            dit.Add("ParentCategoryId", categoryId);
            return this.GetList(dit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        public IList<ShopCategories> GetList(List<int> categoryIds)
        {
            string where = " WHERE  IsDeleted=0  ";
            if (categoryIds != null && categoryIds.Count > 0)
            {
                where += string.Format(" AND CategoryId IN({0})", string.Join(",", categoryIds.ToArray()));
            }
            return this.GetList(where, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ShopCategories GetPreModel(int categoryId)
        {
            return this.ExecuteToEntity<ShopCategories>("GetPreModel", new SqlParamrterBuilder().Append("CategoryId", categoryId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ShopCategories GetNextModel(int categoryId)
        {
            return this.ExecuteToEntity<ShopCategories>("GetNextModel", new SqlParamrterBuilder().Append("CategoryId", categoryId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IList<ShopCategories> GetParents(int categoryId)
        {
            return this.ExecuteTolist<ShopCategories>("GetParents", new SqlParamrterBuilder().Append("CategoryId", categoryId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ShopCategories> ShopCategoriesHasWProductsGet(int wid)
        {
            return this.ExecuteTolist<ShopCategories>("ShopCategoriesHasWProductsGet", new SqlParamrterBuilder().Append("WID", wid)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool IsReferenceByProduct(int categoryId)
        {
            string sql = @"select count(*) from BaseProducts where ShopCategoryId1=@categoryId OR ShopCategoryId2=@categoryId OR ShopCategoryId3=@categoryId;";
            int result = int.Parse(DBHelper.GetInstance().GetSingle(sql, new SqlParamrterBuilder().Append("categoryId", categoryId).ToSqlParameters()).ToString());
            return result > 0;
        }
    }
}