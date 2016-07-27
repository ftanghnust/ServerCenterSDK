
/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;
using System.Text;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data.SqlClient;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Platform.DBUtility;
using System.Data;
using System.Text.RegularExpressions;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.Utility.Log;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
	/// <summary>
	/// 数据访问类:SysDictDetail
	/// </summary>
    public partial class SysDictDetailDAO : BaseDAL, ISysDictDetailDAO
	{
        public SysDictDetailDAO()
		{}


        /// <summary>
        /// 获取分类数据字典
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        public IList<SysDictDetail> GetModelListByDictCode(string dictCode)
        {
            DBHelper helper = DBHelper.GetInstance();
            IList<SysDictDetail> list = new List<SysDictDetail>();
            string sql = "select ID,DictValue,DictLabel,Remark from SysDictDetail where IsDeleted=0 and DictCode=@DictCode order by SerialNumber asc";           
            SqlParameter[] parameters = {new SqlParameter("@DictCode", SqlDbType.VarChar,32)};
            parameters[0].Value = dictCode;
            DataSet ds = DBHelper.GetInstance().GetDataSet(sql,parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                SysDictDetail model = null;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row != null)
                    {
                        model = new SysDictDetail();
                        if (row["ID"] != null && row["ID"].ToString() != "")
                        {
                            model.ID = int.Parse(row["ID"].ToString());
                        }
                        if (row["DictValue"] != null)
                        {
                            model.DictValue = row["DictValue"].ToString();
                        }
                        if (row["DictLabel"] != null)
                        {
                            model.DictLabel = row["DictLabel"].ToString();
                        }
                        if (row["Remark"] != null)
                        {
                            model.Remark = row["Remark"].ToString();
                        }
                        list.Add(model);
                    }
                }
            }
            ds = null;
            return list;
        }

        protected override string TableName
        {
            get { return "SysDictDetail"; }
        }
    }
}

