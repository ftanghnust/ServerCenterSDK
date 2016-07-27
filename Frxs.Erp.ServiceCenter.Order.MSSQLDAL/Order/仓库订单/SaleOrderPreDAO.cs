
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
using Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Order;
using System.Linq;
using Frxs.Erp.ServiceCenter.Order.Model.Deliver;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;


namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// ### SaleOrderPre数据库访问类
    /// </summary>
    public partial class SaleOrderPreDAO : BaseDAL, ISaleOrderPreDAO
    {
        public SaleOrderPreDAO(string warehouseId)
            : base(warehouseId)
        {

        }

        const string tableName = "SaleOrderPre";
        #region 成员方法
        #region 根据主键验证SaleOrderPre是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPre是否存在
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>是否存在</returns>
        public bool Exists(SaleOrderPre model)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Exists", base.AssemblyName, base.DatabaseName);
            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.Exists",
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


        #region 添加一个SaleOrderPre
        /// <summary>
        /// 添加一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Save(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Save", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar,100),
new SqlParameter("@CityName", SqlDbType.VarChar,100),
new SqlParameter("@RegionName", SqlDbType.VarChar,100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
new SqlParameter("@StockOutRate", SqlDbType.Money)
};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.OrderDate;
            sp[4].Value = model.OrderType;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.ShopID;
            sp[10].Value = model.XSUserID;
            sp[11].Value = model.ShopType;
            sp[12].Value = model.ShopCode;
            sp[13].Value = model.ShopName;
            sp[14].Value = model.Status;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.ProvinceName;
            sp[19].Value = model.CityName;
            sp[20].Value = model.RegionName;
            sp[21].Value = model.Address;
            sp[22].Value = model.FullAddress;
            sp[23].Value = model.RevLinkMan;
            sp[24].Value = model.RevTelephone;
            sp[25].Value = model.ConfDate;
            sp[26].Value = model.SendDate;
            sp[27].Value = model.LineID;
            sp[28].Value = model.LineName;
            sp[29].Value = model.StationNumber;
            sp[30].Value = model.PickingBeginDate;
            sp[31].Value = model.PickingEndDate;
            sp[32].Value = model.PackingEmpID;
            sp[33].Value = model.PackingEmpName;
            sp[34].Value = model.PackingTime;
            sp[35].Value = model.IsPrinted;
            sp[36].Value = model.PrintDate;
            sp[37].Value = model.PrintUserID;
            sp[38].Value = model.PrintUserName;
            sp[39].Value = model.ShippingBeginDate;
            sp[40].Value = model.ShippingUserID;
            sp[41].Value = model.ShippingUserName;
            sp[42].Value = model.ShippingEndDate;
            sp[43].Value = model.FinishDate;
            sp[44].Value = model.CancelDate;
            sp[45].Value = model.CloseDate;
            sp[46].Value = model.CloseReason;
            sp[47].Value = model.Remark;
            sp[48].Value = model.TotalProductAmt;
            sp[49].Value = model.CouponAmt;
            sp[50].Value = model.TotalAddAmt;
            sp[51].Value = model.PayAmount;
            sp[52].Value = model.TotalPoint;
            sp[53].Value = model.TotalBasePoint;
            sp[54].Value = model.UserShowFlag;
            sp[55].Value = model.ClientType;
            sp[56].Value = model.CreateTime;
            sp[57].Value = model.CreateUserID;
            sp[58].Value = model.CreateUserName;
            sp[59].Value = model.ModifyTime;
            sp[60].Value = model.ModifyUserID;
            sp[61].Value = model.ModifyUserName;
            sp[62].Value = model.OrderId;
            sp[63].Value = model.StockOutRate;

            try
            {
                object o = new object();
                if (conn != null && tran != null)
                {
                    o = helper.ExecNonQuery(conn, tran, sql, sp);
                }
                else
                {
                    o = helper.ExecNonQuery(sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.Save",
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


        #region 更新一个SaleOrderPre
        /// <summary>
        /// 更新一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Edit(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Edit", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@SettleID", SqlDbType.VarChar, 36),
new SqlParameter("@WID", SqlDbType.Int),
new SqlParameter("@SubWID", SqlDbType.Int),
new SqlParameter("@OrderDate", SqlDbType.DateTime),
new SqlParameter("@OrderType", SqlDbType.Int),
new SqlParameter("@WCode", SqlDbType.VarChar, 32),
new SqlParameter("@WName", SqlDbType.NVarChar, 50),
new SqlParameter("@SubWCode", SqlDbType.VarChar, 32),
new SqlParameter("@SubWName", SqlDbType.NVarChar, 50),
new SqlParameter("@ShopID", SqlDbType.Int),
new SqlParameter("@XSUserID", SqlDbType.Int),
new SqlParameter("@ShopType", SqlDbType.Int),
new SqlParameter("@ShopCode", SqlDbType.VarChar, 10),
new SqlParameter("@ShopName", SqlDbType.VarChar, 100),
new SqlParameter("@Status", SqlDbType.Int),
new SqlParameter("@ProvinceID", SqlDbType.Int),
new SqlParameter("@CityID", SqlDbType.Int),
new SqlParameter("@RegionID", SqlDbType.Int),
new SqlParameter("@ProvinceName", SqlDbType.VarChar,100),
new SqlParameter("@CityName", SqlDbType.VarChar,100),
new SqlParameter("@RegionName", SqlDbType.VarChar,100),
new SqlParameter("@Address", SqlDbType.VarChar, 100),
new SqlParameter("@FullAddress", SqlDbType.VarChar, 200),
new SqlParameter("@RevLinkMan", SqlDbType.VarChar, 20),
new SqlParameter("@RevTelephone", SqlDbType.VarChar, 20),
new SqlParameter("@ConfDate", SqlDbType.DateTime),
new SqlParameter("@SendDate", SqlDbType.DateTime),
new SqlParameter("@LineID", SqlDbType.Int),
new SqlParameter("@LineName", SqlDbType.NVarChar, 50),
new SqlParameter("@StationNumber", SqlDbType.Int),
new SqlParameter("@PickingBeginDate", SqlDbType.DateTime),
new SqlParameter("@PickingEndDate", SqlDbType.DateTime),
new SqlParameter("@PackingEmpID", SqlDbType.Int),
new SqlParameter("@PackingEmpName", SqlDbType.VarChar, 32),
new SqlParameter("@PackingTime", SqlDbType.DateTime),
new SqlParameter("@IsPrinted", SqlDbType.Int),
new SqlParameter("@PrintDate", SqlDbType.DateTime),
new SqlParameter("@PrintUserID", SqlDbType.Int),
new SqlParameter("@PrintUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
new SqlParameter("@ShippingUserID", SqlDbType.Int),
new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ShippingEndDate", SqlDbType.DateTime),
new SqlParameter("@FinishDate", SqlDbType.DateTime),
new SqlParameter("@CancelDate", SqlDbType.DateTime),
new SqlParameter("@CloseDate", SqlDbType.DateTime),
new SqlParameter("@CloseReason", SqlDbType.NVarChar, 200),
new SqlParameter("@Remark", SqlDbType.NVarChar, 400),
new SqlParameter("@TotalProductAmt", SqlDbType.Money),
new SqlParameter("@CouponAmt", SqlDbType.Money),
new SqlParameter("@TotalAddAmt", SqlDbType.Money),
new SqlParameter("@PayAmount", SqlDbType.Money),
new SqlParameter("@TotalPoint", SqlDbType.Money),
new SqlParameter("@TotalBasePoint", SqlDbType.Money),
new SqlParameter("@UserShowFlag", SqlDbType.Int),
new SqlParameter("@ClientType", SqlDbType.Int),
new SqlParameter("@CreateTime", SqlDbType.DateTime),
new SqlParameter("@CreateUserID", SqlDbType.Int),
new SqlParameter("@CreateUserName", SqlDbType.VarChar, 32),
new SqlParameter("@ModifyTime", SqlDbType.DateTime),
new SqlParameter("@ModifyUserID", SqlDbType.Int),
new SqlParameter("@ModifyUserName", SqlDbType.VarChar, 32),
new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
new SqlParameter("@StockOutRate", SqlDbType.Money)
};
            sp[0].Value = model.SettleID;
            sp[1].Value = model.WID;
            sp[2].Value = model.SubWID;
            sp[3].Value = model.OrderDate;
            sp[4].Value = model.OrderType;
            sp[5].Value = model.WCode;
            sp[6].Value = model.WName;
            sp[7].Value = model.SubWCode;
            sp[8].Value = model.SubWName;
            sp[9].Value = model.ShopID;
            sp[10].Value = model.XSUserID;
            sp[11].Value = model.ShopType;
            sp[12].Value = model.ShopCode;
            sp[13].Value = model.ShopName;
            sp[14].Value = model.Status;
            sp[15].Value = model.ProvinceID;
            sp[16].Value = model.CityID;
            sp[17].Value = model.RegionID;
            sp[18].Value = model.ProvinceName;
            sp[19].Value = model.CityName;
            sp[20].Value = model.RegionName;
            sp[21].Value = model.Address;
            sp[22].Value = model.FullAddress;
            sp[23].Value = model.RevLinkMan;
            sp[24].Value = model.RevTelephone;
            sp[25].Value = model.ConfDate;
            sp[26].Value = model.SendDate;
            sp[27].Value = model.LineID;
            sp[28].Value = model.LineName;
            sp[29].Value = model.StationNumber;
            sp[30].Value = model.PickingBeginDate;
            sp[31].Value = model.PickingEndDate;
            sp[32].Value = model.PackingEmpID;
            sp[33].Value = model.PackingEmpName;
            sp[34].Value = model.PackingTime;
            sp[35].Value = model.IsPrinted;
            sp[36].Value = model.PrintDate;
            sp[37].Value = model.PrintUserID;
            sp[38].Value = model.PrintUserName;
            sp[39].Value = model.ShippingBeginDate;
            sp[40].Value = model.ShippingUserID;
            sp[41].Value = model.ShippingUserName;
            sp[42].Value = model.ShippingEndDate;
            sp[43].Value = model.FinishDate;
            sp[44].Value = model.CancelDate;
            sp[45].Value = model.CloseDate;
            sp[46].Value = model.CloseReason;
            sp[47].Value = model.Remark;
            sp[48].Value = model.TotalProductAmt;
            sp[49].Value = model.CouponAmt;
            sp[50].Value = model.TotalAddAmt;
            sp[51].Value = model.PayAmount;
            sp[52].Value = model.TotalPoint;
            sp[53].Value = model.TotalBasePoint;
            sp[54].Value = model.UserShowFlag;
            sp[55].Value = model.ClientType;
            sp[56].Value = model.CreateTime;
            sp[57].Value = model.CreateUserID;
            sp[58].Value = model.CreateUserName;
            sp[59].Value = model.ModifyTime;
            sp[60].Value = model.ModifyUserID;
            sp[61].Value = model.ModifyUserName;
            sp[62].Value = model.OrderId;
            sp[63].Value = model.StockOutRate;

            try
            {
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.Edit",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int EditSatusByOrderId(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "EditSatusByOrderId", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@ShippingBeginDate", SqlDbType.DateTime),
                    new SqlParameter("@ShippingUserID", SqlDbType.Int),
                    new SqlParameter("@ShippingUserName", SqlDbType.VarChar, 32),
                    new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
                    new SqlParameter("@ShippingEndDate", SqlDbType.DateTime)
                    };
            sp[0].Value = model.Status;
            sp[1].Value = model.ShippingBeginDate;
            sp[2].Value = model.ShippingUserID;
            sp[3].Value = model.ShippingUserName;
            sp[4].Value = model.OrderId;
            sp[5].Value = model.ShippingEndDate;

            try
            {
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.Edit",
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


        #region 删除一个SaleOrderPre
        /// <summary>
        /// 删除一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public int Delete(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "Delete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = model.OrderId;

            try
            {
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, sp);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.Delete",
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


        #region 根据主键逻辑删除一个SaleOrderPre
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPre
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>数据库影响行数</returns>
        public int LogicDelete(string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "LogicDelete", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
 new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
 };
            sp[0].Value = orderId;

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.LogicDelete",
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


        #region 根据线路获取信息

        /// <summary>
        /// 根据线路获取等待配送门店集合
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public IList<WaitDeliverData> GetWaitDeliverData(string orderId, string empId, string lineIDs, string status)
        {
            StringBuilder where = new StringBuilder();
            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(lineIDs))
            {
                where.AppendFormat("  and LineID IN({0})", lineIDs);
            }

            if (!string.IsNullOrEmpty(orderId))
            {
                where.AppendFormat("  and OrderId = '{0}'", orderId);
            }

            if (!string.IsNullOrEmpty(empId))
            {
                where.AppendFormat("  and p.ShippingUserID ={0} ", empId);
            }

            if (!string.IsNullOrEmpty(status))
            {
                where.AppendFormat("  and p.Status={0} ", status);

                if (status == "6") //排除已配送
                {
                    where.Append(" and (p.ShippingEndDate is null or p.ShippingEndDate ='') ");
                }
            }
            where.Append(" order by p.OrderId asc ");

            IList<WaitDeliverData> list = GetListToWaitDeliverData(where.ToString(), sp);
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<WaitDeliverData>();
            }
        }



        /// <summary>
        /// 获取配送对账单明细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="empId"></param>
        /// <param name="lineIDs"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public IList<SaleDeliverOrderInfo> GetSaleOrderDetailInfo(string searchDate, string empId, string lineIDs)
        {
            StringBuilder where = new StringBuilder();
            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(lineIDs))
            {
                where.AppendFormat("  and LineID IN({0})", lineIDs);
            }

            if (!string.IsNullOrEmpty(searchDate))
            {
                where.AppendFormat("  and CONVERT(varchar(100), PackingTime, 23) = '{0}'", searchDate);
            }

            if (!string.IsNullOrEmpty(empId))
            {
                where.AppendFormat("  and ShippingUserID ={0} ", empId);
            }
            where.Append("  and Status >=6 ");

            where.Append(" order by OrderId desc ");

            IList<SaleDeliverOrderInfo> list = GetListToSaleOrderDetailData(where.ToString(), sp);
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SaleDeliverOrderInfo>();
            }
        }

        /// <summary>
        /// 获取配送对账单汇总信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="empId"></param>
        /// <param name="lineIDs"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public IList<SaleDeliverOrderInfo> GetSaleOrderTotalInfo(string searchMonth, string empId, string lineIDs)
        {
            StringBuilder where = new StringBuilder();
            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(lineIDs))
            {
                where.AppendFormat("  and LineID IN({0})", lineIDs);
            }

            if (!string.IsNullOrEmpty(searchMonth))
            {
                where.AppendFormat("  and CONVERT(varchar(7), PackingTime, 23)  = '{0}'", searchMonth);
            }

            if (!string.IsNullOrEmpty(empId))
            {
                where.AppendFormat("  and ShippingUserID ={0} ", empId);
            }

            where.Append("  and Status >=6 ");

            where.Append(" group by CONVERT(varchar(10), PackingTime, 23) order by  CONVERT(varchar(10), PackingTime, 23) asc ");

            IList<SaleDeliverOrderInfo> list = GetListToSaleOrderTotalData(where.ToString(), sp);
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<SaleDeliverOrderInfo>();
            }
        }


        /// <summary>
        /// 获取正在拣货数量
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="lineIDs"></param>
        /// <returns></returns>
        public IList<PickingData> GetPickingData(string wid, string lineIDs)
        {
            StringBuilder where = new StringBuilder();

            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(lineIDs))
            {
                where.AppendFormat(" and p.Status In (2,3,4) and p.LineID IN({0})", lineIDs);

            }
            IList<PickingData> list = GetListToPickingData(where.ToString(), sp);
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<PickingData>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="orderId"></param>
        /// <param name="shelfAreaID"></param>
        /// <returns></returns>
        public IList<ProductData> GetProductData(string wid, string orderId)
        {
            StringBuilder where = new StringBuilder();

            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(orderId))
            {
                where.AppendFormat(" and predetails.OrderID ='{0}'", orderId);

            }

            IList<ProductData> list = GetListToProductData(where.ToString(), sp);
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<ProductData>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="orderId"></param>
        /// <param name="shelfAreaID"></param>
        /// <returns></returns>
        public IList<ProductDetailExt> GetProductDataExt(string wid, string orderId)
        {
            StringBuilder where = new StringBuilder();

            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(orderId))
            {
                where.AppendFormat(" and a.OrderID ='{0}'", orderId);

            }

            IList<ProductDetailExt> list = GetListToProductDataExt(where.ToString(), sp);
            if (list != null && list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<ProductDetailExt>();
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public DeliverOrderInfo GetDeliverOrderInfo(string orderId, string wid)
        {
            StringBuilder where = new StringBuilder();

            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(orderId))
            {
                where.AppendFormat(" and pre.orderId='{0}' ", orderId);

            }
            DeliverOrderInfo model = GetDeliverOrderInfo(where.ToString(), sp);
            if (model != null)
            {
                return model;
            }
            else
            {
                return new DeliverOrderInfo();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public DeliverOrderInfo GetDeliverOrderInfoExt(string orderId, string wid)
        {
            StringBuilder where = new StringBuilder();

            SqlParameter[] sp = SqlParameterHelper.CreateParameters(null);
            where.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(orderId))
            {
                where.AppendFormat(" and a.orderId='{0}' ", orderId);

            }
            DeliverOrderInfo model = GetDeliverOrderInfoExt(where.ToString(), sp);
            if (model != null)
            {
                return model;
            }
            else
            {
                return new DeliverOrderInfo();
            }
        }
        #endregion


        #region 根据字典获取SaleOrderPre对象
        /// <summary>
        /// 根据字典获取SaleOrderPre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderPre对象</returns>
        public SaleOrderPre GetModel(IDictionary<string, object> conditionDict)
        {
            SaleOrderPre model = null;
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
                IList<SaleOrderPre> list = GetList(where.ToString(), sp);
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

        #region 根据字典获取SaleOrderPre集合
        /// <summary>
        /// 根据字典获取SaleOrderPre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public IList<SaleOrderPre> GetList(IDictionary<string, object> conditionDict)
        {
            IList<SaleOrderPre> list = null;
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


        #region 根据字典获取SaleOrderPre数据集
        /// <summary>
        /// 根据字典获取SaleOrderPre数据集
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetDataSet",
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


        #region 分页获取SaleOrderPre集合
        /// <summary>
        /// 分页获取SaleOrderPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderPre> GetPageList(PageListBySql<SaleOrderPre> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = tableName;
                page.Fields = "OrderId,SettleID,WID,SubWID,OrderDate,OrderType,WCode,WName,SubWCode,SubWName,ShopID,XSUserID,ShopCode,ShopName,Status,ProvinceID,CityID,RegionID,Address,FullAddress,RevLinkMan,RevTelephone,ConfDate,LineID,LineName,StationNumber,PickingBeginDate,PickingEndDate,PackingEmpID,PackingEmpName,PackingTime,IsPrinted,PrintDate,PrintUserID,PrintUserName,ShippingBeginDate,ShippingUserID,ShippingUserName,ShippingEndDate,FinishDate,CancelDate,CloseDate,CloseReason,Remark,TotalProductAmt,CouponAmt,TotalAddAmt,PayAmount,TotalPoint,TotalBasePoint,UserShowFlag,ClientType,CreateTime,CreateUserID,CreateUserName,ModifyTime,ModifyUserID,ModifyUserName,StockOutRate";
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
                    page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderPre>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetPageList",
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
        public int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, IDbConnection conn = null, IDbTransaction tran = null)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            try
            {
                IDbDataParameter[] parameters = null;
                string sql = new FieldUpdater().UpdateField(fieldList, whereConditionList, tableName, ref parameters);
                if (conn != null && tran != null)
                {
                    result = helper.ExecNonQuery(conn, tran, sql, parameters);
                }
                else
                {
                    result = helper.ExecNonQuery(sql, parameters);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.UpdateField",
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
        /// 订单查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public IList<SaleOrderPre> Query(OrderQuery query, out int total)
        {
            string sql = "WITH LIST AS (" + SQLConfigBuilder.GetSQLScriptByTable(tableName, "Query", base.AssemblyName, base.DatabaseName);
            sql = string.Format(sql, query.SortBy);
            StringBuilder sWhere = new StringBuilder(" where 1=1 ");
            SqlParamrterBuilder sp = new SqlParamrterBuilder();

            //sp.Add("Sort", SqlDbType.NVarChar, 100, query.SortBy);
            if (!string.IsNullOrEmpty(query.OrderId))
            {
                sWhere.Append(" And OrderId like @OrderId");
                sp.Add("OrderId", SqlDbType.VarChar, 55, "%" + query.OrderId + "%");
            }
            if (!string.IsNullOrEmpty(query.SettleID))
            {
                sWhere.Append(" And SettleID like @SettleID");
                sp.Add("SettleID", SqlDbType.VarChar, 40, "%" + query.SettleID + "%");
            }
            if (query.OrderDateBegin.HasValue)
            {
                sWhere.Append(" And OrderDate>=@OrderDateBegin");
                sp.Add("OrderDateBegin", SqlDbType.DateTime, query.OrderDateBegin.Value);
            }
            if (query.OrderDateEnd.HasValue)
            {
                sWhere.Append(" And OrderDate<=@OrderDateEnd");
                sp.Add("OrderDateEnd", SqlDbType.DateTime, query.OrderDateEnd.Value);
            }
            if (query.Status.HasValue)
            {
                if (query.Status.Value != OrderStatus.Cancel)
                {
                    sWhere.Append(" And Status=@Status");
                    sp.Add("Status", SqlDbType.Int, 4, (int)query.Status.Value);
                }
                else if (query.Status.Value == OrderStatus.Cancel)
                {
                    sWhere.Append(" And (Status=8 or Status=9)");
                }
                else if (query.Status.Value == OrderStatus.CanEdit)
                {
                    sWhere.Append(" And (Status=2 or Status=3)");
                }
            }
            if (query.ShopId.HasValue)
            {
                sWhere.Append(" And ShopId=@ShopId");
                sp.Add("ShopId", SqlDbType.Int, 4, query.ShopId.Value);
            }
            if (!string.IsNullOrEmpty(query.ShopName))
            {
                sWhere.Append(" And ( ShopName like @ShopName or ShopCode like @ShopName)");
                sp.Add("ShopName", SqlDbType.VarChar, 40, "%" + query.ShopName + "%");
            }
            if (query.WID.HasValue)
            {
                sWhere.Append(" And WID=@WID");
                sp.Add("WID", SqlDbType.Int, 4, query.WID.Value);
            }
            if (query.LineID.HasValue)
            {
                sWhere.Append(" And LineID=@LineID");
                sp.Add("LineID", SqlDbType.Int, 4, query.LineID.Value);
            }
            if (!string.IsNullOrEmpty(query.ShopCode))
            {
                sWhere.Append(" And ShopCode like @ShopCode");
                sp.Add("ShopCode", SqlDbType.VarChar, 40, "%" + query.ShopCode + "%");
            }
            if (query.ShopType.HasValue)
            {
                sWhere.Append(" And ShopType=@ShopType");
                sp.Add("ShopType", SqlDbType.Int, 4, query.ShopType.Value);
            }
            if (query.ConfDateBegin.HasValue)
            {
                sWhere.Append(" And ConfDate>=@ConfDateBegin");
                sp.Add("ConfDateBegin", SqlDbType.DateTime, query.ConfDateBegin.Value);
            }
            if (query.ConfDateEnd.HasValue)
            {
                sWhere.Append(" And ConfDate<=@ConfDateEnd");
                sp.Add("ConfDateEnd", SqlDbType.DateTime, query.ConfDateEnd.Value);
            }
            if (query.ShippingBeginDateBegin.HasValue)
            {
                sWhere.Append(" And ShippingBeginDate>=@ShippingBeginDateBegin");
                sp.Add("ShippingBeginDateBegin", SqlDbType.DateTime, query.ShippingBeginDateBegin.Value);
            }
            if (query.ShippingBeginDateEnd.HasValue)
            {
                sWhere.Append(" And ShippingBeginDate<=@ShippingBeginDateEnd");
                sp.Add("ShippingBeginDateEnd", SqlDbType.DateTime, query.ShippingBeginDateEnd.Value);
            }
            if (query.SendDateBegin.HasValue)
            {
                sWhere.Append(" And SendDate>=@SendDateBegin");
                sp.Add("SendDateBegin", SqlDbType.DateTime, query.SendDateBegin.Value);
            }
            if (query.SendDateEnd.HasValue)
            {
                sWhere.Append(" And SendDate<=@SendDateEnd");
                sp.Add("SendDateEnd", SqlDbType.DateTime, query.SendDateEnd.Value);
            }
            if (query.SubID.HasValue)
            {
                sWhere.Append(" And SubWID=@SubWID");
                sp.Add("SubWID", SqlDbType.Int, query.SubID.Value);
            }
            if (query.IsPrinted.HasValue)
            {
                sWhere.Append(" And IsPrinted=@IsPrinted");
                sp.Add("IsPrinted", SqlDbType.Int, query.IsPrinted.Value);
            }
            if (query.OrderType.HasValue)
            {
                sWhere.Append(" And OrderType=@OrderType");
                sp.Add("OrderType", SqlDbType.Int, query.OrderType.Value);
            }
            if (query.StationNumber.HasValue)
            {
                sWhere.Append(" And StationNumber=@StationNumber");
                sp.Add("StationNumber", SqlDbType.Int, query.StationNumber.Value);
            }
            if (query.ConfDateBegin.HasValue)
            {
                sWhere.Append(" And ConfDate>=@ConfDateBegin");
                sp.Add("ConfDateBegin", SqlDbType.DateTime, query.ConfDateBegin.Value);
            }
            if (query.ConfDateEnd.HasValue)
            {
                sWhere.Append(" And ConfDate<=@ConfDateEnd");
                sp.Add("ConfDateEnd", SqlDbType.DateTime, query.ConfDateEnd.Value);
            }

            if (query.FilterStatus != null && query.FilterStatus.Count > 0)
            {
                int i = 0;
                var tmpStr = "";
                foreach (var status in query.FilterStatus)
                {
                    tmpStr += status + ",";
                    sp.Add("ConfDateEnd" + i.ToString(), SqlDbType.Int, status);
                    i++;
                }
                sWhere.Append(" And Status not in (" + tmpStr.Substring(0, tmpStr.Length - 1) + ") ");
            }

            if (!string.IsNullOrEmpty(query.SKU))
            {
                if (query.SKU.Length < 6)
                {
                    sWhere.Append(@" And OrderId in (
	                                select OrderId from SaleOrderPreDetails where SKU like @SKU
	                                union
	                                select OrderId from SaleOrderDetails where SKU like @SKU
                                )");
                    sp.Add("SKU", SqlDbType.VarChar, 40, "%" + query.SKU + "%");
                }
                else
                {
                    sWhere.Append(@" And OrderId in (
	                                select OrderId from SaleOrderPreDetails where SKU=@SKU
	                                union
	                                select OrderId from SaleOrderDetails where SKU=@SKU
                                )");
                    sp.Add("SKU", SqlDbType.VarChar, 40, query.SKU);
                }
            }

            string sqlCount = "";
            sqlCount += sql + sWhere.ToString() + ") select Count(*) from LIST ";
            total = GetCount(sqlCount, sp.ToSqlParameters());
            if (query.PageIndex > 1 && query.PageSize >= total)
            {
                query.PageIndex = 1;
            }
            sql += sWhere.ToString() + string.Format(") SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (query.PageIndex - 1) * query.PageSize + 1, query.PageIndex * query.PageSize);

            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            using (IDataReader dataReader = helper.GetIDataReader(sql, sp.ToSqlParameters()))
            {
                return this.ExecuteTolist<SaleOrderPre>(dataReader);
            }
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        private int GetCount(string sql, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            var result = helper.GetSingle(sql, sp);
            if (result != null)
            {
                return int.Parse(result.ToString());
            }
            else
            {
                return 0;
            }

        }


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
            #region 构建参数-龙武
            if (conditionDict.ContainsKey("OrderId"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "OrderId",
                        FieldValue = conditionDict["OrderId"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("ShopCode"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ShopCode",
                        FieldValue = conditionDict["ShopCode"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("ShopName"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ShopName",
                        FieldValue = conditionDict["ShopName"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.NVarChar),
                        FieldLength = 50
                    }
                });
            }
            if (conditionDict.ContainsKey("ShopType"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ShopType",
                        FieldValue = conditionDict["ShopType"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                    }
                });
            }
            if (conditionDict.ContainsKey("ShelfAreaID"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "ShelfAreaID",
                        FieldValue = conditionDict["ShelfAreaID"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                    }
                });
            }
            if (conditionDict.ContainsKey("OrderType"))
            {
                whereConditionList.Add(
                new WhereCondition
                {
                    AttachSymbol = Attach.And,
                    CompareSymbol = Compare.Equals,
                    FieldObj = new Field
                    {
                        FieldName = "OrderType",
                        FieldValue = conditionDict["OrderType"],
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                    }
                });
            }
            #endregion
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
                return "OrderId";
            }
            else
            {
                return order;
            }
        }
        #endregion


        #region 根据条件获取SaleOrderPre列表
        /// <summary>
        /// 根据条件获取SaleOrderPre列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPre> GetList(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderPre> list = new List<SaleOrderPre>();
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
                        list = DataReaderHelper.ExecuteToList<SaleOrderPre>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }



        /// <summary>
        /// 根据条件获取SaleDeliverOrderInfo列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleDeliverOrderInfo> GetListToSaleOrderTotalData(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleDeliverOrderInfo> list = new List<SaleDeliverOrderInfo>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToSaleDeliverOrderTotalData", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new SaleDeliverOrderInfo
                        {
                            PackingTime = DataTypeHelper.GetString(sdr["PackingTime"], null),
                            TotalOrderCount = DataTypeHelper.GetInt(sdr["TotalOrderCount"]),
                            TotalBasePoint = DataTypeHelper.GetDecimal(sdr["TotalBasePoint"]),
                            TotalPoint = DataTypeHelper.GetDecimal(sdr["TotalPoint"]),
                            TotalProductAmt = DataTypeHelper.GetDecimal(sdr["TotalProductAmt"])
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetListToSaleOrderTotalData",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }


        /// <summary>
        /// 根据条件获取SaleDeliverOrderInfo列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<SaleDeliverOrderInfo> GetListToSaleOrderDetailData(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleDeliverOrderInfo> list = new List<SaleDeliverOrderInfo>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToSaleDeliverOrderData", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new SaleDeliverOrderInfo
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            TotalBasePoint = DataTypeHelper.GetDecimal(sdr["TotalBasePoint"]),
                            TotalPoint = DataTypeHelper.GetDecimal(sdr["TotalPoint"]),
                            TotalProductAmt = DataTypeHelper.GetDecimal(sdr["TotalProductAmt"])
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetListToSaleOrderDetailData",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }

        /// <summary>
        /// 根据条件获取WaitDeliverData列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<WaitDeliverData> GetListToWaitDeliverData(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WaitDeliverData> list = new List<WaitDeliverData>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToWaitDeliverData", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new WaitDeliverData
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            OrderType = DataTypeHelper.GetInt(sdr["OrderType"]),
                            WID = DataTypeHelper.GetInt(sdr["WID"]),
                            XSUserID = DataTypeHelper.GetInt(sdr["XSUserID"]),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"]),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"]),
                            RevLinkMan = DataTypeHelper.GetString(sdr["RevLinkMan"]),
                            RevTelephone = DataTypeHelper.GetString(sdr["RevTelephone"]),
                            StationNumber = DataTypeHelper.GetString(sdr["StationNumber"], null),
                            SettleTypeName = DataTypeHelper.GetString(sdr["SettleTypeName"], null),
                            ShippingBeginDate = DataTypeHelper.GetDateTimeNull(sdr["ShippingBeginDate"], null),
                            ShippingEndDate = DataTypeHelper.GetDateTimeNull(sdr["ShippingEndDate"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetListToWaitDeliverData",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }

        /// <summary>
        /// 根据条件获取DeliverOrderInfo列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        DeliverOrderInfo GetDeliverOrderInfo(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            DeliverOrderInfo orderinfo = new DeliverOrderInfo();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToDeliverOrderInfo", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        orderinfo = new DeliverOrderInfo
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            OrderDate = DataTypeHelper.GetDateTime(sdr["OrderDate"]),
                            StationNumber = DataTypeHelper.GetInt(sdr["StationNumber"]),
                            SaleQty = DataTypeHelper.GetDecimal(sdr["SaleQty"]),
                            PayAmount = DataTypeHelper.GetDecimal(sdr["TotalProductAmt"]),
                            TotalPoint = DataTypeHelper.GetDecimal(sdr["TotalPoint"]),
                            Package1Qty = DataTypeHelper.GetInt(sdr["Package1Qty"]),
                            Package2Qty = DataTypeHelper.GetInt(sdr["Package2Qty"]),
                            Package3Qty = DataTypeHelper.GetInt(sdr["Package3Qty"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null)
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetDeliverOrderInfo",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return orderinfo;
        }

        /// <summary>
        /// 根据条件获取DeliverOrderInfo列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        DeliverOrderInfo GetDeliverOrderInfoExt(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            DeliverOrderInfo orderinfo = new DeliverOrderInfo();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToDeliverOrderInfoExt", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        orderinfo = new DeliverOrderInfo
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            OrderDate = DataTypeHelper.GetDateTime(sdr["OrderDate"]),
                            StationNumber = DataTypeHelper.GetInt(sdr["StationNumber"]),
                            SaleQty = DataTypeHelper.GetDecimal(sdr["SaleQty"], 0),
                            PayAmount = DataTypeHelper.GetDecimal(sdr["PayAmount"], 0),
                            TotalPoint = DataTypeHelper.GetDecimal(sdr["TotalPoint"], 0),
                            Package1Qty = DataTypeHelper.GetInt(sdr["Package1Qty"]),
                            Package2Qty = DataTypeHelper.GetInt(sdr["Package2Qty"]),
                            Package3Qty = DataTypeHelper.GetInt(sdr["Package3Qty"]),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            PackingEmpName = DataTypeHelper.GetString(sdr["PackingEmpName"], null),
                            PackingEmpID = DataTypeHelper.GetIntNull(sdr["PackingEmpID"]),
                            PackingTime = DataTypeHelper.GetDateTimeNull(sdr["PackingTime"]),

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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetDeliverOrderInfo",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return orderinfo;
        }

        /// <summary>
        /// 根据条件获取ProductData列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<ProductData> GetListToProductData(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<ProductData> list = new List<ProductData>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToProductData", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                bool isWrite = true;
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {

                        ProductDetail detail = new ProductDetail
                           {
                               ProductId = DataTypeHelper.GetString(sdr["ProductId"], null),
                               ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                               SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                               BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                               SaleQty = DataTypeHelper.GetDecimal(sdr["SaleQty"]),
                               Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                               ShelfAreaID = DataTypeHelper.GetString(sdr["ShelfAreaID"], null),
                               ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null),
                               ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                               CheckTime = DataTypeHelper.GetDateTime(sdr["CheckTime"]),
                               SaleUnit = DataTypeHelper.GetString(sdr["SaleUnit"], null),
                               PickUserId = DataTypeHelper.GetInt(sdr["PickUserID"], 0),
                               PickUserName = DataTypeHelper.GetString(sdr["PickUserName"], null),
                               ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null)
                           };

                        foreach (ProductData data in list)
                        {
                            if (data.ShelfAreaType == DataTypeHelper.GetString(sdr["ShelfAreaName"], null))
                            {
                                data.ProdcutDetailList.Add(detail);
                                isWrite = false;
                                break;
                            }
                        }

                        if (isWrite)
                        {

                            ProductData newData = new ProductData();
                            newData.ProdcutDetailList = new List<ProductDetail>();
                            newData.ShelfAreaType = DataTypeHelper.GetString(sdr["ShelfAreaName"], null);
                            newData.AreaCheckTime = DataTypeHelper.GetDateTimeNull(sdr["AreaCheckTime"], null);
                            newData.PickEndTime = DataTypeHelper.GetDateTimeNull(sdr["PickEndTime"], null);
                            newData.ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null);
                            newData.ProdcutDetailList.Add(detail);
                            list.Add(newData);

                        }
                        isWrite = true;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetListToProductData",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }
        /// <summary>
        /// 根据条件获取ProductData列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<ProductDetailExt> GetListToProductDataExt(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<ProductDetailExt> list = new List<ProductDetailExt>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToProductDataExt", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        ProductDetailExt detail = new ProductDetailExt
                        {
                            ProductId = DataTypeHelper.GetString(sdr["ProductId"], null),
                            ProductName = DataTypeHelper.GetString(sdr["ProductName"], null),
                            SKU = DataTypeHelper.GetString(sdr["SKU"], null),
                            BarCode = DataTypeHelper.GetString(sdr["BarCode"], null),
                            SaleQty = DataTypeHelper.GetDecimal(sdr["SaleQty"], 0),
                            Remark = DataTypeHelper.GetString(sdr["Remark"], null),
                            ShelfAreaID = DataTypeHelper.GetString(sdr["ShelfAreaID"], null),
                            ShelfAreaCode = DataTypeHelper.GetString(sdr["ShelfAreaCode"], null),
                            ShelfAreaName = DataTypeHelper.GetString(sdr["ShelfAreaName"], null),
                            PickUserName = DataTypeHelper.GetString(sdr["PickUserName"], null),
                            PreQty = DataTypeHelper.GetDecimal(sdr["PreQty"], 0),
                            SalePrice = DataTypeHelper.GetDecimal(sdr["SalePrice"], 0),
                            SaleUnit = DataTypeHelper.GetString(sdr["SaleUnit"], null),
                            ShelfCode = DataTypeHelper.GetString(sdr["ShelfCode"], null),
                            ShelfID = DataTypeHelper.GetInt(sdr["ShelfID"]),
                            ShopAddPerc = DataTypeHelper.GetDecimal(sdr["ShopAddPerc"], 0),
                            ShopCategoryId1Name = DataTypeHelper.GetString(sdr["ShopCategoryId1Name"], null),
                            ShopCategoryId2Name = DataTypeHelper.GetString(sdr["ShopCategoryId2Name"], null),
                            ShopCategoryId3Name = DataTypeHelper.GetString(sdr["ShopCategoryId3Name"], null),
                            SubBasePoint = DataTypeHelper.GetDecimal(sdr["SubBasePoint"], 0),
                            SubPoint = DataTypeHelper.GetDecimal(sdr["SubPoint"], 0),
                            SubAmt = DataTypeHelper.GetDecimal(sdr["SubAmt"], 0),
                            SubAddAmt = DataTypeHelper.GetDecimal(sdr["SubAddAmt"], 0)
                        };

                        list.Add(detail);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetListToProductData",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return list;
        }

        /// <summary>
        /// 根据条件获取PickingData列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sp">参数数组</param>
        /// <returns>数据集合</returns>
        IList<PickingData> GetListToPickingData(string where, SqlParameter[] sp)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<PickingData> list = new List<PickingData>();
            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadToPickingData", base.AssemblyName, base.DatabaseName));

                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append(where);
                }
                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new PickingData
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"])
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetListToPickingData",
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

    /// <summary>
    /// ### SaleOrderPre数据库访问类 
    /// 龙武
    /// </summary>
    public partial class SaleOrderPreDAO : BaseDAL, ISaleOrderPreDAO
    {
        /// <summary>
        /// 获取待拣货数量
        /// </summary>
        /// <param name="shelfAreaID">货区编号</param>
        /// <returns></returns>
        public int? GetWaitPickingNum(int shelfAreaID)
        {
            string connectionString = base.ConnectionString;
            DBHelper helper = DBHelper.GetInstance(connectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetWaitPickingNum", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[]{
                    new SqlParameter("@ShelfAreaID",SqlDbType.Int)
                };
                sParam[0].Value = shelfAreaID;
                object o = helper.GetSingle(sql, sParam);
                if (o == null)
                {
                    return null;
                }
                else
                {
                    return Utils.StrToInt(o, 0);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPreDAO.GetWaitPickingNum",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 获取待拣货订单列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        public PageListBySql<SaleOrderPreWaitPickingList> GetPageWaitPickList(PageListBySql<SaleOrderPreWaitPickingList> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "(SELECT * FROM ( " + SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetWaitPickingList", base.AssemblyName, base.DatabaseName) + " ) AS TEMPTAB) AS TEMPTAB";
                page.Fields = "ShelfAreaID,OrderId,OrderType,ShopID,XSUserID,ShopType,ShopCode,ShopName,Status,SettleID,WID,OrderDate,WCode,WName,Address,ProvinceID,CityID,RegionID,FullAddress,RevLinkMan,RevTelephone,LineID,StationNumber,Remark,Sendnumber,lineSerialNumber,ShopSerialNumber";
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
                    if (sdr.HasRows)
                    {
                        page.ItemList = DataReaderHelper.ExecuteToList<SaleOrderPreWaitPickingList>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetPageAtPickList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return page;
        }

        /// <summary>
        /// 获取订单详情(APP)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="shelfAreaID">货区编号</param>
        public SaleOrderPreWaitPickingList GetWaitPickDetails(string orderId, int shelfAreaID)
        {
            //订单库
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);

                SqlParameter[] sParam = new SqlParameter[]{
                            new SqlParameter("@OrderId",SqlDbType.NVarChar)
                        };
                sParam[0].Value = orderId;
                SaleOrderPreWaitPickingList orderModel = null;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sParam) as SqlDataReader)
                {
                    if (sdr.HasRows)
                    {
                        orderModel = DataReaderHelper.ExecuteToEntity<SaleOrderPreWaitPickingList>(sdr);
                    }
                }
                if (orderModel == null)
                {
                    return null;
                }
                string sqlProducts = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "GetProductListByOrderIDAndAreaID", base.AssemblyName, base.DatabaseName);

                SqlParameter[] dParam = new SqlParameter[]{
                        new SqlParameter("@OrderID",SqlDbType.NVarChar),
                        new SqlParameter("@ShelfAreaID",SqlDbType.Int)
                    };
                dParam[0].Value = orderId;
                dParam[1].Value = shelfAreaID;
                using (SqlDataReader sdrProduct = helper.GetIDataReader(sqlProducts, dParam) as SqlDataReader)
                {
                    if (sdrProduct.HasRows)
                    {
                        orderModel.ProductData = DataReaderHelper.ExecuteToList<SaleOrderPreDetailsPick>(sdrProduct);
                    }
                }
                return orderModel;
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetPageWaitPickList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 获取订单详情(后台)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="shelfAreaID">货区编号</param>
        public SaleOrderPreWaitPickingList GetWaitPickDetails(string orderId)
        {
            //订单库
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);

                SqlParameter[] sParam = new SqlParameter[]{
                            new SqlParameter("@OrderId",SqlDbType.NVarChar)
                        };
                sParam[0].Value = orderId;
                SaleOrderPreWaitPickingList orderModel = null;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sParam) as SqlDataReader)
                {
                    if (sdr.HasRows)
                    {
                        orderModel = DataReaderHelper.ExecuteToEntity<SaleOrderPreWaitPickingList>(sdr);
                    }
                }
                string sqlProducts = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "GetProductListByOrderID", base.AssemblyName, base.DatabaseName);

                SqlParameter[] dParam = new SqlParameter[]{
                        new SqlParameter("@OrderID",SqlDbType.NVarChar)
                    };
                dParam[0].Value = orderId;
                using (SqlDataReader sdrProduct = helper.GetIDataReader(sqlProducts, dParam) as SqlDataReader)
                {
                    if (sdrProduct.HasRows)
                    {
                        orderModel.ProductData = DataReaderHelper.ExecuteToList<SaleOrderPreDetailsPick>(sdrProduct);
                    }
                }
                return orderModel;
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetPageWaitPickList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 分页获取正在拣货订单列表
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public PageListBySql<SaleOrderPre7ShelfArea> GetPageAtPickList(PageListBySql<SaleOrderPre7ShelfArea> page, IDictionary<string, object> conditionDict)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int totalRecords = 0;
            int totalPages = 1;
            try
            {
                page.TableName = "(SELECT * FROM ( " + SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetAtPickingOrderList", base.AssemblyName, base.DatabaseName) + " ) AS TEMPTAB) AS TEMPTAB";
                page.Fields = "OrderId,ShopCode,ShopName,ShopID,ShopType,ShelfAreaID,OrderDate,OrderType,WCode,WName,SubWCode,SubWName,ProvinceID,CityID,RegionID,ProvinceName,CityName,RegionName,LineID";
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
                        page.ItemList.Add(new SaleOrderPre7ShelfArea
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"], null),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"]),
                            ShopCode = DataTypeHelper.GetString(sdr["ShopCode"], null),
                            ShopName = DataTypeHelper.GetString(sdr["ShopName"], null),
                            ShopType = DataTypeHelper.GetInt(sdr["ShopType"]),
                            ShelfAreaID = DataTypeHelper.GetInt(sdr["ShelfAreaID"]),
                            OrderDate = DataTypeHelper.GetDateTime(sdr["OrderDate"]),
                            OrderType = DataTypeHelper.GetInt(sdr["OrderType"]),
                            WCode = DataTypeHelper.GetString(sdr["WCode"], null),
                            WName = DataTypeHelper.GetString(sdr["WName"], null),
                            SubWCode = DataTypeHelper.GetString(sdr["SubWCode"], null),
                            SubWName = DataTypeHelper.GetString(sdr["SubWName"], null),
                            ProvinceID = DataTypeHelper.GetInt(sdr["ProvinceID"]),
                            CityID = DataTypeHelper.GetInt(sdr["CityID"]),
                            RegionID = DataTypeHelper.GetInt(sdr["RegionID"]),
                            ProvinceName = DataTypeHelper.GetString(sdr["ProvinceName"], null),
                            CityName = DataTypeHelper.GetString(sdr["CityName"], null),
                            RegionName = DataTypeHelper.GetString(sdr["RegionName"], null),
                            LineID = DataTypeHelper.GetInt(sdr["LineID"])
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetPageAtPickList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return page;
        }

        /// <summary>
        /// 开始拣货更新订单数据
        /// </summary>
        /// <param name="status"></param>
        /// <param name="stationNumber"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public int UpdateSaleOrderPick(string orderID, int status, int stationNumber, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateSaleOrderPick", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[] { 
                    new SqlParameter("@Status",status),
                    new SqlParameter("@StationNumber",stationNumber),
                    new SqlParameter("@OrderID",orderID)
                };
                return helper.ExecNonQuery(conn, tran, sql, sParam);
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.UpdateSaleOrderPick",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }

        /// <summary>
        /// 提交拣货
        /// </summary>
        /// <param name="orderDetails">拣货数据</param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public ReturnSubmitInfo SubmitPick(SubmitPickOrder orderDetails, string warehouseId, List<PickUserIdAndUserName> userInfo, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                ///订单拣货状态
                int pickStatus = -1;
                ///订单货区拣货状态
                int shelfAreaPickStatus = -1;
                #region 第一步：查询订单是否是拣货状态
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetOrderStatusByOrderID", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[]{
                    new SqlParameter("@orderId",SqlDbType.NVarChar),
                    new SqlParameter("@shelfAreaID",SqlDbType.Int)
                };
                sParam[0].Value = orderDetails.OrderId;
                sParam[1].Value = orderDetails.ProductsData[0].ShelfAreaID;//默认取第一个货区的货区编号
                DataSet ds = helper.GetDataSet(conn, tran, sql, sParam);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    pickStatus = Utils.StrToInt(ds.Tables[0].Rows[0]["Status"], 0);
                    shelfAreaPickStatus = Utils.StrToInt(ds.Tables[0].Rows[0]["ShelfAreaPickStatus"], 0);
                }
                else
                {
                    return new ReturnSubmitInfo() { Flag = 1, IsResult = false, Info = string.Format("找不到该订单; 订单ID:{0}", orderDetails.OrderId) };
                }
                if (pickStatus != (int)OrderStatus.Picking)
                {
                    return new ReturnSubmitInfo() { Flag = 2, IsResult = false, Info = "该订单其他人已经完成了拣货，提交并未完成" };
                }
                /*
                 * 如果提交商品的货区个数大于1，那么提交端肯定为后台，APP提交只能提交一个货区的商品
                 * 如果后台提交的货区只有一个，那么提交的货区如果已拣货完成，那么该订单肯定已经拣货完成
                 * 后台提交拣货不区分货区，所以不判断货区是否已经拣货完成
                 */

                //根据提交的商品数据获取货区的个数
                var shelfAreaIDList = orderDetails.ProductsData.ToList().Select(x => { return x.ShelfAreaID; }).GroupBy(x => new { x.Value });
                //这里判断提交的货区小于等于1：原因在于进入到此判断一定是APP提交的拣货。如果是后台提交的，那么只有一个货区的订单，在订单状态判断的时候已经Return。
                if (shelfAreaIDList.Count() <= 1)
                {
                    if (shelfAreaPickStatus <= 0)
                    {
                        //此返回的提示只适用APP提交拣货。
                        return new ReturnSubmitInfo() { Flag = 3, IsResult = false, Info = "该订单当前货区其他人已经完成了拣货，提交并未完成" };
                    }
                }
                #endregion
                List<PickOrderProducts> listProduct = orderDetails.ProductsData as List<PickOrderProducts>;
                if (listProduct == null || listProduct.Count == 0)
                {
                    return new ReturnSubmitInfo() { Flag = 4, IsResult = false, Info = string.Format("提交拣货的数据不能为空。订单ID:{0}", orderDetails.OrderId) };
                }
                string sqlPickDetails = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "UpdatePickDetails", base.AssemblyName, base.DatabaseName);
                string sqlOrderPreDetails = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetails", "UpdateOrderpreDetails", base.AssemblyName, base.DatabaseName);

                //购买商品实际总数量
                double sumQty = 0D;
                //购买商品预定总数量
                double sumPreQty = 0D;
                Dictionary<string, DataSet> dic = new Dictionary<string, DataSet>();
                listProduct.ForEach(x =>
                {
                    #region 获取商品货区的拣货状态
                    string sqlGetWaitPickNum = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "GetWaitPickNumByAreaIDOrderID", base.AssemblyName, base.DatabaseName);
                    SqlParameter[] sParamGetWaitPickNum = new SqlParameter[] { 
                            new SqlParameter("@OrderId",orderDetails.OrderId),
                            new SqlParameter("@ShelfAreaID",x.ShelfAreaID)
                        };
                    ///根据货区编号和订单编号获取货区名和未拣货完成个数
                    DataSet dsGetNumAndName = helper.GetDataSet(conn, tran, sqlGetWaitPickNum, sParamGetWaitPickNum);
                    if (!dic.Keys.Contains(orderDetails.OrderId + x.ShelfAreaID))
                    {
                        dic.Add(orderDetails.OrderId + x.ShelfAreaID, dsGetNumAndName);
                    }
                    #endregion

                    int userId = orderDetails.PickUserID;
                    string userName = orderDetails.PickUserName;
                    if (userInfo != null && userInfo.Count > 0)
                    {
                        var user = userInfo.Where(y => y.ProductID == x.ProductID).ToList();
                        if (user != null && user.Count > 0)
                        {
                            userId = user[0].EmpID;
                            userName = user[0].EmpName;
                        }
                    }
                    sumQty += x.PickQty >= x.PreQty ? 0.00 : Convert.ToDouble(x.PreQty - x.PickQty);
                    sumPreQty += Convert.ToDouble(x.PreQty);

                    #region 第二步：更新销售订单商品拣货明细__待处理单据
                    SqlParameter[] sParamPickDetails = new SqlParameter[]{
                        new SqlParameter("@SaleQty", x.PickQty),//购买数量为预定数量
                        new SqlParameter("@SaleUnit", x.SaleUnit),//购买单位为更换后的单位
                        new SqlParameter("@SalePackingQty", x.SalePackingQty),//
                        new SqlParameter("@PickQty", x.PickQty),//拣货数量为实际购买数量
                        new SqlParameter("@PickUserID", userId),//
                        new SqlParameter("@PickUserName", userName),
                        new SqlParameter("@OrderId", orderDetails.OrderId),
                        new SqlParameter("@ProductID", x.ProductID)
                    };

                    int resultPickDetails = helper.ExecNonQuery(conn, tran, sqlPickDetails, sParamPickDetails);
                    #endregion
                    #region 第三步：更新销售订单商品明细_待处理单据
                    SqlParameter[] sParamOrderPreDetails = new SqlParameter[]{
                        new SqlParameter("@PreQty", x.PreQty),//购买数量/预定数量
                        new SqlParameter("@SaleUnit", x.SaleUnit),//购买单位/更换后的单位
                        new SqlParameter("@SalePackingQty", x.SalePackingQty),//配送单位包装数
                        new SqlParameter("@SaleQty", x.PickQty),//拣货数量为实际购买数量
                        new SqlParameter("@UnitQty", x.PickQty * x.SalePackingQty),//单位包装数*实际购买数量
                        new SqlParameter("@IsStockOut", x.PickQty <= x.PreQty ? 0 : 1),
                        new SqlParameter("@OrderId", orderDetails.OrderId),
                        new SqlParameter("@ProductID", x.ProductID)
                    };
                    int resultOrderPreDetails = helper.ExecNonQuery(conn, tran, sqlOrderPreDetails, sParamOrderPreDetails);
                    int t = resultOrderPreDetails;

                    #endregion
                });
                #region 更新订单表的总门店积分-TotalPoint
                string UpdateOrderSalePrePointByOrderID = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateOrderSalePrePointByOrderID", base.AssemblyName, base.DatabaseName);
                SqlParameter[] UpdateOrderSalePrePointByOrderIDParams = new SqlParameter[] { 
                    new SqlParameter("@OrderId",orderDetails.OrderId)//当前拣货人员登录后只能拣当前货区的商品，故取第一个订单货区
                };
                int SetTotalPoint = helper.ExecNonQuery(conn, tran, UpdateOrderSalePrePointByOrderID, UpdateOrderSalePrePointByOrderIDParams);
                #endregion
                //缺货率
                double stockOutRate = 0D;
                if (sumPreQty != 0D)
                {
                    stockOutRate = sumQty / sumPreQty;
                }
                //当前货区是否全部拣货完成
                bool isCurrentPicked = true;
                //所有货区是否全部拣货完成
                bool isAllPicked = true;
                #region 第四步：更改待拣货区表数据
                //当前货区全部拣货完成,更改待拣货区表拣货结束时间
                string sqlUpdatePickTime = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreShelfArea", "UpdatePickTime", base.AssemblyName, base.DatabaseName);
                foreach (var item in listProduct)
                {
                    if (dic.Count > 0 && dic.Keys.Contains(orderDetails.OrderId + item.ShelfAreaID))
                    {
                        //当前提交拣货操作，代码表达含义：
                        //1:有在该订单下当前货区未完成拣货，才更新待拣货区表；
                        //2:所以，当查询语句（GetWaitPickNumByAreaIDOrderID）获取拣货详细表PickTime为NULL，代码中判断大于0则表示还有未拣货的商品。
                        //3:当订单未完成拣货，此时提交拣货才添加订单跟踪记录。
                        if (dic[orderDetails.OrderId + item.ShelfAreaID] != null && dic[orderDetails.OrderId + item.ShelfAreaID].Tables.Count > 0 && dic[orderDetails.OrderId + item.ShelfAreaID].Tables[0].Rows.Count > 0)
                        {
                            isCurrentPicked = Utils.StrToInt(dic[orderDetails.OrderId + item.ShelfAreaID].Tables[0].Rows[0]["num"], 0) > 0;
                        }
                        else
                        {
                            isCurrentPicked = false;
                        }
                        if (isCurrentPicked)
                        {
                            SaleOrderTrack trackModel = new SaleOrderTrack();
                            trackModel.ID = warehouseId + Guid.NewGuid().ToString();
                            trackModel.OrderID = orderDetails.OrderId;
                            trackModel.WID = Utils.StrToInt(warehouseId, 0);
                            trackModel.Remark = "您的订单[" + dic[orderDetails.OrderId + item.ShelfAreaID].Tables[0].Rows[0]["ShelfAreaName"] + "]拣货完成";
                            trackModel.IsDisplayUser = 0;
                            trackModel.OrderStatus = 4;
                            trackModel.OrderStatusName = "拣货完成";
                            trackModel.CreateTime = DateTime.Now;
                            trackModel.CreateUserID = orderDetails.PickUserID;
                            trackModel.CreateUserName = orderDetails.PickUserName;
                            new SaleOrderTrackDAO().Save(conn, tran, trackModel);
                            SqlParameter[] sParamUpdatePickTime = new SqlParameter[]{
                                new SqlParameter("@OrderID",orderDetails.OrderId),
                                new SqlParameter("@ShelfAreaID",item.ShelfAreaID)
                            };
                            int resultUpdatePickTime = helper.ExecNonQuery(conn, tran, sqlUpdatePickTime, sParamUpdatePickTime);
                            dic.Remove(orderDetails.OrderId + item.ShelfAreaID);
                        }
                    }
                }

                #endregion
                #region 获取此订单下所有货区是否全部完成拣货
                string sqlGetAllPickNum = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "GetAllPickNumByOrderId", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParamGetAllPickNum = new SqlParameter[] { 
                    new SqlParameter("@OrderId",orderDetails.OrderId)//当前拣货人员登录后只能拣当前货区的商品，故取第一个订单货区
                };
                isAllPicked = Utils.StrToInt(helper.GetSingle(conn, tran, sqlGetAllPickNum, sParamGetAllPickNum), 0) > 0;
                #endregion
                #region 第五步：更改订单表状态和结束拣货时间/缺货率
                if (!isAllPicked)
                {
                    SaleOrderTrack trackModel = new SaleOrderTrack();
                    trackModel.ID = warehouseId + Guid.NewGuid().ToString();
                    trackModel.OrderID = orderDetails.OrderId;
                    trackModel.WID = Utils.StrToInt(warehouseId, 0);
                    trackModel.Remark = "您的订单拣货完成";
                    trackModel.IsDisplayUser = 1;
                    trackModel.OrderStatus = 4;
                    trackModel.OrderStatusName = "拣货完成";
                    trackModel.CreateTime = DateTime.Now;
                    trackModel.CreateUserID = orderDetails.PickUserID;
                    trackModel.CreateUserName = orderDetails.PickUserName;
                    new SaleOrderTrackDAO().Save(conn, tran, trackModel);
                    //所有货区全部拣货完成
                    string sqlUpdateOrderStatus = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateStatusByOrderId", base.AssemblyName, base.DatabaseName);
                    SqlParameter[] sParamUpdateOrderStatus = new SqlParameter[] { 
                        new SqlParameter("@OrderId",orderDetails.OrderId)
                    };
                    int resultUpdateOrderStatus = helper.ExecNonQuery(conn, tran, sqlUpdateOrderStatus, sParamUpdateOrderStatus);
                }
                #endregion
                return new ReturnSubmitInfo() { Flag = 0, IsResult = true, Info = "提交成功" };
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.SubmitPick",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }


        /// <summary>
        /// 提交对货
        /// </summary>
        /// <param name="shelfAreaId">货区编号</param>
        /// <param name="checkedUserId">拣货人编号</param>
        /// <param name="checkedUserName">贱货人名称</param>
        /// <param name="orderId">订单编号</param>
        /// <param name="goodsInfo">商品信息</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns></returns>
        public string SubmitCheckedGoods(int shelfAreaId, int checkedUserId, string checkedUserName, string orderId, List<CheckedGoodsNumInfo> goodsInfo, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                if (shelfAreaId > 0)
                {
                    #region 前提 判断此订单对应的货区是否已对货完成
                    string sqlGetCheckTime = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreShelfArea", "GetCheckTimeByOrderIDAndAreaID", base.AssemblyName, base.DatabaseName);
                    SqlParameter[] sParamGetCheckTime = new SqlParameter[] { 
                        new SqlParameter("@OrderID",SqlDbType.VarChar),
                        new SqlParameter("@ShelfAreaID",SqlDbType.Int)
                    };
                    sParamGetCheckTime[0].Value = orderId;
                    sParamGetCheckTime[1].Value = shelfAreaId;
                    //获取当前订单编号对应货区的对货时间
                    object checkTimeResult = helper.GetSingle(conn, tran, sqlGetCheckTime, sParamGetCheckTime);
                    if (checkTimeResult != null)
                    {
                        return (string.Format("该订单对应的货区已完成对货；订单编号：{0}，货区编号：{1}", orderId, shelfAreaId));
                    }
                    #endregion
                    #region 第一步：更改 销售订单待拣货区表-SaleOrderPreShelfArea
                    string sqlUpdateShelfAreaCheckInfo = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreShelfArea", "UpdateCheckedInfoByAreaId", base.AssemblyName, base.DatabaseName);
                    SqlParameter[] sParamUpdateShelfAreaCheckInfo = new SqlParameter[] { 
                        new SqlParameter("@OrderID",SqlDbType.VarChar),
                        new SqlParameter("@ShelfAreaID",SqlDbType.Int),
                        new SqlParameter("@CheckUserID",SqlDbType.Int),
                        new SqlParameter("@CheckUserName",SqlDbType.VarChar)
                    };
                    sParamUpdateShelfAreaCheckInfo[0].Value = orderId;
                    sParamUpdateShelfAreaCheckInfo[1].Value = shelfAreaId;
                    sParamUpdateShelfAreaCheckInfo[2].Value = checkedUserId;
                    sParamUpdateShelfAreaCheckInfo[3].Value = checkedUserName;
                    int updateShelfAreaCheckInfoResult = helper.ExecNonQuery(conn, tran, sqlUpdateShelfAreaCheckInfo, sParamUpdateShelfAreaCheckInfo);
                    #endregion
                    #region 第二步：更改 销售订单商品拣货明细表-SaleOrderPreDetailsPick
                    string sqlUpdateDetailsPickCheckInfo = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "UpdateDetailsPickCheckInfoByAreaID", base.AssemblyName, base.DatabaseName);
                    if (goodsInfo.Count > 0)
                    {
                        foreach (var item in goodsInfo)
                        {
                            SqlParameter[] sParamDetailsPickUpdateCheckInfo = new SqlParameter[] { 
                                new SqlParameter("@OrderID",SqlDbType.VarChar),
                                new SqlParameter("@ShelfAreaID",SqlDbType.Int),
                                new SqlParameter("@CheckUserID",SqlDbType.Int),
                                new SqlParameter("@CheckUserName",SqlDbType.VarChar),
                                new SqlParameter("@CheckNum",SqlDbType.Decimal),
                                new SqlParameter("@IsCheckRight",SqlDbType.Int),
                                new SqlParameter("@ProductID",SqlDbType.Int)
                            };
                            sParamDetailsPickUpdateCheckInfo[0].Value = orderId;
                            sParamDetailsPickUpdateCheckInfo[1].Value = shelfAreaId;
                            sParamDetailsPickUpdateCheckInfo[2].Value = checkedUserId;
                            sParamDetailsPickUpdateCheckInfo[3].Value = checkedUserName;
                            sParamDetailsPickUpdateCheckInfo[4].Value = item.Number;
                            sParamDetailsPickUpdateCheckInfo[5].Value = item.IsCheckRight;
                            sParamDetailsPickUpdateCheckInfo[6].Value = item.ProductId;
                            int updateDetailsPickResult = helper.ExecNonQuery(conn, tran, sqlUpdateDetailsPickCheckInfo, sParamDetailsPickUpdateCheckInfo);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 第一步：更改 销售订单待拣货区表-SaleOrderPreShelfArea
                    string sqlUpdateShelfAreaCheckInfo = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreShelfArea", "UpdateCheckedInfo", base.AssemblyName, base.DatabaseName);
                    SqlParameter[] sParamUpdateShelfAreaCheckInfo = new SqlParameter[] { 
                        new SqlParameter("@OrderID",SqlDbType.VarChar),
                        new SqlParameter("@CheckUserID",SqlDbType.Int),
                        new SqlParameter("@CheckUserName",SqlDbType.VarChar)
                    };
                    sParamUpdateShelfAreaCheckInfo[0].Value = orderId;
                    sParamUpdateShelfAreaCheckInfo[1].Value = checkedUserId;
                    sParamUpdateShelfAreaCheckInfo[2].Value = checkedUserName;
                    int updateShelfAreaCheckInfoResult = helper.ExecNonQuery(conn, tran, sqlUpdateShelfAreaCheckInfo, sParamUpdateShelfAreaCheckInfo);
                    #endregion
                    #region 第二步：更改 销售订单商品拣货明细表-SaleOrderPreDetailsPick
                    string sqlUpdateDetailsPickCheckInfo = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "UpdateDetailsPickCheckInfo", base.AssemblyName, base.DatabaseName);
                    if (goodsInfo.Count > 0)
                    {
                        foreach (var item in goodsInfo)
                        {
                            SqlParameter[] sParamDetailsPickUpdateCheckInfo = new SqlParameter[] { 
                                new SqlParameter("@OrderID",SqlDbType.VarChar),
                                new SqlParameter("@CheckUserID",SqlDbType.Int),
                                new SqlParameter("@CheckUserName",SqlDbType.VarChar),
                                new SqlParameter("@CheckNum",SqlDbType.Decimal),
                                new SqlParameter("@IsCheckRight",SqlDbType.Int),
                                new SqlParameter("@ProductID",SqlDbType.Int)
                            };
                            sParamDetailsPickUpdateCheckInfo[0].Value = orderId;
                            sParamDetailsPickUpdateCheckInfo[1].Value = checkedUserId;
                            sParamDetailsPickUpdateCheckInfo[2].Value = checkedUserName;
                            sParamDetailsPickUpdateCheckInfo[3].Value = item.Number;
                            sParamDetailsPickUpdateCheckInfo[4].Value = item.IsCheckRight;
                            sParamDetailsPickUpdateCheckInfo[5].Value = item.ProductId;
                            int updateDetailsPickResult = helper.ExecNonQuery(conn, tran, sqlUpdateDetailsPickCheckInfo, sParamDetailsPickUpdateCheckInfo);
                        }
                    }
                    #endregion
                }
                #region 第三步：更改 销售订单商品明细表-SaleOrderPreDetails
                string sqlUpdateDetailsCheckInfo = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetails", "UpdateCheckDetails", base.AssemblyName, base.DatabaseName);
                if (goodsInfo.Count > 0)
                {
                    foreach (var item in goodsInfo)
                    {
                        SqlParameter[] sParamDetails = new SqlParameter[] { 
                            new SqlParameter("@SaleQty",SqlDbType.Decimal),
                            new SqlParameter("@OrderId",SqlDbType.VarChar),
                            new SqlParameter("@ProductID",SqlDbType.Int)
                        };
                        sParamDetails[0].Value = item.Number;
                        sParamDetails[1].Value = orderId;
                        sParamDetails[2].Value = item.ProductId;
                        int updateDetailsResult = helper.ExecNonQuery(conn, tran, sqlUpdateDetailsCheckInfo, sParamDetails);
                    }
                }
                #endregion
                #region 第四步：更改 销售订单表-SaleOrderPre
                string sqlUpdateOrderAmt = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateCheckGoodsAmtByOrderId", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParamOrderOfCheckGoods = new SqlParameter[] { 
                    new SqlParameter("@OrderId",SqlDbType.VarChar)
                };
                sParamOrderOfCheckGoods[0].Value = orderId;
                int updateOrderResult = helper.ExecNonQuery(conn, tran, sqlUpdateOrderAmt, sParamOrderOfCheckGoods);
                #endregion
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取装箱订单列表
        /// </summary>
        /// <param name="WID">仓库编号</param>
        /// <returns></returns>
        public IList<SaleOrderPre> GetPackingList(string WID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetPackingList", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParam = new SqlParameter[]{
                    new SqlParameter("@WID",WID)
                };
                using (IDataReader sdr = helper.GetIDataReader(sql, sParam))
                {
                    IList<SaleOrderPre> list = DataReaderHelper.ExecuteToList<SaleOrderPre>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetPackingList",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }

        }


        /// <summary>
        /// 开始拣货操作更新库存数量
        /// </summary>
        /// <param name="stockModel">商品编号和对应库存数</param>
        /// <param name="orderId">订单编号</param>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns></returns>
        public bool EditEnQty(IList<ProductUserQty> stockModel, string orderId, string shelfAreaId, IDbConnection conn, IDbTransaction tran)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                stockModel.ToList().ForEach(x =>
                {
                    int orderPickResult = 0; //判断是否该货区有商品
                    if (string.IsNullOrWhiteSpace(shelfAreaId))
                    {
                        #region 第一步 更新销售订单拣货明细表 SaleOrderPreDetailsPick
                        string sqlUpdateOrderPickQty = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "UpdateDetailsQty", base.AssemblyName, base.DatabaseName);
                        SqlParameter[] sParamOrderPick = new SqlParameter[] { 
                        new SqlParameter("@OrderId",orderId),
                        new SqlParameter("@ProductID",x.ProductId),
                        new SqlParameter("@EnQty",x.ProductUserNum)
                    };
                        orderPickResult = helper.ExecNonQuery(conn, tran, sqlUpdateOrderPickQty, sParamOrderPick);
                        #endregion
                    }
                    else
                    {
                        #region 第一步 更新销售订单拣货明细表 SaleOrderPreDetailsPick
                        string sqlUpdateOrderPickQty = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetailsPick", "UpdateDetailsByAreaIdQty", base.AssemblyName, base.DatabaseName);
                        SqlParameter[] sParamOrderPick = new SqlParameter[] { 
                            new SqlParameter("@OrderId",orderId),
                            new SqlParameter("@ProductID",x.ProductId),
                            new SqlParameter("@EnQty",x.ProductUserNum),
                            new SqlParameter("@ShelfAreaId",shelfAreaId)
                        };
                        orderPickResult = helper.ExecNonQuery(conn, tran, sqlUpdateOrderPickQty, sParamOrderPick);
                        #endregion
                    }
                    #region 第二步 更新销售订单明细表 SaleOrderPreDetails
                    if (orderPickResult > 0)
                    {
                        string sqlUpdateDetailsQty = SQLConfigBuilder.GetSQLScriptByTable("SaleOrderPreDetails", "UpdateCheckDetailsQty", base.AssemblyName, base.DatabaseName);
                        SqlParameter[] sParamOrderDetails = new SqlParameter[] { 
                            new SqlParameter("@OrderId",orderId),
                            new SqlParameter("@ProductID",x.ProductId),
                            new SqlParameter("@EnQty",x.ProductUserNum)
                        };
                        int orderDetailsResult = helper.ExecNonQuery(conn, tran, sqlUpdateDetailsQty, sParamOrderDetails);
                    }
                    #endregion
                });
                #region 第三步 更新销售订单表 SaleOrderPre
                string sqlUpdateOrderQty = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateCheckGoodsAmtByOrderId", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sParamOrder = new SqlParameter[] { 
                    new SqlParameter("@OrderId",orderId)
                };
                int orderResult = helper.ExecNonQuery(conn, tran, sqlUpdateOrderQty, sParamOrder);
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }


        }


        #region 根据主键获取SaleOrderPre对象(事物)
        /// <summary>
        /// 根据主键获取SaleOrderPre对象(事物)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        public SaleOrderPre GetModel(IDbConnection conn, IDbTransaction tran, string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderPre model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
                };
                sp[0].Value = orderId;
                DataSet ds = helper.GetDataSet(conn, tran, sql, sp);
                model = Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SaleOrderPre>(ds.Tables[0])[0];


            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetModel",
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
        #region 根据主键获取SaleOrderPre对象(事物)
        /// <summary>
        /// 根据主键获取SaleOrderPre对象(事物)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        public SaleOrderPre GetModel(IDbConnection conn, IDbTransaction tran, string orderId, string shelfAreaID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderPre model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                sql += " AND sopsa.ShelfAreaID=@ShelfAreaID ";
                SqlParameter[] sp = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
                    new SqlParameter("@ShelfAreaID",SqlDbType.Int)
                };
                sp[0].Value = orderId;
                sp[1].Value = shelfAreaID;
                DataSet ds = helper.GetDataSet(conn, tran, sql, sp);
                model = Frxs.Platform.Utility.Map.DataTableConverter.ConvertDataTableToList<SaleOrderPre>(ds.Tables[0])[0];


            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetModel",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
            return model;
        }

        /// <summary>
        /// 获取拣货时间
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="shelfAreaID"></param>
        /// <returns></returns>
        public PickTimeModel GetPickTimeByOrderIdAndAreaID(string orderId, string shelfAreaID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            PickTimeModel model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetPickTimeByOrderIdAndAreaID", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar, 50),
                    new SqlParameter("@ShelfAreaID",SqlDbType.Int)
                };
                sp[0].Value = orderId;
                sp[1].Value = shelfAreaID;
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<PickTimeModel>(sdr);
                    return model;
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetPickTimeByOrderIdAndAreaID",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }

        }

        #endregion
        #region 根据主键获取SaleOrderPre对象(事物)
        /// <summary>
        /// 根据主键获取SaleOrderPre对象(事物)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        public SaleOrderPre GetModel(string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            SaleOrderPre model = null;
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetModelById", base.AssemblyName, base.DatabaseName);
                SqlParameter[] sp = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar, 50)
                };
                sp[0].Value = orderId;

                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    model = DataReaderHelper.ExecuteToEntity<SaleOrderPre>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.GetModel",
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
    }




    public partial class SaleOrderPreDAO : BaseDAL, ISaleOrderPreDAO
    {

        #region ISaleOrderPreDAO 成员

        /// <summary>
        /// 修改订单线路
        /// </summary>
        /// <param name="model">订单模型，包含orderId,lineId,lineName即可</param>
        /// <returns></returns>
        public int UpdateLine(SaleOrderPre model, BaseUserModel user)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int result = 0;
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "UpdateLine", base.AssemblyName, base.DatabaseName);

            SqlParamrterBuilder sp = new SqlParamrterBuilder();
            sp.Add("LineId", SqlDbType.Int, 4, model.LineID);
            sp.Add("LineName", SqlDbType.NVarChar, model.LineName);
            sp.Add("OrderId", SqlDbType.VarChar, model.OrderId);
            sp.Add("ModifyUserID", SqlDbType.Int, user.UserId);
            sp.Add("ModifyUserName", SqlDbType.NVarChar, user.UserName);
            sp.Add("ModifyTime", SqlDbType.DateTime, DateTime.Now);
            try
            {
                result = helper.ExecNonQuery(sql, sp.ToSqlParameters());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderPre.UpdateLine",
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
        /// 根据订单号集合获取订单信息集合
        /// </summary>
        /// <param name="orderIds">订单号集合</param>
        /// <returns>订单信息集合</returns>
        public IList<SaleOrderPre> GetList(IList<string> orderIds)
        {
            IList<SaleOrderPre> list = new List<SaleOrderPre>();
            if (orderIds != null && orderIds.Count > 0)
            {
                string where = string.Empty;
                SqlParamrterBuilder sp = new SqlParamrterBuilder();
                StringBuilder sb = new StringBuilder();
                int i = 1;
                foreach (var id in orderIds)
                {
                    sb.Append(string.Format(" @OrderId{0} ,", i));
                    sp.Add(string.Format("OrderId{0}", i), id);
                    i++;
                }
                where = " And OrderId in (" + sb.ToString(0, sb.Length - 1) + " ) ";
                list = GetList(where, sp.ToSqlParameters());
            }
            return list;
        }
    }
}