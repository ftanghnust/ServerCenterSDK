
/*****************************
* Author:TangFan
*
* Date:2016-03-10
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
    /// ### BuyBackDetails数据库访问类
    /// </summary>
    public partial class BuyBackDetailsDAO : BaseDAL, IBuyBackDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyBackDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyBackDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }

        const string tableName = "BuyBackDetails";

        #region 添加一个BuyBackDetails
        /// <summary>
        /// 添加一个BuyBackDetails
        /// </summary>
        /// <param name="model">BuyBackDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(BuyBackPreDetails model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@ID", SqlDbType.VarChar, 50),
                                new SqlParameter("@BackID", SqlDbType.VarChar, 36),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@ProductId", SqlDbType.Int),
                                new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
                                new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
                                new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
                                new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
                                new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
                                new SqlParameter("@BackUnit", SqlDbType.VarChar, 32),
                                new SqlParameter("@BackPackingQty", SqlDbType.Decimal),
                                new SqlParameter("@BackQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@BackPrice", SqlDbType.Money),
                                new SqlParameter("@Unit", SqlDbType.VarChar, 32),
                                new SqlParameter("@UnitQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@UnitPrice", SqlDbType.Money),
                                new SqlParameter("@SubAmt", SqlDbType.Money),
                                new SqlParameter("@Remark", SqlDbType.NVarChar, 200),
                                new SqlParameter("@SerialNumber", SqlDbType.Int),
                                new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                                new SqlParameter("@ModifyUserID", SqlDbType.Int),
                                new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
                                new SqlParameter("@SalePrice", SqlDbType.Money)

                                };
            sp[0].Value = model.ID;
            sp[1].Value = model.BackID;
            sp[2].Value = model.WID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.BackUnit;
            sp[10].Value = model.BackPackingQty;
            sp[11].Value = model.BackQty;
            sp[12].Value = model.BackPrice;
            sp[13].Value = model.Unit;
            sp[14].Value = model.UnitQty;
            sp[15].Value = model.UnitPrice;
            sp[16].Value = model.SubAmt;
            sp[17].Value = model.Remark;
            sp[18].Value = model.SerialNumber;
            sp[19].Value = model.ModifyTime;
            sp[20].Value = model.ModifyUserID;
            sp[21].Value = model.ModifyUserName;
            sp[22].Value = model.SalePrice;

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
                    LogOperation = "Frxs.ServiceCenter.Order.MSSQLDAL.BuyBackDetails.Save",
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