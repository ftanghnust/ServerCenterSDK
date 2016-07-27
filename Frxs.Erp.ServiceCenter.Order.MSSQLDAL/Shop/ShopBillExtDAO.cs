using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Log;
using Frxs.Platform.Utility.Pager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL
{
    /// <summary>
    /// 门店单据信息数据访问类  为判断门店是否可以被安全删除，需要查询相关订单信息，特增加此类
    /// </summary>
    public class ShopBillExtDAO : BaseDAL, IShopBillExtDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ShopBillExtDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public ShopBillExtDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "ShopBillExt";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }




        #region 根据仓库ID和门店ID获取ShopBillExt集合
        /// <summary>
        /// 根据仓库ID和门店ID获取ShopBillExt集合
        /// </summary>
        ///<param name="wid">仓库ID</param>
        ///<param name="shopID">门店ID</param>
        /// <returns>数据集合</returns>
        public IList<ShopBillExt> GetList(int wid, int shopID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<ShopBillExt> list = new List<ShopBillExt>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetList", base.AssemblyName, base.DatabaseName));
                IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "@WID", SqlDbType = SqlDbType.Int, Size = 4, Value = wid });
                parameters.Add(new SqlParameter() { ParameterName = "@ShopID", SqlDbType = SqlDbType.Int, Size = 4, Value = shopID });

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), parameters.ToArray()) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<ShopBillExt>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.ShopBillExt.GetList",
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
    }
}
