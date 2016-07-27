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
    public class BrandCategorieQueryDAO : BaseDAL, IBrandCategorieQueryDAO
    {
        /// <summary>
        /// 读取SQL配置文件节点Name名称
        /// </summary>
        protected override string TableName
        {
            get
            {
                return "BrandCategories";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BrandCategorieQueryParams SearchParams { get; set; }

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
        private string _sql = string.Empty;

        /// <summary>
        /// 构造查询语句
        /// </summary>
        /// <returns></returns>
        private void BuildWhereSql()
        {
            //构造SQL语句
            this._sql = "WITH LIST AS (" + this.GetSQLScriptByTable("Query");

            //构造SQL参数
            this.sqlParametersBuilder = new SqlParamrterBuilder();

            if (this.SearchParams.BrandIds != null && this.SearchParams.BrandIds.Count > 0)
            {
                _sql += string.Format(" AND BrandId IN({0})", string.Join(",", this.SearchParams.BrandIds.ToArray()));
            }

            if (!string.IsNullOrWhiteSpace(this.SearchParams.BrandName))
            {
                _sql += " AND BrandName LIKE @BrandName ";
                this.sqlParametersBuilder.Add("BrandName", "%" + this.SearchParams.BrandName + "%");
            }

            if (this.SearchParams.HasLogo.HasValue)
            {
                if (this.SearchParams.HasLogo.Value)
                {
                    _sql += " AND Logo<>'' ";
                }
                else
                {
                    _sql += " AND ISNULL(Logo,'')='' ";
                }
            }

            _sql += ")";

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
                string _sql = this._sql + " SELECT COUNT(*) FROM LIST ";
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
        public IList<BrandCategories> GetList()
        {
            DBHelper helper = DBHelper.GetInstance();
            try
            {
                this.BuildWhereSql();
                string _sql = this._sql + string.Format(" SELECT * FROM LIST WHERE RowNum BETWEEN {0} AND {1}", (this.PageIndex - 1) * this.PageSize + 1, this.PageIndex * this.PageSize);
                using (IDataReader dataReader = helper.GetIDataReader(_sql, this.sqlParametersBuilder.ToSqlParameters()))
                {
                    return this.ExecuteTolist<BrandCategories>(dataReader);
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
