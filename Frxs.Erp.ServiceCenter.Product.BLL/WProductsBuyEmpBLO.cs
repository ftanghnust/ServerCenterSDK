using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Product.Model;
using Frxs.Platform.Utility.Pager;
using Frxs.ServiceCenter.Api.Core;
using Frxs.Erp.ServiceCenter.Product.IDAL;

namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    public class WProductsBuyEmpBLO
    {

        public static int SaveWProductsBuyEmp(int wid, int UserId, string UserName, List<int> wProductIds, List<int> BuyEmpIds)
        {
            int result = 0;

            var connection = DALFactory.GetLazyInstance<IWProductsBuyEmpDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            IWProductsBuyEmpDAO dao = DALFactory.GetLazyInstance<IWProductsBuyEmpDAO>();
            try
            {
                //foreach (var wProductId in wProductIds)
                //{
                //    var WProductsBuyEmps = new List<WProductsBuyEmp>();
                //    var SerialNumberIndex = 1;
                //    foreach (var BuyEmpId in BuyEmpIds)
                //    {
                //        var BuyEmp = new WProductsBuyEmp()
                //        {
                //            WProductID = wProductId,
                //            WID = wid,
                //            EmpID = BuyEmpId,
                //            SerialNumber = SerialNumberIndex,
                //            CreateTime = DateTime.Now,
                //            CreateUserID = UserId,
                //            CreateUserName = UserName
                //        };
                //        WProductsBuyEmps.Add(BuyEmp);
                //        SerialNumberIndex += 1;
                //    }
                //    result += WProductsBuyEmpBLO.SaveWProductsBuyEmp(wid, wProductId, WProductsBuyEmps,connection,trans);
                //}

                dao.BatDelWProductsBuyEmp(wid, UserId, UserName, wProductIds, BuyEmpIds, connection, trans);
                dao.SaveWProductsBuyEmp(wid, UserId, UserName, wProductIds, BuyEmpIds, connection, trans);
                result = wProductIds.Count;
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                result = 0;
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        public static int SaveWProductsBuyEmp(int wid, int wProductID, List<WProductsBuyEmp> BuyEmps, IDbConnection connection, IDbTransaction trans)
        {
            DeleteByWProductID(wid,wProductID, connection, trans);
            foreach (var BuyEmp in BuyEmps)
            {
                Save(BuyEmp, connection, trans);
            }
            return 1;
        }

        public static int DeleteByWProductID(int wid, int wProductID, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductsBuyEmpDAO>().DeleteByWProductID(wid,wProductID, conn, tran);
        }

        public static int Save(WProductsBuyEmp wProductsBuyEmp, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductsBuyEmpDAO>().Save(conn, tran, wProductsBuyEmp);
        }
    }
}
