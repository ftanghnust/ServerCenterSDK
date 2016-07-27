
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
    /// BuyBackPre业务逻辑类
    /// </summary>
    public partial class BuyBackPreBLO
    {
        #region 根据主键验证BuyBackPre是否存在
        /// <summary>
        /// 根据主键验证BuyBackPre是否存在
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(BuyBackPre model)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDAO>().Exists(model);
        }
        #endregion

        #region 添加一个BuyBackPre
        /// <summary>
        /// 添加一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(BuyBackPre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDAO>().Save(model, conn, trans);
        }
        #endregion

        #region 根据主键获取BuyBackPre对象
        /// <summary>
        /// 根据主键获取BuyBackPre对象
        /// </summary>
        /// <param name="BackID">采购单编号</param>
        /// <returns>BuyBackPre对象</returns>
        public static BuyBackPre GetModel(string BackID, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).GetModel(BackID);
        }
        #endregion

        #region 删除一个BuyBackPre
        /// <summary>
        /// 删除一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(BuyBackPre model, IDbConnection conn, IDbTransaction trans, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).Delete(model, conn, trans);
        }
        #endregion

        #region 更新一个BuyBackPre
        /// <summary>
        /// 更新一个BuyBackPre
        /// </summary>
        /// <param name="model">BuyBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(BuyBackPre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDAO>().Edit(model, conn, trans);
        }
        #endregion

        #region 分页获取BuyBackPre集合
        /// <summary>
        /// 分页获取BuyBackPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static BuyBackPageModel GetPageList(BuyBackPageModel page, IDictionary<string, object> conditionDict, string WID)
        {
            return DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).GetPageList(page, conditionDict);
        }
        #endregion

    }

    public partial class BuyBackPreBLO
    {

        /// <summary>
        /// 添加退货票据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public static BackMessage<bool> Save(BuyBackPre order, List<BuyBackPreDetails> orderdetails, List<BuyBackPreDetailsExt> orderdetailsexts, string WID)
        {
            var connection = DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).Save(order, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "保存采购退货订单主表信息失败");
                }
                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    if (DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购退货订单明细信息失败");
                    }
                    detailscount = detailscount + 1;
                }
                int detailsextcount = 0;
                foreach (var model in orderdetailsexts)
                {
                    if (DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购退货订单明细扩展信息失败");
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
                    return BackMessage<bool>.FailBack(false, "添加采购退货订单信息失败");
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
        /// 添加退货票据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdetails"></param>
        /// <returns>返回0表示确认</returns>
        public static string Save(IList<BuyBackPre> orderList, IList<BuyBackPreDetails> orderdetails, IList<BuyBackPreDetailsExt> orderdetailsexts, string WID, IDbConnection connection, IDbTransaction trans)
        {
            try
            {
                int count = 0;
                foreach (var model in orderList)
                {
                    if (DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).Save(model, connection, trans) <= 0)
                    {

                        return "保存采购退货订单主表信息失败";
                    }
                    count = count + 1;
                }

                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    if (DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        return "保存采购退货订单明细信息失败";
                    }
                    detailscount = detailscount + 1;
                }
                int detailsextcount = 0;
                foreach (var model in orderdetailsexts)
                {
                    if (DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        return "保存采购退货订单明细扩展信息失败";
                    }
                    detailsextcount = detailsextcount + 1;
                }
                if (count == orderList.Count && detailscount == orderdetails.Count && detailscount == detailsextcount)
                {
                    return "0";
                }
                else
                {
                    return "添加采购退货订单信息失败";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// 批量更改BuyBackPre状态
        /// </summary>
        /// <param name="BackIDs"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static BackMessage<bool> ChangeStatus(string backids, int status, int userid, string username, string WID)
        {
            IList<BuyBackPreDetails> orderdetails = null;
            IList<BuyBackPreDetailsExt> orderdetailsext = null;
            if (status == 2)
            {
                orderdetails = DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>(WID).GetListByPre(null);
                orderdetailsext = DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(WID).GetListByPre(null);
                if (orderdetails == null)
                {
                    return BackMessage<bool>.FailBack(false, "获取单据商品信息失败");
                }
                if (orderdetailsext == null)
                {
                    return BackMessage<bool>.FailBack(false, "获取单据商品扩展信息失败");
                }
            }

            var backIDs = backids.Split(',');
            int row = 0;
            var connection = DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                foreach (var backid in backIDs)
                {
                    BuyBackPre model = BuyBackPreBLO.GetModel(backid, WID);
                    if (model == null)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, string.Format("没有找到订单{0}", backid));
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
                    if (model.Status == 1 && status == 2)   //由确认到过账
                    {
                        //过账
                        model.Status = status;
                        model.PostingTime = DateTime.Now;
                        model.PostingUserID = userid;
                        model.PostingUserName = username;
                        if (DALFactory.GetLazyInstance<IBuyBackDAO>(WID).Save(model, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存采购退货订单主表历史信息失败");
                        }
                        IList<BuyBackPreDetails> buyBackPreDetailsList = orderdetails.Where(p => p.BackID == model.BackID).ToList();
                        foreach (var item in buyBackPreDetailsList)
                        {
                            if (DALFactory.GetLazyInstance<IBuyBackDetailsDAO>(WID).Save(item, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, "保存采购退货订单明细历史信息失败");
                            }
                        }

                        IList<BuyBackPreDetailsExt> orderdetailsextList = orderdetailsext.Where(p => p.BackID == model.BackID).ToList();
                        foreach (var item in orderdetailsextList)
                        {
                            if (DALFactory.GetLazyInstance<IBuyBackDetailsExtDAO>(WID).Save(item, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, "保存采购退货订单明细扩展历史信息失败");
                            }
                        }
                        if (BuyBackPreBLO.Delete(model, connection, trans, WID) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除采购退货订单主表信息失败");
                        }
                        if (BuyBackPreDetailsBLO.Delete(backid, connection, trans, WID) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除采购退货订单明细信息失败");
                        }
                        if (DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(WID).Delete(backid, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除采购退货订单明细扩展信息失败");
                        }
                        row = row + 1;

                        //查看商品配送价格与单据中的商品采购价是否一致 
                        var ProductSdkClient = WorkContext.CreateProductSdkClient();
                        var resp = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWProductsGetByIDsRequest()
                        {
                            WID = int.Parse(WID),
                            ProductIds = (from o in buyBackPreDetailsList select o.ProductId).ToList()
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


                        foreach (var item in buyBackPreDetailsList)
                        {
                            var temp = WProducts.Where(o => o.ProductId == item.ProductId).FirstOrDefault();
                            if (temp != null)
                            {
                                if (temp.SalePrice != (decimal)item.UnitPrice)
                                {
                                    trans.Rollback();
                                    return BackMessage<bool>.FailBack(false, string.Format("{0}配送价与退货价不一致，不能过账！", item.ProductName));
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
                        }

                        //修改库存
                        BatStockOutModel outMod = new BatStockOutModel();
                        outMod.WID = model.WID;
                        outMod.SubWID = model.SubWID;
                        outMod.BillType = 3;
                        outMod.BillID = model.BackID;
                        outMod.VendorID = model.VendorID;
                        outMod.CreateUserID = userid;
                        outMod.CreateUserName = username;
                        IList<StockOutInPutInModel> OutPList = new List<StockOutInPutInModel>();
                        foreach (var item in buyBackPreDetailsList)
                        {
                            StockOutInPutInModel temp = new StockOutInPutInModel();
                            temp.BillDetailID = item.ID;
                            temp.ProductID = item.ProductId;
                            temp.SKU = item.SKU;
                            temp.OutQty = item.UnitQty;
                            OutPList.Add(temp);
                        }
                        outMod.OutPList = OutPList;
                        string msg = "";
                        if (!StockMangerBLO.BatStockOut(outMod, false, connection, trans, ref msg))
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, string.Format("采购退货单【{0}】修改库存失败，{1}", backid, msg));
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
                        if (DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).EditInChange(model, connection, trans) > 0)
                        {
                            row = row + 1;
                        }
                        else
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, string.Format("反确认订单{0}失败", model.BackID));
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
                        if (DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).EditInChange(model, connection, trans) > 0)
                        {
                            row = row + 1;
                        }
                        else
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, string.Format("确认订单{0}失败", model.BackID));
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
        /// 事务批量删除退货订单及订单详情
        /// </summary>
        /// <param name="BackIDs"></param>
        /// <returns></returns>
        public static BackMessage<bool> Delete(string BackIDs, string WID)
        {
            var backIds = BackIDs.Split(',');
            var connection = DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            int row = 0;
            try
            {
                foreach (string backid in backIds)
                {
                    BuyBackPre model = BuyBackPreBLO.GetModel(backid, WID);
                    if (model == null)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, string.Format("没有找到订单{0}", backid));
                    }
                    if (model.Status != 0)   //未提交状态
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "订单状态不是录单状态");
                    }
                    if (BuyBackPreBLO.Delete(model, connection, trans, WID) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除采购退货订单主表信息失败");
                    }
                    else
                    {
                        row = row + 1;
                    }
                    if (BuyBackPreDetailsBLO.Delete(backid, connection, trans, WID) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除采购退货订单明细信息失败");
                    }
                    if (DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(WID).Delete(backid, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除采购退货订单明细扩展信息失败");
                    }
                }
                if (row == backIds.Length)
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
        /// 更新退货票据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public static BackMessage<bool> Edit(BuyBackPre order, List<BuyBackPreDetails> orderdetails, List<BuyBackPreDetailsExt> orderdetailsexts, string WID)
        {
            BuyBackPre orderTemp = BuyBackPreBLO.GetModel(order.BackID, WID);
            if (orderTemp == null)
            {
                return BackMessage<bool>.FailBack(false, "没有找到这个订单");
            }
            if (orderTemp.Status != 0)  //不是未提交状态
            {
                return BackMessage<bool>.FailBack(false, "订单不是录单状态");
            }

            var connection = DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (DALFactory.GetLazyInstance<IBuyBackPreDAO>(WID).Edit(order, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "修改采购退货订单主表信息失败");
                }
                if (BuyBackPreDetailsBLO.Delete(order.BackID, connection, trans, WID) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除采购退货订单明细信息失败");
                }

                if (DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(WID).Delete(order.BackID, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除采购退货订单明细扩展信息失败");
                }

                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    model.ModifyUserID = order.ModifyUserID;
                    model.ModifyUserName = order.ModifyUserName;
                    if (DALFactory.GetLazyInstance<IBuyBackPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购退货订单明细信息失败");
                    }
                    detailscount = detailscount + 1;
                }
                int detailsextcount = 0;
                foreach (var model in orderdetailsexts)
                {
                    model.ModifyUserName = order.ModifyUserName;
                    model.ModifyUserName = order.ModifyUserName;
                    if (DALFactory.GetLazyInstance<IBuyBackPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存采购退货订单明细扩展信息失败");
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
                    return BackMessage<bool>.FailBack(false, "编辑采购退货订单信息失败");
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