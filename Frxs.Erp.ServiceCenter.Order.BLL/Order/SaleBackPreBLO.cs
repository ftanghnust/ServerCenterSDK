
/*****************************
* Author:Tang.Fan
*
* Date:2016-03-24
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Erp.ServiceCenter.Order.BLL.Stock;
using System.Linq;



namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// SaleBackPre业务逻辑类
    /// </summary>
    public partial class SaleBackPreBLO
    {
        #region 成员方法


        #region 事务添加一个SaleBackPre
        /// <summary>
        /// 添加一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleBackPre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDAO>().Save(model, conn, trans);
        }
        #endregion


        #region 事务更新一个SaleBackPre
        /// <summary>
        /// 更新一个SaleBackPre
        /// </summary>
        /// <param name="model">SaleBackPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleBackPre model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDAO>().Edit(model, conn, trans);
        }
        #endregion


        #region 事务删除一个SaleBackPre
        ///// <summary>
        ///// 事务删除一个SaleBackPre
        ///// </summary>
        ///// <param name="model">SaleBackPre对象</param>
        ///// <returns>数据库影响行数</returns>
        //public static int Delete(SaleBackPre model, IDbConnection conn, IDbTransaction trans)
        //{
        //    return DALFactory.GetLazyInstance<ISaleBackPreDAO>().Delete(model, conn, trans);
        //}
        #endregion




        #region 根据字典获取SaleBackPre对象
        /// <summary>
        /// 根据字典获取SaleBackPre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleBackPre对象</returns>
        public static SaleBackPre GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleBackPre对象
        /// <summary>
        /// 根据主键获取SaleBackPre对象
        /// </summary>
        /// <param name="backID">退货单编号</param>
        /// <returns>SaleBackPre对象</returns>
        public static SaleBackPre GetModel(string backID, string WID)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetModel(backID);
        }
        #endregion


        #region 根据字典获取SaleBackPre集合
        /// <summary>
        /// 根据字典获取SaleBackPre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleBackPre> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取SaleBackPre数据集
        /// <summary>
        /// 根据字典获取SaleBackPre数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleBackPre集合
        /// <summary>
        /// 分页获取SaleBackPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleBackPre> GetPageList(PageListBySql<SaleBackPre> page, IDictionary<string, object> conditionDict, string WID)
        {
            return DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetPageList(page, conditionDict);
        }
        #endregion




        #endregion
    }

    public partial class SaleBackPreBLO
    {

        /// <summary>
        /// 添加退货票据
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderdetails"></param>
        /// <returns></returns>
        public static BackMessage<bool> Save(SaleBackPre order, List<SaleBackPreDetails> orderdetails, List<SaleBackPreDetailsExt> orderdetailsexts, string WID)
        {
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).Save(order, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "保存销售退货订单主表信息失败");
                }
                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    if (DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存销售退货订单明细信息失败");
                    }
                    detailscount = detailscount + 1;
                }
                int detailsextcount = 0;
                foreach (var model in orderdetailsexts)
                {
                    if (DALFactory.GetLazyInstance<ISaleBackPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存销售退货订单明细扩展信息失败");
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
                    return BackMessage<bool>.FailBack(false, "添加销售退货订单信息失败");
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
        public static BackMessage<bool> Edit(SaleBackPre order, List<SaleBackPreDetails> orderdetails, List<SaleBackPreDetailsExt> orderdetailsexts, string WID)
        {
            SaleBackPre orderTemp = DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetModel(order.BackID);
            if (orderTemp == null)
            {
                return BackMessage<bool>.FailBack(false, "没有找到这个订单");
            }
            if (orderTemp.Status != 0)  //不是未提交状态
            {
                return BackMessage<bool>.FailBack(false, "订单不是录单状态");
            }

            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).Edit(order, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "修改销售退货订单主表信息失败");
                }
                if (DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>(WID).Delete(order.BackID, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除销售退货订单明细信息失败");
                }
                if (DALFactory.GetLazyInstance<ISaleBackPreDetailsExtDAO>(WID).Delete(order.BackID, connection, trans) <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除销售退货订单明细扩展信息失败");
                }
                int detailscount = 0;
                foreach (var model in orderdetails)
                {
                    model.ModifyUserID = order.ModifyUserID;
                    model.ModifyUserName = order.ModifyUserName;
                    if (DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存销售退货订单明细信息失败");
                    }
                    detailscount = detailscount + 1;
                }
                int detailsextcount = 0;
                foreach (var model in orderdetailsexts)
                {
                    model.ModifyUserName = order.ModifyUserName;
                    model.ModifyUserName = order.ModifyUserName;
                    if (DALFactory.GetLazyInstance<ISaleBackPreDetailsExtDAO>(WID).Save(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存销售退货订单明细扩展信息失败");
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
                    return BackMessage<bool>.FailBack(false, "编辑销售退货订单信息失败");
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
        /// 批量更改SaleBackPre状态
        /// </summary>
        /// <param name="BackIDs"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static BackMessage<bool> ChangeStatus(string backids, int status, int userid, string username, string WID)
        {
            IList<SaleBackPreDetails> orderdetails = null;
            IList<SaleBackPreDetailsExt> orderdetailsext = null;
            if (status == 2)
            {
                orderdetails = DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>(WID).GetListByPre(null);
                orderdetailsext = DALFactory.GetLazyInstance<ISaleBackPreDetailsExtDAO>(WID).GetListByPre(null);
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
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var backid in backIDs)
                {
                    SaleBackPre model = DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetModel(backid);

                    if (model == null)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, string.Format("没有找到单据{0}，请在单据列表中刷新重新操作", backid));
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
                        if (DALFactory.GetLazyInstance<ISaleBackDAO>(WID).Save(model, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存销售退货订单主表历史信息失败");
                        }
                        IList<SaleBackPreDetails> orderdetailslist = orderdetails.Where(o => o.BackID == model.BackID).ToList();
                        foreach (var item in orderdetailslist)
                        {
                            if (DALFactory.GetLazyInstance<ISaleBackDetailsDAO>(WID).Save(item, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, "保存销售退货订单明细历史信息失败");
                            }
                        }
                        IList<SaleBackPreDetailsExt> orderdetailsextlist = orderdetailsext.Where(o => o.BackID == model.BackID).ToList();
                        foreach (var item in orderdetailsextlist)
                        {
                            if (DALFactory.GetLazyInstance<ISaleBackDetailsExtDAO>(WID).Save(item, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, "保存销售退货订单明细扩展历史信息失败");
                            }
                        }
                        if (DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).Delete(model, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除销售退货订单主表信息失败");
                        }
                        if (DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>(WID).Delete(backid, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除销售退货订单明细信息失败");
                        }
                        if (DALFactory.GetLazyInstance<ISaleBackPreDetailsExtDAO>(WID).Delete(backid, connection, trans) <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除销售退货订单明细扩展信息失败");
                        }
                        row = row + 1;
                        //修改库存
                        BatStockInModel stockInModel = new BatStockInModel();
                        stockInModel.BatchNO = model.BackID;
                        stockInModel.WID = model.WID;
                        stockInModel.WCode = model.WCode;
                        stockInModel.WName = model.WName;
                        stockInModel.SubWID = model.SubWID;
                        stockInModel.SubWName = model.SubWName;
                        stockInModel.CreateUserID = userid;
                        stockInModel.CreateUserName = username;
                        IList<StockFIFOInModel> InPList = new List<StockFIFOInModel>();
                        var ProductSdkClient = WorkContext.CreateProductSdkClient();
                        var resp = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWProductsBuyListSreachRequest()
                        {
                            WID = int.Parse(WID),
                            PDList = (from o in orderdetailslist select o.ProductId).ToList()
                        });
                        var VendorInfo = new List<Frxs.Erp.ServiceCenter.Product.SDK.Resp.FrxsErpProductWProductsBuyListSreachResp.FrxsErpProductWProductsBuyListSreachRespData>();
                        if (resp != null)
                        {
                            VendorInfo = resp.Data.ToList();
                        }
                        else
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "获取供应商信息失败");
                        }
                        foreach (var item in orderdetailslist)
                        {
                            StockFIFOInModel temp = new StockFIFOInModel();
                            temp.BatchNO = item.BackID;
                            temp.WID = model.WID;
                            temp.WCode = model.WCode;
                            temp.WName = model.WName;
                            temp.SubWID = model.SubWID;
                            temp.SubWName = model.SubWName;
                            temp.ProductID = item.ProductId;
                            temp.SKU = item.SKU;
                            temp.ProductName = item.ProductName;
                            temp.StockQty = 0.0m;
                            temp.BillType = 1;
                            temp.BillID = item.BackID;
                            temp.BillDetailID = item.ID;
                            temp.Unit = item.Unit;
                            temp.Qty = item.UnitQty;
                            temp.TotalOutQty = 0.0m;
                            temp.Flag = 0;
                            temp.InPrice = (decimal)item.BackPrice;
                            temp.StockTime = DateTime.Now;
                            temp.ModifyTime = DateTime.Now;
                            var tempVendor = VendorInfo.Where(o => o.ProductId == item.ProductId).FirstOrDefault();
                            if (tempVendor != null)
                            {
                                temp.VendorID = tempVendor.VendorID;
                                temp.VendorCode = tempVendor.VendorCode;
                                temp.VendorName = tempVendor.VendorName;
                            }
                            else
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, string.Format("商品【{0}】供应商信息不存在！",item.SKU));
                            }
                            InPList.Add(temp);
                        }
                        stockInModel.InPList = InPList;
                        StockMangerBLO.BatStockIn(stockInModel, connection, trans);
                    }
                    else if (model.Status == 1 && status == 0)   //由确认到反确认
                    {
                        //反确认  
                        model.Status = status;
                        model.ConfTime = null;
                        model.ConfUserID = 0;
                        model.ConfUserName = "";
                        model.ModifyTime = DateTime.Now;
                        if (DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).EditInChange(model, connection, trans) > 0)
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
                        if (DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).EditInChange(model, connection, trans) > 0)
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
            var connection = DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            int row = 0;
            try
            {
                foreach (string backid in backIds)
                {
                    SaleBackPre model = DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).GetModel(backid);
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

                    if (DALFactory.GetLazyInstance<ISaleBackPreDAO>(WID).Delete(model, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除销售退货订单主表信息失败");
                    }
                    else
                    {
                        row = row + 1;
                    }
                    if (DALFactory.GetLazyInstance<ISaleBackPreDetailsDAO>(WID).Delete(backid, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除销售退货订单明细信息失败");
                    }
                    if (DALFactory.GetLazyInstance<ISaleBackPreDetailsExtDAO>(WID).Delete(backid, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "清除销售退货订单明细扩展信息失败");
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

    }
}