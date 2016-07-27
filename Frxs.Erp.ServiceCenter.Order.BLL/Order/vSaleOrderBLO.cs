using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.IOCFactory;

namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    public class vSaleOrderBLO
    {
        /// <summary>
        /// 查询所有订单
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="total"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static IList<SaleOrderPre> Query(OrderQuery query, out int total,out decimal totalAmt, int wid)
        {
            IvSaleOrderDAO dao = DALFactory.GetLazyInstance<IvSaleOrderDAO>(wid.ToString());
            int hash = dao.GetHashCode();
            return dao.Query(query, out total,out totalAmt);
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static SaleOrderPre GetModel(string orderId, int wid)
        {
            return DALFactory.GetLazyInstance<IvSaleOrderDAO>(wid.ToString()).GetModel(orderId);
        }

        /// <summary>
        /// 获取装箱打印订单列表
        /// </summary>
        /// <param name="statusStr"></param>
        /// <param name="wId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static IList<vSaleOrder> GetPrintList(string statusStr, int wId, string orderId)
        {
            return DALFactory.GetLazyInstance<IvSaleOrderDAO>(wId.ToString()).GetPrintList(statusStr, wId, orderId);
        }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="searchDate"></param>
       /// <param name="wid"></param>
       /// <returns></returns>
        public static  IList<SaleOrderExt> GetShopOrder(string searchDate, int wid)
        {
            return DALFactory.GetLazyInstance<IvSaleOrderDAO>(wid.ToString()).GetShopOrder(searchDate, wid);
        }


       
    }
}
