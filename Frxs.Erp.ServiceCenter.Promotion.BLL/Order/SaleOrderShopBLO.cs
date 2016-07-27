
/*****************************
* Author:leidong
*
* Date:2016-04-06
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Erp.ServiceCenter.Promotion.BLL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;
using System.Linq;

namespace Frxs.Erp.ServiceCenter.Promotion.BLL
{
    /// <summary>
    /// SaleOrderShop业务逻辑类
    /// </summary>
    public partial class SaleOrderShopBLO
    {
        #region 成员方法
        #region 根据主键验证SaleOrderShop是否存在
        /// <summary>
        /// 根据主键验证SaleOrderShop是否存在
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleOrderShop model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个SaleOrderShop
        /// <summary>
        /// 添加一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleOrderShop model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Save(model);
        }
        #endregion


        #region 更新一个SaleOrderShop
        /// <summary>
        /// 更新一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleOrderShop model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Edit(model);
        }
        #endregion


        #region 删除一个SaleOrderShop
        /// <summary>
        /// 删除一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleOrderShop model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleOrderShop
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderShop
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string orderId, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).LogicDelete(orderId);
        }
        #endregion


        #region 根据字典获取SaleOrderShop对象
        /// <summary>
        /// 根据字典获取SaleOrderShop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderShop对象</returns>
        public static SaleOrderShop GetModel(IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取SaleOrderShop对象
        /// <summary>
        /// 根据主键获取SaleOrderShop对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderShop对象</returns>
        public static SaleOrderShop GetModel(string orderId, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetModel(orderId);
        }
        #endregion


        #region 根据字典获取SaleOrderShop集合
        /// <summary>
        /// 根据字典获取SaleOrderShop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleOrderShop> GetList(IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取SaleOrderShop数据集
        /// <summary>
        /// 根据字典获取SaleOrderShop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleOrderShop集合
        /// <summary>
        /// 分页获取SaleOrderShop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderShop> GetPageList(PageListBySql<SaleOrderShop> page, IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).UpdateField(fieldList, whereConditionList);
        }
        #endregion



        #region 用于门店排单
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="searchDate"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
       public static IList<ShopOrder> GetShopOrder(string searchDate, int wid) 
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(wid.ToString()).GetShopOrder(searchDate,wid);
        }

        #endregion

        #endregion
    }

    public partial class SaleOrderShopBLO
    {
        private static int _remarkLength = 200;
        /// <summary>
        /// 查询门店是否存在未确认订单
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <returns></returns>
        public static SaleOrderShop ExistsUnConfirm(int shopId, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetUnConfirmOrder(shopId);
        }

        /// <summary>
        /// 追加订单到原来的订单
        /// </summary>
        /// <param name="oldOrder">老订单</param>
        /// <param name="newOrder">新订单</param>
        /// <param name="details">新订单商品明细</param>
        /// <param name="detailsExts">新订单商品明细护展</param>
        /// <returns></returns>
        public static BackMessage<bool> AppendOrder(SaleOrderShop oldOrder, SaleOrderShop newOrder, IList<SaleOrderShopDetails> details, IList<SaleOrderShopDetailsExt> detailsExts, int Wid,BaseUserModel user=null)
        {
            //合并订单数据
            oldOrder.ModifyTime = DateTime.Now;
            oldOrder.ModifyUserID = newOrder.CreateUserID;
            oldOrder.ModifyUserName = newOrder.CreateUserName;
            if(!string.IsNullOrEmpty(newOrder.Remark))
            {
                oldOrder.Remark = newOrder.Remark;
            }


            //商品明细检查
            var checkOrder = CheckDetails(details, oldOrder.OrderId);
            if(details.Count<=0)
            {
                return BackMessage<bool>.FailBack(false,"订单商品明细为空");
            }
            if (!checkOrder.IsSuccess)
            {
                return checkOrder;
            }
            if (detailsExts != null)
            {
                if (detailsExts.Count != details.Count)
                {
                    return BackMessage<bool>.FailBack(false, "商品明细列表与明细扩展列表不匹配");
                }
            }

            //取老订单商品明细
            var oldDetail = GetDetailByOrderId(oldOrder.OrderId,Wid);
            var oldDetailExt = GetDetailExsByOrderId(oldOrder.OrderId,Wid);
            var newDetails = new List<SaleOrderShopDetails>();
            var newDetailsExt = new List<SaleOrderShopDetailsExt>();
            //将原有的details装入新的列表
            foreach (var detailse in oldDetail)
            {
                newDetails.Add(detailse);
            }
            foreach (var detail in details)
            {
                newDetails.Add(detail);
            }
            foreach (var detailsExt in oldDetailExt)
            {
                newDetailsExt.Add(detailsExt);
            }
            foreach (var detailsExt in detailsExts)
            {
                newDetailsExt.Add(detailsExt);
            }
            
            //商品明细合并
            var result = MergeList(newDetails, newDetailsExt);
            //订单数据重算
            oldOrder.CouponAmt = 0;
            oldOrder.TotalAddAmt = newDetails.Sum(x => x.SubAddAmt);
            oldOrder.TotalPoint = newDetails.Where(x=>x.SubPoint.HasValue).Sum(x => x.SubPoint.Value);
            oldOrder.TotalProductAmt = newDetails.Where(x => x.SubAmt.HasValue).Sum(x => x.SubAmt.Value);
            oldOrder.PayAmount = oldOrder.TotalAddAmt.Value + oldOrder.TotalProductAmt;
            oldOrder.TotalPoint = newDetails.Where(x=>x.SubPoint.HasValue).Sum(x => x.SubPoint.Value);
            oldOrder.TotalBasePoint = newDetails.Sum(x => x.SubBasePoint);

            //使用修改订单流程
            return ModifyOrder(oldOrder, newDetails, newDetailsExt,Wid,user);
        }

         /// <summary>
         /// 修改订单
         /// </summary>
        /// <param name="order">订单</param>
         /// <param name="details">订单商品明细</param>
         /// <param name="detailsExts">订单商品明细扩展</param>
         /// <returns></returns>
        public static BackMessage<bool> ModifyOrder(SaleOrderShop order, IList<SaleOrderShopDetails> details, IList<SaleOrderShopDetailsExt> detailsExts, int Wid,BaseUserModel user=null)
         {
             var old = GetModel(order.OrderId, Wid);
             if(old==null)
             {
                 return BackMessage<bool>.FailBack(false, "没有这个订单");
             }
             
             //数据检查
             order.WID = Wid;
             var checkOrder = CheckOrder(order);
             if (!checkOrder.IsSuccess)
             {
                 return checkOrder;
             }

             if(details.Count<=0)
             {
                 #region 删除订单处理
                 var connectionDel = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetConnection();
                 connectionDel.Open();
                 var transDel = connectionDel.BeginTransaction();
                 try
                 {
                     var flag = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Delete(order, connectionDel, transDel);
                     if (flag <= 0)
                     {
                         transDel.Rollback();
                         return BackMessage<bool>.FailBack(false, "删除订单失败");
                     }

                     var i = 0;
                     //清除原有明细
                     var bFlag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsDAO>(Wid.ToString()).DeleteByOrderId(order.OrderId,connectionDel,transDel);
                     if (!bFlag)
                     {
                         transDel.Rollback();
                         return BackMessage<bool>.FailBack(false, "清除原有订单明细失败");
                     }

                     bFlag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsExtDAO>(Wid.ToString()).DeleteByOrderId(order.OrderId,connectionDel,transDel);
                     if (!bFlag)
                     {
                         transDel.Rollback();
                         return BackMessage<bool>.FailBack(false, "清除原有订单明细扩展失败");
                     }

                     transDel.Commit();
                     return BackMessage<bool>.SuccessBack(true,"订单商品数为0，已删除订单");
                 }
                 catch (Exception ex)
                 {
                     transDel.Rollback();
                     return BackMessage<bool>.FailBack(false, ex.Message);
                 }
                 finally
                 {
                     transDel.Dispose();
                     connectionDel.Close();
                     connectionDel.Dispose();
                 }
                 #endregion
             }
             
             checkOrder = CheckDetails(details, order.OrderId);
             if (!checkOrder.IsSuccess)
             {
                 return checkOrder;
             }

             if (detailsExts != null)
             {
                 if (detailsExts.Count != details.Count)
                 {
                     return BackMessage<bool>.FailBack(false, "商品明细列表与明细扩展列表不匹配");
                 }
             }

             //开始事务
             var connection = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetConnection();
             connection.Open();
             var trans = connection.BeginTransaction();
             try
             {
                 var flag = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Edit(order, connection, trans);
                 if (flag <= 0)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "修改订单失败");
                 }

           
                 var i = 0;
                 //清除原有明细
                 var bFlag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsDAO>(Wid.ToString()).DeleteByOrderId(order.OrderId, connection, trans);
                 if(!bFlag)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false,"清除原有订单明细失败");
                 }
                 foreach (var detail in details)
                 {
                     detail.SerialNumber = i + 1;
                     detail.OrderID = order.OrderId;
                     detail.ID = detail.WID.ToString() + Guid.NewGuid();
                     detail.WID = Wid;
                     detail.ModifyTime = DateTime.Now;
                     detail.ModifyUserID = user.UserId;
                     detail.ModifyUserName = user.UserName;
                     flag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsDAO>(Wid.ToString()).Save(detail, connection, trans);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "保存订单商品明细失败");
                     }
                     detailsExts[i].ID = detail.ID;
                     detailsExts[i].OrderID = order.OrderId;
                     i++;
                 }

                 bFlag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsExtDAO>(Wid.ToString()).DeleteByOrderId(order.OrderId, connection, trans);
                 if (!bFlag)
                 {
                     trans.Rollback();
                     return BackMessage<bool>.FailBack(false, "清除原有订单明细扩展失败");
                 }
                 foreach (var detailExt in detailsExts)
                 {
                     flag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsExtDAO>(Wid.ToString()).Save(detailExt, connection, trans);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "保存订单商品明细扩展数据失败");
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
        /// 合并订单商品列表相同数据
        /// </summary>
        /// <param name="details">订单商品列表</param>
        /// <returns></returns>
        private static BackMessage<bool> MergeList(IList<SaleOrderShopDetails> details, IList<SaleOrderShopDetailsExt> detailsExts)
        {
            for (int i = details.Count-1; i >0; i--)
            {
                var detail = details[i];
                for (int j = i-1; j >= 0; j--)
                {
                    //同一商品，并且价格相同才认为是同一商品
                    if(detail.ProductId==details[j].ProductId && detail.SalePrice==details[j].SalePrice)
                    {
                        detail.PreQty += details[j].PreQty;
                        detail.UnitQty += details[j].UnitQty;
                        detail.SalePackingQty = detail.SalePackingQty;
                        detail.SalePrice = detail.SalePrice;
                        detail.SaleQty = detail.PreQty;
                        detail.ShopAddPerc = detail.ShopAddPerc;
                        detail.ShopPoint = detail.ShopPoint;
                        detail.UnitPrice = detail.UnitPrice;
                        detail.UnitQty = detail.UnitQty;
                        detail.VendorPerc1 = detail.VendorPerc1;
                        detail.VendorPerc2 = detail.VendorPerc2;
                        if (!detail.PromotionShopPoint.HasValue || detail.PromotionShopPoint.Value <= 0)
                        {
                            detail.SubPoint = detail.ShopPoint * detail.UnitQty;
                        }
                        else
                        {
                            detail.SubPoint = detail.PromotionShopPoint * detail.UnitQty;
                        }
                        detail.PromotionUnitPrice = detail.UnitPrice;
                        detail.SubAmt = detail.SalePrice * detail.PreQty; //没有促销价格，按原价计算

                        detail.SubAddAmt = detail.SubAmt * detail.ShopAddPerc ;
                        detail.SubBasePoint = detail.BasePoint * detail.SubAmt;
                        detail.SubVendor1Amt = detail.VendorPerc1 * detail.SubAmt ;
                        detail.SubVendor2Amt = detail.VendorPerc2 * detail.SubAmt;
                        details.Remove(details[j]);
                        detailsExts.Remove(detailsExts[j]);
                    }
                }
            }
            return ReMarkSerialNumber(details);
        }

        /// <summary>
        /// 取订单商品扩展明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static IList<SaleOrderShopDetailsExt> GetDetailExsByOrderId(string orderId, int Wid)
        {
            var condtion = new Dictionary<string, object>();
            condtion.Add("OrderId",orderId);
            return DALFactory.GetLazyInstance<ISaleOrderShopDetailsExtDAO>(Wid.ToString()).GetList(condtion);
        }

        /// <summary>
        /// 取订单商品明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static IList<SaleOrderShopDetails> GetDetailByOrderId(string orderId, int Wid)
        {
            var condtion = new Dictionary<string, object>();
            condtion.Add("OrderId", orderId);
            return DALFactory.GetLazyInstance<ISaleOrderShopDetailsDAO>(Wid.ToString()).GetList(condtion);
        }

        /// <summary>
        /// 创建一个新的订单
        /// </summary>
        /// <param name="order">订单</param>
        /// <param name="details">商品明细</param>
        /// <param name="detailsExts">商品明细护展</param>
        /// <returns></returns>
        public static BackMessage<bool> NewOrder(SaleOrderShop order, IList<SaleOrderShopDetails> details, IList<SaleOrderShopDetailsExt> detailsExts, int Wid,BaseUserModel user)
        {
            //数据检查

            order.WID = Wid;
            var checkOrder = CheckOrder(order);
            if (!checkOrder.IsSuccess)
            {
                return checkOrder;
            }
    
            checkOrder = CheckDetails(details, order.OrderId);
            if (details.Count <= 0)
            {
                return BackMessage<bool>.FailBack(false, "订单商品明细为空");
            }
            if (!checkOrder.IsSuccess)
            {
                return checkOrder;
            }

            if (detailsExts != null)
            {
                if (detailsExts.Count != details.Count)
                {
                    return BackMessage<bool>.FailBack(false, "商品明细列表与明细扩展列表不匹配");
                }
            }


            //开始事务
            var connection = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                var flag = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Save(order, connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "保存订单失败");
                }

                var i = 0;
                foreach (var detail in details)
                {
                    detail.SerialNumber = i + 1;
                    detail.ID = detail.WID.ToString() + Guid.NewGuid();
                    detail.WID = Wid;
                    detail.ModifyTime = DateTime.Now;
                    detail.ModifyUserID = user.UserId;
                    detail.ModifyUserName = user.UserName;
                    flag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsDAO>(Wid.ToString()).Save(detail, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存订单商品明细失败");
                    }
                    detailsExts[i].ID = detail.ID;
                    detailsExts[i].OrderID = order.OrderId;
                    i++;
                }
                foreach (var detailExt in detailsExts)
                {
                    flag = DALFactory.GetLazyInstance<ISaleOrderShopDetailsExtDAO>(Wid.ToString()).Save(detailExt, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存订单商品明细扩展数据失败");
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
        /// 订单数据检查
        /// </summary>
        /// <param name="order">订单数据</param>
        /// <returns></returns>
        private static BackMessage<bool> CheckOrder(SaleOrderShop order)
        {
            if (!order.OrderDate.HasValue)
            {
                order.OrderDate = DateTime.Now;
            }
            if (order.ShopID <= 0)
            {
                return BackMessage<bool>.FailBack(false, "没有输入下单门店ID");
            }
            if (string.IsNullOrEmpty(order.OrderId))
            {
                return BackMessage<bool>.FailBack(false, "订单编号不能为空");
            }
            if (!string.IsNullOrEmpty(order.Remark) && order.Remark.Length > _remarkLength)
            {
                return BackMessage<bool>.FailBack(false, string.Format("备注信息超过{0}长度", _remarkLength));
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 订单商品明细检查
        /// </summary>
        /// <param name="details">商品明细</param>
        /// <returns></returns>
        private static BackMessage<bool> CheckDetails(IList<SaleOrderShopDetails> details, string orderId = "")
        {
            if (details.Count <= 0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }

            var i = 0;
            foreach (var detail in details)
            {
                i++;
                if (detail.ProductId <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("第{0}条商品的商品编号错误", i));
                }
                if (detail.PreQty <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("第{0}条商品的预定数量小于等于0", i));
                }
                if (!string.IsNullOrEmpty(orderId))
                {
                    detail.OrderID = orderId;
                }
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="orderId">订单编号</param>
        ///  <param name="status">订单状态，8为客户取消，9为客服关闭</param>
        /// <param name="reason">订单关闭原因</param>
        /// <returns></returns>
        public static  BackMessage<bool> CloseOrder(int Wid,string orderId,int status,string reason="",BaseUserModel user=null)
        {
            var list = new List<string>();
            list.Add(orderId);
            return CloseOrders(Wid, list, status, reason, user);
        } 

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderIds">订单ID列表</param>
        /// <param name="status">状态</param>
        /// <param name="reason">取消原因</param>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public static BackMessage<bool> CloseOrders(int Wid,IList<string> orderIds,int status,string reason="",BaseUserModel user=null)
        {
             var connection = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetConnection();
             connection.Open();
             var trans = connection.BeginTransaction();
             try
             {
                 foreach (var orderId in orderIds)
                 {
                     var order = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetModel(orderId);
                     if (order == null)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "没有这个订单");
                     }
                     //订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
                     string msg = "";
                     switch (order.Status)
                     {
                         case 0:
                             break;
                         case 1:
                             break;
                         case 2:
                             msg = "已确认订单不能取消";
                             break;
                         case 3:
                             msg = "已确认订单不能取消";
                             break;
                         case 4:
                             msg = "已确认订单不能取消";
                             break;
                         case 5:
                             msg = "已确认订单不能取消";
                             break;
                         case 6:
                             msg = "已确认订单不能取消";
                             break;
                         case 7:
                             msg = "订单交易已完成，不能取消";
                             break;
                         case 8:
                             msg = "订单已被取消";
                             break;
                         case 9:
                             msg = "订单已被关闭";
                             break;
                         default:
                             msg = "订单状态异常";
                             break;
                     }
                     if (!string.IsNullOrEmpty(msg))
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, msg);
                     }
                     order.Status = status;
                     order.CloseDate = DateTime.Now;
                     order.CloseReason = reason;
                     order.ModifyTime = DateTime.Now;



                     var listField = new List<Field>();
                     listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "Status", FieldValue = order.Status, ParamterName = "Status" });
                     listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "CloseDate", FieldValue = order.CloseDate, ParamterName = "CloseDate" });
                     listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "CloseReason", FieldValue = order.CloseReason, ParamterName = "CloseReason" });
                     listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ModifyTime", FieldValue = order.ModifyTime, ParamterName = "ModifyTime" });
                     if (status == 8)
                     {
                         listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "CancelDate", FieldValue = DateTime.Now, ParamterName = "CancelDate" });
                     }
                     if (user != null)
                     {
                         listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "ModifyUserID", FieldValue = user.UserId, ParamterName = "ModifyUserID" });
                         listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "ModifyUserName", FieldValue = user.UserName, ParamterName = "ModifyUserName" });
                     }

                     var listWhere = new List<WhereCondition>();
                     listWhere.Add(new WhereCondition()
                     {
                         AttachSymbol = Attach.And,
                         CompareSymbol = Compare.Equals,
                         FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "OrderID", FieldValue = orderId, ParamterName = "OrderID" }
                     });
                     var flag = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).UpdateField(listField, listWhere, connection, trans);
                     if (flag <= 0)
                     {
                         trans.Rollback();
                         return BackMessage<bool>.FailBack(false, "修改订单状态失败");
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
        /// 配送完成
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public static BackMessage<bool> ConfirmReceiver(string orderId, int Wid,BaseUserModel user=null)
        {
            //订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
            var order = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetModel(orderId);
            if (order == null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个订单");
            }
            
            string msg = "";
            switch (order.Status)
            {
                case 0:
                    msg = "订单不在配送状态";
                    break;
                case 1:
                    msg = "订单不在配送状态";
                    break;
                case 2:
                    msg = "订单不在配送状态";
                    break;
                case 3:
                    msg = "订单不在配送状态";
                    break;
                case 4:
                    msg = "订单不在配送状态";
                    break;
                case 5:
                    msg = "订单不在配送状态";
                    break;
                case 6:
                    break;
                case 7:
                    msg = "订单交易已完成，不能确认收货";
                    break;
                case 8:
                    msg = "订单已被取消";
                    break;
                case 9:
                    msg = "订单已被关闭";
                    break;
                default:
                    msg = "订单状态异常";
                    break;
            }
            if (!string.IsNullOrEmpty(msg))
            {
                return BackMessage<bool>.FailBack(false, msg);
            }
            order.Status = 7;
            order.ModifyTime = DateTime.Now;
            order.ShippingEndDate = DateTime.Now;


            var listField = new List<Field>();
            listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "Status", FieldValue = order.Status, ParamterName = "Status" });
            listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ShippingEndDate", FieldValue = order.ShippingEndDate, ParamterName = "ShippingEndDate" });
            listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ModifyTime", FieldValue = DateTime.Now, ParamterName = "ModifyTime" });
            if (user != null)
            {
                listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "ModifyUserID", FieldValue = user.UserId, ParamterName = "ModifyUserID" });
                listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "ModifyUserName", FieldValue = user.UserName, ParamterName = "ModifyUserName" });
            }
            var listWhere = new List<WhereCondition>();
            listWhere.Add(new WhereCondition()
            {
                AttachSymbol = Attach.And,
                CompareSymbol = Compare.Equals,
                FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "OrderID", FieldValue = orderId, ParamterName = "OrderID" }
            });
            var flag = UpdateField(listField, listWhere,Wid);
            if (flag > 0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "修改订单状态失败");
            }
        }

        /// <summary>
        /// 确认订单
        /// </summary>
        /// <returns></returns>
        public static BackMessage<bool> ConfirmOrderShop(string orderId, int Wid, BaseUserModel user = null)
        {
            //订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
            var order = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetModel(orderId);
            if (order == null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个订单");
            }

            string msg = "";
            switch (order.Status)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    msg = "已确认的订单";
                    break;
                case 3:
                    msg = "已确认的订单";
                    break;
                case 4:
                    msg = "已确认的订单";
                    break;
                case 5:
                    msg = "订单不在配送状态";
                    break;
                case 6:
                    msg = "订单不在配送状态";
                    break;
                case 7:
                    msg = "订单交易已完成";
                    break;
                case 8:
                    msg = "订单已被取消";
                    break;
                case 9:
                    msg = "订单已被关闭";
                    break;
                default:
                    msg = "订单状态异常";
                    break;
            }
            if (!string.IsNullOrEmpty(msg))
            {
                return BackMessage<bool>.FailBack(false, msg);
            }
            order.Status = 2;
            order.ModifyTime = DateTime.Now;
            order.ShippingEndDate = DateTime.Now;
            var listField = new List<Field>();
            listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "Status", FieldValue = order.Status, ParamterName = "Status" });
            listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ShippingEndDate", FieldValue = order.ShippingEndDate, ParamterName = "ShippingEndDate" });
            listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ModifyTime", FieldValue = DateTime.Now, ParamterName = "ModifyTime" });
            if (user != null)
            {
                listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "ModifyUserID", FieldValue = user.UserId, ParamterName = "ModifyUserID" });
                listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "ModifyUserName", FieldValue = user.UserName, ParamterName = "ModifyUserName" });
            }
            var listWhere = new List<WhereCondition>();
            listWhere.Add(new WhereCondition()
            {
                AttachSymbol = Attach.And,
                CompareSymbol = Compare.Equals,
                FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "OrderID", FieldValue = orderId, ParamterName = "OrderID" }
            });
            var flag = UpdateField(listField, listWhere, Wid);
            if (flag > 0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "修改订单状态失败");
            }
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public static IList<SaleOrderShop> Query(OrderQuery query, out int total, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).Query(query,out total);
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="order">订单</param>
        /// <param name="details">明细</param>
        /// <param name="detailsExts">明细扩展</param>
        /// <param name="bDeleteOld">是否覆盖旧数据</param>
        /// <returns></returns>
        public static BackMessage<bool> SubmitOrder(int Wid,int shopId,SaleOrderShop order, IList<SaleOrderShopDetails> details, IList<SaleOrderShopDetailsExt> detailsExts,bool bDeleteOld=false,BaseUserModel user=null)
        {
            var existOrder = GetModel(order.OrderId, Wid);

            //是否存在未确认订单
            var old = ExistsUnConfirm(shopId,Wid);
            
            //没有未确认订单，新增
            if(old==null)
            {
                if(existOrder!=null)
                {
                    return BackMessage<bool>.FailBack(false, "你的订单状态发生了变化，请重新提交");
                }
                return NewOrder(order, details, detailsExts,Wid,user);
            }

            //覆盖旧数据
            if(bDeleteOld)
            {
                if (existOrder != null && existOrder.Status != 1)
                {
                    return BackMessage<bool>.FailBack(false, "你的订单状态发生了变化，请重新提交");
                }
                return ModifyOrder(order, details, detailsExts,Wid,user);
            }
            else
            {
                if (old != null && old.Status != 1)
                {
                    return BackMessage<bool>.FailBack(false, "你的订单状态发生了变化，请重新提交");
                }
                return AppendOrder(old, order, details, detailsExts,Wid,user);
            }
        }

        /// <summary>
        /// 修改订单备注
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public static BackMessage<bool> UpdateRemark(string orderId, string remark, int Wid,BaseUserModel user=null)
       {
           var listField = new List<Field>();
           listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "Remark", FieldValue = remark, ParamterName = "Remark" });
           listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ModifyTime", FieldValue = DateTime.Now, ParamterName = "ModifyTime" });
           if (user != null)
           {
               listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "ModifyUserID", FieldValue = user.UserId, ParamterName = "ModifyUserID" });
               listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "ModifyUserName", FieldValue = user.UserName, ParamterName = "ModifyUserName" });
           }

           var listWhere = new List<WhereCondition>();
           listWhere.Add(new WhereCondition()
           {
               AttachSymbol = Attach.And,
               CompareSymbol = Compare.Equals,
               FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "OrderID", FieldValue = orderId, ParamterName = "OrderID" }
           });
           var flag = UpdateField(listField, listWhere,Wid);
           if (flag > 0)
           {
               return BackMessage<bool>.SuccessBack(true);
           }
           else
           {
               return BackMessage<bool>.FailBack(false, "修改订单备注失败");
           }
       }

        /// <summary>
        /// 修改订单单行备注
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="detailId">明细ID</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public static BackMessage<bool> UpdateRemark(string orderId, string detailId, string remark, int Wid,BaseUserModel user=null)
       {
           var listField = new List<Field>();
           listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "Remark", FieldValue = remark, ParamterName = "Remark" });
           listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ModifyTime", FieldValue = DateTime.Now, ParamterName = "ModifyTime" });
           if (user != null)
           {
               listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "ModifyUserID", FieldValue = user.UserId, ParamterName = "ModifyUserID" });
               listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "ModifyUserName", FieldValue = user.UserName, ParamterName = "ModifyUserName" });
           }

           var listWhere = new List<WhereCondition>();
           listWhere.Add(new WhereCondition()
           {
               AttachSymbol = Attach.And,
               CompareSymbol = Compare.Equals,
               FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "OrderID", FieldValue = orderId, ParamterName = "OrderID" }
           });
           listWhere.Add(new WhereCondition()
           {
               AttachSymbol = Attach.And,
               CompareSymbol = Compare.Equals,
               FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "ID", FieldValue = detailId, ParamterName = "ID" }
           });

           var flag = UpdateField(listField, listWhere,Wid);
           if (flag > 0)
           {
               return BackMessage<bool>.SuccessBack(true);
           }
           else
           {
               return BackMessage<bool>.FailBack(false, "修改单行备注失败");
           }
       }
        
        /// <summary>
        /// 将订单中的商品导入购物车
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="shopId">门店ID</param>
        /// <returns></returns>
        public static BackMessage<bool> LoadOrderToCart(string orderId, int shopId,int Wid,BaseUserModel user)
        {
            var details = GetDetailByOrderId(orderId,Wid);
            var list = new List<SaleCart>();
            if(details==null || details.Count<=0)
            {
                return BackMessage<bool>.FailBack(false, "订单中没有商品");
            }
            foreach (var detail in details)
            {
                var cart = new SaleCart()
                               {
                                   WID = Wid,
                                   ShopID = shopId,
                                   XSUserID = user.UserId,
                                   ProductID = detail.ProductId,
                                   PreQty = detail.PreQty,
                                   Remark=detail.Remark,
                                   CreateTime = DateTime.Now,
                                   ModifyTime = DateTime.Now,
                                   ModifyUserID = user.UserId,
                                   ModifyUserName = user.UserName
                               };
                list.Add(cart);
            }
            return SaleCartBLO.AppendProduct(list,user, false,Wid);
        }

        /// <summary>
        /// 将订单类型转为字符
        /// </summary>
        /// <param name="orderStatus">订单类型</param>
        /// <returns></returns>
        public static string ConvertStatusToString(int orderStauts)
        {
            return ConvertStatusToString((OrderStatus) orderStauts);
        }

        /// <summary>
        /// 将订单类型转为字符
        /// </summary>
        /// <param name="orderStatus">订单类型</param>
        /// <returns></returns>
        public static string ConvertStatusToString(OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.Draft:
                    return "代客下单";
                case OrderStatus.WaitConfirm:
                    return "等待确认";
                case OrderStatus.WaitPick:
                    return "等待拣货";
                case OrderStatus.Picking:
                    return "正在拣货";
                case OrderStatus.PickFinished:
                    return "等待装箱";
                case OrderStatus.Printed:
                    return "等待配送";
                case OrderStatus.Delivering:
                    return "正在配送";
                case OrderStatus.Finished:
                    return "交易完成";
                case OrderStatus.CancelByCustomer:
                    return "客户交易取消";
                case OrderStatus.CancelByService:
                    return "客服交易关闭";
                case OrderStatus.Cancel:
                    return "交易取消";
                default:
                    return "交易状态不明";
            }
        }

        /// <summary>
        /// 转换门店类型为字符串
        /// </summary>
        /// <param name="shopType"></param>
        /// <returns></returns>
        public static  string ConvertShopTypeToString(int shopType)
        {
            return shopType == 1 ? "签约店" : "加盟店";
        }

        /// <summary>
        /// 更新订单字段，不进行数据检查（请在Action中完成检查后调用）
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="FieldName"></param>
        /// <param name="FiledValues"></param>
        /// <returns></returns>
        public static BackMessage<bool> UpdateFieldWithUnCheck(string orderId,IList<string> FieldName,IList<object> FiledValues,int WID, BaseUserModel user=null)
        {
            var listField = new List<Field>();
            listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ModifyTime", FieldValue = DateTime.Now, ParamterName = "ModifyTime" });
            if (user != null)
            {
                listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "ModifyUserID", FieldValue = user.UserId, ParamterName = "ModifyUserID" });
                listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "ModifyUserName", FieldValue = user.UserName, ParamterName = "ModifyUserName" });
            }

            var listWhere = new List<WhereCondition>();
            listWhere.Add(new WhereCondition()
            {
                AttachSymbol = Attach.And,
                CompareSymbol = Compare.Equals,
                FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "OrderID", FieldValue = orderId, ParamterName = "OrderID" }
            });

            Type type = new SaleOrderShop().GetType();
            var i = 0;
            foreach (var name in FieldName)
            {
                var propertyInfo = type.GetProperty(name);
                if(propertyInfo!=null)
                {
                    var proType = propertyInfo.PropertyType;
                    int len = 0;
                    var dbType=GetDBType(proType, out len);
                    listField.Add(new Field() { FieldDbType = dbType, FieldLength = len, FieldName = name, FieldValue = FiledValues[i], ParamterName = name });
                }
                i++;
            }
            var flag = UpdateField(listField, listWhere, WID);
            if (flag > 0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "更新数据失败");
            }
        } 

        /// <summary>
        /// 为明细列表标序
        /// </summary>
        /// <param name="details">明细列表</param>
        /// <returns></returns>
        private static  BackMessage<bool> ReMarkSerialNumber(IList<SaleOrderShopDetails> details)
        {
            int i = 0;
            foreach (var saleOrderShopDetailse in details)
            {
                i++;
                saleOrderShopDetailse.SerialNumber = i;
            }
            return BackMessage<bool>.SuccessBack(true);
        }


        /// <summary>
        /// 编辑订单，仅修改单个明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="detail">明细</param>
        /// <param name="editType">编辑类型 0：添加 1：修改 2：删除</param>
        /// <returns></returns>
        public static BackMessage<bool> EditSingleDetail(string orderId, SaleOrderShopDetails detail,SaleOrderShopDetailsExt detailsExt=null,int editType=0,BaseUserModel user=null, int Wid=0)
        {
            var orderModel = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(Wid.ToString()).GetModel(orderId);
            var details = GetDetailByOrderId(orderId, Wid);
            var detailsExts = GetDetailExsByOrderId(orderId, Wid);
            var oldDetail = details.Where(x => x.ProductId == detail.ProductId).FirstOrDefault();
            var index = -1;

            var newOrderDetail = new SaleOrderShopDetails();
            #region 参数加工重算
            if (editType == 0){
                //新增
                if (oldDetail == null)
                {
                    detail.OrderID = orderId;
                    detail.ID = Wid.ToString() + Guid.NewGuid();
                    detail.SerialNumber = details[details.Count - 1].SerialNumber + 1;
                    detail.ModifyTime = DateTime.Now;
                    detail.ModifyUserID = user.UserId;
                    detail.ModifyUserName = user.UserName;
                    details.Add(detail);
                    detailsExt.OrderID = orderId;
                    detailsExt.ID = detail.ID;
                    detailsExts.Add(detailsExt);
                    newOrderDetail = detail;
                }
            }
            if (editType == 1)
            {
                if (oldDetail != null)
                {
                    detail.ModifyTime = DateTime.Now;
                    detail.ModifyUserID = user.UserId;
                    detail.ModifyUserName = user.UserName;
                    newOrderDetail = detail;
                    details.Remove(oldDetail);
                    details.Add(newOrderDetail);
                }
            }
            if (editType == 2)
            {
                if (oldDetail != null)
                {
                    var oldDetailExt = detailsExts.Where(x => x.ID == oldDetail.ID).FirstOrDefault();
                    details.Remove(oldDetail);
                    detailsExts.Remove(oldDetailExt);
                }
            }

            if(editType!=2)
            {
                if (newOrderDetail.PromotionShopPoint <= 0)
                {
                    newOrderDetail.SubPoint = newOrderDetail.ShopPoint * newOrderDetail.UnitQty;
                }
                else
                {
                    newOrderDetail.SubPoint = newOrderDetail.PromotionShopPoint * newOrderDetail.UnitQty;
                }
                newOrderDetail.PromotionUnitPrice = newOrderDetail.UnitPrice;
                newOrderDetail.SubAmt = newOrderDetail.SalePrice * newOrderDetail.PreQty; //没有促销价格，按原价计算
                newOrderDetail.SubAddAmt = newOrderDetail.SubAmt*newOrderDetail.ShopAddPerc;
                newOrderDetail.SubBasePoint = newOrderDetail.BasePoint * newOrderDetail.SubAmt;
                newOrderDetail.SubVendor1Amt = newOrderDetail.VendorPerc1 * newOrderDetail.SubAmt *
                                                      0.01m;
                newOrderDetail.SubVendor2Amt = newOrderDetail.VendorPerc2 * newOrderDetail.SubAmt *
                                                      0.01m; 
            }
            //订单数据重算
            orderModel.CouponAmt = 0;
            orderModel.TotalAddAmt = details.Sum(x => x.SubAddAmt);
            orderModel.TotalProductAmt = details.Where(x => x.SubAmt.HasValue).Sum(x => x.SubAmt.Value);
            orderModel.PayAmount = orderModel.TotalAddAmt.Value + orderModel.TotalProductAmt;
            orderModel.TotalPoint = details.Where(x => x.SubPoint.HasValue).Sum(x => x.SubPoint.Value);
            orderModel.TotalBasePoint = details.Sum(x => x.SubBasePoint);
            orderModel.ModifyTime = DateTime.Now;
            orderModel.ModifyUserID = user.UserId;
            orderModel.ModifyUserName = user.UserName;
            #endregion

            ReMarkSerialNumber(details);
            return ModifyOrder(orderModel, details, detailsExts, Wid,user);

        } 

        /// <summary>
        /// 批量删除订单中商品
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="productIds">商品ID</param>
        /// <param name="user"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static BackMessage<bool> DeleteProductsFromOrderShop(string orderId,IList<int> productIds,BaseUserModel user=null,int wid=0)
        {
            var orderModel = DALFactory.GetLazyInstance<ISaleOrderShopDAO>(wid.ToString()).GetModel(orderId);
            if (orderModel == null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个订单");
            }
            var details = GetDetailByOrderId(orderId, wid);
            var detailsExts = GetDetailExsByOrderId(orderId, wid);
            var extsIds = new List<string>();
            for (int i = 0; i < details.Count; i++)
            {
                var d = details[i];
                if(productIds.Contains(d.ProductId))
                {
                    details.RemoveAt(i);
                    detailsExts.RemoveAt(i);
                }
            }
            ReMarkSerialNumber(details);
            //订单数据重算
            orderModel.CouponAmt = 0;
            orderModel.TotalAddAmt = details.Sum(x => x.SubAddAmt);
            orderModel.TotalProductAmt = details.Where(x => x.SubAmt.HasValue).Sum(x => x.SubAmt.Value);
            orderModel.PayAmount = orderModel.TotalAddAmt.Value + orderModel.TotalProductAmt;
            orderModel.TotalPoint = details.Where(x => x.SubPoint.HasValue).Sum(x => x.SubPoint.Value);
            orderModel.TotalBasePoint = details.Sum(x => x.SubBasePoint);
            orderModel.ModifyTime = DateTime.Now;
            orderModel.ModifyUserID = user.UserId;
            orderModel.ModifyUserName = user.UserName;
            return ModifyOrder(orderModel, details, detailsExts, wid, user);
        } 


        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="t">类型</param>
        /// <returns></returns>
        private static DbType GetDBType(Type t,out int length)
        {
            if(t==typeof(int))
            {
                length = 4;
                return DbType.Int32;
            }
            if(t==typeof(long))
            {
                length = 8;
                return DbType.Int64;
            }
            if(t==typeof(string))
            {
                length = 300;
                return DbType.String;
            }
            if(t==typeof(DateTime))
            {
                length = 20;
                return DbType.DateTime;
            }
            if(t==typeof(decimal))
            {
                length = 18;
                return DbType.Decimal;
            }
            if(t==typeof(double))
            {
                length = 18;
                return DbType.Double;
            }
            length = 300;
            return DbType.String;
        }
    }
}