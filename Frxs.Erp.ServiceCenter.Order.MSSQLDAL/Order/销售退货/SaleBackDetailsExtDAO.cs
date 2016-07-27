
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
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


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### SaleBackDetailsExt数据库访问类
    /// </summary>
    public partial class SaleBackDetailsExtDAO : BaseDAL, ISaleBackDetailsExtDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaleBackDetailsExtDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public SaleBackDetailsExtDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "SaleBackDetailsExt";

        #region 事务添加一个SaleBackDetailsExt
        /// <summary>
        /// 添加一个SaleBackDetailsExt
        /// </summary>
        /// <param name="model">SaleBackDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleBackPreDetailsExt model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@ID", SqlDbType.VarChar, 50),
                                new SqlParameter("@CategoryId1", SqlDbType.Int),
                                new SqlParameter("@CategoryId1Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@CategoryId2", SqlDbType.Int),
                                new SqlParameter("@CategoryId2Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@CategoryId3", SqlDbType.Int),
                                new SqlParameter("@CategoryId3Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ShopCategoryId1", SqlDbType.Int),
                                new SqlParameter("@ShopCategoryId1Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ShopCategoryId2", SqlDbType.Int),
                                new SqlParameter("@ShopCategoryId2Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ShopCategoryId3", SqlDbType.Int),
                                new SqlParameter("@ShopCategoryId3Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@BrandId1", SqlDbType.Int),
                                new SqlParameter("@BrandId1Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@BrandId2", SqlDbType.Int),
                                new SqlParameter("@BrandId2Name", SqlDbType.NVarChar, 100),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36)

                                };
            sp[0].Value = model.ID;
            sp[1].Value = model.CategoryId1;
            sp[2].Value = model.CategoryId1Name;
            sp[3].Value = model.CategoryId2;
            sp[4].Value = model.CategoryId2Name;
            sp[5].Value = model.CategoryId3;
            sp[6].Value = model.CategoryId3Name;
            sp[7].Value = model.ShopCategoryId1;
            sp[8].Value = model.ShopCategoryId1Name;
            sp[9].Value = model.ShopCategoryId2;
            sp[10].Value = model.ShopCategoryId2Name;
            sp[11].Value = model.ShopCategoryId3;
            sp[12].Value = model.ShopCategoryId3Name;
            sp[13].Value = model.BrandId1;
            sp[14].Value = model.BrandId1Name;
            sp[15].Value = model.BrandId2;
            sp[16].Value = model.BrandId2Name;
            sp[17].Value = model.ModifyTime;
            sp[18].Value = model.ModifyUserID;
            sp[19].Value = model.ModifyUserName;
            sp[20].Value = model.BackID;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleBackDetailsExt.Save",
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