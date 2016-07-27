
/*****************************
* Author:leidong
*
* Date:2016-04-05
******************************/
using System;
using System.Collections.Generic;
using System.Text;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using System.Configuration;
using System.Reflection;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{ 
    /// <summary>
    /// ### SaleOrderPreDetailsPick数据库访问类
    /// </summary>
    public partial class SaleOrderPreDetailsPickDAO: BaseDAL, ISaleOrderPreDetailsPickDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleOrderPreDetailsPickDAO() { }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleOrderPreDetailsPickDAO(string warehouseId)
            : base(warehouseId)
        {

        }


        const string tableName = "SaleOrderPreDetailsPick";

        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        {
            get { return tableName; }
        }



        #region  成员方法
        #region 根据主键验证SaleOrderPreDetailsPick是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreDetailsPick是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderPreDetailsPick model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
               new SqlParameter("@ID", SqlDbType.VarChar, 50)
                    };
            sp[0].Value=model.ID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.Exists",
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


        #region 添加一个SaleOrderPreDetailsPick
        /// <summary>
        /// 添加一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(SaleOrderPreDetailsPick model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql =SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
               new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.NVarChar, 10),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@PickQty", SqlDbType.Decimal, 4),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PickTime", SqlDbType.DateTime),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32),
new SqlParameter("@IsCheckRight", SqlDbType.Int),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

					};
            sp[0].Value=model.ID;
sp[1].Value=model.OrderID;
sp[2].Value=model.ProductID;
sp[3].Value=model.WCProductID;
sp[4].Value=model.SKU;
sp[5].Value=model.ProductName;
sp[6].Value=model.BarCode;
sp[7].Value=model.ProductImageUrl200;
sp[8].Value=model.ProductImageUrl400;
sp[9].Value=model.ShelfAreaID;
sp[10].Value=model.ShelfID;
sp[11].Value=model.ShelfCode;
sp[12].Value=model.SaleQty;
sp[13].Value=model.SaleUnit;
sp[14].Value=model.SalePackingQty;
sp[15].Value=model.PickQty;
sp[16].Value=model.PickUserID;
sp[17].Value=model.PickUserName;
sp[18].Value=model.PickTime;
sp[19].Value=model.CheckTime;
sp[20].Value=model.CheckUserID;
sp[21].Value=model.CheckUserName;
sp[22].Value=model.IsCheckRight;
sp[23].Value=model.IsAppend;
sp[24].Value=model.Remark;
sp[25].Value=model.ModifyTime;
sp[26].Value=model.ModifyUserID;
sp[27].Value=model.ModifyUserName;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.Save",
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


        #region 添加一个SaleOrderPreDetailsPick(事务处理)
        /// <summary>
        /// 添加一个SaleOrderPreDetailsPick(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        public int Save(IDbConnection conn, IDbTransaction tran, SaleOrderPreDetailsPick model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql =SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
               new SqlParameter("@ID", SqlDbType.VarChar, 50),
new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.NVarChar, 10),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@PickQty", SqlDbType.Decimal, 4),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PickTime", SqlDbType.DateTime),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32),
new SqlParameter("@IsCheckRight", SqlDbType.Int),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32)

					};
            sp[0].Value=model.ID;
sp[1].Value=model.OrderID;
sp[2].Value=model.ProductID;
sp[3].Value=model.WCProductID;
sp[4].Value=model.SKU;
sp[5].Value=model.ProductName;
sp[6].Value=model.BarCode;
sp[7].Value=model.ProductImageUrl200;
sp[8].Value=model.ProductImageUrl400;
sp[9].Value=model.ShelfAreaID;
sp[10].Value=model.ShelfID;
sp[11].Value=model.ShelfCode;
sp[12].Value=model.SaleQty;
sp[13].Value=model.SaleUnit;
sp[14].Value=model.SalePackingQty;
sp[15].Value=model.PickQty;
sp[16].Value=model.PickUserID;
sp[17].Value=model.PickUserName;
sp[18].Value=model.PickTime;
sp[19].Value=model.CheckTime;
sp[20].Value=model.CheckUserID;
sp[21].Value=model.CheckUserName;
sp[22].Value=model.IsCheckRight;
sp[23].Value=model.IsAppend;
sp[24].Value=model.Remark;
sp[25].Value=model.ModifyTime;
sp[26].Value=model.ModifyUserID;
sp[27].Value=model.ModifyUserName;

            try
            {
                
                result = helper.ExecNonQuery(conn, tran, sql, sp);
            
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.Save",
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

 
        #region 更新一个SaleOrderPreDetailsPick
        /// <summary>
        /// 更新一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderPreDetailsPick model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql =SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
					new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.NVarChar, 10),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@PickQty", SqlDbType.Decimal, 4),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PickTime", SqlDbType.DateTime),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32),
