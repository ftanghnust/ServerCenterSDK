
/*****************************
* Author:叶求
*
* Date:2016-03-09
******************************/

using Frxs.Erp.ServiceCenter.ID.IDAL;
using Frxs.Erp.ServiceCenter.ID.Model;
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

namespace Frxs.Erp.ServiceCenter.ID.MSSQLDAL
{
    public class IDFactoryDAO:BaseDAL,IIDFactoryDAO
    {

             /// <summary>
        /// 获取一个外部显示单据号
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>数据库影响行数</returns>
        public string GetID(IDTypes idType,int wid)
        {
            if(wid<=0)
            {
                throw new Exception(string.Format("wid:{0}输入错误！",idType));
            }
            DBHelper helper = DBHelper.GetInstance();
            string idTypeName="";
            switch(idType)
            {
                case IDTypes.BuyBack:
                    idTypeName="IDService_BuyBack";
                    break;
                case IDTypes.BuyOrder:
                    idTypeName="IDService_BuyOrder";
                    break;
                case IDTypes.CheckStock:
                    idTypeName="IDService_CheckStock";
                    break;
                case IDTypes.CheckStockPlan:
                    idTypeName="IDService_CheckStockPlan";
                    break;
                case IDTypes.FeeID:
                    idTypeName="IDService_FeeID";
                    break;
                case IDTypes.SaleBack:
                    idTypeName="IDService_SaleBack";
                    break;
                case IDTypes.SaleEdit:
                    idTypeName="IDService_SaleEdit";
                    break;
                case IDTypes.SaleOrder:
                    idTypeName="IDService_SaleOrder";
                    break;
                case IDTypes.SaleSettle:
                    idTypeName="IDService_SaleSettle";
                    break;
                 case IDTypes.StockAdj:
                    idTypeName="IDService_StockAdj";
                    break;
                 case IDTypes.BaseInfoID:
                 case IDTypes.ShelfAdjust:
                    idTypeName = "IDService_BaseInfoID";
                    break;
            }
            if(string.IsNullOrEmpty(idTypeName))
            {
                throw new Exception(string.Format("IDTypes:{0}未被定义！",idType));
            }
            int result = 0;
            string sql = "INSERT INTO " + idTypeName + "(WID,CreateTime)values(@WID,@CreateTime);select @@IDENTITY";
            
            SqlParameter[] sp = {
            new SqlParameter("@WID", SqlDbType.Int),
            new SqlParameter("@CreateTime", SqlDbType.DateTime)
            };
            sp[0].Value = wid;
            sp[1].Value = DateTime.Now;

            try
            {
                object o = helper.GetSingle(sql, sp);
                if (o != null)
                {
                    bool isSuccess = int.TryParse(o.ToString(), out result);
                }
                return string.Format("{0:d3}", wid)+string.Format("{0:d9}", result); //(12位ID序号 3位（仓库编码）+9位(序号))
            }
            catch (Exception ex)
            {
                string exceptionSql = ExceptionSqlGettter.GetSqlAndParamter(helper.Sql, helper.ParamArray);
                Logger.GetInstance().DBOperatingLog
                (
                new NormalLog
                {
                    LogSource = helper.DataSource,
                    LogOperation = "Frxs.Erp.ServiceCenter.ID.MSSQLDAL.IDFactoryDAO.GetID",
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