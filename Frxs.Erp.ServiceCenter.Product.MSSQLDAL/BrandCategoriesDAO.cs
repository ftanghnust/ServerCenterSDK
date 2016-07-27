
/*****************************
* Author:CR
*
* Date:2016-03-14
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
    /// ### 从原表Buymoo_BrandCategories 复制结构及名称BrandCategories数据库访问类
    /// </summary>
    public partial class BrandCategoriesDAO : BaseDAL, IBrandCategoriesDAO
    {
        const string tableName = "BrandCategories";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证BrandCategories是否存在
        /// <summary>
        /// 根据主键验证BrandCategories是否存在
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(BrandCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@BrandId", SqlDbType.Int)
 };
            sp[0].Value = model.BrandId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.Exists",
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


        #region 添加一个BrandCategories
        /// <summary>
        /// 添加一个BrandCategories
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(BrandCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@BrandName", SqlDbType.NVarChar, 50),
new SqlParameter("@BrandEnName", SqlDbType.NVarChar, 50),
new SqlParameter("@Logo", SqlDbType.NVarChar, 255),
new SqlParameter("@DisplaySequence", SqlDbType.Int),
new SqlParameter("@IsDeleted", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

};
            sp[0].Value = model.BrandName;
            sp[1].Value = model.BrandEnName;
            sp[2].Value = model.Logo;
            sp[3].Value = model.DisplaySequence;
            sp[4].Value = model.IsDeleted;
            sp[5].Value = model.CreateTime;
            sp[6].Value = model.CreateUserID;
            sp[7].Value = model.CreateUserName;
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.Save",
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


        #region 更新一个BrandCategories
        /// <summary>
        /// 更新一个BrandCategories
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(BrandCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@BrandName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@BrandEnName", SqlDbType.NVarChar, 50),
                    new SqlParameter("@Logo", SqlDbType.NVarChar, 255),
                    new SqlParameter("@DisplaySequence", SqlDbType.Int),
                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@BrandId", SqlDbType.Int)
                };
            sp[0].Value = model.BrandName;
            sp[1].Value = model.BrandEnName;
            sp[2].Value = model.Logo;
            sp[3].Value = model.DisplaySequence;
            sp[4].Value = model.IsDeleted;
            sp[5].Value = model.ModifyTime;
            sp[6].Value = model.ModifyUserID;
            sp[7].Value = model.ModifyUserName;
            sp[8].Value = model.BrandId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.Edit",
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


        #region 删除一个BrandCategories
        /// <summary>
        /// 删除一个BrandCategories
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(BrandCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@BrandId", SqlDbType.Int)
 };
            sp[0].Value = model.BrandId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.Delete",
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


        #region 根据主键逻辑删除一个BrandCategories
        /// <summary>
        /// 根据主键逻辑删除一个BrandCategories
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int brandId)
        {
            DBHelper helper = DBHelper.GetInstance();

          

            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@BrandId", SqlDbType.Int)
 };
            sp[0].Value = brandId;

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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.LogicDelete",
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


        #region 根据字典获取BrandCategories对象
        /// <summary>
        /// 根据字典获取BrandCategories对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BrandCategories对象</returns>
        public BrandCategories GetModel(IDictionary<string, object> conditionDict)
        {
            BrandCategories model = null;
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
                IList<BrandCategories> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取BrandCategories对象
        /// <summary>
        /// 根据主键获取BrandCategories对象
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <returns>BrandCategories对象</returns>
        public BrandCategories GetModel(int brandId)
        {
            DBHelper helper = DBHelper.GetInstance();
            BrandCategories model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@BrandId", SqlDbType.Int)
 };
                sp[0].Value = brandId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new BrandCategories
                        {
                            BrandId = DataTypeHelper.GetInt(sdr["BrandId"]),
                            BrandName = DataTypeHelper.GetString(sdr["BrandName"], null),
                            BrandEnName = DataTypeHelper.GetString(sdr["BrandEnName"], null),
                            Logo = DataTypeHelper.GetString(sdr["Logo"], null),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.GetModel",
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


        #region 根据字典获取BrandCategories集合
        /// <summary>
        /// 根据字典获取BrandCategories集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<BrandCategories> GetList(IDictionary<string, object> conditionDict)
        {
            IList<BrandCategories> list = null;
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


        #region 根据字典获取BrandCategories数据集
        /// <summary>
        /// 根据字典获取BrandCategories数据集
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.GetDataSet",
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


        #region 分页获取BrandCategories集合
        /// <summary>
        /// 分页获取BrandCategories集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<BrandCategories> GetPageList(PageListBySql<BrandCategories> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "BrandId,BrandName,BrandEnName,Logo,DisplaySequence,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new BrandCategories
                        {
                            BrandId = DataTypeHelper.GetInt(sdr["BrandId"]),
                            BrandName = DataTypeHelper.GetString(sdr["BrandName"], null),
                            BrandEnName = DataTypeHelper.GetString(sdr["BrandEnName"], null),
                            Logo = DataTypeHelper.GetString(sdr["Logo"], null),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.GetPageList",
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.UpdateField",
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
                return "BrandId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取BrandCategories列表
        /// <summary>
        /// 根据条件获取BrandCategories列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<BrandCategories> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<BrandCategories> list = new List<BrandCategories>();
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
                        list.Add(new BrandCategories
                        {
                            BrandId = DataTypeHelper.GetInt(sdr["BrandId"]),
                            BrandName = DataTypeHelper.GetString(sdr["BrandName"], null),
                            BrandEnName = DataTypeHelper.GetString(sdr["BrandEnName"], null),
                            Logo = DataTypeHelper.GetString(sdr["Logo"], null),
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
                    LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.BrandCategories.GetList",
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


    public partial class BrandCategoriesDAO : BaseDAL, IBrandCategoriesDAO
    {


        #region 查询列表功能
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandIds"></param>
        /// <param name="brandName"></param>
        /// <param name="hasLogo"></param>
        /// <returns></returns>
        public IList<BrandCategories> GetList(List<int> brandIds, string brandName, bool? hasLogo)
        {
            string where = " WHERE IsDeleted=0 ";
            SqlParamrterBuilder sqlParamrterBuilder = new SqlParamrterBuilder();

            if (brandIds != null && brandIds.Count > 0)
            {
                where += string.Format(" AND BrandId IN({0})", string.Join(",", brandIds.ToArray()));
            }

            if (!string.IsNullOrWhiteSpace(brandName))
            {
                where += " AND BrandName LIKE @BrandName ";
                sqlParamrterBuilder.Add("BrandName", "%" + brandName + "%");
            }

            if (hasLogo.HasValue)
            {
                if (hasLogo.Value)
                {
                    where += " AND Logo<>'' ";
                }
                else
                {
                    where += " AND ISNULL(Logo,'')='' ";
                }
            }
            return this.GetList(where, sqlParamrterBuilder.ToSqlParameters());

        }
        #endregion


        #region 是否存在同名称品牌
        /// <summary>
        /// 是否存在同名称品牌
        /// </summary>
        /// <param name="model">品牌对象</param>
        /// <returns>true or false</returns>
        public bool ExistsName(BrandCategories model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsName", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                 new SqlParameter("@BrandId", SqlDbType.Int),
                                 new SqlParameter("@BrandName",SqlDbType.NVarChar) 
                                 };
            sp[0].Value = model.BrandId;
            sp[1].Value = model.BrandName;
            try
            {
                var requestObj = helper.GetSingle(sql, sp);
                if (requestObj == null)
                {
                    return false;
                }
                result = int.Parse(requestObj.ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BrandCategoriesDAO.ExistsName",
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

        #region 是否关联了母商品
        /// <summary>
        /// 是否关联了母商品
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>关联的第一个母商品名称</returns>
        public string UsedName(int id)
        {
            DBHelper helper = DBHelper.GetInstance();
            string result = "";
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "bUsed", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                 new SqlParameter("@BrandId", SqlDbType.Int)
                                 };
            sp[0].Value = id;
            try
            {
                var res = helper.GetSingle(sql, sp);
                if (res != null)
                {
                    result = res.ToString();
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.BrandCategoriesDAO.UsedName",
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
    }
}