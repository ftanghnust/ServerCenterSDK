
/*****************************
* Author:CR
*
* Date:2016-03-25
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
    /// ### 促销门店群组表ShopGroup数据库访问类
    /// </summary>
    public partial class ShopGroupDAO : BaseDAL, IShopGroupDAO
    {
        const string tableName = "ShopGroup";


        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region 成员方法
        #region 根据主键验证ShopGroup是否存在
        /// <summary>
        /// 根据主键验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(ShopGroup model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@GroupID", SqlDbType.Int)
            };
            sp[0].Value = model.GroupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.Exists",
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


        #region 添加一个ShopGroup
        /// <summary>
        /// 添加一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(ShopGroup model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@GroupCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.GroupCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupName;
            sp[3].Value = model.IsDeleted;
            sp[4].Value = model.Remark;
            sp[5].Value = model.CreateTime;
            sp[6].Value = model.CreateUserID;
            sp[7].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.Save",
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


        #region 更新一个ShopGroup
        /// <summary>
        /// 更新一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ShopGroup model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@GroupCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
            new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
            new SqlParameter("@GroupID", SqlDbType.Int)

            };
            sp[0].Value = model.GroupCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupName;
            sp[3].Value = model.Remark;
            sp[4].Value = model.GroupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.Edit",
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


        #region 删除一个ShopGroup
        /// <summary>
        /// 删除一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(ShopGroup model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@GroupID", SqlDbType.Int)
            };
            sp[0].Value = model.GroupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.Delete",
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


        #region 根据主键逻辑删除一个ShopGroup
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroup
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int groupID)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@GroupID", SqlDbType.Int)
            };
            sp[0].Value = groupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.LogicDelete",
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


        #region 根据字典获取ShopGroup对象
        /// <summary>
        /// 根据字典获取ShopGroup对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShopGroup对象</returns>
        public ShopGroup GetModel(IDictionary<string, object> conditionDict)
        {
            ShopGroup model = null;
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
                IList<ShopGroup> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取ShopGroup对象
        /// <summary>
        /// 根据主键获取ShopGroup对象
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <returns>ShopGroup对象</returns>
        public ShopGroup GetModel(int groupID)
        {
            DBHelper helper = DBHelper.GetInstance();
            ShopGroup model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@GroupID", SqlDbType.Int)
                };
                sp[0].Value = groupID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new ShopGroup
                        {
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
                            GroupCode = DataTypeHelper.GetString(sdr["GroupCode"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupName = DataTypeHelper.GetString(sdr["GroupName"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null)
                        };
                    }
                }
                model.List = new List<ShopGroupDetails>();
                #region 获取 门店群组明细表 的列表项目
                string sqlDetails = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetDetailsById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] spDetails = {
                new SqlParameter("@GroupID", SqlDbType.Int)
                };
                spDetails[0].Value = groupID;

                using (SqlDataReader sdrDetails = helper.GetIDataReader(sqlDetails, spDetails) as SqlDataReader)
                {
                    while (sdrDetails.Read())
                    {
                        model.List.Add(new ShopGroupDetails
                        {
                            ID = DataTypeHelper.GetInt(sdrDetails["ID"]),
                            GroupID = DataTypeHelper.GetInt(sdrDetails["GroupID"]),
                            WID = DataTypeHelper.GetInt(sdrDetails["WID"]),
                            ShopID = DataTypeHelper.GetInt(sdrDetails["ShopID"]),
                            CreateTime = DataTypeHelper.GetDateTime(sdrDetails["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdrDetails["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdrDetails["CreateUserName"], null),
                            ShopCode = DataTypeHelper.GetString(sdrDetails["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdrDetails["ShopName"], null),
                            FullAddress = DataTypeHelper.GetString(sdrDetails["FullAddress"], null)
                        });
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.GetModel",
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


        #region 根据字典获取ShopGroup集合
        /// <summary>
        /// 根据字典获取ShopGroup集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<ShopGroup> GetList(IDictionary<string, object> conditionDict)
        {
            IList<ShopGroup> list = null;
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


        #region 根据字典获取ShopGroup数据集
        /// <summary>
        /// 根据字典获取ShopGroup数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.GetDataSet",
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


        #region 分页获取ShopGroup集合
        /// <summary>
        /// 分页获取ShopGroup集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<ShopGroup> GetPageList(PageListBySql<ShopGroup> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "(select *,(select COUNT(0) from ShopGroupDetails as d where s.GroupID=d.GroupID) as ShopNum from shopgroup as s where IsDeleted=0) a";
                page.Fields = "GroupID,GroupCode,WID,GroupName,Remark,CreateUserID,CreateUserName,ShopNum,CreateTime";
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
                        page.ItemList.Add(new ShopGroup
                        {
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
                            GroupCode = DataTypeHelper.GetString(sdr["GroupCode"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupName = DataTypeHelper.GetString(sdr["GroupName"], null),                            
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                            CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                            CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                            ShopNum = DataTypeHelper.GetInt(sdr["ShopNum"])
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.UpdateField",
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

            if (conditionDict.ContainsKey("WID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "WID",
                        FieldValue = conditionDict["WID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                        FieldLength = 4
                    }
                });
            }

            if (conditionDict.ContainsKey("GroupCode"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "GroupCode",
                        FieldValue = conditionDict["GroupCode"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 32
                    }
                });
            }

            if (conditionDict.ContainsKey("GroupName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "GroupName",
                        FieldValue = conditionDict["GroupName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }


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
                return "CreateTime desc";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取ShopGroup列表
        /// <summary>
        /// 根据条件获取ShopGroup列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<ShopGroup> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<ShopGroup> list = new List<ShopGroup>();
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
                        list.Add(new ShopGroup
                        {
                            GroupID = DataTypeHelper.GetInt(sdr["GroupID"]),
                            GroupCode = DataTypeHelper.GetString(sdr["GroupCode"], null),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            GroupName = DataTypeHelper.GetString(sdr["GroupName"], null),
                            IsDeleted = DataTypeHelper.GetInt(sdr["IsDeleted"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.GetList",
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


    public partial class ShopGroupDAO : BaseDAL, IShopGroupDAO
    {
        #region 根据 群组编号 验证ShopGroup是否存在
        /// <summary>
        /// 根据 群组编号 验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsGroupCode(ShopGroup model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsGroupCode", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@GroupCode", SqlDbType.VarChar,32),
            new SqlParameter("@GroupID", SqlDbType.Int)
            };
            sp[0].Value = model.GroupCode;
            sp[1].Value = model.GroupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.ExistsGroupCode",
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

        #region 根据 群组名称 验证ShopGroup是否存在
        /// <summary>
        /// 根据 群组名称 验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsGroupName(ShopGroup model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsGroupName", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
            new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
            new SqlParameter("@GroupID", SqlDbType.Int)
            };
            sp[0].Value = model.GroupName;
            sp[1].Value = model.GroupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.ExistsGroupName",
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

        #region 根据主键逻辑删除一个ShopGroup事务操作
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroup 事务操作
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事物对象</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(int groupID, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@GroupID", SqlDbType.Int)
            };
            sp[0].Value = groupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.LogicDelete",
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

        #region 添加一个ShopGroup 事务处理
        /// <summary>
        /// 添加一个ShopGroup 事务处理
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事物对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(ShopGroup model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@GroupCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
            new SqlParameter("@IsDeleted", SqlDbType.Int),
            new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
            new SqlParameter("@CreateTime", SqlDbType.DateTime),
            new SqlParameter("@CreateUserID", SqlDbType.Int),
            new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)

            };
            sp[0].Value = model.GroupCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupName;
            sp[3].Value = model.IsDeleted;
            sp[4].Value = model.Remark;
            sp[5].Value = model.CreateTime;
            sp[6].Value = model.CreateUserID;
            sp[7].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.SaveTran",
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

        #region 更新一个ShopGroup 事务处理
        /// <summary>
        /// 更新一个ShopGroup 事务处理
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事物对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(ShopGroup model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
            new SqlParameter("@GroupCode", SqlDbType.VarChar, 32),
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
            new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
            new SqlParameter("@GroupID", SqlDbType.Int)

            };
            sp[0].Value = model.GroupCode;
            sp[1].Value = model.WID;
            sp[2].Value = model.GroupName;
            sp[3].Value = model.Remark;
            sp[4].Value = model.GroupID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.ShopGroup.EditTran",
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