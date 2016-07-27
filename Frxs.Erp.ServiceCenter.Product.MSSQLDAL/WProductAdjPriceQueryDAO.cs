/*********************************************************
 * FRXS(ISC) zhangliang4629@163.com 2015/11/9 9:38:13
 * *******************************************************/

using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.DBUtility;
using Frxs.Platform.Utility.Pager;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Frxs.Platform.Utility.Log;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{

    /// <summary>
    /// 
    /// </summary>
    public class WProductAdjPriceQueryDAO : BaseDAL, IWProductAdjPriceQueryDAO
    {
        /// <summary>
        /// 读取SQL配置文件节点Name名称
        /// </summary>
        protected override string TableName
        {
            get
            {
                return "WProductAdjPrice";
            }
        }

        /// <summary>
        /// 查询参数
        /// </summary>
        public WProductAdjPriceQuerySearchParams SearchParams { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页显示
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private SqlParamrterBuilder sqlParametersBuilder = null;
        private string sql = string.Empty;

        /// <summary>
        /// 构造查询语句
        /// </summary>
        /// <returns></returns>
        private void BuildWhereSql()
        {
            //构造SQL语句
            this.sql = "WITH LIST AS (" + this.GetSQLScriptByTable("GetList");

            //构造SQL参数
            this.sqlParametersBuilder = new SqlParamrterBuilder();
            this.sqlParametersBuilder.Add("WID", this.SearchParams.WID);
            this.sqlParametersBuilder.Add("AdjType", this.SearchParams.AdjType);

            if (this.SearchParams.AdjID.HasValue)
            {
                sql += " and wap.AdjID = @AdjID";
                this.sqlParametersBuilder.Add("AdjID", this.SearchParams.AdjID);
            }

            if (this.SearchParams.Status.HasValue)
            {
                sql += " and wap.[Status] = @Status";
                this.sqlParametersBuilder.Add("Status", this.SearchParams.Status);
            }

            if (this.SearchParams.BeginTime1.HasValue)
            {
                sql += " and wap.[BeginTime] >= @BeginTime1";
                this.sqlParametersBuilder.Add("BeginTime1", this.SearchParams.BeginTime1);
            }
            if (this.SearchParams.BeginTime2.HasValue)
            {
                sql += " and wap.[BeginTime] <= @BeginTime2";
                this.sqlParametersBuilder.Add("BeginTime2", this.SearchParams.BeginTime2);
            }

            if (!string.IsNullOrEmpty(this.SearchParams.ProductName) || !string.IsNullOrEmpty(this.SearchParams.SKU) || !string.IsNullOrEmpty(this.SearchParams.BarCode))
            {

                sql = sql + " and exists(select 1 from WProductAdjPriceDetails wapd inner join Products p on wapd.ProductID=p.ProductId inner join WProducts wp on wapd.WProductID=wp.WProductID left join ProductsBarCodes pcode on wapd.ProductID=pcode.ProductId where wapd.AdjID=wap.AdjID ";

                if (!string.IsNullOrWhiteSpace(this.SearchParams.ProductName))
                {
                    sql += " and ( p.ProductName like @ProductName OR wp.ProductName2 like @ProductName)";
                    this.sqlParametersBuilder.Add("ProductName", "%" + this.SearchParams.ProductName + "%");
                }

                if (!string.IsNullOrWhiteSpace(this.SearchParams.SKU))
                {
                    sql += " and p.SKU like @SKU";
                    this.sqlParametersBuilder.Add("SKU", "%" + this.SearchParams.SKU + "%");
                }

                if (!string.IsNullOrWhiteSpace(this.SearchParams.BarCode))
                {
                    sql += " and pcode.BarCode like @BarCode";
                    this.sqlParametersBuilder.Add("BarCode", "%" + this.SearchParams.BarCode + "%");
                }

                sql = sql + ")";
            }

            sql += ")";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = this.sql + " SELECT COUNT(*) FROM LIST ";
                return int.Parse(helper.GetSingle(_sql, this.sqlParametersBuilder.ToSqlParameters()).ToString());
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                    new NormalLog
                    {
                        LogSource = helper.DataSource,
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductQueryDAO.GetCount",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<WProductAdjPrice> GetList()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = this.sql + string.Format(" SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (this.PageIndex - 1) * this.PageSize + 1, this.PageIndex * this.PageSize);
                using (IDataReader dataReader = helper.GetIDataReader(_sql, this.sqlParametersBuilder.ToSqlParameters()))
                {
                    return this.ExecuteTolist<WProductAdjPrice>(dataReader);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductQueryDAO.GetList",
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
