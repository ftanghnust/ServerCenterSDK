
/*****************************
* Author:TangFan
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Order.BLL.Stock;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using System.Linq;

namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// BuyOrderPre业务逻辑类
    /// </summary>
    public partial class BuyOrderPreBLO
    {
        #region 根据主键验证BuyOrderPre是否存在
        /// <summary>
        /// 根据主键验证BuyOrderPre是否存在
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(BuyOrderPre model)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDAO>().Exists(model);
        }
        #endregion

        #region 添加一个BuyOrderPre
        /// <summary>
        /// 添加一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyOrderPre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDAO>().Save(model, conn, trans);
        }
        #endregion

        #region 根据主键获取BuyOrderPre对象
        /// <summary>
        /// 根据主键获取BuyOrderPre对象
        /// </summary>
        /// <param name="buyID">采购单编号</param>
        /// <returns>BuyOrderPre对象</returns>
        public static BuyOrderPre GetModel(string buyID, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).GetModel(buyID);
        }
        #endregion

        #region 删除一个BuyOrderPre
        /// <summary>
        /// 删除一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BuyOrderPre model, IDbConnection conn, IDbTransaction trans, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).Delete(model, conn, trans);
        }
        #endregion

        #region 更新一个BuyOrderPre
        /// <summary>
        /// 更新一个BuyOrderPre
        /// </summary>
        /// <param name="model">BuyOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyOrderPre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDAO>().Edit(model, conn, trans);
        }
        #endregion

        #region 分页获取BuyOrderPre集合
        /// <summary>
        /// 分页获取BuyOrderPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static BuyOrderPageModel GetPageList(BuyOrderPageModel page, IDictionary<string, object> conditionDict, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).GetPageList(page, conditionDict);
        }
        #endregion

    }

    public partial class BuyOrderPreBLO
    {

        /// <summary>
        /// 添加采购票据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public static BackMessage<bool> Save(BuyOrderPre order, List<BuyOrderPreDetails> orderdetails, List<BuyOrderPreDetailsExt> orderdetailsext, string WID)
        {
            var connection = DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).Save(order, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "保存采购订单主表信息失败");
                }
                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购订单明细信息失败");
                    }
                    detailscount = detailscount + 1;
                }
                int detailsextcount = 0;
                foreach (var model in orderdetailsext)
                {
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购订单明细扩展信息失败");
                    }
                    detailsextcount = detailsextcount + 1;
                }
                if (detailscount == orderdetails.Count && detailscount == detailsextcount)
                {
                    trans.Commit();
                    return BackMessage<bool>.SuccessBack(true);
                }
                else
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "添加采购订单信息失败");
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return BackMessage<bool>.FailBack(false, ex.Message);
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 添加采购票据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdetails"></param>
        /// <returns>返回0表示成功</returns>
        public static string Save(IList<BuyOrderPre> orderList, IList<BuyOrderPreDetails> orderdetails, IList<BuyOrderPreDetailsExt> orderdetailsext, string WID, IDbConnection connection, IDbTransaction trans)
        {
            try
            {
                int count = 0;
                foreach (var model in orderList)
                {
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).Save(model, connection, trans) <= 0)
                    {

                        return "保存采购订单主表信息失败";
                    }
                    count = count + 1;
                }

                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {

                        return "保存采购订单明细信息失败";
                    }
                    detailscount = detailscount + 1;
                }

                int detailsextcount = 0;
                foreach (var model in orderdetailsext)
                {
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {

                        return "保存采购订单明细扩展信息失败";
                    }
                    detailsextcount = detailsextcount + 1;
                }

                if (count == orderList.Count && detailscount == orderdetails.Count && detailscount == detailsextcount)
                {
                    return "0";
                }
                else
                {

                    return "添加采购订单信息失败";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }


        /// <summary>
        /// 批量更改BuyOrderPre状态
        /// </summary>
        /// <param name="buyids"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static BackMessage<bool> ChangeStatus(string buyids, int status, int userid, string username, string WID)
        {
            IList<BuyOrderPreDetails> orderdetails = null;
            IList<BuyOrderPreDetailsExt> orderdetailsext = null;
            if (status == 2)
            {
                orderdetails = DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>(WID).GetListByPre(null);
                orderdetailsext = DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(WID).GetListByPre(null);
                if (orderdetails == null)
                {
                    return BackMessage<bool>.FailBack(false, "获取单据商品信息失败");
                }
                if (orderdetailsext == null)
                {
                    return BackMessage<bool>.FailBack(false, "获取单据商品扩展信息失败");
                }
            }

            var buyIds = buyids.Split(',');
            int row = 0;
            var connection = DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var buyid in buyIds)
                {
                    BuyOrderPre model = BuyOrderPreBLO.GetModel(buyid, WID);
                    if (model == null)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, string.Format("没有找到订单{0}", buyid));
                    }
                    if (status == 2 && model.Status != 1)
                    {
                        //过账状态验证
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "状态错误，不能更改");
                    }
                    if (status == 0 && model.Status != 1)
                    {
                        //由确认到反确认
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "状态错误，不能更改");
                    }
                    if (status == 1 && model.Status != 0)
                    {
                        //由录单到确认
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "状态错误，不能更改");
                    }
                    model.ModifyUserID = userid;
                    model.ModifyUserName = username;
                    if (model.Status == 1 && status == 2) //由确认到过账
                    {
                        //过账
                        model.Status = status;
                        model.PostingTime = DateTime.Now;
                        model.PostingUserID = userid;
                        model.PostingUserName = username;
                        if (DALFactory.GetLazyInstance<IBuyOrderDAO>(WID).Save(model, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存采购订单主表历史信息失败");
                        }
                        IList<BuyOrderPreDetails> orderdetailslist = orderdetails.Where(o => o.BuyID == model.BuyID).ToList();
                        foreach (var item in orderdetailslist)
                        {
                            if (DALFactory.GetLazyInstance<IBuyOrderDetailsDAO>(WID).Save(item, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, "保存采购订单明细历史信息失败");
                            }
                        }
                        IList<BuyOrderPreDetailsExt> orderdetailsextlist = orderdetailsext.Where(o => o.BuyID == model.BuyID).ToList();
                        foreach (var item in orderdetailsextlist)
                        {
                            if (DALFactory.GetLazyInstance<IBuyOrderDetailsExtDAO>(WID).Save(item, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, "保存采购订单明细扩展历史信息失败");
                            }
                        }
                        if (BuyOrderPreBLO.Delete(model, connection, trans, WID) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除采购订单主表信息失败");
                        }
                        if (BuyOrderPreDetailsBLO.Delete(buyid, connection, trans, WID) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除采购订单明细信息失败");
                        }
                        if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(WID).Delete(buyid, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除采购订单明细扩展信息失败");
                        }

                        row = row + 1;

                        //查看商品配送价格与单据中的商品采购价是否一致 
                        var ProductSdkClient = WorkContext.CreateProductSdkClient();
                        var resp = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWProductsGetByIDsRequest()
                        {
                            WID = int.Parse(WID),
                            ProductIds = (from o in orderdetailslist select o.ProductId).ToList()
                        });
                        var WProducts = new List<Frxs.Erp.ServiceCenter.Product.SDK.Resp.FrxsErpProductWProductsGetByIDsResp.FrxsErpProductWProductsGetByIDsRespData>();
                        if (resp != null)
                        {
                            WProducts = resp.Data.ToList();
                        }
                        else
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "获取商品配送价格失败");
                        }
                        //获取商品的供应商信息
                        var respVendor = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWProductsBuyListGetRequest()
                        {
                            PageIndex = 1,
                            PageSize = int.MaxValue,
                            WID = int.Parse(WID),
                            VendorID = model.VendorID
                        });

                        var VendorInfo = new List<Frxs.Erp.ServiceCenter.Product.SDK.Resp.FrxsErpProductWProductsBuyListGetResp.WProductsQueryModel>();
                        if (respVendor != null)
                        {
                            VendorInfo = respVendor.Data.ItemList;
                        }
                        else
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "获取供应商对应商品信息失败");
                        }

                        List<Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductProductsVendorUpdateLastBuyPriceRequest.ProductsVendorUnitPriceRequestDto> ProductUnitPriceUpdateList
                            = new List<Product.SDK.Request.FrxsErpProductProductsVendorUpdateLastBuyPriceRequest.ProductsVendorUnitPriceRequestDto>();
                        foreach (var item in orderdetailslist)
                        {
                            var temp = WProducts.Where(o => o.ProductId == item.ProductId).FirstOrDefault();
                            if (temp != null)
                            {
                                if (temp.SalePrice != (decimal)item.UnitPrice)
                                {
                                    trans.Rollback();
                                    return BackMessage<bool>.FailBack(false, string.Format("{0}配送价与进货价不一致，不能过账！", item.ProductName));
                                }
                            }
                            else
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, string.Format("{0}配送价数据库中不存在", item.ProductName));
                            }
                            var tempVendor = VendorInfo.Where(o => o.ProductId == item.ProductId).FirstOrDefault();
                            if (tempVendor == null)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, string.Format("{0}供应商信息已经变更，不能过账！", item.ProductName));
                            }
                            ProductUnitPriceUpdateList.Add(new Product.SDK.Request.FrxsErpProductProductsVendorUpdateLastBuyPriceRequest.ProductsVendorUnitPriceRequestDto()
                            {
                                ProductId = item.ProductId,
                                BuyPrice = item.UnitPrice,
                                Unit = item.Unit
                            });
                        }

                        //改库存
                        BatStockInModel stockInModel = new BatStockInModel();
                        stockInModel.BatchNO = model.BuyID;
                        stockInModel.WID = model.WID;
                        stockInModel.WCode = model.WCode;
                        stockInModel.WName = model.WName;
                        stockInModel.SubWID = model.SubWID;
                        stockInModel.SubWName = model.SubWName;
                        stockInModel.CreateUserID = userid;
                        stockInModel.CreateUserName = username;
                        IList<StockFIFOInModel> InPList = new List<StockFIFOInModel>();
                        foreach (var item in orderdetailslist)
                        {
                            StockFIFOInModel temp = new StockFIFOInModel();
                            temp.BatchNO = item.BuyID;
                            temp.WID = model.WID;
                            temp.WCode = model.WCode;
                            temp.WName = model.WName;
                            temp.SubWID = model.SubWID;
                            temp.SubWName = model.SubWName;
                            temp.ProductID = item.ProductId;
                            temp.SKU = item.SKU;
                            temp.ProductName = item.ProductName;
                            temp.StockQty = 0.0m;
                            temp.BillType = 0;
                            temp.BillID = item.BuyID;
                            temp.BillDetailID = item.ID;
                            temp.Unit = item.Unit;
                            temp.Qty = item.UnitQty;
                            temp.TotalOutQty = 0.0m;
                            temp.Flag = 0;
                            temp.VendorID = model.VendorID;
                            temp.VendorCode = model.VendorCode;
                            temp.VendorName = model.VendorName;
                            temp.InPrice = (decimal)item.BuyPrice;
                            temp.StockTime = DateTime.Now;
                            temp.ModifyTime = DateTime.Now;
                            InPList.Add(temp);
                        }
                        stockInModel.InPList = InPList;
                        StockMangerBLO.BatStockIn(stockInModel, connection, trans);

                        //更新商品最后一次的采购价
                        var respUpdateLasePrice = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductProductsVendorUpdateLastBuyPriceRequest()
                        {
                            VendorID = model.VendorID,
                            Wid = int.Parse(WID),
                            ProductsVendorBuyPriceList = ProductUnitPriceUpdateList
                        });

                        if (respUpdateLasePrice == null || respUpdateLasePrice.Flag != 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, (respUpdateLasePrice == null ? "更新商品最后一次采购价失败" : respUpdateLasePrice.Info));
                        }
                    }
                    else if (model.Status == 1 && status == 0)   //由确认到反确认
                    {
                        //反确认  
                        model.Status = status;
                        model.ConfTime = null;
                        model.ConfUserID = 0;
                        model.ConfUserName = "";
                        model.ModifyTime = DateTime.Now;
                        if (DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).EditInChange(model, connection, trans) > 0)
                        {
                            row = row + 1;
                        }
                        else
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, string.Format("反确认订单{0}失败", model.BuyID));
                        }
                    }
                    else if (model.Status == 0 && status == 1)   //由录单到确认
                    {
                        //确认
                        model.Status = status;
                        model.ConfTime = DateTime.Now;
                        model.ConfUserID = userid;
                        model.ConfUserName = username;
                        model.ModifyTime = DateTime.Now;
                        if (DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).EditInChange(model, connection, trans) > 0)
                        {
                            row = row + 1;
                        }
                        else
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, string.Format("确认订单{0}失败", model.BuyID));
                        }
                    }
                }
                trans.Commit();
                return BackMessage<bool>.SuccessBack(true);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return BackMessage<bool>.FailBack(false, ex.Message);
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }



        /// <summary>
        /// 事务批量删除采购订单及订单详情
        /// </summary>
        /// <param name="BuyIDs"></param>
        /// <returns></returns>
        public static BackMessage<bool> Delete(string BuyIDs, string WID)
        {
            var buyIds = BuyIDs.Split(',');
            var connection = DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            int row = 0;
            try
            {
                foreach (string buyid in buyIds)
                {
                    BuyOrderPre model = BuyOrderPreBLO.GetModel(buyid, WID);
                    if (model == null)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, string.Format("没有找到订单{0}", buyid));
                    }
                    if (model.Status != 0)   //未提交状态
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "订单状态不是录单状态");
                    }
                    if (BuyOrderPreBLO.Delete(model, connection, trans, WID) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除采购订单主表信息失败");
                    }
                    else
                    {
                        row = row + 1;
                    }
                    if (BuyOrderPreDetailsBLO.Delete(buyid, connection, trans, WID) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除采购订单明细信息失败");
                    }
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(WID).Delete(buyid, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除采购订单明细扩展信息失败");
                    }
                }
                if (row == buyIds.Length)
                {
                    trans.Commit();
                    return BackMessage<bool>.SuccessBack(true);
                }
                else
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除订单失败");
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return BackMessage<bool>.FailBack(false, ex.Message);
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }



        /// <summary>
        /// 更新采购票据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public static BackMessage<bool> Edit(BuyOrderPre order, List<BuyOrderPreDetails> orderdetails, List<BuyOrderPreDetailsExt> orderdetailsext, string WID)
        {
            BuyOrderPre orderTemp = BuyOrderPreBLO.GetModel(order.BuyID, WID);
            if (orderTemp == null)
            {
                return BackMessage<bool>.FailBack(false, "没有找到这个订单");
            }
            if (orderTemp.Status != 0)  //不是未提交状态
            {
                return BackMessage<bool>.FailBack(false, "订单不是录单状态");
            }
            var connection = DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (DALFactory.GetLazyInstance<IBuyOrderPreDAO>(WID).Edit(order, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "修改采购订单主表信息失败");
                }
                if (BuyOrderPreDetailsBLO.Delete(order.BuyID, connection, trans, WID) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除采购订单明细信息失败");
                }

                if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(WID).Delete(order.BuyID, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除采购订单明细扩展信息失败");
                }
                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    model.ModifyUserID = order.ModifyUserID;
                    model.ModifyUserName = order.ModifyUserName;
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购订单明细信息失败");
                    }
                    detailscount = detailscount + 1;
                }
                int detailsextcount = 0;
                foreach (var model in orderdetailsext)
                {
                    model.ModifyUserName = order.ModifyUserName;
                    model.ModifyUserName = order.ModifyUserName;
                    if (DALFactory.GetLazyInstance<IBuyOrderPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购订单明细扩展信息失败");
                    }
                    detailsextcount = detailsextcount + 1;
                }
                if (detailscount == orderdetails.Count && detailscount == detailsextcount)
                {
                    trans.Commit();
                    return BackMessage<bool>.SuccessBack(true);
                }
                else
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "编辑采购订单信息失败");
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return BackMessage<bool>.FailBack(false, ex.Message);
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
    }
}