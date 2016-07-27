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
    /// ### Products数据库访问类
    /// </summary>
    public partial class ProductsDAO : BaseDAL, IProductsDAO
    {
        const string tableName = "Products";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证Products是否存在
        /// <summary>
        /// 根据主键验证Products是否存在
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(Products model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@ProductId", SqlDbType.Int)
 };
            sp[0].Value = model.ProductId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Products.Exists",
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


        #region 根据主键逻辑删除一个Products
        /// <summary>
        /// 根据主键逻辑删除一个Products
        /// </summary>
        /// <param name="productId">商品ID(主键)SKUNumberService.ID取得</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int productId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ProductId", SqlDbType.Int)
 };
            sp[0].Value = productId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Products.LogicDelete",
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


        #region 根据字典获取Products对象
        /// <summary>
        /// 根据字典获取Products对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Products对象</returns>
        public Products GetModel(IDictionary<string, object> conditionDict)
        {
            Products model = null;
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
                IList<Products> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取Products对象
        /// <summary>
        /// 根据主键获取Products对象
        /// </summary>
        /// <param name="productId">商品ID(主键)SKUNumberService.ID取得</param>
        /// <returns>Products对象</returns>
        public Products GetModel(int productId)
        {
            DBHelper helper = DBHelper.GetInstance();
            Products model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
 new SqlParameter("@ProductId", SqlDbType.Int)
 };
                sp[0].Value = productId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new Products
                        {
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            ImageProductId = DataTypeHelper.GetInt(sdr["ImageProductId"]),
                            Mnemonic = DataTypeHelper.GetString(sdr["Mnemonic"], null),
                            Keywords = DataTypeHelper.GetString(sdr["Keywords"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TXTKID = DataTypeHelper.GetString(sdr["TXTKID"], null),
                            MutAttributes = DataTypeHelper.GetString(sdr["MutAttributes"], null),
                            MutValues = DataTypeHelper.GetString(sdr["MutValues"], null),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            Volume = DataTypeHelper.GetDecimal(sdr["Volume"]),
                            Weight = DataTypeHelper.GetDecimal(sdr["Weight"]),
                            VExt1 = DataTypeHelper.GetString(sdr["VExt1"], null),
                            VExt2 = DataTypeHelper.GetString(sdr["VExt2"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Products.GetModel",
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


        #region 根据字典获取Products集合
        /// <summary>
        /// 根据字典获取Products集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<Products> GetList(IDictionary<string, object> conditionDict)
        {
            IList<Products> list = null;
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


        #region 根据字典获取Products数据集
        /// <summary>
        /// 根据字典获取Products数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Products.GetDataSet",
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


        #region 分页获取Products集合
        /// <summary>
        /// 分页获取Products集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Products> GetPageList(PageListBySql<Products> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ProductId,SKU,ProductName,ProductName2,BaseProductId,ImageProductId,Mnemonic,Keywords,IsDeleted,Status,TXTKID,MutAttributes,MutValues,SaleBackFlag,Volume,Weight,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,VExt1,VExt2";
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
                        page.ItemList.Add(new Products
                        {
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            ImageProductId = DataTypeHelper.GetInt(sdr["ImageProductId"]),
                            Mnemonic = DataTypeHelper.GetString(sdr["Mnemonic"], null),
                            Keywords = DataTypeHelper.GetString(sdr["Keywords"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TXTKID = DataTypeHelper.GetString(sdr["TXTKID"], null),
                            MutAttributes = DataTypeHelper.GetString(sdr["MutAttributes"], null),
                            MutValues = DataTypeHelper.GetString(sdr["MutValues"], null),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            Volume = DataTypeHelper.GetDecimal(sdr["Volume"]),
                            Weight = DataTypeHelper.GetDecimal(sdr["Weight"]),
                            VExt1 = DataTypeHelper.GetString(sdr["VExt1"], null),
                            VExt2 = DataTypeHelper.GetString(sdr["VExt2"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Products.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Products.UpdateField",
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
                return "ProductId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取Products列表
        /// <summary>
        /// 根据条件获取Products列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<Products> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<Products> list = new List<Products>();
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
                        list.Add(new Products
                        {
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            ProductName2 = DataTypeHelper.GetString(sdr["ProductName2"], null),
                            BaseProductId = DataTypeHelper.GetInt(sdr["BaseProductId"]),
                            ImageProductId = DataTypeHelper.GetInt(sdr["ImageProductId"]),
                            Mnemonic = DataTypeHelper.GetString(sdr["Mnemonic"], null),
                            Keywords = DataTypeHelper.GetString(sdr["Keywords"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            TXTKID = DataTypeHelper.GetString(sdr["TXTKID"], null),
                            MutAttributes = DataTypeHelper.GetString(sdr["MutAttributes"], null),
                            MutValues = DataTypeHelper.GetString(sdr["MutValues"], null),
                            SaleBackFlag = DataTypeHelper.GetString(sdr["SaleBackFlag"], null),
                            Volume = DataTypeHelper.GetDecimal(sdr["Volume"]),
                            Weight = DataTypeHelper.GetDecimal(sdr["Weight"]),
                            VExt1 = DataTypeHelper.GetString(sdr["VExt1"], null),
                            VExt2 = DataTypeHelper.GetString(sdr["VExt2"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Products.GetList",
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

    public partial class ProductsDAO : BaseDAL, IProductsDAO
    {


        #region 添加一个Products

        /// <summary>
        /// 添加一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <param name="conn">连接对象 </param>
        /// <param name="tran"> 事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(Products model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@ProductId", SqlDbType.Int),
                    new SqlParameter("@SKU", SqlDbType.VarChar, 10),
                    new SqlParameter("@ProductName", SqlDbType.NVarChar, 100),
                    new SqlParameter("@ProductName2", SqlDbType.NVarChar, 400),
                    new SqlParameter("@BaseProductId", SqlDbType.Int),
                    new SqlParameter("@ImageProductId", SqlDbType.Int),
                    new SqlParameter("@Mnemonic", SqlDbType.VarChar, 10),
                    new SqlParameter("@Keywords", SqlDbType.NVarChar, 200),
                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@TXTKID", SqlDbType.Char, 36),
                    new SqlParameter("@MutAttributes", SqlDbType.VarChar, 200),
                    new SqlParameter("@MutValues", SqlDbType.VarChar, 200),
                    new SqlParameter("@SaleBackFlag", SqlDbType.VarChar, 20),
                    new SqlParameter("@BackDays", SqlDbType.Int),
                    new SqlParameter("@Volume", SqlDbType.Decimal),
                    new SqlParameter("@Weight", SqlDbType.Decimal),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreateUserID", SqlDbType.Int),
                    new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@VExt1", SqlDbType.VarChar, 50),
                    new SqlParameter("@VExt2", SqlDbType.VarChar, 50)
                };
            sp[0].Value = model.ProductId;
            sp[1].Value = model.SKU;
            sp[2].Value = model.ProductName;
            sp[3].Value = model.ProductName2;
            sp[4].Value = model.BaseProductId;
            sp[5].Value = model.ImageProductId;
            sp[6].Value = model.Mnemonic;
            sp[7].Value = model.Keywords;
            sp[8].Value = model.IsDeleted;
            sp[9].Value = model.Status;
            sp[10].Value = model.TXTKID;
            sp[11].Value = model.MutAttributes;
            sp[12].Value = model.MutValues;
            sp[13].Value = model.SaleBackFlag;
            sp[14].Value = model.BackDays;
            sp[15].Value = model.Volume;
            sp[16].Value = model.Weight;
            sp[17].Value = model.CreateTime;
            sp[18].Value = model.CreateUserID;
            sp[19].Value = model.CreateUserName;
            sp[20].Value = model.ModifyTime;
            sp[21].Value = model.ModifyUserID;
            sp[22].Value = model.ModifyUserName;
            sp[23].Value = model.VExt1;
            sp[24].Value = model.VExt2;

            try
            {
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
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.Save",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            result = model.ProductId;
            return result;
        }
        #endregion


        #region 更新一个Products

        /// <summary>
        /// 更新一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <param name="conn"> 连接对象</param>
        /// <param name="tran">事务对象 </param>
        /// <returns>数据库影响行数</returns>
        public int Edit(Products model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@SKU", SqlDbType.VarChar, 10),
                    new SqlParameter("@ProductName", SqlDbType.NVarChar, 100),
                    new SqlParameter("@ProductName2", SqlDbType.NVarChar, 400),
                    new SqlParameter("@BaseProductId", SqlDbType.Int),
                    new SqlParameter("@ImageProductId", SqlDbType.Int),
                    new SqlParameter("@Mnemonic", SqlDbType.VarChar, 10),
                    new SqlParameter("@Keywords", SqlDbType.NVarChar, 200),
                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@TXTKID", SqlDbType.Char, 36),
                    new SqlParameter("@MutAttributes", SqlDbType.VarChar, 200),
                    new SqlParameter("@MutValues", SqlDbType.VarChar, 200),
                    new SqlParameter("@SaleBackFlag", SqlDbType.VarChar, 20),
                    new SqlParameter("@BackDays", SqlDbType.Int),
                    new SqlParameter("@Volume", SqlDbType.Decimal),
                    new SqlParameter("@Weight", SqlDbType.Decimal),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@VExt1", SqlDbType.VarChar, 50),
                    new SqlParameter("@VExt2", SqlDbType.VarChar, 50),
                    new SqlParameter("@ProductId", SqlDbType.Int)
                };
            sp[0].Value = model.SKU;
            sp[1].Value = model.ProductName;
            sp[2].Value = model.ProductName2;
            sp[3].Value = model.BaseProductId;
            sp[4].Value = model.ImageProductId;
            sp[5].Value = model.Mnemonic;
            sp[6].Value = model.Keywords;
            sp[7].Value = model.IsDeleted;
            sp[8].Value = model.Status;
            sp[9].Value = model.TXTKID;
            sp[10].Value = model.MutAttributes;
            sp[11].Value = model.MutValues;
            sp[12].Value = model.SaleBackFlag;
            sp[13].Value = model.BackDays;
            sp[14].Value = model.Volume;
            sp[15].Value = model.Weight;
            sp[16].Value = model.ModifyTime;
            sp[17].Value = model.ModifyUserID;
            sp[18].Value = model.ModifyUserName;
            sp[19].Value = model.VExt1;
            sp[20].Value = model.VExt2;
            sp[21].Value = model.ProductId;
            try
            {
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.Edit",
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


        #region 删除一个Products
        /// <summary>
        /// 删除一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(Products model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                     new SqlParameter("@ProductId", SqlDbType.Int),
                                     new SqlParameter("@IsDeleted",SqlDbType.Int), 
                                    new SqlParameter("@ModifyTime",SqlDbType.DateTime),
                                    new SqlParameter("@ModifyUserID",SqlDbType.Int),
                                    new SqlParameter("@ModifyUserName",SqlDbType.NVarChar)
                                };
            sp[0].Value = model.ProductId;
            sp[1].Value = 1;
            sp[2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sp[3].Value = model.ModifyUserID;
            sp[4].Value = model.ModifyUserName;
            try
            {
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.Delete",
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

        #region IProductsDAO 成员

        /// <summary>
        /// 重名判断
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistName(Model.Products model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsName", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@ProductId", SqlDbType.Int),
                                    new SqlParameter("@ProductName",SqlDbType.NVarChar)
                                };
            sp[0].Value = model.ProductId;
            sp[1].Value = model.ProductName;

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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.ExistName",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result > 0;
        }


        /// <summary>
        /// 重ERP判断
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistERP(Model.Products model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsERP", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@ProductId", SqlDbType.Int),
                                    new SqlParameter("@SKU",SqlDbType.VarChar)
                                };
            sp[0].Value = model.ProductId;
            sp[1].Value = model.SKU;

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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.ExistERP",
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

        /// <summary>
        /// 根据商品ID获取商品表对象
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Products ProductGetByProductId(int productId)
        {
            //return this.ExecuteToEntity<Products>("ProductGetByProductId", new SqlParamrterBuilder().Append("ProductId", SqlDbType.Int, productId).ToSqlParameters());
            Dictionary<string, object> dit = new Dictionary<string, object>();
            dit.Add("ProductId", productId);
            return this.GetModel(dit);
        }

        /// <summary>
        /// 商品SEO设置
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public int ProductKeyWordUpdate(int productId, string keyword)
        {
            DBHelper helper = DBHelper.GetInstance();
            string sql = this.GetSQLScriptByTable("ProductKeyWordUpdate");
            return helper.ExecNonQuery(sql, new SqlParamrterBuilder()
                .Append("ProductId", SqlDbType.Int, productId)
                .Append("Keywords", SqlDbType.NVarChar, 200, keyword)
                .ToSqlParameters());
        }

        /// <summary>
        /// 是否被网仓使用
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <returns>true or false</returns>
        public bool bUsedByWc(int productId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "bUserByWc", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@ProductId", SqlDbType.Int)
                                };
            sp[0].Value = productId;

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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.bUsedByWc",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result > 0;
        }

        /// <summary>
        /// 是否被门店使用
        /// </summary>
        /// <param name="productId">商品Id</param>
        /// <returns>true or false</returns>
        public bool bUsedBySupplier(int productId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "bUserBySupplier", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@ProductId", SqlDbType.Int)
                                };
            sp[0].Value = productId;

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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.bUsedBySupplier",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result > 0;
        }

        /// <summary>
        /// 获取ERP编码返回集合
        /// </summary>
        /// <returns>数据集合</returns>
        public Dictionary<int, string> GetProductErpCodeList(IList<int> products)
        {
            DBHelper helper = DBHelper.GetInstance();
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            var productIds = string.Join(",", products);
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));
                sql.Append(string.Format(" WHERE ProductId IN ({0})", productIds));

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), null) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        dictionary.Add(DataTypeHelper.GetInt(sdr["ProductId"]), DataTypeHelper.GetString(sdr["ErpCode"], null));
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.GetProductErpCodeList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return dictionary;
        }

        #region 添加编辑促销时--根据商品或订单促销验证同一时间段是否有相同的商品或基本分类
        /// <summary>
        /// 添加编辑促销时--根据商品或订单促销验证同一时间段是否有相同的商品或基本分类
        /// </summary>
        /// <param name="conditionDict">查询条件</param>
        /// <returns></returns>
        public bool IsPromotionDataTimeProductList(Dictionary<string, string> conditionDict)
        {

            DBHelper helper = DBHelper.GetInstance();
            int result = 0;

            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "PromotionDataTimeProduct", base.AssemblyName, base.DatabaseName);

            sql += IsPromotionDataTimeProductListWhere(conditionDict);

            try
            {
                result = int.Parse(helper.GetSingle(sql, null).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.IsPromotionDataTimeProductList",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
            return result > 0;
        }

        /// <summary>
        /// 添加编辑促销时--根据商品或订单促销验证同一时间段是否有相同的商品或基本分类--查询条件
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        private static string IsPromotionDataTimeProductListWhere(Dictionary<string, string> conditionDict)
        {
            //查询条件
            string strWhere = "  ";

            //指定分类促销
            string CategoryListID = conditionDict["CategoryListID"].ToString();
            if (!string.IsNullOrWhiteSpace(CategoryListID))
            {
                strWhere += string.Format(" AND bp.CategoryId2 IN ({0})", CategoryListID);
            }

            //指定商品促销
            string ProductListID = conditionDict["ProductListID"].ToString();
            if (!string.IsNullOrWhiteSpace(ProductListID))
            {
                strWhere += string.Format(" AND p.ProductId IN ({0})", ProductListID);
            }
            return strWhere;
        }
        #endregion


        /// <summary>
        /// 商品销量增加
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="quantity">增加数量</param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int SaleAdd(int productId, int quantity, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = this.GetSQLScriptByTable("SaleAdd");
                SqlParameter[] sps = new SqlParamrterBuilder().Append("Quantity", quantity).Append("ProductId", productId).ToSqlParameters();
                if (conn != null && tran != null)
                    return helper.ExecNonQuery(conn, tran, sql, sps);
                else
                    return helper.ExecNonQuery(sql, sps);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.SaleAdd",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }


        /// <summary>
        /// 商品销量减少
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="quantity">减少数量</param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int SaleSubtract(int productId, int quantity, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = this.GetSQLScriptByTable("SaleSubtract");
                SqlParameter[] sps = new SqlParamrterBuilder().Append("Quantity", quantity).Append("ProductId", productId).ToSqlParameters();
                if (conn != null && tran != null)
                    return helper.ExecNonQuery(conn, tran, sql, sps);
                else
                    return helper.ExecNonQuery(sql, sps);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductsDAO.SaleAdd",
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