/*****************************
* Author:
*
* Date:2016-04-07
******************************/


using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;


namespace Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL
{
    /// <summary>
    /// ### WProductPromotion数据库访问类
    /// </summary>
    public partial class WProductPromotionDAO : BaseDAL, IWProductPromotionDAO
    {

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public WProductPromotionDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public WProductPromotionDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "WProductPromotion";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }


        #region  成员方法
        #region 根据主键验证WProductPromotion是否存在
        /// <summary>
        /// 根据主键验证WProductPromotion是否存在
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(WProductPromotion model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
               new SqlParameter("@PromotionID", SqlDbType.VarChar, 50)
                    };
            sp[0].Value = model.PromotionID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.Exists",
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


        #region 添加一个WProductPromotion
        /// <summary>
        /// 添加一个WProductPromotion
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductPromotion model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
                new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
                new SqlParameter("@PromotionType", SqlDbType.Int),
                new SqlParameter("@WID", SqlDbType.Int),
                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
                new SqlParameter("@BeginTime", SqlDbType.DateTime),
                new SqlParameter("@EndTime", SqlDbType.DateTime),
                new SqlParameter("@Status", SqlDbType.Int),
                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                new SqlParameter("@CreateUserID", SqlDbType.Int),
                new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

                };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.PromotionType;
            sp[2].Value = model.WID;
            sp[3].Value = model.WCode;
            sp[4].Value = model.WName;
            sp[5].Value = model.PromotionName;
            sp[6].Value = model.BeginTime;
            sp[7].Value = model.EndTime;
            sp[8].Value = model.Status;
            sp[9].Value = model.Remark;
            sp[10].Value = model.CreateTime;
            sp[11].Value = model.CreateUserID;
            sp[12].Value = model.CreateUserName;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.Save",
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


        #region 更新一个WProductPromotion
        /// <summary>
        /// 更新一个WProductPromotion
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductPromotion model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                new SqlParameter("@PromotionType", SqlDbType.Int),
                new SqlParameter("@WID", SqlDbType.Int),
                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
                new SqlParameter("@BeginTime", SqlDbType.DateTime),
                new SqlParameter("@EndTime", SqlDbType.DateTime),
                new SqlParameter("@Status", SqlDbType.Int),
                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                new SqlParameter("@PromotionID", SqlDbType.VarChar, 50)

                };
            sp[0].Value = model.PromotionType;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.PromotionName;
            sp[5].Value = model.BeginTime;
            sp[6].Value = model.EndTime;
            sp[7].Value = model.Status;
            sp[8].Value = model.Remark;
            sp[9].Value = model.ModifyTime;
            sp[10].Value = model.ModifyUserID;
            sp[11].Value = model.ModifyUserName;
            sp[12].Value = model.PromotionID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.Edit",
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


        #region 删除一个WProductPromotion
        /// <summary>
        /// 删除一个WProductPromotion
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(WProductPromotion model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
					new SqlParameter("@PromotionID", SqlDbType.VarChar, 50)
					};
            sp[0].Value = model.PromotionID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.Delete",
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


        #region 根据主键逻辑删除一个WProductPromotion
        /// <summary>
        /// 根据主键逻辑删除一个WProductPromotion
        /// </summary>
        /// <param name="promotionID">主键ID(WID+ID服务表)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string promotionID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
			    new SqlParameter("@PromotionID", SqlDbType.VarChar, 50)
			};
            sp[0].Value = promotionID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.LogicDelete",
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


        #region 根据字典获取WProductPromotion对象
        /// <summary>
        /// 根据字典获取WProductPromotion对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductPromotion对象</returns>
        public WProductPromotion GetModel(IDictionary<string, object> conditionDict)
        {
            WProductPromotion model = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
                }
                IList<WProductPromotion> list = GetList(where.ToString(), sp);
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


        #region 根据主键获取WProductPromotion对象
        /// <summary>
        /// 根据主键获取WProductPromotion对象
        /// </summary>
        /// <param name="promotionID">主键ID(WID+ID服务表)</param>
        /// <returns>WProductPromotion对象</returns>
        public WProductPromotion GetModel(string promotionID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            WProductPromotion model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                new SqlParameter("@PromotionID", SqlDbType.VarChar, 50)
                };
                sp[0].Value = promotionID;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<WProductPromotion>(sdr);//2016-4-11 测试发现 ExecuteToEntity方法处理数据有异常，对可空的时间类型，即使数据库中有值，获取到的值是null
                    //while (sdr.Read())
                    //{
                    //    model = new WProductPromotion
                    //    {
                    //        PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                    //        PromotionType = DataTypeHelper.GetInt(sdr["PromotionType"]),
                    //        WID = DataTypeHelper.GetInt(sdr["WID"]),
                    //        WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                    //        WName = DataTypeHelper.GetString(sdr["WName"], null),
                    //        PromotionName = DataTypeHelper.GetString(sdr["PromotionName"], null),
                    //        BeginTime = DataTypeHelper.GetDateTimeNull(sdr["BeginTime"]),
                    //        EndTime = DataTypeHelper.GetDateTimeNull(sdr["EndTime"]),
                    //        Status = DataTypeHelper.GetInt(sdr["Status"]),
                    //        ConfTime = DataTypeHelper.GetDateTimeNull(sdr["ConfTime"]),
                    //        ConfUserID = DataTypeHelper.GetIntNull(sdr["ConfUserID"]),
                    //        ConfUserName = DataTypeHelper.GetString(sdr["ConfUserName"], null),
                    //        PostingTime = DataTypeHelper.GetDateTimeNull(sdr["PostingTime"]),
                    //        PostingUserID = DataTypeHelper.GetIntNull(sdr["PostingUserID"]),
                    //        PostingUserName = DataTypeHelper.GetString(sdr["PostingUserName"], null),
                    //        Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                    //        CreateTime = DataTypeHelper.GetDateTime(sdr["CreateTime"]),
                    //        CreateUserID = DataTypeHelper.GetInt(sdr["CreateUserID"]),
                    //        CreateUserName = DataTypeHelper.GetString(sdr["CreateUserName"], null),
                    //        ModifyTime = DataTypeHelper.GetDateTime(sdr["ModifyTime"]),
                    //        ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
                    //        ModifyUserName = DataTypeHelper.GetString(sdr["ModifyUserName"], null)
                    //    };
                    //}
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.GetModel",
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


        #region 根据字典获取WProductPromotion集合
        /// <summary>
        /// 根据字典获取WProductPromotion集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<WProductPromotion> GetList(IDictionary<string, object> conditionDict)
        {
            IList<WProductPromotion> list = null;
            try
            {
                SqlParameter[] sp = SqlParameterHelper.CreateParameters(conditionDict);
                StringBuilder where = new StringBuilder();
                if (sp != null && sp.Length > 0 && sp[0] != null)
                {
                    where.Append(" WHERE 1=1 ");
                    foreach (SqlParameter s in sp)
                    {
                        where.Append(string.Format(" AND {0}=@{0}", s.ParameterName));
                    }
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


        #region 根据字典获取WProductPromotion数据集
        /// <summary>
        /// 根据字典获取WProductPromotion数据集
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.GetDataSet",
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


        #region 分页获取WProductPromotion集合 增加一些查询条件(来自详情表)
        /// <summary>
        /// 分页获取WProductPromotion集合 增加一些查询条件(来自详情表)
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<WProductPromotion> GetPageList(PageListBySql<WProductPromotion> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                string sql1 = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByPromotionIDSql1", base.AssemblyName, base.DatabaseName);
                string sql2 = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelByPromotionIDSql2", base.AssemblyName, base.DatabaseName);

                IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
                string where = CreateCondition(conditionDict, ref parameters);
                if (string.IsNullOrWhiteSpace(where))
                {
                    sql2 += " WHERE prm.PromotionID = pmd.PromotionID and prm.WID = @WID ";
                }
                else
                {
                    sql2 += (" WHERE " + where + " AND prm.PromotionID = pmd.PromotionID and prm.WID = @WID ");
                }

                //分库查询 增加WID参数，防止以后合并数据库
                parameters.Add(new SqlParameter() { ParameterName = "@WID", SqlDbType = SqlDbType.Int, Size = 4, Value = conditionDict["WID"] });

                page.TableName = string.Format("({0}) tmp", string.Format(sql1, sql2));//tableName;
                page.Fields = "PromotionID,PromotionType,WID,WCode,WName,PromotionName,BeginTime,EndTime,Status,ConfTime,ConfUserID,ConfUserName,PostingTime,PostingUserID,PostingUserName,Remark,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName";
                page.OrderFields = CreateOrder(page.OrderFields);
                page.Where = string.Empty; // CreateCondition(conditionDict, ref parameters);
                page.Parameters = (parameters as List<IDbDataParameter>).ToArray();

                string getCountSql = page.GetCountsSql();
                object counts = helper.GetSingle(getCountSql, page.Parameters);
                if (counts != null)
                {
                    int.TryParse(counts.ToString(), out totalRecords);
                }
                page.TotalRecords = totalRecords;

                string sql = page.GetRecordsSql(ref totalPages);
                //调试时记录SQL语句
                //Logger.GetInstance().DebugLog
                //(
                //    new NormalLog
                //    {
                //        LogSource = helper.DataSource,
                //        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.GetPageList",
                //        LogContent = ExceptionSqlGettter.GetSqlAndParamter(sql, helper.ParamArray),
                //        LogTime = DateTime.Now
                //    }
                //);

                page.TotalPages = totalPages;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, page.Parameters) as SqlDataReader)
                {
                    //page.ItemList = DataReaderHelper.ExecuteToList<WProductPromotion>(sdr);//2016-4-11 测试发现 ExecuteToList方法处理数据有异常，对可空的时间类型，即使数据库中有值，获取到的值是null,暂时改成手动读取的方式
                    while (sdr.Read())
                    {
                        page.ItemList.Add(new WProductPromotion
                        {
                            PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                            PromotionType = DataTypeHelper.GetInt(sdr["PromotionType"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            PromotionName = DataTypeHelper.GetString(sdr["PromotionName"], null),
                            BeginTime = DataTypeHelper.GetDateTimeNull(sdr["BeginTime"]),
                            EndTime = DataTypeHelper.GetDateTimeNull(sdr["EndTime"]),
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
                            ModifyUserID = DataTypeHelper.GetIntNull(sdr["ModifyUserID"]),
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.GetPageList",
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.UpdateField",
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

            if (conditionDict.ContainsKey("PromotionType"))//促销类型 (1:门店积分促销;2:平台费率促销) WProductPromotion.PromotionType
            {
                where.Append(" AND prm.PromotionType = @PromotionType");
                SqlParameter s = new SqlParameter("@PromotionType", SqlDbType.Int, 4);
                s.Value = conditionDict["PromotionType"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("PromotionName"))//活动名称 WProductPromotion.PromotionName
            {
                where.Append(" AND prm.PromotionName like @PromotionName");
                SqlParameter s = new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50);
                s.Value = "%" + conditionDict["PromotionName"] + "%";
                parameters.Add(s);
            }


            if (conditionDict.ContainsKey("Status"))//单据状态 WProductPromotion.Status ()
            {
                where.Append(" AND prm.Status=@Status");
                SqlParameter s = new SqlParameter("@Status", SqlDbType.Int, 4);
                s.Value = conditionDict["Status"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("PromotionID"))//单据号 WProductPromotion.PromotionID
            {
                where.Append(" AND prm.PromotionID like @PromotionID");
                SqlParameter s = new SqlParameter("@PromotionID", SqlDbType.NVarChar, 50);
                s.Value = "%" + conditionDict["PromotionID"] + "%";
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("BeginTimeFrom")) //生效时间 开始时间点 WProductPromotion.BeginTime
            {
                where.Append(" AND prm.BeginTime >= @BeginTimeFrom");
                SqlParameter s = new SqlParameter("@BeginTimeFrom", SqlDbType.DateTime);
                s.Value = conditionDict["BeginTimeFrom"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("BeginTimeEnd")) //生效时间 截至时间点 WProductPromotion.BeginTime
            {
                where.Append(" AND prm.BeginTime <= @BeginTimeEnd");
                SqlParameter s = new SqlParameter("@BeginTimeEnd", SqlDbType.DateTime);
                s.Value = conditionDict["BeginTimeEnd"];
                parameters.Add(s);
            }

            if (conditionDict.ContainsKey("ProductName")) //产品名称 WProductPromotionDetails.ProductName
            {
                where.Append(" AND pmd.ProductName like @ProductName");
                SqlParameter s = new SqlParameter("@ProductName", SqlDbType.NVarChar, 50);
                s.Value = "%" + conditionDict["ProductName"] + "%";
                parameters.Add(s);
            }

            //TODO 数据库设计时 忘记做BarCode字段的冗余了，造成要跨库查询 2016-4-9 下午和胡总沟通，胡总表示暂时不查询这个字段
            //if (conditionDict.ContainsKey("BarCode")) //商品条码 WProductPromotionDetails.BarCode 
            //{
            //    where.Append(" AND pbc.BarCode like @BarCode");
            //    SqlParameter s = new SqlParameter("@BarCode", SqlDbType.NVarChar, 32);
            //    s.Value = "%" + conditionDict["BarCode"] + "%";
            //    parameters.Add(s);
            //}

            if (conditionDict.ContainsKey("SKU")) //ERP编号 WProductPromotionDetails.SKU
            {
                where.Append(" AND pmd.SKU like @SKU");
                SqlParameter s = new SqlParameter("@SKU", SqlDbType.VarChar, 10);
                s.Value = "%" + conditionDict["SKU"] + "%";
                parameters.Add(s);
            }
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
                return "PromotionID";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取WProductPromotion列表
        /// <summary>
        /// 根据条件获取WProductPromotion列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WProductPromotion> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WProductPromotion> list = new List<WProductPromotion>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<WProductPromotion>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.GetList",
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

    public partial class WProductPromotionDAO : BaseDAL, IWProductPromotionDAO
    {
        #region 添加一个WProductPromotion 事务操作
        /// <summary>
        /// 添加一个WProductPromotion 事务操作
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(WProductPromotion model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
                new SqlParameter("@PromotionType", SqlDbType.Int),
                new SqlParameter("@WID", SqlDbType.Int),
                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
                new SqlParameter("@BeginTime", SqlDbType.DateTime),
                new SqlParameter("@EndTime", SqlDbType.DateTime),
                new SqlParameter("@Status", SqlDbType.Int),
                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                new SqlParameter("@CreateUserID", SqlDbType.Int),
                new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

                };
            sp[0].Value = model.PromotionID;
            sp[1].Value = model.PromotionType;
            sp[2].Value = model.WID;
            sp[3].Value = model.WCode;
            sp[4].Value = model.WName;
            sp[5].Value = model.PromotionName;
            sp[6].Value = model.BeginTime;
            sp[7].Value = model.EndTime;
            sp[8].Value = model.Status;
            sp[9].Value = model.Remark;
            sp[10].Value = model.CreateTime;
            sp[11].Value = model.CreateUserID;
            sp[12].Value = model.CreateUserName;
            sp[13].Value = model.ModifyTime;
            sp[14].Value = model.ModifyUserID;
            sp[15].Value = model.ModifyUserName;

            try
            {
                object o = new object();
                if (conn == null && tran == null)
                {
                    o = helper.ExecNonQuery(sql, sp);//主键是字符串而不是自增长int
                }
                else
                {
                    o = helper.ExecNonQuery(conn, tran, sql, sp);//主键是字符串而不是自增长int,返回受影响行数
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.Save",
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

        #region 更新一个WProductPromotion 事务操作
        /// <summary>
        /// 更新一个WProductPromotion 事务操作
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(WProductPromotion model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                new SqlParameter("@PromotionType", SqlDbType.Int),
                new SqlParameter("@WID", SqlDbType.Int),
                new SqlParameter("@WCode", SqlDbType.VarChar, 32),
                new SqlParameter("@WName", SqlDbType.NVarChar, 50),
                new SqlParameter("@PromotionName", SqlDbType.NVarChar, 50),
                new SqlParameter("@BeginTime", SqlDbType.DateTime),
                new SqlParameter("@EndTime", SqlDbType.DateTime),
                new SqlParameter("@Status", SqlDbType.Int),
                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                new SqlParameter("@PromotionID", SqlDbType.VarChar, 50)

                };
            sp[0].Value = model.PromotionType;
            sp[1].Value = model.WID;
            sp[2].Value = model.WCode;
            sp[3].Value = model.WName;
            sp[4].Value = model.PromotionName;
            sp[5].Value = model.BeginTime;
            sp[6].Value = model.EndTime;
            sp[7].Value = model.Status;
            sp[8].Value = model.Remark;
            sp[9].Value = model.ModifyTime;
            sp[10].Value = model.ModifyUserID;
            sp[11].Value = model.ModifyUserName;
            sp[12].Value = model.PromotionID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.Edit",
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

        #region 删除一个WProductPromotion 事务操作
        /// <summary>
        /// 删除一个WProductPromotion 事务操作
        /// </summary>        
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="promotionID">促销ID</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(IDbConnection conn, IDbTransaction tran, string promotionID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
					new SqlParameter("@PromotionID", SqlDbType.VarChar, 50)
					};
            sp[0].Value = promotionID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.Delete",
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


        #region 根据规则验证 互斥条件
        /// <summary>
        /// 根据规则验证 互斥条件
        /// </summary>
        /// <param name="promotionID">促销ID</param>
        /// <param name="promotionType">促销类型(1:门店积分促销;2:平台费率促销)</param>
        /// <param name="wid">仓库ID</param>        
        /// <returns>RepeatPromotionInfo对象</returns>
        public RepeatPromotionInfo GetRepeatInfo(string promotionID, int promotionType, int wid)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            RepeatPromotionInfo model = new RepeatPromotionInfo();
            try
            {
                //根据促销类型，读取不同的xml文档中的SQL语句  GetRepeatRateInfo 查平台费率; GetRepeatPromotionInfo 查积分促销
                string sqlXml = (promotionType == 2) ? "GetRepeatRateInfo" : "GetRepeatPromotionInfo";
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, sqlXml, base.AssemblyName, base.DatabaseName);

                SqlParameter[] sp = {
                new SqlParameter("@PromotionID", SqlDbType.VarChar, 50),
                new SqlParameter("@WID", SqlDbType.Int)
                };
                sp[0].Value = promotionID;
                sp[1].Value = wid;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<RepeatPromotionInfo>(sdr); //RepeatPromotionInfo.Exist属性不存在于SQL查询结果中
                    //while (sdr.Read())
                    //{
                    //    model = new RepeatPromotionInfo
                    //    {
                    //        PromotionID = DataTypeHelper.GetString(sdr["PromotionID"], null),
                    //        ProductID = DataTypeHelper.GetInt(sdr["ProductID"]),
                    //        ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                    //        ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                    //        Sku = DataTypeHelper.GetString(sdr["ShopCode"], null)
                    //    };
                    //}
                    if (model != null)
                    {
                        if (!string.IsNullOrWhiteSpace(model.PromotionID) || !string.IsNullOrWhiteSpace(model.ShopCode) || !string.IsNullOrWhiteSpace(model.Sku) || model.ShopID > 0 || model.ProductID > 0)
                        {
                            model.Exist = true;//发现相关信息则认为是已经存在生效记录了
                        }
                        else
                        {
                            model.Exist = false;
                        }
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Promotion.MSSQLDAL.WProductPromotion.GetRepeatInfo",
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int TimerWProductPromotionPosting(int promotionType, int userId, string userName)
        {
            string sql = "UPDATE WProductPromotion SET Status=2,PostingTime=GETDATE(),PostingUserID=@PostingUserID,PostingUserName=@PostingUserName WHERE Status=1 AND PromotionType=@PromotionType AND BeginTime<=GETDATE()";
            SqlParamrterBuilder sqlParameterHelper = new  SqlParamrterBuilder();
            sqlParameterHelper.Add("PromotionType", promotionType);
            sqlParameterHelper.Add("PostingUserID", userId);
            sqlParameterHelper.Add("PostingUserName", userName);
            return DBHelper.GetInstance(this.ConnectionString).ExecNonQuery(sql, sqlParameterHelper.ToSqlParameters());
        }
    }
}
