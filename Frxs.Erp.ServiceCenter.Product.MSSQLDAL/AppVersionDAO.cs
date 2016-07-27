using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frxs.Erp.ServiceCenter.Product.MSSQLDAL
{
    /// <summary>
    /// 数据访问类:AppVersion
    /// </summary>
    public partial class AppVersionDAO : IAppVersionDAO
    {
        public AppVersionDAO()
        { }
        /// <summary>
        /// 获取指定的更新版本
        /// </summary>
        public AppVersionModel GetUpdateModel(int SysType, int AppType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from AppVersion");
            strSql.Append(" where SysType=@SysType and AppType=@AppType order by  ID desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@SysType", SqlDbType.Int,4),
					new SqlParameter("@AppType", SqlDbType.Int,4)};
            parameters[0].Value = SysType;
            parameters[1].Value = AppType;

            DataSet ds = DBHelper.GetInstance().GetDataSet(strSql.ToString(), parameters);
            AppVersionModel model = null;
            if (ds!=null && ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
            }
            ds = null;
            return model;
        }

       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AppVersionModel DataRowToModel(DataRow row)
        {
            AppVersionModel model = new AppVersionModel();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CurCode"] != null && row["CurCode"].ToString() != "")
                {
                    model.CurCode = int.Parse(row["CurCode"].ToString());
                }
                if (row["SysType"] != null && row["SysType"].ToString() != "")
                {
                    model.SysType = int.Parse(row["SysType"].ToString());
                }
                if (row["AppType"] != null && row["AppType"].ToString() != "")
                {
                    model.AppType = int.Parse(row["AppType"].ToString());
                }
                if (row["CurVersion"] != null)
                {
                    model.CurVersion = row["CurVersion"].ToString();
                }
                if (row["DownUrl"] != null)
                {
                    model.DownUrl = row["DownUrl"].ToString();
                }
                if (row["UpdateFlag"] != null && row["UpdateFlag"].ToString() != "")
                {
                    model.UpdateFlag = int.Parse(row["UpdateFlag"].ToString());
                }
                if (row["UpdateRemark"] != null)
                {
                    model.UpdateRemark = row["UpdateRemark"].ToString();
                }
                if (row["ModifyTime"] != null && row["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(row["ModifyTime"].ToString());
                }
                if (row["ModifyUserID"] != null && row["ModifyUserID"].ToString() != "")
                {
                    model.ModifyUserID = int.Parse(row["ModifyUserID"].ToString());
                }
                if (row["ModifyUserName"] != null)
                {
                    model.ModifyUserName = row["ModifyUserName"].ToString();
                }
            }
            return model;
        }
    }
}
