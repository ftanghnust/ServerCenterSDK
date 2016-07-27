using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;

namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    public interface IvSaleOrderDAO
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        IList<SaleOrderPre> Query(OrderQuery query, out int total, out decimal totalAmt);

        /// <summary>
        /// 根据主键获取SaleOrderPre对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrder对象</returns>
        SaleOrderPre GetModel(string orderId);

         /// <summary>
        /// 获取装箱打印订单列表
        /// </summary>
        /// <param name="statusStr"></param>
        /// <param name="wId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        IList<vSaleOrder> GetPrintList(string statusStr, int wId, string orderId);

        /// <summary>
        /// 门店排单
        /// </summary>
        /// <param name="searchDate"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        IList<SaleOrderExt> GetShopOrder(string searchDate, int wid);
    }
}