new SqlParameter("@IsCheckRight", SqlDbType.Int),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

					};
            sp[0].Value=model.OrderID;
sp[1].Value=model.ProductID;
sp[2].Value=model.WCProductID;
sp[3].Value=model.SKU;
sp[4].Value=model.ProductName;
sp[5].Value=model.BarCode;
sp[6].Value=model.ProductImageUrl200;
sp[7].Value=model.ProductImageUrl400;
sp[8].Value=model.ShelfAreaID;
sp[9].Value=model.ShelfID;
sp[10].Value=model.ShelfCode;
sp[11].Value=model.SaleQty;
sp[12].Value=model.SaleUnit;
sp[13].Value=model.SalePackingQty;
sp[14].Value=model.PickQty;
sp[15].Value=model.PickUserID;
sp[16].Value=model.PickUserName;
sp[17].Value=model.PickTime;
sp[18].Value=model.CheckTime;
sp[19].Value=model.CheckUserID;
sp[20].Value=model.CheckUserName;
sp[21].Value=model.IsCheckRight;
sp[22].Value=model.IsAppend;
sp[23].Value=model.Remark;
sp[24].Value=model.ModifyTime;
sp[25].Value=model.ModifyUserID;
sp[26].Value=model.ModifyUserName;
sp[27].Value=model.ID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.Edit",
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


        #region 更新一个SaleOrderPreDetailsPick(事务处理)
        /// <summary>
        /// 更新一个SaleOrderPreDetailsPick(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderPreDetailsPick model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql =SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
					new SqlParameter("@OrderID", SqlDbType.VarChar, 50),
new SqlParameter("@ProductID", SqlDbType.Int),
new SqlParameter("@WCProductID", SqlDbType.Int),
new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
new SqlParameter("@ShelfAreaID", SqlDbType.Int),
new SqlParameter("@ShelfID", SqlDbType.Int),
new SqlParameter("@ShelfCode", SqlDbType.VarChar, 10),
new SqlParameter("@SaleQty", SqlDbType.Decimal, 4),
new SqlParameter("@SaleUnit", SqlDbType.NVarChar, 10),
new SqlParameter("@SalePackingQty", SqlDbType.Decimal),
new SqlParameter("@PickQty", SqlDbType.Decimal, 4),
new SqlParameter("@PickUserID", SqlDbType.Int),
new SqlParameter("@PickUserName", SqlDbType.VarChar, 32),
new SqlParameter("@PickTime", SqlDbType.DateTime),
new SqlParameter("@CheckTime", SqlDbType.DateTime),
new SqlParameter("@CheckUserID", SqlDbType.Int),
new SqlParameter("@CheckUserName", SqlDbType.VarChar, 32),
new SqlParameter("@IsCheckRight", SqlDbType.Int),
new SqlParameter("@IsAppend", SqlDbType.Int),
new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ID", SqlDbType.VarChar, 50)

					};
            sp[0].Value=model.OrderID;
