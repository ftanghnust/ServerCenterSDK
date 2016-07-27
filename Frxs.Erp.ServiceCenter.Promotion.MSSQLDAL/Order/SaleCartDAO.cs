
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;
/*****************************
* Author:leidong
*
* Date:2016-04-06
******************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;


namespace Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL
{
    /// <summary>
    /// ### 销售购物车表SaleCart数据库访问类
    /// </summary>
    public partial class SaleCartDAO : BaseDAL, ISaleCartDAO
    {
        const string tableName = "SaleCart";

        public SaleCartDAO(string warehouseId)
            : base(warehouseId)
        {

        }

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }
        
        #region 成员方法
        #region 根据主键验证SaleCart是否存在
        /// <summary>
        /// 根据主键验证SaleCart是否存在
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleCart model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.Exists",
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


        #region 添加一个SaleCart
        /// <summary>
        /// 添加一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleCart model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200)
};
            sp[0].Value = model.WID;
            sp[1].Value = model.ShopID;
            sp[2].Value = model.XSUserID;
            sp[3].Value = model.ProductID;
            sp[4].Value = model.PreQty;
            sp[5].Value = model.CreateTime;
            sp[6].Value = model.ModifyTime;
            sp[7].Value = model.ModifyUserID;
            sp[8].Value = model.ModifyUserName;
            sp[9].Value = model.Remark;

            try
            {
                object o=new object();
                if(conn!=null && tran!=null)
                {
                    o = helper.GetSingle(conn,tran,sql, sp);
                }
                else
                {
                    o = helper.GetSingle(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.Save",
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


        #region 更新一个SaleCart
        /// <summary>
        /// 更新一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleCart model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@PreQty", SqlDbType.Decimal, 4),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.BigInt),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200)
};
            sp[0].Value = model.WID;
            sp[1].Value = model.ShopID;
            sp[2].Value = model.XSUserID;
            sp[3].Value = model.ProductID;
            sp[4].Value = model.PreQty;
            sp[5].Value = model.ModifyTime;
            sp[6].Value = model.ModifyUserID;
            sp[7].Value = model.ModifyUserName;
            sp[8].Value = model.ID;
            sp[9].Value = model.Remark;

            try
            {
                if(conn!=null && tran!=null)
                {
                    result = helper.ExecNonQuery(conn,tran,sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.Edit",
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


        #region 删除一个SaleCart
        /// <summary>
        /// 删除一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleCart model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@ID", SqlDbType.BigInt)
 };
            sp[0].Value = model.ID;

            try
            {
                if(conn!=null && tran!=null)
                {
                    result = helper.ExecNonQuery(conn,tran,sql, sp);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.Delete",
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


        #region 根据主键逻辑删除一个SaleCart
        /// <summary>
        /// 根据主键逻辑删除一个SaleCart
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(long iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.LogicDelete",
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


        #region 根据字典获取SaleCart对象
        /// <summary>
        /// 根据字典获取SaleCart对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleCart对象</returns>
        public SaleCart GetModel(IDictionary<string, object> conditionDict)
        {
            SaleCart model = null;
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
                IList<SaleCart> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取SaleCart对象
        /// <summary>
        /// 根据主键获取SaleCart对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>SaleCart对象</returns>
        public SaleCart GetModel(long iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleCart model = null;
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
                        model = new SaleCart
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                            PreQty = DataTypeHelper.GetDecimal(sdr["PreQty"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"],null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.GetModel",
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


        #region 根据字典获取SaleCart集合
        /// <summary>
        /// 根据字典获取SaleCart集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleCart> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleCart> list = null;
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


        #region 根据字典获取SaleCart数据集
        /// <summary>
        /// 根据字典获取SaleCart数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.GetDataSet",
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


        #region 分页获取SaleCart集合
        /// <summary>
        /// 分页获取SaleCart集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleCart> GetPageList(PageListBySql<SaleCart> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,WID,ShopID,XSUserID,ProductID,PreQty,CreateTime,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new SaleCart
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                            PreQty = DataTypeHelper.GetDecimal(sdr["PreQty"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.GetPageList",
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
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.UpdateField",
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


        #region 根据条件获取SaleCart列表
        /// <summary>
        /// 根据条件获取SaleCart列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleCart> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleCart> list = new List<SaleCart>();
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
                        list.Add(new SaleCart
                        {
                            ID = DataTypeHelper.GetLong(sdr["ID"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                            PreQty = DataTypeHelper.GetDecimal(sdr["PreQty"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                            ModifyUserID = DataTypeHelper.GetInt(sdr["ModifyUserID"]),
                            ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.GetList",
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

    public partial class SaleCartDAO : BaseDAL, ISaleCartDAO
    {
        /// <summary>
        /// 删除购物车列表
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <param name="wId">仓库Id</param>
        /// <returns>true or false</returns>
        public bool DeleteList(int shopId, int wId = 0, IList<int> productIds = null, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteList", base.AssemblyName, base.DatabaseName);
            var sp = new SqlParamrterBuilder();
            sp.Add("ShopID",SqlDbType.Int,4,shopId);
            if(wId>0)
            {
                sql += " and WId=@WId ";
                sp.Add("WId",SqlDbType.Int,4,wId);
            }
            if(productIds!=null)
            {
                int i = 0;
                StringBuilder ids=new StringBuilder(" And ProductID in ( ");
                foreach (var productId in productIds)
                {
                    ids.Append(" @id" + i + " ,");
                    sp.Add("id"+i,SqlDbType.Int,4,productId);
                    i++;
                }
                sql += ids.ToString().Substring(0, ids.Length - 1) + ")";
               
            }
            try
            {
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp.ToSqlParameters());
                }
                else
                {
                    result = helper.ExecNonQuery(sql, sp.ToSqlParameters());
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.Exists",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result >= 0;
        }

        /// <summary>
        /// 获取购物车商品数量
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public decimal GetCartsCount(int shopId, int? productId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            decimal result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Count", base.AssemblyName, base.DatabaseName);
            var sp = new SqlParamrterBuilder();
            sp.Add("ShopID", SqlDbType.Int, 4, shopId);
            if(productId.HasValue)
            {
                sp.Add("PrdouctId", SqlDbType.Int, 4, productId.Value);
                sql += " And ProductId=@PrdouctId";
            }
            try
            {
               var o=helper.GetSingle(sql, sp.ToSqlParameters());
               result = Convert.ToDecimal(o);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.SaleCart.GetCartsCount",
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