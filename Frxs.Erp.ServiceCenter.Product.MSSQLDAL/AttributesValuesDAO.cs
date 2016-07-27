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
    /// ### 多规格属性值表AttributesValues数据库访问类
    /// </summary>
    public partial class AttributesValuesDAO : BaseDAL, IAttributesValuesDAO
    {
        const string tableName = "AttributesValues";

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "AttributesValues"; }
        }


        #region 成员方法
        #region 根据主键验证AttributesValues是否存在
        /// <summary>
        /// 根据主键验证AttributesValues是否存在
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(AttributesValues model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp =
                {
                    new SqlParameter("@ValuesId", SqlDbType.Int)
                };
            sp[0].Value = model.ValuesId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.Exists",
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


        #region 添加一个AttributesValues
        /// <summary>
        /// 添加一个AttributesValues 
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(AttributesValues model)
        {
            DBHelper helper = DBHelper.GetInstance();

            //已存在同名规格值
            if (ExistsValuesStr(model))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.ExistSameName;
            }

            int maxSeq = MaxSeq(model.AttributeId);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@AttributeId", SqlDbType.Int),
                                    new SqlParameter("@ValueStr", SqlDbType.NVarChar, 20),
                                    new SqlParameter("@DisplaySequence", SqlDbType.Int),
                                    new SqlParameter("@IsDeleted", SqlDbType.Int),
                                    new SqlParameter("@CreateUserID", SqlDbType.Int),
                                    new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32)
                                };
            sp[0].Value = model.AttributeId;
            sp[1].Value = model.ValueStr;
            sp[2].Value = maxSeq;
            sp[3].Value = model.IsDeleted;
            sp[4].Value = model.CreateUserID;
            sp[5].Value = model.CreateUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.Save",
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


        #region 更新一个AttributesValues
        /// <summary>
        /// 更新一个AttributesValues
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(AttributesValues model)
        {
            DBHelper helper = DBHelper.GetInstance();

            //如果已不存在
            if (!ExistsValuesId(model))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.NoExist;
            }
            //判断重名
            if (ExistsValuesStr(model))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.ExistSameName;
            }

            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@ValueStr", SqlDbType.NVarChar, 20),
                                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                    new SqlParameter("@ValuesId", SqlDbType.Int)
                                };
            sp[0].Value = model.ValueStr;
            sp[1].Value = model.ModifyUserID;
            sp[2].Value = model.ModifyUserName;
            sp[3].Value = model.ValuesId;


            try
            {
                result = helper.ExecNonQuery(sql, sp);
                //修改冗余名称 （商品规格值名称）
                if (result > 0)
                {
                    string updateSql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateValueStr", base.AssemblyName, base.DatabaseName);
                    SqlParameter[] spUpdate ={
                                                new SqlParameter("@ValueStr", SqlDbType.NVarChar, 20),                   
                                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                                new SqlParameter("@ValuesId", SqlDbType.Int)
                                             };
                    spUpdate[0].Value = model.ValueStr;
                    spUpdate[1].Value = model.ModifyUserID;
                    spUpdate[2].Value = model.ModifyUserName;
                    spUpdate[3].Value = model.ValuesId;

                    helper.ExecNonQuery(updateSql, spUpdate);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.Edit",
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


        #region 删除一个AttributesValues
        /// <summary>
        /// 已废弃
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Obsolete("本系统没有使用这个方法")]
        public int Delete(AttributesValues model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;

        

            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@ValuesId", SqlDbType.Int),
                                
                                };
            sp[0].Value = model.ValuesId;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.Delete",
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


        #region 根据对象逻辑删除一个商品规格值

        /// <summary>
        /// 逻辑删除商品规格值，更新
        /// 要求判断商品规格值是否存在、商品规格是否已被商品引用
        /// </summary>
        /// <param name="model">商品规格值对象</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(AttributesValues model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;

            //如果已不存在
            if (!ExistsValuesId(model))
            {
                return (int)ProductCenterEnum.ReturnResultInfo.NoExist;
            }
            //逻辑删除前，判断是否存在关联引用
            if (ValuesReference(model.ValuesId) > 0)
            {
                return (int)ProductCenterEnum.ReturnResultInfo.ExistReference;
            }
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                    new SqlParameter("@ValuesId", SqlDbType.Int),
                                    new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                    new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)
                                };
            sp[0].Value = model.ValuesId;
            sp[1].Value = model.ModifyUserID;
            sp[2].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.LogicDelete",
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


        #region 根据字典获取AttributesValues对象
        /// <summary>
        /// 根据字典获取AttributesValues对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>AttributesValues对象</returns>
        public AttributesValues GetModel(IDictionary<string, object> conditionDict)
        {
            AttributesValues model = null;
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
                IList<AttributesValues> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取AttributesValues对象
        /// <summary>
        /// 根据主键获取AttributesValues对象
        /// </summary>
        /// <param name="valuesId">主键ID</param>
        /// <returns>AttributesValues对象</returns>
        public AttributesValues GetModel(int valuesId)
        {
            DBHelper helper = DBHelper.GetInstance();
            AttributesValues model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp =
                    {
                        new SqlParameter("@ValuesId", SqlDbType.Int)
                    };
                sp[0].Value = valuesId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        model = new AttributesValues
                        {
                            ValuesId = DataTypeHelper.GetInt(sdr["ValuesId"]),
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            ValueStr = DataTypeHelper.GetString(sdr["ValueStr"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.GetModel",
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


        #region 根据字典获取AttributesValues集合
        /// <summary>
        /// 根据字典获取AttributesValues集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<AttributesValues> GetList(IDictionary<string, object> conditionDict)
        {
            IList<AttributesValues> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                where.Append(" WHERE IsDeleted=0 ");
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
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


        #region 根据字典获取AttributesValues数据集
        /// <summary>
        /// 根据字典获取AttributesValues数据集
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
                where.Append(" WHERE IsDeleted=0 ");
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.GetDataSet",
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


        #region 分页获取AttributesValues集合
        /// <summary>
        /// 分页获取AttributesValues集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<AttributesValues> GetPageList(PageListBySql<AttributesValues> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance();
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;

                page.Fields = "ValuesId,AttributeId,ValueStr,DisplaySequence,IsDeleted,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
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
                        page.ItemList.Add(new AttributesValues
                        {
                            ValuesId = DataTypeHelper.GetInt(sdr["ValuesId"]),
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            ValueStr = DataTypeHelper.GetString(sdr["ValueStr"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.GetPageList",
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.UpdateField",
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
            //默认排序字段
            if (string.IsNullOrEmpty(order))
            {
                return "DisplaySequence";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取AttributesValues列表
        /// <summary>
        /// 根据条件获取AttributesValues列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>SP对象集合</returns>
        IList<AttributesValues> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<AttributesValues> list = new List<AttributesValues>();
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
                        list.Add(new AttributesValues
                        {
                            ValuesId = DataTypeHelper.GetInt(sdr["ValuesId"]),
                            AttributeId = DataTypeHelper.GetInt(sdr["AttributeId"]),
                            ValueStr = DataTypeHelper.GetString(sdr["ValueStr"], null),
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.GetList",
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

    public partial class AttributesValuesDAO : BaseDAL, IAttributesValuesDAO
    {

        #region 根据主键验证AttributesValues是否存在
        /// <summary>
        /// 根据主键验证AttributesValues是否存在
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsValuesId(AttributesValues model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsValueId", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@ValuesId", SqlDbType.Int)
                                };
            sp[0].Value = model.ValuesId;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValuesDAO.ExistsValuesId",
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
        #region 根据名称验证AttributesValues是否重名
        /// <summary>
        /// 根据名称验证AttributesValues是否存在重名
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>是否存在</returns>
        public bool ExistsValuesStr(AttributesValues model)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ExistsValueStr", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                    new SqlParameter("@AttributeId", SqlDbType.Int),
                                    new SqlParameter("@ValueStr",SqlDbType.NVarChar,40),
                                    new SqlParameter("@ValuesId",SqlDbType.Int)
                                };
            sp[0].Value = model.AttributeId;
            sp[1].Value = model.ValueStr;
            sp[2].Value = model.ValuesId;
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValuesDAO.ExistsValuesStr",
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

        #region 查找存在引用的条数
        /// <summary>
        /// 查找存在引用的条数
        /// </summary>
        /// <param name="valuesId">规格值Id</param>
        /// <returns></returns>
        private int ValuesReference(int valuesId)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "AttributesValuesReference", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = { new SqlParameter("@ValuesId", SqlDbType.Int) };
                sp[0].Value = valuesId;
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.ValuesReference",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }
        #endregion

        #region 取最大排序号
        /// <summary>
        /// 取最大排序号
        /// </summary>
        /// <param name="attributeId">规格Id</param>
        /// <returns></returns>
        public int MaxSeq(int attributeId)
        {
            DBHelper helper = DBHelper.GetInstance();
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "MaxSeq", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                                  new SqlParameter("@AttributeId",SqlDbType.Int)
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValuesDAO.MaxSeq",
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
        /// <param name="attributeId"></param>
        /// <returns></returns>
        public IList<AttributesValues> AttributesValuesGetList(int attributeId)
        {
            return this.ExecuteTolist<AttributesValues>("AttributesValuesGet", new SqlParamrterBuilder().Append("AttributeId", attributeId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int AttributesValuesAdd(AttributesValues value)
        {
            return this.Save(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valuesId"></param>
        /// <returns></returns>
        public int AttributesValuesDelete(int valuesId)
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                string sql = this.GetSQLScriptByTable("AttributesValuesDelete");
                return helper.ExecNonQuery(sql, new SqlParamrterBuilder().Append("ValuesId", valuesId).ToSqlParameters());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.AttributesValuesDelete",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 规格值上移下移
        /// </summary>
        public int DisplaySequence(AttributesValues modelA, AttributesValues modelB)
        {
            DBHelper helper = DBHelper.GetInstance();
            //如果已不存在
            if ((!ExistsValuesId(modelA)) || (!ExistsValuesId(modelB)))
            {
                return -100;
            }
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DisplaySequenceEdit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] spA = {
                                     new SqlParameter("@DisplaySequence", SqlDbType.Int),
                                     new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                     new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                     new SqlParameter("@ValuesId", SqlDbType.Int)
                                 };
            spA[0].Value = modelB.DisplaySequence;
            spA[1].Value = modelA.ModifyUserID;
            spA[2].Value = modelA.ModifyUserName;
            spA[3].Value = modelA.ValuesId;

            SqlParameter[] spB = {
                                     new SqlParameter("@DisplaySequence", SqlDbType.Int),
                                     new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                     new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                     new SqlParameter("@ValuesId", SqlDbType.Int)
                                 };
            spB[0].Value = modelA.DisplaySequence;
            spB[1].Value = modelB.ModifyUserID;
            spB[2].Value = modelB.ModifyUserName;
            spB[3].Value = modelB.ValuesId;

            try
            {
                result = helper.ExecNonQuery(sql, spA);
                if (result > 0)
                {
                    result = helper.ExecNonQuery(sql, spB);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.AttributesValues.DisplaySequence",
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