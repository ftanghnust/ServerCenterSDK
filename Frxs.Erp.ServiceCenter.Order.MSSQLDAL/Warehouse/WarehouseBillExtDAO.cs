using Frxs.Erp.ServiceCenter.Order.IDAL.Warehouse;
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

namespace Frxs.Erp.ServiceCenter.Order.MSSQLDAL.Warehouse
{
    /// <summary>
    /// 仓库子机构单据信息数据访问类
    /// 为判断仓库子机构是否可以被安全删除，需要查询相关订单信息，特增加此类
    /// </summary>
    public class WarehouseBillExtDAO : BaseDAL, IWarehouseBillExtDAO
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public WarehouseBillExtDAO() { }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        public WarehouseBillExtDAO(string warehouseId)
            : base(warehouseId)
        {
        }


        const string tableName = "WarehouseBillExt";
        /// <summary>
        /// 数据表名
        /// </summary>
        protected override string TableName
        { get { return tableName; } }




        #region 获取仓库子机构单据信息集合
        /// <summary>
        /// 获取仓库子机构单据信息集合
        /// </summary>
        ///<param name="subWID">仓库子机构ID</param>
        /// <returns>数据集合</returns>
        public IList<WarehouseBillExt> GetList(int subWID)
        {
            DBHelper helper = DBHelper.GetInstance(base.ConnectionString);
            IList<WarehouseBillExt> list = new List<WarehouseBillExt>();

            try
            {
                StringBuilder sql = new StringBuilder(SQLConfigBuilder.GetSQLScriptByTable(tableName, "GetList", base.AssemblyName, base.DatabaseName));
                IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "@SubWID", SqlDbType = SqlDbType.Int, Size = 4, Value = subWID });

                using (SqlDataReader sdr = helper.GetIDataReader(sql.ToString(), parameters.ToArray()) as SqlDataReader)
                {
                    list = DataReaderHelper.ExecuteToList<WarehouseBillExt>(sdr);
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
                    LogOperation = "Frxs.Erp.ServiceCenter.Order.MSSQLDAL.WarehouseBillExt.GetList",
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
