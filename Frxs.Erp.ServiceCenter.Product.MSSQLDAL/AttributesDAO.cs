
/*****************************
* Author:luojing
*
* Date:2016-03-09
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
    /// ### 多规格属性表Attributes数据库访问类
    /// </summary>
    public partial class AttributesDAO : BaseDAL, IAttributesDAO
    {
        const string tableName = "Attributes";

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Attributes"; }
        }


        #region 成员方法

        #region 添加一个Attributes
        /// <summary>
        /// 添加一个Attributes
        /// </summary>
        /// <param name="model">Attributes对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(Attributes model)
        {
            DBHelper helper = DBHelper.GetInstance();

            //已存在同名规格
            if (ExistsAttributeName(model.AttributeName, model.AttributeId))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.ExistSameName;
            }

            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@AttributeName", SqlDbType.NVarChar, 20),
                                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                                    new SqlParameter("@CreateUserID", SqlDbType.Int),
                                    new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                                };
            sp[0].Value = model.AttributeName;
            sp[1].Value = model.IsDeleted;
            sp[2].Value = model.CreateUserID;
            sp[3].Value = model.CreateUserName;

            try
            {
                object o = helper.GetSingle(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.Save",
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


        #region 更新一个Attributes
        /// <summary>
        /// 更新一个Attributes
        /// </summary>
        /// <param name="model">Attributes对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(Attributes model)
        {
            DBHelper helper = DBHelper.GetInstance();

            //如果已不存在
            if (!ExistsAttributeId(model.AttributeId))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.NoExist;
            }
            //已存在同名规格
            if (ExistsAttributeName(model.AttributeName, model.AttributeId))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.ExistSameName;
            }

            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@AttributeName", SqlDbType.NVarChar, 20),
                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@AttributeId", SqlDbType.Int)
                };
            sp[0].Value = model.AttributeName;
            sp[1].Value = model.IsDeleted;
            sp[2].Value = model.ModifyUserID;
            sp[3].Value = model.ModifyUserName;
            sp[4].Value = model.AttributeId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.Edit",
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


 //       #region 删除一个Attributes
 //       /// <summary>
 //       /// 删除一个Attributes
 //       /// </summary>
 //       /// <param name="model">Attributes对象</param>
 //       /// <returns>数据库影响行数</returns>
 //       [Obsolete]
 //       public int Delete(Attributes model)
 //       {
 //           DBHelper helper = DBHelper.GetInstance();
 //           int result = 0;
 //           string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

 //           SqlParameter[] sp = {
 //new SqlParameter("@AttributeId", SqlDbType.Int)
 //};
 //           sp[0].Value = model.AttributeId;

 //           try
 //           {
 //               result = helper.ExecNonQuery(sql, sp);
 //           }
 //           catch (Exception ex)
 //           {
 //               string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
 //               Logger.GetInstance().DBOperatingLog
 //               (
 //               new NormalLog
 //               {
 //                   LogSource = helper.DataSource,
 //                   LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.Delete",
 //                   LogContent = exceptionSql,
 //                   LogTime = DateTime.Now
 //               },
 //               ex
 //               );
 //               throw;
 //           }
 //           return result;
 //       }
 //       #endregion


        #region 根据主键逻辑删除一个Attributes
        /// <summary>
        /// 根据主键逻辑删除一个Attributes
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(Attributes model)
        {
            DBHelper helper = DBHelper.GetInstance();

            //如果已不存在
            if (!ExistsAttributeId(model.AttributeId))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.NoExist;
            }

            //逻辑删除，判断是否存在关联引用
            if (AttributesReference(model.AttributeId) > 0)
            {
                return (int)ProductCenterEnum.ReturnResultInfo.ExistReference;
            }

            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp =
                {
                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@AttributeId", SqlDbType.Int)
                };

            sp[0].Value = model.ModifyUserID;
            sp[1].Value = model.ModifyUserName;
            sp[2].Value = model.AttributeId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.LogicDelete",
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


        #region 根据字典获取Attributes对象
        /// <summary>
        /// 根据字典获取Attributes对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Attributes对象</returns>
        public Attributes GetModel(IDictionary<string, object> conditionDict)
        {
            Attributes model = null;
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
                IList<Attributes> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取Attributes对象
        /// <summary>
        /// 根据主键获取Attributes对象
        /// </summary>
        /// <param name="attributeId">主键ID</param>
        /// <returns>Attributes对象</returns>
        public Attributes GetModel(int attributeId)
        {
            DBHelper helper = DBHelper.GetInstance();
            Attributes model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp =
                    {
                        new SqlParameter("@AttributeId", SqlDbType.Int)
                    };
                sp[0].Value = attributeId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new Attributes
                        {
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            AttributeName = DataTypeHelper.GetString(sdr["AttributeName"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.GetModel",
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


        #region 根据字典获取Attributes集合
        /// <summary>
        /// 根据字典获取Attributes集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<Attributes> GetList(IDictionary<string, object> conditionDict)
        {
            IList<Attributes> list = null;
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


        #region 根据字典获取Attributes数据集
        /// <summary>
        /// 根据字典获取Attributes数据集
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
                    where.Append(" WHERE IsDeleted=0 ");
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.GetDataSet",
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


        #region 分页获取Attributes集合
        /// <summary>
        /// 分页获取Attributes集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<Attributes> GetPageList(PageListBySql<Attributes> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {

                page.TableName = SQLConfigBuilder.GetSQLScriptByTable(tableName, "AttributesGetList", base.AssemblyName, base.DatabaseName);
                page.Fields = "AttributeId,AttributeName,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);
                page.Parameters = (parameters as List<IDbDataParameter>).ToArray();
                page.IsGroup = 1;
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
                        page.ItemList.Add(new Attributes
                        {
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            AttributeName = DataTypeHelper.GetString(sdr["AttributeName"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.UpdateField",
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

            //属性名
            if (conditionDict.ContainsKey("AttributeName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "AttributeName",
                        FieldValue = conditionDict["AttributeName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 40
                    }
                });
            }
            //属性值
            if (conditionDict.ContainsKey("ValueStr"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "ValueStr",
                        FieldValue = conditionDict["ValueStr"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 40
                    }
                });
            }
            //SKU编码
            if (conditionDict.ContainsKey("SKU"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Like,
                    FieldObj = new Field
                    {
                        FieldName = "SKU",
                        FieldValue = conditionDict["SKU"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                        FieldLength = 10
                    }
                });
            }
            //规格Id
            if (conditionDict.ContainsKey("AttributeId"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "AttributeId",
                        FieldValue = conditionDict["AttributeId"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int)
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
        /// <param name="order">分页辅助类</param>
        string CreateOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                return "AttributeId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取Attributes列表
        /// <summary>
        /// 根据条件获取Attributes列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<Attributes> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<Attributes> list = new List<Attributes>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "AttributesGetAll", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new Attributes
                        {
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            AttributeName = DataTypeHelper.GetString(sdr["AttributeName"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.GetList",
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


    public partial class AttributesDAO : BaseDAL, IAttributesDAO
    {
        #region 根据规格名称验证Attributes是否存在

        /// <summary>
        /// 根据规格名称验证Attributes是否存在
        /// </summary>
        /// <param name="attributeName">规格名称</param>
        /// <param name="attributeId">规格编号</param>
        /// <returns>是否存在</returns>
        public bool ExistsAttributeName(string attributeName, int attributeId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsAttributeName", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@AttributeName", SqlDbType.NVarChar,40),
                                    new SqlParameter("@AttributeId",SqlDbType.Int)
                                };
            sp[0].Value = attributeName;
            sp[1].Value = attributeId;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.ExistsAttributeName",
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


        #region 根据主键验证Attributes是否存在
        /// <summary>
        /// 根据主键验证Attributes是否存在
        /// </summary>
        /// <param name="attributeId">规格编号</param>
        /// <returns>是否存在</returns>
        public bool ExistsAttributeId(int attributeId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsAttributeId", base.AssemblyName, base.DatabaseName);
            IDbDataParameter[] sp = {
                                    new SqlParameter("@AttributeId", SqlDbType.Int)
                                };
            sp[0].Value = attributeId;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.ExistsAttributeId",
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


        #region 取规格名称
        /// <summary>
        /// 取规格名称
        /// </summary>
        /// <param name="attriduteId">规格编号</param>
        /// <returns></returns>
        public string GetAttributeName(int attriduteId)
        {
            DBHelper helper = DBHelper.GetInstance();
            string result = "";
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetAttributeName", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@AttributeId", SqlDbType.Int)
                                };
            sp[0].Value = attriduteId;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.GetAttributeName",
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


        #region 分页获取包含商品集合
        /// <summary>
        /// 分页获取包含商品集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<AttributesProducts> ProductsGetPageList(PageListBySql<AttributesProducts> page, Dictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Products", base.AssemblyName, base.DatabaseName);
                page.Fields = "ProductId,SKU,ProductName,ValueStr";
                page.OrderFields = "ModifyUserName desc";
                IList<IDbDataParameter> parameters = null;
                page.Where = CreateCondition(conditionDict, ref parameters);
                page.Parameters = (parameters as List<IDbDataParameter>).ToArray();
                page.IsGroup = 0;
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
                        page.ItemList.Add(new AttributesProducts
                        {
                            ProductId = DataTypeHelper.GetInt(sdr["ProductId"]),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            ValueStr = DataTypeHelper.GetString(sdr["ValueStr"], null)
                        });
                    }
                }
                page.TableName = GetAttributeName(DataTypeHelper.GetInt(conditionDict["AttributeId"]));
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.ProductsGetPageList",
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

        #region 查找存在引用的条数
        /// <summary>
        /// 查找存在引用的条数
        /// </summary>
        /// <param name="attributeId">规格Id</param>
        /// <returns></returns>
        private int AttributesReference(int attributeId)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "AttributesReference", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = { new SqlParameter("@AttributeId", SqlDbType.Int) };
                sp[0].Value = attributeId;
                return int.Parse(helper.GetSingle(sql, sp).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.Attributes.AttributesReference",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }
        #endregion
    }
}