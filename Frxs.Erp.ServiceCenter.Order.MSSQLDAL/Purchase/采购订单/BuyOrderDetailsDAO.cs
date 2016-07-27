
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
    /// ### BuyOrderDetails数据库访问类
    /// </summary>
    public partial class BuyOrderDetailsDAO : BaseDAL, IBuyOrderDetailsDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BuyOrderDetailsDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public BuyOrderDetailsDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "BuyOrderDetails";

        #region 添加一个BuyOrderDetails
        /// <summary>
        /// 添加一个BuyOrderDetails
        /// </summary>
        /// <param name="model">BuyOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(BuyOrderPreDetails model, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                                new SqlParameter("@ID", SqlDbType.VarChar, 50),
                                new SqlParameter("@WID", SqlDbType.Int),
                                new SqlParameter("@BuyID", SqlDbType.VarChar, 36),
                                new SqlParameter("@ProductId", SqlDbType.Int),
                                new SqlParameter("@SKU", SqlDbType.NVarChar, 50),
                                new SqlParameter("@ProductName", SqlDbType.NVarChar, 200),
                                new SqlParameter("@BarCode", SqlDbType.VarChar, 20),
                                new SqlParameter("@ProductImageUrl200", SqlDbType.VarChar, 200),
                                new SqlParameter("@ProductImageUrl400", SqlDbType.VarChar, 200),
                                new SqlParameter("@BuyUnit", SqlDbType.VarChar, 32),
                                new SqlParameter("@BuyPackingQty", SqlDbType.Decimal),
                                new SqlParameter("@BuyQty", SqlDbType.Decimal, 4),
                                new SqlParameter("@BuyPrice", SqlDbType.Money),
                                new SqlParameter("@Unit", SqlDbType.VarChar,32),
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
            sp[1].Value = model.WID;
            sp[2].Value = model.BuyID;
            sp[3].Value = model.ProductId;
            sp[4].Value = model.SKU;
            sp[5].Value = model.ProductName;
            sp[6].Value = model.BarCode;
            sp[7].Value = model.ProductImageUrl200;
            sp[8].Value = model.ProductImageUrl400;
            sp[9].Value = model.BuyUnit;
            sp[10].Value = model.BuyPackingQty;
            sp[11].Value = model.BuyQty;
            sp[12].Value = model.BuyPrice;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.BuyOrderDetails.Save",
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