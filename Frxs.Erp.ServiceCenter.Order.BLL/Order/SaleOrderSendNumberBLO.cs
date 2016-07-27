/*****************************
* Author:周进
*
* Date:2016-04-26
******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;
using System.Reflection;

namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    public class SaleOrderSendNumberBLO
    {
        public static SaleOrderPre GetSaleOrderSendNumberSearchOrder(int Wid, string ShopCode, string OrderId)
        {
            var condtion = new Dictionary<string, object>();
            condtion.Add("WID", Wid);
            if (!String.IsNullOrEmpty(ShopCode))
            {
                condtion.Add("ShopCode", ShopCode);
            }
            if (!String.IsNullOrEmpty(OrderId))
            {
                condtion.Add("OrderId", OrderId);
            }
            return DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSearchSaleOrderSend(condtion);
        }

        public static IList<SaleOrderSendNumberLine> GetSaleOrderSendNumberLineList(int Wid)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberLineList(Wid.ToString());
            foreach (var line in list)
            {
                var serviceCenter = WorkContext.CreateProductSdkClient();
                var resp = serviceCenter.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWarehouseLineGetRequest()
                {
                    LineID = line.LineID
                });
                if (resp != null && resp.Flag == 0)
                {
                    var obj = resp.Data;
                    if (obj != null)
                    {
                        line.LineCode = obj.LineCode;
                        line.LineName = obj.LineName;
                    }
                }
            }
            return list;
        }

        public static IList<SaleOrderSendNumberShop> GetSaleOrderSendNumberOrderShopList(int Wid, int LineID)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberShopList(Wid.ToString(), LineID);
            return list;
        }

        public static int? GetSaleOrderSendNumberLineOrderMax(int Wid, int LineID)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberLineOrderMax(Wid.ToString(), LineID);
            return list;
        }

        public static int? GetSaleOrderSendNumberLineOrderMin(int Wid, int LineID)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberLineOrderMin(Wid.ToString(), LineID);
            return list;
        }

        public static int? GetSaleOrderSendNumberLinesOrderMax(int Wid, int LineID)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberLinesOrderMax(Wid.ToString(), LineID);
            return list;
        }

        public static int? GetSaleOrderSendNumberLinesOrderMin(int Wid, int LineID)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberLinesOrderMin(Wid.ToString(), LineID);
            return list;
        }

        /// <summary>
        /// 改变一个仓库下 预销售单 线路的排序
        /// 如果是上移和下移。将进行替换操作
        /// 如果是置顶和置底。只改变一条记录(置顶是读取线路下门店排序的最小值-1)
        /// </summary>
        /// <param name="Wid"></param>
        /// <param name="LineID"></param>
        /// <param name="changeType"></param>
        /// <returns></returns>
        public static int ChangeSaleOrderSendNumberLineOrder(int Wid, int LineID, int changeType)
        {
            var lineSerialNumber = 0;
            int changecount = 0;
            switch (changeType)
            {
                case 1: //上移
                    {
                        int prevLineSerialNumber = 0;
                        var saleOrderSendNumberLinelist = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberLineList(Wid.ToString());

                        if (saleOrderSendNumberLinelist == null || saleOrderSendNumberLinelist.Count == 0)
                        {
                            return -1;
                        }
                        //当前线路数据,读取的上移排序字段和其替换
                        SaleOrderSendNumberLine currentSaleLineSend = saleOrderSendNumberLinelist.FirstOrDefault(i => i.LineID == LineID);
                        if (currentSaleLineSend == null)
                        {
                            return -1;
                        }
                        lineSerialNumber = currentSaleLineSend.LineSerialNumber;
                        SaleOrderSendNumberLine prevSaleLineSend = saleOrderSendNumberLinelist.OrderByDescending(i => i.LineSerialNumber).FirstOrDefault(i => i.LineSerialNumber < lineSerialNumber);
                        if (prevSaleLineSend == null)
                        {
                            return -1;
                        }
                        prevLineSerialNumber = prevSaleLineSend.LineSerialNumber;
                        //读取上移的数据 
                        var prevSaleLineSendList = saleOrderSendNumberLinelist.Where(i => i.LineSerialNumber == prevLineSerialNumber);
                        foreach (var item in prevSaleLineSendList)
                        {
                            changecount = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberLineOrder(Wid.ToString(), item.LineID, lineSerialNumber);
                        }
                        //上移数据
                        changecount += DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberLineOrder(Wid.ToString(), LineID, prevLineSerialNumber);
                        return changecount;

                    }
                case 2: //下移
                    {
                        int nextLineSerialNumber = 0;
                        var saleOrderSendNumberLinelist = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberLineList(Wid.ToString());

                        if (saleOrderSendNumberLinelist == null || saleOrderSendNumberLinelist.Count == 0)
                        {
                            return -1;
                        }

                        //当前线路数据,读取的上移排序字段和其替换
                        SaleOrderSendNumberLine currentSaleLineSend = saleOrderSendNumberLinelist.FirstOrDefault(i => i.LineID == LineID);
                        if (currentSaleLineSend == null)
                        {
                            return -1;
                        }
                        lineSerialNumber = currentSaleLineSend.LineSerialNumber;
                        SaleOrderSendNumberLine nextSaleLineSend = saleOrderSendNumberLinelist.OrderBy(i => i.LineSerialNumber).FirstOrDefault(i => i.LineSerialNumber > lineSerialNumber);
                        if (nextSaleLineSend == null)
                        {
                            return -1;
                        }
                        nextLineSerialNumber = nextSaleLineSend.LineSerialNumber;
                        //读取下移的数据 
                        var nextSaleLineSendList = saleOrderSendNumberLinelist.Where(i => i.LineSerialNumber == nextLineSerialNumber);
                        foreach (var item in nextSaleLineSendList)
                        {
                            changecount = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberLineOrder(Wid.ToString(), item.LineID, lineSerialNumber);
                        }
                        //下移数据
                        changecount += DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberLineOrder(Wid.ToString(), LineID, nextLineSerialNumber);
                        return changecount;
                    }
                case 3: //置顶
                    {
                        var lineSerialNumberMin = GetSaleOrderSendNumberLinesOrderMin(Wid, LineID);
                        if (lineSerialNumberMin == null)
                        {
                            return -1;
                        }
                        lineSerialNumber = (int)lineSerialNumberMin - 1;
                        var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberLineOrder(Wid.ToString(), LineID, lineSerialNumber);
                        return list;
                    }

                case 4: //置底
                    {
                        var lineSerialNumberMax = GetSaleOrderSendNumberLinesOrderMax(Wid, LineID);
                        if (lineSerialNumberMax == null)
                        {
                            return -1;
                        }

                        lineSerialNumber = (int)lineSerialNumberMax + 1;
                        var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberLineOrder(Wid.ToString(), LineID, lineSerialNumber);
                        return list;
                    }
            }
            return changecount;
        }

        public static int? GetSaleOrderSendNumberShopOrder(int Wid, int LineID, string OrderId)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberShopOrder(Wid.ToString(), LineID, OrderId);
            return list;
        }


        /// <summary>
        /// 读取 选中某仓库下 选中某送货路线 下 所有订单中 门店送货排序的最大值
        /// </summary>
        /// <param name="Wid">仓库编号</param>
        /// <param name="LineID">路线编号</param>
        /// <param name="OrderId">订单编号（用来确定门店）多余的传递参数</param>
        /// <returns>某仓库下某送货路线包含门店排序最大值</returns>
        public static int? GetSaleOrderSendNumberShopsOrderMax(int Wid, int LineID, string OrderId)
        {
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberShopsOrderMax(Wid.ToString(), LineID, OrderId);
            return list;
        }

        /// <summary>
        /// 读取 选中某仓库下 选中某送货路线 下 所有订单中 门店送货排序的最小值
        /// </summary>
        /// <param name="Wid">仓库编号</param>
        /// <param name="LineID">路线编号</param>
        /// <param name="OrderId">订单编号（用来确定门店）多余的传递参数</param>
        /// <returns>某仓库下某送货路线包含门店排序最小值</returns>
        public static int? GetSaleOrderSendNumberShopsOrderMin(int Wid, int LineID, string OrderId)
        {
            var condtion = new Dictionary<string, object>();
            var list = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).GetSaleOrderSendNumberShopsOrderMin(Wid.ToString(), LineID, OrderId);
            return list;
        }

        /// <summary>
        /// 改变预销售单一条线路下的门店发货顺序
        /// 如果是上移和下移。将进行替换操作
        /// 如果是置顶和置底。只改变一条记录(置顶是读取线路下门店排序的最小值-1)
        /// </summary>
        /// <param name="Wid"></param>
        /// <param name="LineID"></param>
        /// <param name="OrderId"></param>
        /// <param name="changeType"></param>
        /// <returns></returns>
        public static int ChangeSaleOrderSendNumberShopOrder(int Wid, int LineID, string OrderId, int changeType)
        {

            var shopSerialNumber = 0;
            int changecount = 0;
            switch (changeType)
            {
                case 1:
                    {
                        //上移
                        IList<SaleOrderSendNumberShop> saleOrderSendNumberShoplist = GetSaleOrderSendNumberOrderShopList(Wid, LineID);
                        if (saleOrderSendNumberShoplist == null || saleOrderSendNumberShoplist.Count == 0)
                        {
                            return -1;
                        }

                        //当前数据,上移的话将 读取的上移排序字段和其替换
                        SaleOrderSendNumberShop currentSaleOrderSend = saleOrderSendNumberShoplist.FirstOrDefault(i => i.OrderId == OrderId);
                        if (currentSaleOrderSend == null)
                        {
                            return -1;
                        }

                        shopSerialNumber = currentSaleOrderSend.ShopSerialNumber;
                        SaleOrderSendNumberShop prevSaleOrderSend = saleOrderSendNumberShoplist.OrderByDescending(i => i.ShopSerialNumber).FirstOrDefault(i => i.ShopSerialNumber < shopSerialNumber);
                        if (prevSaleOrderSend == null)
                        {
                            return -1;
                        }

                        int prevShopSerialNumber = prevSaleOrderSend.ShopSerialNumber;
                        //读取上移的数据 
                        var prevSaleOrderSendList = saleOrderSendNumberShoplist.Where(i => i.ShopSerialNumber == prevShopSerialNumber);
                        foreach (SaleOrderSendNumberShop item in prevSaleOrderSendList)
                        {
                            //上移的数据下移
                            changecount = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberShopOrder(Wid.ToString(), LineID, item.OrderId, shopSerialNumber);
                        }
                        //上移数据
                        changecount += DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberShopOrder(Wid.ToString(), LineID, OrderId, prevShopSerialNumber);
                        return changecount;

                    }
                case 2:
                    {
                        //下移
                        IList<SaleOrderSendNumberShop> saleOrderSendNumberShoplist = GetSaleOrderSendNumberOrderShopList(Wid, LineID);
                        if (saleOrderSendNumberShoplist == null || saleOrderSendNumberShoplist.Count == 0)
                        {
                            return -1;
                        }

                        SaleOrderSendNumberShop currentSaleOrderSend = saleOrderSendNumberShoplist.FirstOrDefault(i => i.OrderId == OrderId);
                        if (currentSaleOrderSend == null)
                        {
                            return -1;
                        }

                        shopSerialNumber = currentSaleOrderSend.ShopSerialNumber;
                        SaleOrderSendNumberShop nextSaleOrderSend = saleOrderSendNumberShoplist.OrderBy(i => i.ShopSerialNumber).FirstOrDefault(i => i.ShopSerialNumber > shopSerialNumber);
                        if (nextSaleOrderSend == null)
                        {
                            return -1;
                        }

                        int nextShopSerialNumber = nextSaleOrderSend.ShopSerialNumber;
                        //读取下一条数据
                        var prevSaleOrderSendList = saleOrderSendNumberShoplist.Where(i => i.ShopSerialNumber == nextShopSerialNumber);
                        foreach (SaleOrderSendNumberShop item in prevSaleOrderSendList)
                        {
                            //替换2个的排序字段
                            changecount = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberShopOrder(Wid.ToString(), LineID, item.OrderId, shopSerialNumber);
                        }
                        //下移数据
                        changecount += DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberShopOrder(Wid.ToString(), LineID, OrderId, nextShopSerialNumber);
                        return changecount;
                    }
                case 3:
                    {
                        //置顶（读取线路下门店排序的最小值-1）
                        var shopSerialNumberMin = GetSaleOrderSendNumberShopsOrderMin(Wid, LineID, OrderId);
                        if (shopSerialNumberMin == null)
                        {
                            return -1;
                        }

                        shopSerialNumber = (int)shopSerialNumberMin - 1;

                        changecount = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberShopOrder(Wid.ToString(), LineID, OrderId, shopSerialNumber);
                        return changecount;
                    }
                case 4:
                    {
                        //置底（读取线路下门店排序的最大值+1）
                        var shopSerialNumberMax = GetSaleOrderSendNumberShopsOrderMax(Wid, LineID, OrderId);
                        if (shopSerialNumberMax == null)
                        {
                            return -1;
                        }
                        shopSerialNumber = (int)shopSerialNumberMax + 1;
                        changecount = DALFactory.GetLazyInstance<ISaleOrderSendNumberOrderDAO>(Wid.ToString()).ChangeSaleOrderSendNumberShopOrder(Wid.ToString(), LineID, OrderId, shopSerialNumber);
                        return changecount;
                    }
            }
            return changecount;
        }
    }
}
