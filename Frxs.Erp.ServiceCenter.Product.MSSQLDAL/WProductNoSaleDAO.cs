
/*****************************
* Author:CR
*
* Date:2016-03-31
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
    /// ### WProductNoSale数据库访问类
    /// </summary>
    public partial class WProductNoSaleDAO : BaseDAL, IWProductNoSaleDAO
    {
        const string tableName = "WProductNoSale";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证WProductNoSale是否存在
        /// <summary>
        /// 根据主键验证WProductNoSale是否存在
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductNoSale model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.NoSaleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.Exists",
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


        #region 添加一个WProductNoSale
        /// <summary>
        /// 添加一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductNoSale model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WName", SqlDbType.NVarChar, 50),
            new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
            new SqlParameter("@BeginTime", SqlDbType.DateTime),            
            new SqlParameter("@Status", SqlDbType.Int),            
            new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.NoSaleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.PromotionName;
            sp[5].Value = model.BeginTime;
            sp[6].Value = model.Status;
            sp[7].Value = model.Remark;
            sp[8].Value = model.CreateTime;
            sp[9].Value = model.CreateUserID;
            sp[10].Value = model.CreateUserName;
            sp[11].Value = model.ModifyTime;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.Save",
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


        #region 更新一个WProductNoSale
        /// <summary>
        /// 更新一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductNoSale model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WName", SqlDbType.NVarChar, 50),
            new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
            new SqlParameter("@BeginTime", SqlDbType.DateTime),            
            new SqlParameter("@Status", SqlDbType.Int),           
            new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50)

            };
            sp[0].Value = model.WID;
            sp[1].Value = model.WCode;
            sp[2].Value = model.WName;
            sp[3].Value = model.PromotionName;
            sp[4].Value = model.BeginTime;
            sp[5].Value = model.Status;
            sp[6].Value = model.Remark;
            sp[7].Value = model.ModifyTime;
            sp[8].Value = model.ModifyUserID;
            sp[9].Value = model.ModifyUserName;
            sp[10].Value = model.NoSaleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.Edit",
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


        #region 删除一个WProductNoSale
        /// <summary>
        /// 删除一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductNoSale model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.NoSaleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.Delete",
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


        #region 根据主键逻辑删除一个WProductNoSale
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSale
        /// </summary>
        /// <param name="noSaleID">主键ID(WID + GUID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string noSaleID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50)
 };
            sp[0].Value = noSaleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.LogicDelete",
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


        #region 根据字典获取WProductNoSale对象
        /// <summary>
        /// 根据字典获取WProductNoSale对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSale对象</returns>
        public WProductNoSale GetModel(IDictionary<string, object> conditionDict)
        {
            WProductNoSale model = null;
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
                IList<WProductNoSale> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductNoSale对象
        /// <summary>
        /// 根据主键获取WProductNoSale对象
        /// </summary>
        /// <param name="noSaleID">主键ID(WID + GUID)</param>
        /// <returns>WProductNoSale对象</returns>
        public WProductNoSale GetModel(string noSaleID)
        {
            DBHelper helper = DBHelper.GetInstance();
            WProductNoSale model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                                        new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50)
                                    };
                sp[0].Value = noSaleID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new WProductNoSale
                        {
                            NoSaleID = DataTypeHelper.GetString(sdr["NoSaleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            PromotionName = DataTypeHelper.GetString(sdr["PromotionName"], null),
                            BeginTime = DataTypeHelper.GetDateTime(sdr["BeginTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTimeNull(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetIntNull(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.GetModel",
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


        #region 根据字典获取WProductNoSale集合
        /// <summary>
        /// 根据字典获取WProductNoSale集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductNoSale> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductNoSale> list = null;
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


        #region 根据字典获取WProductNoSale数据集
        /// <summary>
        /// 根据字典获取WProductNoSale数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.GetDataSet",
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


        #region 分页获取WProductNoSale集合 增加一些查询条件(来自其他表)
        /// <summary>
        /// 分页获取WProductNoSale集合 增加一些查询条件(来自其他表)
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductNoSale> GetPageList(PageListBySql<WProductNoSale> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                string sql1 = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByNoSaleIDSql1", base.AssemblyName, base.DatabaseName);
                string sql2 = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByNoSaleIDSql2", base.AssemblyName, base.DatabaseName);
                IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string where = CreateCondition(conditionDict, ref parameters);
                if (string.IsNullOrWhiteSpace(where))
                {
                    sql2 += " WHERE nsd.nosaleID=ns.NoSaleID";
                }
                else
                {
                    sql2 += (" WHERE " + where + " AND nsd.nosaleID=ns.NoSaleID");
                }
                page.TableName = string.Format("({0}) tmp", string.Format(sql1, sql2));
                page.Fields = "NoSaleID,WID,WCode,WName,PromotionName,BeginTime,EndTime,Status,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                page.Where = string.Empty;
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
                        page.ItemList.Add(new WProductNoSale
                        {
                            NoSaleID = DataTypeHelper.GetString(sdr["NoSaleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            PromotionName = DataTypeHelper.GetString(sdr["PromotionName"], null),
                            BeginTime = DataTypeHelper.GetDateTime(sdr["BeginTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTimeNull(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetIntNull(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.UpdateField",
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
        /// 构建Where条件 对多张表检索
        /// </summary>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>where 条件</returns>
        string CreateCondition(IDictionary<string, object> conditionDict, ref IList<IDbDataParameter> parameters)
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            IList<WhereCondition> whereConditionList = new List<WhereCondition>();//TODO

            if (conditionDict.ContainsKey("PromotionName"))//活动名称 WProductNoSale.PromotionName
            {
                where.Append(" AND ns.PromotionName like @PromotionName");
                SqlParameter s = new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50);
                s.Value = "%" + conditionDict["PromotionName"] + "%";
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("WID"))//仓库ID，在仓库后台中必须传
            {
                where.Append(" AND ns.WID=@WID");
                SqlParameter s = new SqlParameter("@WID", SqlDbType.Int, 4);
                s.Value = conditionDict["WID"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("Status"))//单据状态 WProductNoSale.Status (0:未提交;1:已提交;2:(立即生效)已过帐/已开始;3:已停用)
            {
                where.Append(" AND ns.Status=@Status");
                SqlParameter s = new SqlParameter("@Status", SqlDbType.Int, 4);
                s.Value = conditionDict["Status"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("NoSaleID"))//单据号 WProductNoSale.NoSaleID
            {
                where.Append(" AND ns.NoSaleID like @NoSaleID");
                SqlParameter s = new SqlParameter("@NoSaleID", SqlDbType.NVarChar, 50);
                s.Value = "%" + conditionDict["NoSaleID"] + "%";
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("BeginTimeFrom")) //生效时间 开始时间点 WProductNoSale.BeginTime
            {
                where.Append(" AND ns.BeginTime >= @BeginTimeFrom");
                SqlParameter s = new SqlParameter("@BeginTimeFrom", SqlDbType.DateTime);
                s.Value = conditionDict["BeginTimeFrom"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("BeginTimeEnd")) //生效时间 截至时间点 WProductNoSale.BeginTime
            {
                where.Append(" AND ns.BeginTime <= @BeginTimeEnd");
                SqlParameter s = new SqlParameter("@BeginTimeEnd", SqlDbType.DateTime);
                s.Value = conditionDict["BeginTimeEnd"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("ProductName")) //产品名称 Products.ProductName
            {
                where.Append(" AND p.ProductName like @ProductName");
                SqlParameter s = new SqlParameter("@ProductName", SqlDbType.NVarChar, 100);
                s.Value = "%" + conditionDict["ProductName"] + "%";
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("BarCode")) //商品条码 ProductsBarCodes.BarCode
            {
                where.Append(" AND pbc.BarCode like @BarCode");
                SqlParameter s = new SqlParameter("@BarCode", SqlDbType.NVarChar, 32);
                s.Value = "%" + conditionDict["BarCode"] + "%";
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("SKU")) //ERP编号 Products.SKU
            {
                where.Append(" AND p.SKU like @SKU");
                SqlParameter s = new SqlParameter("@SKU", SqlDbType.VarChar, 10);
                s.Value = "%" + conditionDict["SKU"] + "%";
                parameters.Add(s);
            }
            return Regex.Replace(where.ToString(), "^ AND ", string.Empty);
        }
        #endregion


        #region 构建Sort条件
        /// <summary>
        /// 构建Sort条件 默认按照修改时间倒序
        /// </summary>
        /// <param name="page">分页辅助类</param>
        string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return " ModifyTime Desc ";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WProductNoSale列表
        /// <summary>
        /// 根据条件获取WProductNoSale列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<WProductNoSale> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<WProductNoSale> list = new List<WProductNoSale>();
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
                        list.Add(new WProductNoSale
                        {
                            NoSaleID = DataTypeHelper.GetString(sdr["NoSaleID"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            PromotionName = DataTypeHelper.GetString(sdr["PromotionName"], null),
                            BeginTime = DataTypeHelper.GetDateTime(sdr["BeginTime"]),
                            EndTime = DataTypeHelper.GetDateTime(sdr["EndTime"]),
                            Status = DataTypeHelper.GetInt(sdr["Status"]),
                            ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                            ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                            ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                            PostingTime = DataTypeHelper.GetDateTimeNull(sdr["PostingTime"]),
                            PostingUserID = DataTypeHelper.GetIntNull(sdr["PostingUserID"]),
                            PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.GetList",
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


    public partial class WProductNoSaleDAO : BaseDAL, IWProductNoSaleDAO
    {
        #region 添加一个WProductNoSale 事务操作
        /// <summary>
        /// 添加一个WProductNoSale 事务操作
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductNoSale model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WName", SqlDbType.NVarChar, 50),
            new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
            new SqlParameter("@BeginTime", SqlDbType.DateTime),            
            new SqlParameter("@Status", SqlDbType.Int),            
            new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.NoSaleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.PromotionName;
            sp[5].Value = model.BeginTime;
            sp[6].Value = model.Status;
            sp[7].Value = model.Remark;
            sp[8].Value = model.CreateTime;
            sp[9].Value = model.CreateUserID;
            sp[10].Value = model.CreateUserName;
            sp[11].Value = model.ModifyTime;
            sp[12].Value = model.ModifyUserID;
            sp[13].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.Save",
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

        #region 更新一个WProductNoSale
        /// <summary>
        /// 更新一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductNoSale model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@WCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WName", SqlDbType.NVarChar, 50),
            new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
            new SqlParameter("@BeginTime", SqlDbType.DateTime),            
            new SqlParameter("@Status", SqlDbType.Int),           
            new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
            new SqlParameter("@ModifyTime", SqlDbType.DateTime),
            new SqlParameter("@ModifyUserID", SqlDbType.Int),
            new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
            new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50)

            };
            sp[0].Value = model.WID;
            sp[1].Value = model.WCode;
            sp[2].Value = model.WName;
            sp[3].Value = model.PromotionName;
            sp[4].Value = model.BeginTime;
            sp[5].Value = model.Status;
            sp[6].Value = model.Remark;
            sp[7].Value = model.ModifyTime;
            sp[8].Value = model.ModifyUserID;
            sp[9].Value = model.ModifyUserName;
            sp[10].Value = model.NoSaleID;

            try
            {
                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.ExecNonQuery(sql, sp);
                }
                else
                {
                    o = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.Edit",
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

        #region 删除一个WProductNoSale
        /// <summary>
        /// 删除一个WProductNoSale
        /// </summary>
        /// <param name="NoSaleID">限购单号</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(string NoSaleID, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@NoSaleID", SqlDbType.VarChar, 50)
            };
            sp[0].Value = NoSaleID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.WProductNoSale.Delete",
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

        /// <summary>
        /// 
        /// </summary>
        public int JobPosting(int userId, string userName)
        {
            string sql = "update WProductNoSale set [Status]=2,PostingTime=getdate(),PostingUserID=@UserId,PostingUserName=@UserName where [Status]=1 AND BeginTime<=GETDATE()";
            var s = new SqlParamrterBuilder();
            s.Add("UserId", userId);
            s.Add("UserName", userName);
            return DBHelper.GetInstance().ExecNonQuery(sql, s.ToSqlParameters());
        }
    }
}