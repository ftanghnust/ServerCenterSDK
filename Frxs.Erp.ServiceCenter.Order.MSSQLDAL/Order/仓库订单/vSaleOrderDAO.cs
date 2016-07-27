using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    public partial class vSaleOrderDAO : BaseDAL, IvSaleOrderDAO
    {
        const string tableName = "vSaleOrder";
        #region IvSaleOrderDAO 成员

        public vSaleOrderDAO(string warehouseId)
            : base(warehouseId)
        {

        }

        public IList<Model.SaleOrderPre> Query(Model.OrderQuery query, out int total,out decimal totalAmt)
        {
            string sql = "WITH LIST AS (" + SQLConfigBuilder.GetSQLScriptByTable(tableName, "Query", base.AssemblyName, base.DatabaseName);
            StringBuilder sWhere = new StringBuilder(" where 1=1 ");
            SqlParamrterBuilder sp = new SqlParamrterBuilder();

            sql = string.Format(sql, query.SortBy);
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
                if (query.Status.Value != OrderStatus.Cancel && query.Status.Value != OrderStatus.CanEdit)
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
                    sWhere.Append(" And (Status=2 or Status=1)");
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
            if(query.FilterStatus!=null && query.FilterStatus.Count>0)
            {
                int i = 0;
                var tmpStr = "";
                foreach (var status in query.FilterStatus)
                {
                    tmpStr += status + ",";
                    sp.Add("ConfDateEnd"+i.ToString(), SqlDbType.Int, status);
                    i++;
                }
                sWhere.Append(" And Status not in (" + tmpStr.Substring(0,tmpStr.Length-1)+") ");
            }
            if(!string.IsNullOrEmpty(query.SKU))
            {
                if(query.SKU.Length<6)
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
                    sp.Add("SKU", SqlDbType.VarChar, 40,  query.SKU );
                }
            }
            
            string sqlCount = "";
            sqlCount += sql + sWhere.ToString() + ") select Count(*) as total ,SUM(PayAmount) as totalAmt from LIST ";
            totalAmt = 0;
            total = GetCount(sqlCount, sp.ToSqlParameters(), ref totalAmt);
            if(query.PageIndex>1 && query.PageSize>=total)
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
        private int GetCount(string sql, SqlParameter[] sp,ref decimal totalAmt)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            int count = 0;
            using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
            {
                while (sdr.Read())
                {

                    totalAmt = DataTypeHelper.GetDecimal(sdr["totalAmt"]);
                    count = DataTypeHelper.GetInt(sdr["total"]);
                }
            }
            return count;
        }



        #region 根据主键获取SaleOrder对象
        /// <summary>
        /// 根据主键获取SaleOrderPre对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrder对象</returns>
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.vSaleOrderDAO.GetModel",
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


        #region 用于门店排单

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="searchDate"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public IList<SaleOrderExt> GetShopOrder(string searchDate, int wid)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<SaleOrderExt> list = new List<SaleOrderExt>();
            string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "ReadShopOrder", base.AssemblyName, base.DatabaseName);

            SqlParameter[] sp = {
                 new SqlParameter("@SendDate", SqlDbType.VarChar, 50),
                 new SqlParameter("@WID", SqlDbType.VarChar, 50)
                 };
            sp[0].Value = searchDate;
            sp[1].Value = wid;

            try
            {
                using (SqlDataReader sdr = helper.GetIDataReader(sql, sp) as SqlDataReader)
                {
                    while (sdr.Read())
                    {
                        list.Add(new SaleOrderExt
                        {
                            OrderId = DataTypeHelper.GetString(sdr["OrderId"]),
                            ShopID = DataTypeHelper.GetInt(sdr["ShopID"])

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
                    LogOperation = "Frxs.Erp.ServiceCenter.PROMOTION.MSSQLDAL.SaleOrderShop.GetShopOrder",
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
    /// 龙武
    /// </summary>
    public partial class vSaleOrderDAO : BaseDAL, IvSaleOrderDAO
    {
        /// <summary>
        /// 获取装箱打印订单列表
        /// </summary>
        /// <param name="statusStr"></param>
        /// <param name="wId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public IList<vSaleOrder> GetPrintList(string statusStr, int wId, string orderId)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            try
            {
                string sql = SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetPrintList", base.AssemblyName, base.DatabaseName);
                sql += " AND Status in(" + statusStr + ") AND WID=" + wId + " AND ORDERID='" + orderId + "'";
                using (SqlDataReader sdr = helper.GetIDataReader(sql, null) as SqlDataReader)
                {
                    IList<vSaleOrder> list = DataReaderHelper.ExecuteToList<vSaleOrder>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.SaleOrderDetailsPick.Edit",
                    LogContent = exceptionSql,
                    LogTime = DateTime.Now
                },
                ex
                );
                throw;
            }
        }
    }
}
