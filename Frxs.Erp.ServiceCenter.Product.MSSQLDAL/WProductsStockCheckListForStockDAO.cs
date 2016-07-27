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
    /// 盘点商品批量导入列表查询 接口实现类
    /// </summary>
    public class WProductsStockCheckListForStockDAO : BaseDAL, IWProductsStockCheckListForStockDAO
    {
        /// <summary>
        /// 读取SQL配置文件节点Name名称
        /// </summary>
        protected override string TableName { get { return "ProductsForStockImportQuery"; } }

        /// <summary>
        /// 
        /// </summary>
        public WProductsStockCheckListParams SearchParams { get; set; }

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
            this.sql = " (" + this.GetSQLScriptByTable("WProductsForStockImportList");

            //构造SQL参数
            this.sqlParametersBuilder = new SqlParamrterBuilder();
            this.sqlParametersBuilder.Add("WID", SearchParams.WID);

            if (SearchParams.SKUs != null && SearchParams.SKUs.Count > 0)
            {
                sql += " AND ( ";
                string tmpSql = string.Empty;

                for (int i = 0; i < SearchParams.SKUs.Count; i++)
                {
                    if (i == 0)
                    {
                        tmpSql += " p.SKU = @Sku ";
                        sqlParametersBuilder.Add("Sku", SearchParams.SKUs[i].Trim());
                    }
                    else
                    {//按照胡总的意见，为了以后更换数据库时性能不打折扣，不采用 In 运算符，而采用 OR 
                        tmpSql += string.Format(" OR p.SKU = @SKU{0} ", i);
                        sqlParametersBuilder.Add(string.Format("SKU{0}", i), SearchParams.SKUs[i].Trim());
                    }
                }

                sql += tmpSql + " ) ";
            }

            sql += ") LIST ";
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = string.Format(" SELECT COUNT(*) FROM {0} ", this.sql);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductForStockImportDAO.GetCount",
                        LogContent = exceptionSql,
                        LogTime = DateTime.Now
                    },
                    ex
                );
                throw;
            }
        }

        /// <summary>
        /// 获取盘点商品详情列表
        /// </summary>
        /// <returns></returns>
        public IList<WProductsStockCheckModel> GetList()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = string.Format(" SELECT * FROM {0} ", this.sql);
                using (IDataReader dataReader = helper.GetIDataReader(_sql, this.sqlParametersBuilder.ToSqlParameters()))
                {
                    return this.ExecuteTolist<WProductsStockCheckModel>(dataReader);
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
                        LogOperation = "Frxs.ServiceCenter.Product.MSSQLDAL.ProductForStockImportDAO.GetList",
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