sp[1].Value=model.ProductID;
sp[2].Value=model.WCProductID;
sp[3].Value=model.SKU;
sp[4].Value=model.ProductName;
sp[5].Value=model.BarCode;
sp[6].Value=model.ProductImageUrl200;
sp[7].Value=model.ProductImageUrl400;
sp[8].Value=model.ShelfAreaID;
sp[9].Value=model.ShelfID;
sp[10].Value=model.ShelfCode;
sp[11].Value=model.SaleQty;
sp[12].Value=model.SaleUnit;
sp[13].Value=model.SalePackingQty;
sp[14].Value=model.PickQty;
sp[15].Value=model.PickUserID;
sp[16].Value=model.PickUserName;
sp[17].Value=model.PickTime;
sp[18].Value=model.CheckTime;
sp[19].Value=model.CheckUserID;
sp[20].Value=model.CheckUserName;
sp[21].Value=model.IsCheckRight;
sp[22].Value=model.IsAppend;
sp[23].Value=model.Remark;
sp[24].Value=model.ModifyTime;
sp[25].Value=model.ModifyUserID;
sp[26].Value=model.ModifyUserName;
sp[27].Value=model.ID;

            try
            {
                result = helper.ExecNonQuery(conn, tran, sql, sp);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.Edit",
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


        #region 删除一个SaleOrderPreDetailsPick
        /// <summary>
        /// 删除一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderPreDetailsPick model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
					new SqlParameter("@ID", SqlDbType.VarChar, 50)
					};
            sp[0].Value=model.ID;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderPreDetailsPick
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql =SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
			    new SqlParameter("@ID", SqlDbType.VarChar, 50)
			};
            sp[0].Value=iD;

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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.LogicDelete",
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


        #region 根据主键获取SaleOrderPreDetailsPick对象
        /// <summary>
        /// 根据主键获取SaleOrderPreDetailsPick对象
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>SaleOrderPreDetailsPick对象</returns>
        public SaleOrderPreDetailsPick GetModel(string iD)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderPreDetailsPick model=null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);  

                SqlParameter[] sp = {
					new SqlParameter("@ID", SqlDbType.VarChar, 50)
					};
                sp[0].Value=iD;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
               {
                   model = DataReaderHelper.ExecuteToEntity<SaleOrderPreDetailsPick>(sdr);
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
                       LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.GetModel",
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


        #region 根据字典获取SaleOrderPreDetailsPick数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreDetailsPick数据集
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.GetDataSet",
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


       #region 分页获取SaleOrderPreDetailsPick集合
        /// <summary>
        /// 分页获取SaleOrderPreDetailsPick集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderPreDetailsPick> GetPageList(PageListBySql<SaleOrderPreDetailsPick> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "ID,OrderID,ProductID,WCProductID,SKU,ProductName,BarCode,ProductImageUrl200,ProductImageUrl400,ShelfAreaID,ShelfID,ShelfCode,SaleQty,SaleUnit,SalePackingQty,PickQty,PickUserID,PickUserName,PickTime,CheckTime,CheckUserID,CheckUserName,IsCheckRight,IsAppend,Remark,ModifyTime,ModifyUserID,ModifyUserName";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderPreDetailsPick>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.GetPageList",
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.UpdateField",
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


        #region 根据条件获取SaleOrderPreDetailsPick列表
        /// <summary>
        /// 根据条件获取SaleOrderPreDetailsPick列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPreDetailsPick> GetList(string where,SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderPreDetailsPick> list = new List<SaleOrderPreDetailsPick>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "Read", base.AssemblyName, base.DatabaseName));
                
                if(!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }   

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
               {
                  list = DataReaderHelper.ExecuteToList<SaleOrderPreDetailsPick>(sdr);
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
                        LogOperation = "Frxs.Erp.ServiceCenter.Product.MSSQLDAL.SaleOrderPreDetailsPick.GetList",
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

     public partial class SaleOrderPreDetailsPickDAO: BaseDAL, ISaleOrderPreDetailsPickDAO
     {
         /// <summary>
         /// 根据OrderId删除商品明细
         /// </summary>
         /// <param name="orderId">订单ID</param>
         /// <param name="conn">连接</param>
         /// <param name="tran">事务</param>
         /// <returns></returns>
         public int DeleteByOrderId(string orderId, IDbConnection conn = null, IDbTransaction tran = null)
         {
             DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
             int result = 0;
             string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "DeleteByOrderId", base.AssemblyName, base.DatabaseName);
             SqlParamrterBuilder sp = new SqlParamrterBuilder();
             sp.Add("OrderID", SqlDbType.VarChar, 50, orderId);
             try
             {
                 object o = new object();
                 if (conn != null && tran != null)
                 {
                     o = helper.ExecNonQuery(conn, tran, sql, sp.ToSqlParameters());
                 }
                 else
                 {
                     o = helper.ExecNonQuery(sql, sp.ToSqlParameters());
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
                     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPreShelfAreaDAO.DeleteByOrderId",
                     LogContent = exceptionSql,
                     LogTime = DateTime.Now
                 },
                 ex
                 );
                 throw;
             }
             return result;
         }

         #region ISaleOrderPreDetailsPickDAO 成员


         /// <summary>
         /// 根据订单号获取捡货明细
         /// </summary>
         /// <param name="orderId">订单号</param>
         /// <returns></returns>
         public IList<SaleOrderPreDetailsPick> GetOrderPick(string orderId)
         {
             DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
             int result = 0;
             string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetOrderPick", base.AssemblyName, base.DatabaseName);
             SqlParamrterBuilder sp = new SqlParamrterBuilder();
             sp.Add("OrderID", SqlDbType.VarChar, 50, orderId);
             try
             {
                 using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp.ToSqlParameters()) as SqlDataReader)
                 {
                    var list = DataReaderHelper.ExecuteToList<SaleOrderPreDetailsPick>(sdr);
                     return list;
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
                     LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPreShelfAreaDAO.DeleteByOrderId",
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
