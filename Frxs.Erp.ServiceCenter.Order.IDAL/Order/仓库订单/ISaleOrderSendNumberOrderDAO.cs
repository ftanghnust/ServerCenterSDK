/*****************************
* Author:周进 
*
* Date:2016-04-26
******************************/
using System;
using System.Collections.Generic;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    public partial interface ISaleOrderSendNumberOrderDAO
    {
        SaleOrderPre GetSearchSaleOrderSend(IDictionary<string, object> conditionDict);

        IList<SaleOrderSendNumberLine> GetSaleOrderSendNumberLineList(string WID);

        IList<SaleOrderSendNumberShop> GetSaleOrderSendNumberShopList(string WID, int LineID);

        int? GetSaleOrderSendNumberLineOrderMax(string WID, int LineID);

        int? GetSaleOrderSendNumberLineOrderMin(string WID, int LineID);

        int? GetSaleOrderSendNumberLinesOrderMax(string WID, int LineID);

        int? GetSaleOrderSendNumberLinesOrderMin(string WID, int LineID);

        int ChangeSaleOrderSendNumberLineOrder(string WID, int LineID, int LineSerialNumber);

        int? GetSaleOrderSendNumberShopOrder(string WID, int LineID, string OrderId);

        int? GetSaleOrderSendNumberShopsOrderMax(string WID, int LineID, string OrderId);

        int? GetSaleOrderSendNumberShopsOrderMin(string WID, int LineID, string OrderId);

        int ChangeSaleOrderSendNumberShopOrder(string WID, int LineID, string OrderId, int ShopSerialNumber);
    }
}
