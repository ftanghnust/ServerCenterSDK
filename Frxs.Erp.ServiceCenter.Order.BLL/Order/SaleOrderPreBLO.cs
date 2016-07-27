
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility;
using Frxs.Erp.ServiceCenter.Order.BLL.Order;
using Frxs.Erp.ServiceCenter.Order.Model.Deliver;

namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// SaleOrderPre业务逻辑类
    /// </summary>
    public partial class SaleOrderPreBLO
    {
        #region 成员方法
        #region 根据主键验证SaleOrderPre是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPre是否存在
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleOrderPre model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个SaleOrderPre
        /// <summary>
        /// 添加一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleOrderPre model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Save(model);
        }
        #endregion


        #region 更新一个SaleOrderPre
        /// <summary>
        /// 更新一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleOrderPre model, int Wid, IDbConnection conn = null, IDbTransaction tran = null)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Edit(model);
        }
        #endregion


        #region 删除一个SaleOrderPre
        /// <summary>
        /// 删除一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleOrderPre model, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPre
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPre
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string orderId, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).LogicDelete(orderId);
        }
        #endregion


        #region 根据字典获取SaleOrderPre对象
        /// <summary>
        /// 根据字典获取SaleOrderPre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderPre对象</returns>
        public static SaleOrderPre GetModel(IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetModel(conditionDict);
        }
        #endregion

        #region 根据主键获取SaleOrderPre对象
        /// <summary>
        /// 根据主键获取SaleOrderPre对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        public static SaleOrderPre GetModel(string orderId, int Wid, IDbConnection conn = null, IDbTransaction tran = null)
        {
            if (conn == null || tran == null)
            {
                return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetModel(orderId);
            }
            else
            {
                return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetModel(conn, tran, orderId);
            }

        }

        #endregion


        #region 根据字典获取SaleOrderPre集合
        /// <summary>
        /// 根据字典获取SaleOrderPre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<SaleOrderPre> GetList(IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取SaleOrderPre数据集
        /// <summary>
        /// 根据字典获取SaleOrderPre数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleOrderPre集合
        /// <summary>
        /// 分页获取SaleOrderPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderPre> GetPageList(PageListBySql<SaleOrderPre> page, IDictionary<string, object> conditionDict, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, int Wid, IDbConnection conn = null, IDbTransaction tran = null)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #endregion
    }


    public partial class SaleOrderPreBLO
    {
        /// <summary>
        /// 订单数据检查
        /// </summary>
        /// <param name="orderPre">订单数据</param>
        /// <returns></returns>
        private static BackMessage<bool> CheckOrder(SaleOrderPre orderPre)
        {
            if (!orderPre.OrderDate.HasValue)
            {
                orderPre.OrderDate = DateTime.Now;
            }
            if (orderPre.ShopID <= 0)
            {
                return BackMessage<bool>.FailBack(false, "没有输入下单门店ID");
            }
            if (string.IsNullOrEmpty(orderPre.OrderId))
            {
                return BackMessage<bool>.FailBack(false, "订单编号不能为空");
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public static IList<SaleOrderPre> Query(OrderQuery query, out int total, int Wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Query(query, out total);
        }

        /// <summary>
        /// 取订单商品扩展明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static IList<SaleOrderPreDetailsExt> GetDetailExsByOrderId(string orderId, int Wid)
        {
            var condtion = new Dictionary<string, object>();
            condtion.Add("OrderId", orderId);
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsExtDAO>(Wid.ToString()).GetList(condtion);
        }

        /// <summary>
        /// 取订单商品明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public static IList<SaleOrderPreDetails> GetDetailByOrderId(string orderId, int Wid)
        {
            var condtion = new Dictionary<string, object>();
            condtion.Add("OrderId", orderId);
            return DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(Wid.ToString()).GetList(condtion);
        }

        /// <summary>
        /// 订单商品明细检查
        /// </summary>
        /// <param name="details">商品明细</param>
        /// <returns></returns>
        public static BackMessage<bool> CheckDetails(IList<SaleOrderPreDetails> details, bool IsEdit, string orderId = "")
        {
            if (details.Count <= 0)
            {
                return BackMessage<bool>.FailBack(false, "商品明细为空");
            }

            var i = 0;
            foreach (var detail in details)
            {
                i++;
                if (detail.ProductId <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("第{0}条商品的商品编号错误", i));
                }
                if (detail.WID <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("第{0}条商品的仓库编号错误", i));
                }

                if (detail.PreQty <= 0 && !IsEdit)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("第{0}条商品的仓库销售预定数量小于等于0", i));
                }
                if (detail.PreQty < 0 && IsEdit)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("第{0}条商品的仓库销售预定数量小于0", i));
                }

                if (!string.IsNullOrEmpty(orderId))
                {
                    detail.OrderID = orderId;
                }
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 根据订单号集合获取订单信息集合
        /// </summary>
        /// <param name="orderIds">订单号集合</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns></returns>
        public static IList<SaleOrderPre> GetList(IList<string> orderIds, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(warehouseId).GetList(orderIds);
        }

        #region 添加一个SaleOrderPre
        /// <summary>
        /// 添加一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>最新标识列</returns>
        public static BackMessage<bool> SaveNewOrder(SaleOrderPre orderPre, IList<SaleOrderPreDetails> details, IList<SaleOrderPreDetailsExt> detailsExts, SaleOrderSendNumber sendNumber, IList<SaleOrderPreDetailsPick> picks, IList<SaleOrderPreShelfArea> shelfAreas, int Wid, BaseUserModel user = null)
        {
            //数据检查
            var checkOrder = CheckOrder(orderPre);
            if (!checkOrder.IsSuccess)
            {
                return checkOrder;
            }

            //商品明细数据检查
            checkOrder = CheckDetails(details, false, orderPre.OrderId);
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
            var connection = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                //订单保存
                var flag = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Save(orderPre, connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "保存订单失败");
                }

                var i = 0;
                foreach (var detail in details)
                {

                    //detail.SerialNumber = i + 1;
                    //detail.ID = detail.WID.ToString() + Guid.NewGuid();
                    flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(Wid.ToString()).Save(detail, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存订单商品明细失败");
                    }
                    //detailsExts[i].ID = detail.ID;
                    //detailsExts[i].OrderID = orderPre.OrderId;
                    //i++;
                }
                foreach (var detailExt in detailsExts)
                {
                    flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsExtDAO>(Wid.ToString()).Save(detailExt, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存订单商品明细扩展数据失败");
                    }
                }

                if (picks != null && picks.Count > 0)
                {
                    foreach (var pick in picks)
                    {
                        pick.OrderID = orderPre.OrderId;
                        pick.ID = Wid.ToString() + Guid.NewGuid();
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(Wid.ToString()).Save(connection, trans, pick);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存订单商品拣货信息失败");
                        }
                    }
                }
                if (shelfAreas != null && shelfAreas.Count > 0)
                {
                    foreach (var shelfArea in shelfAreas)
                    {
                        shelfArea.OrderID = orderPre.OrderId;
                        shelfArea.ID = Wid.ToString() + Guid.NewGuid();
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(Wid.ToString()).Save(connection, trans, shelfArea);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存订单商品货架区域信息失败");
                        }
                    }
                }


                flag = DALFactory.GetLazyInstance<ISaleOrderSendNumberDAO>(Wid.ToString()).Save(sendNumber);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "订单排序处理失败");
                }

                //var track = new SaleOrderTrack()
                //                {
                //                    OrderID = orderPre.OrderId,
                //                    CreateTime = DateTime.Now,
                //                    IsDisplayUser = 1,
                //                    OrderStatus = orderPre.Status,
                //                    ID = Wid.ToString() + Guid.NewGuid(),
                //                    OrderStatusName = ConvertStatusToString(orderPre.Status),
                //                    Remark = "您的订单已经确认"
                //                };
                //if (user != null)
                //{
                //    track.CreateUserID = user.UserId;
                //    track.CreateUserName = user.UserName;
                //}
                //flag = SaleOrderTrackBLO.Save(track, Wid.ToString(), connection, trans);
                //if (flag <= 0)
                //{
                //    trans.Rollback();
                //    return BackMessage<bool>.FailBack(false, "添加订单跟踪信息失败");
                //}
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
        /// 添加一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>最新标识列</returns>
        public static BackMessage<bool> SavePickInfo(string orderId, IList<SaleOrderPreDetailsPick> picks, IList<SaleOrderPreShelfArea> shelfAreas, int Wid, BaseUserModel user = null)
        {
            var order = GetModel(orderId, Wid);
            if (order == null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个订单");
            }
            if (order.Status != 1 && order.Status != 0)
            {
                return BackMessage<bool>.FailBack(false, "不能进行确认的订单");
            }


            //开始事务
            var connection = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                order.Status = 2;
                order.ModifyTime = DateTime.Now;
                order.ConfDate = DateTime.Now;

                var flag = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Edit(order, connection, trans);

                if (picks != null && picks.Count > 0)
                {
                    foreach (var pick in picks)
                    {
                        pick.OrderID = orderId;
                        pick.ID = Wid.ToString() + Guid.NewGuid();
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(Wid.ToString()).Save(connection, trans, pick);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存订单商品拣货信息失败");
                        }
                    }
                }
                if (shelfAreas != null && shelfAreas.Count > 0)
                {
                    foreach (var shelfArea in shelfAreas)
                    {
                        shelfArea.OrderID = orderId;
                        shelfArea.ID = Wid.ToString() + Guid.NewGuid();
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(Wid.ToString()).Save(connection, trans, shelfArea);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存订单商品货架区域信息失败");
                        }
                    }
                }

                var track = new SaleOrderTrack()
                {
                    OrderID = orderId,
                    CreateTime = DateTime.Now,
                    IsDisplayUser = 1,
                    OrderStatus = 2,
                    ID = Wid.ToString() + Guid.NewGuid(),
                    OrderStatusName = ConvertStatusToString(2),
                    Remark = "您的订单已经确认"
                };
                if (user != null)
                {
                    track.CreateUserID = user.UserId;
                    track.CreateUserName = user.UserName;
                }
                flag = SaleOrderTrackBLO.Save(track, Wid.ToString(), connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "添加订单跟踪信息失败");
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
        /// 重排订单发货顺序，1为置顶，999为默认，9999为置底，具体赋值自已定义
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="orderNumber">顺序号</param>
        /// <param name="Wid"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static BackMessage<bool> OrderSendNumber(string orderId, int orderNumber, int Wid, BaseUserModel user)
        {
            var old = DALFactory.GetLazyInstance<ISaleOrderSendNumberDAO>(Wid.ToString()).GetModel(orderId);
            if (old == null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个订单的发货排序");
            }
            old.SendNumber = orderNumber;
            var flag = DALFactory.GetLazyInstance<ISaleOrderSendNumberDAO>(Wid.ToString()).Edit(old);
            if (flag > 0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "更新订单发货排序失败");
            }
        }

        /// <summary>
        /// 将订单类型转为字符
        /// </summary>
        /// <param name="orderStatus">订单类型</param>
        /// <returns></returns>
        public static string ConvertStatusToString(int orderStauts)
        {
            return ConvertStatusToString((OrderStatus)orderStauts);
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
        public static string ConvertShopTypeToString(int shopType)
        {
            return shopType == 1 ? "签约店" : "加盟店";
        }

        /// <summary>
        /// 修改saleOrderPre
        /// </summary>
        /// <param name="orderPre">订单信息</param>
        /// <param name="details">商品明细</param>
        /// <param name="detailsExts">明细扩展</param>
        /// <returns></returns>
        public static BackMessage<bool> EditOrder(SaleOrderPre orderPre, IList<SaleOrderPreDetails> details, IList<SaleOrderPreDetailsExt> detailsExts, IList<SaleOrderPreDetailsPick> picks, IList<SaleOrderPreShelfArea> shelfAreas, int Wid)
        {
            var oldOrder = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetModel(orderPre.OrderId);
            if (oldOrder == null)
            {
                return BackMessage<bool>.FailBack(false, "没有找到这个订单");
            }
            if (oldOrder.Status != 1 && oldOrder.Status != 2)
            {
                return BackMessage<bool>.FailBack(false, "订单状态不允许编辑");
            }

            if (detailsExts == null)
            {
                return BackMessage<bool>.FailBack(false, "商品明细列表与明细扩展列表不匹配");
            }

            if (detailsExts.Count != details.Count)
            {
                return BackMessage<bool>.FailBack(false, "商品明细列表与明细扩展列表不匹配");
            }

            //订单数据检查
            var checkOrder = CheckOrder(orderPre);
            if (!checkOrder.IsSuccess)
            {
                return checkOrder;
            }

            //订单明细数据检查
            checkOrder = CheckDetails(details, true, orderPre.OrderId);
            if (!checkOrder.IsSuccess)
            {
                return checkOrder;
            }

            //开始事务
            var connection = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                //编辑订单信息
                if (oldOrder.ConfDate != null)
                {
                    orderPre.ConfDate = oldOrder.ConfDate;  //确认时间  唐凡
                }
                var flag = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Edit(orderPre, connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "修改订单失败");
                }

                var i = 0;

                //根据订单ID删除明细信息
                flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(Wid.ToString()).DeleteByOrderId(orderPre.OrderId, connection,
                                                                                          trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除原有商品明细失败");
                }
                foreach (var detail in details)
                {
                    //detail.SerialNumber = i + 1;
                    //detail.ID = detail.WID.ToString() + Guid.NewGuid();
                    //新增编辑后的新订单明细信息
                    flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(Wid.ToString()).Save(detail, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存订单商品明细失败");
                    }
                    //detailsExts[i].ID = detail.ID;
                    //detailsExts[i].OrderID = orderPre.OrderId;
                    //i++;
                }

                //根据订单ID删除商品明细扩展
                flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsExtDAO>(Wid.ToString()).DeleteByOrderId(orderPre.OrderId, connection,
                                                                                         trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除原有商品明细扩展失败");
                }
                foreach (var detailExt in detailsExts)
                {
                    //新增编辑后的商品明细扩展
                    flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsExtDAO>(Wid.ToString()).Save(detailExt, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "保存订单商品明细扩展数据失败");
                    }
                }


                if (picks != null && picks.Count > 0)
                {
                    var tempPicks = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(Wid.ToString()).GetOrderPick(orderPre.OrderId);
                    if (tempPicks != null && tempPicks.Count > 0)
                    {
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(Wid.ToString()).DeleteByOrderId(orderPre.OrderId, connection, trans);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除原有商品拣货信息失败");
                        }
                    }
                    foreach (var pick in picks)
                    {
                        pick.OrderID = orderPre.OrderId;
                        pick.ID = Wid.ToString() + Guid.NewGuid();
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(Wid.ToString()).Save(connection, trans, pick);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存订单商品拣货信息失败");
                        }
                    }
                }

                if (shelfAreas != null && shelfAreas.Count > 0)
                {
                    var tempShelfAreas = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(Wid.ToString()).GetModelByOrderId(orderPre.OrderId);
                    if (tempShelfAreas != null && tempShelfAreas.Count > 0)
                    {
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(Wid.ToString()).DeleteByOrderId(orderPre.OrderId, connection, trans);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清除原有商品拣货货架区域信息失败");
                        }
                    }
                    foreach (var shelfArea in shelfAreas)
                    {
                        shelfArea.OrderID = orderPre.OrderId;
                        shelfArea.ID = Wid.ToString() + Guid.NewGuid();
                        flag = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(Wid.ToString()).Save(connection, trans, shelfArea);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "保存订单商品货架区域信息失败");
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

        #endregion




        #region 删除一个SaleOrderPre
        /// <summary>
        /// 删除一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        public static BackMessage<bool> DeleteOrder(SaleOrderPre orderPre, int Wid)
        {
            var checkOrder = CheckOrder(orderPre);
            if (!checkOrder.IsSuccess)
            {
                return checkOrder;
            }

            var oldOrder = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetModel(orderPre.OrderId);
            if (oldOrder == null)
            {
                return BackMessage<bool>.FailBack(false, "没有找到这个订单");
            }


            //开始事务
            var connection = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                //删除订单
                var flag = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).Delete(orderPre, connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "修改预售订失败");
                }
                //删除订单商品明细
                flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(Wid.ToString()).DeleteByOrderId(orderPre.OrderId, connection,
                                                                                          trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除原有商品明细失败");
                }
                //删除明细EXT
                flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsExtDAO>(Wid.ToString()).DeleteByOrderId(orderPre.OrderId, connection,
                                                                                         trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "清除原有商品明细扩展失败");
                }
                //提交事务
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
        #endregion

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderIds">订单ID列表</param>
        /// <param name="status">状态</param>
        /// <param name="reason">取消原因</param>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public static BackMessage<bool> CloseOrders(int Wid, IList<string> orderIds, int status, string reason = "", BaseUserModel user = null)
        {
            var connection = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var orderId in orderIds)
                {
                    var order = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).GetModel(orderId);
                    if (order == null)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "没有这个订单");
                    }
                    //订单状态(0:草稿(代客下单才有);1:等待确认;2:等待拣货;3:正在拣货;4:拣货完成;5:打印完成;6:正在配送中;7:交易完成;8:客户交易取消;9:客服交易关闭）
                    string msg = "";
                    var oldStatus = order.Status;
                    switch (order.Status)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            //msg = "已确认订单不能取消";
                            break;
                        case 3:
                            //msg = "已确认订单不能取消";
                            break;
                        case 4:
                            //msg = "已确认订单不能取消";
                            break;
                        case 5:
                            msg = "订单已经装箱，不能取消";
                            break;
                        case 6:
                            msg = "订单已经配送，不能取消";
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
                    var flag = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(Wid.ToString()).UpdateField(listField, listWhere, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "修改订单状态失败");
                    }
                    var track = new SaleOrderTrack()
                    {
                        ID = Wid.ToString() + Guid.NewGuid().ToString(),
                        WID = Wid,
                        CreateTime = DateTime.Now,
                        CreateUserID = user.UserId,
                        CreateUserName = user.UserName,
                        IsDisplayUser = 1,
                        OrderID = orderId,
                        OrderStatus = status,
                        OrderStatusName = "客服交易取消",
                        Remark = "客服人员帮您取消了订单，交易已经关闭"
                    };
                    flag = DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(Wid.ToString()).Save(connection, trans, track);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "添加订单跟踪消息失败");
                    }
                    //清空待装区
                    if (oldStatus == 3 || oldStatus == 4)
                    {
                        var ProductSdkClient = WorkContext.CreateProductSdkClient();
                        var resp = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWStationNumberResetExtRequest()
                        {
                            OrderId = order.OrderId,
                            UserId = user.UserId,
                            UserName = user.UserName
                        });
                        if (resp == null)
                        {
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false, "清空待装区失败");
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

    }

    /// <summary>
    /// SaleOrderPre业务逻辑类
    /// 龙武
    /// </summary>
    public partial class SaleOrderPreBLO
    {
        /// <summary>
        /// 获取待拣货数量
        /// </summary>
        /// <param name="shelfAreaID">获取编号</param>
        /// <param name="WID">仓库编号</param>
        /// <returns></returns>
        public static int? GetWaitPickingNum(int shelfAreaID, string WID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(WID).GetWaitPickingNum(shelfAreaID);
        }

        /// <summary>
        /// 分页获取等待拣货订单列表
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderPreWaitPickingList> GetPageWaitPickList(PageListBySql<SaleOrderPreWaitPickingList> page, IDictionary<string, object> conditionDict, int wID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wID.ToString()).GetPageWaitPickList(page, conditionDict);
        }

        /// <summary>
        /// 获取订单详情(APP)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        public static SaleOrderPreWaitPickingList GetWaitPickDetails(string orderId, string wID, int shelfAreaID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wID.ToString()).GetWaitPickDetails(orderId, shelfAreaID);
        }

        /// <summary>
        /// 获取订单详情(后台)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="shelfAreaID">货区编号</param>
        public static SaleOrderPreWaitPickingList GetWaitPickDetails(string orderId, string wID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wID).GetWaitPickDetails(orderId);
        }

        /// <summary>
        /// 分页获取正在拣货订单列表
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderPre7ShelfArea> GetPageAtPickList(PageListBySql<SaleOrderPre7ShelfArea> page, IDictionary<string, object> conditionDict, int wID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wID.ToString()).GetPageAtPickList(page, conditionDict);
        }

        /// <summary>
        /// 开始拣货更新订单数据
        /// </summary>
        /// <param name="status"></param>
        /// <param name="stationNumber"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static int UpdateSaleOrderPick(string orderID, int status, int stationNumber, IDbConnection conn, IDbTransaction tran, int wID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wID.ToString()).UpdateSaleOrderPick(orderID, status, stationNumber, conn, tran);
        }

        /// <summary>
        /// 提交拣货
        /// </summary>
        /// <param name="orderDetails">拣货数据</param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static ReturnSubmitInfo SubmitPick(SubmitPickOrder orderDetails, string warehouseId, List<PickUserIdAndUserName> userInfo)
        {
            var FactoryObj = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(warehouseId);
            IDbConnection conn = FactoryObj.GetConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();
            try
            {
                #region 更新订单相关数据
                ReturnSubmitInfo isResult = FactoryObj.SubmitPick(orderDetails, warehouseId, userInfo, conn, tran);
                if (isResult.IsResult)
                {
                    tran.Commit();//提交事务
                }
                else
                {
                    tran.Rollback();
                }
                return isResult;
                #endregion

            }
            catch (Exception ex)
            {
                tran.Rollback();//回滚事务
                throw ex;
            }
            finally
            {
                conn.Close();
                tran.Dispose();
            }
        }

        /// <summary>
        /// 提交对货
        /// </summary>
        /// <param name="shelfAreaId">货区编号</param>
        /// <param name="checkedUserId">拣货人编号</param>
        /// <param name="checkedUserName">贱货人名称</param>
        /// <param name="orderId">订单编号</param>
        /// <param name="goodsInfo">商品信息</param>
        /// <returns></returns>
        public static string SubmitCheckedGoods(int shelfAreaId, string warehouseId, int checkedUserId, string checkedUserName, string orderId, List<CheckedGoodsNumInfo> goodsInfo)
        {
            var FactoryObj = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(warehouseId);
            IDbConnection conn = FactoryObj.GetConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();
            try
            {
                string isResult = FactoryObj.SubmitCheckedGoods(shelfAreaId, checkedUserId, checkedUserName, orderId, goodsInfo, conn, tran);
                if (isResult == "SUCCESS")
                {
                    tran.Commit();//提交事务
                }
                else
                {
                    tran.Rollback();
                }
                return isResult;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
                tran.Dispose();
            }
        }


        /// <summary>
        /// 开始拣货操作更新库存数量
        /// </summary>
        /// <param name="stockModel">商品编号和对应库存数</param>
        /// <param name="orderId">订单编号</param>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="shelfAreaId">货区编号</param>
        /// <returns></returns>
        public static bool EditEnQty(IList<ProductUserQty> stockModel, string warehouseId, string orderId, string shelfAreaId)
        {
            var FactoryObj = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(warehouseId);
            IDbConnection conn = FactoryObj.GetConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();
            try
            {
                bool isResult = FactoryObj.EditEnQty(stockModel, orderId, shelfAreaId, conn, tran);
                tran.Commit();//提交事务
                return isResult;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
                tran.Dispose();
            }
        }

        /// <summary>
        /// 获取装箱订单列表
        /// </summary>
        /// <param name="WID">仓库编号</param>
        /// <returns></returns>
        public static IList<SaleOrderPre> GetPackingList(string WID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(WID).GetPackingList(WID);
        }

        /// <summary>
        /// 获取拣货时间
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="shelfAreaID"></param>
        /// <returns></returns>
        public static PickTimeModel GetPickTimeByOrderIdAndAreaID(string orderId, string wID, string shelfAreaID)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wID).GetPickTimeByOrderIdAndAreaID(orderId, shelfAreaID);
        }

        /// <summary>
        /// 订单打印
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> Print(string orderId, int wid, BaseUserModel user, int isPrinted = 1)
        {
            var order = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid.ToString()).GetModel(orderId);
            if (order == null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个订单");
            }

            var listField = new List<Field>();
            listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "PrintDate", FieldValue = DateTime.Now, ParamterName = "PrintDate" });
            listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "PrintUserID", FieldValue = user.UserId, ParamterName = "PrintUserID" });
            listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "PrintUserName", FieldValue = user.UserName, ParamterName = "PrintUserName" });
            listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "ModifyUserID", FieldValue = user.UserId, ParamterName = "ModifyUserID" });
            listField.Add(new Field() { FieldDbType = DbType.String, FieldLength = 200, FieldName = "ModifyUserName", FieldValue = user.UserName, ParamterName = "ModifyUserName" });
            listField.Add(new Field() { FieldDbType = DbType.DateTime, FieldName = "ModifyTime", FieldValue = DateTime.Now, ParamterName = "ModifyTime" });
            listField.Add(new Field() { FieldDbType = DbType.Int32, FieldLength = 4, FieldName = "IsPrinted", FieldValue = isPrinted, ParamterName = "IsPrinted" });

            var listWhere = new List<WhereCondition>();
            listWhere.Add(new WhereCondition()
            {
                AttachSymbol = Attach.And,
                CompareSymbol = Compare.Equals,
                FieldObj = new Field() { FieldDbType = DbType.String, FieldLength = 50, FieldName = "OrderID", FieldValue = orderId, ParamterName = "OrderID" }
            });
            var flag = UpdateField(listField, listWhere, wid);
            if (flag > 0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "更新打印状态失败");
            }
        }

        /// <summary>
        /// 修改订单线路
        /// </summary>
        /// <param name="model">订单模型，包含orderId,lineId,lineName即可</param>
        /// <returns></returns>
        public static BackMessage<bool> UpdateLine(SaleOrderPre model, BaseUserModel user, int wid)
        {
            var oldOrder = GetModel(model.OrderId, wid);
            if (oldOrder == null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个订单");
            }
            if (oldOrder.Status > 5)
            {
                return BackMessage<bool>.FailBack(false, "订单状态发生了变化，不能修改线路");
            }
            var flag = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid.ToString()).UpdateLine(model, user);
            if (flag > 0)
            {
                if (oldOrder.Status <= 5 && oldOrder.Status >= 3)
                {
                    //修改待装区中的线路
                    var ProductSdkClient = WorkContext.CreateProductSdkClient();
                    var resp = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductSetStationNumberLineInfoActionRequest()
                    {
                        LineID = model.LineID.Value.ToString(),
                        WID = wid,
                        StationNumber = oldOrder.StationNumber.Value,
                        UserId = user.UserId,
                        UserName = user.UserName
                    });
                }
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "修改线路失败");
            }
        }


    }

    /// <summary>
    /// SaleOrderPre业务逻辑类
    /// chujl
    /// </summary>
    public partial class SaleOrderPreBLO
    {

        /// <summary>
        /// 更改状态（装车）
        /// </summary>
        /// <param name="buyids"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string ChangeStatusToDeliver(string orderId, string empId, string empName, int wid)
        {
            SaleOrderPre model = SaleOrderPreBLO.GetModel(orderId, wid);

            var ProductSdkClient = WorkContext.CreateProductSdkClient();
            var respWarehouseEmp = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWarehouseEmpGetRequest()
            {
                EmpID = int.Parse(empId)
            });
            string userMobile = "";
            if (respWarehouseEmp != null && respWarehouseEmp.Flag == 0 && respWarehouseEmp.Data != null)
            {
                userMobile = respWarehouseEmp.Data.UserMobile;
            }

            var connection = DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                if (model != null)
                {
                    if (model.Status == 5) //状态(5) 装车操作
                    {
                        model.Status = 6;
                        model.ShippingUserID = int.Parse(empId);
                        model.ShippingUserName = empName;
                        model.ShippingBeginDate = DateTime.Now;

                        #region 写入日志
                        SaleOrderTrack trackLog = new SaleOrderTrack();
                        trackLog.CreateTime = DateTime.Now;
                        trackLog.CreateUserID = int.Parse(empId);
                        trackLog.CreateUserName = empName;
                        trackLog.ID = wid + Guid.NewGuid().ToString();
                        trackLog.IsDisplayUser = 1;
                        trackLog.OrderID = orderId;
                        trackLog.OrderStatus = 6;
                        trackLog.OrderStatusName = "装车完成";
                        trackLog.Remark = "订单已经完成装车，司机【" + empName + "】，联系电话:" + userMobile + "，感谢您的耐心等待";
                        trackLog.WID = wid;
                        #endregion

                        ///清除状态
                        var resp = ProductSdkClient.Execute(new Frxs.Erp.ServiceCenter.Product.SDK.Request.FrxsErpProductWStationNumberResetExtRequest()
                        {
                            OrderId = orderId,
                            UserId = int.Parse(empId),
                            UserName = empName
                        });
                        if (resp != null && resp.Flag == 0)
                        {
                            if (DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid.ToString()).EditSatusByOrderId(model, connection, trans) > 0)
                            {
                                if (DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(wid.ToString()).Save(connection, trans, trackLog) > 0)
                                {
                                    trans.Commit();
                                    return "1";
                                }
                                else
                                {
                                    trans.Rollback();
                                    return "保存订单状态日志失败！";

                                }
                            }
                            else
                            {
                                trans.Rollback();
                                return "更新订单状态失败！";

                            }
                        }
                        else
                        {
                            trans.Rollback();
                            return "清除装车状态失败！";
                        }
                    }
                    else
                    {
                        trans.Rollback();
                        return "订单非打印完成状态，不能进行装车！";
                    }
                }

                trans.Rollback();
                return "查找不到此订单，仓库：" + wid;

            }
            catch (Exception ex)
            {
                trans.Rollback();
                return "装车失败，原因:" + ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }


        /// <summary>
        /// 更改状态（完成配送）
        /// </summary>
        /// <param name="buyids"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int ChangeStatusToDelivered(string orderId, string empId, string empName, int wid)
        {

            SaleOrderPre model = SaleOrderPreBLO.GetModel(orderId, wid);
            var connection = DALFactory.GetLazyInstance<ISaleFeePreDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                if (model != null)
                {
                    if (model.Status == 6) //状态(5) 装车操作
                    {

                        model.ShippingEndDate = DateTime.Now;

                        #region 写入日志
                        SaleOrderTrack trackLog = new SaleOrderTrack();
                        trackLog.CreateTime = DateTime.Now;
                        trackLog.CreateUserID = int.Parse(empId);
                        trackLog.CreateUserName = empName;
                        trackLog.ID = wid + Guid.NewGuid().ToString();
                        trackLog.IsDisplayUser = 1;
                        trackLog.OrderID = orderId;
                        trackLog.OrderStatus = 6;
                        trackLog.OrderStatusName = "配送完成";
                        trackLog.Remark = "司机【" + empName + "】已经完成配送";
                        trackLog.WID = wid;
                        #endregion

                        if (DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid.ToString()).EditSatusByOrderId(model, connection, trans) > 0)
                        {
                            if (DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(wid.ToString()).Save(connection, trans, trackLog) > 0)
                            {
                                trans.Commit();
                                return 1;
                            }
                        }
                        trans.Rollback();
                        return 0;
                    }
                }

                trans.Rollback();
                return 0;

            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }

        /// <summary>
        /// 等待配送的门店集合
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static IList<WaitDeliverData> GetWaitDeliverData(string orderId, string empId, string wid, string lineIDs, string status)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetWaitDeliverData(orderId, empId, lineIDs, status);
        }

        /// <summary>
        /// 配送对账单明细
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static IList<SaleDeliverOrderInfo> GetSaleOrderDetailInfo(string searechDate, string empId, string wid, string lineIDs)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetSaleOrderDetailInfo(searechDate, empId, lineIDs);
        }

        /// <summary>
        /// 配送对账单总表
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static IList<SaleDeliverOrderInfo> GetSaleOrderTotalInfo(string searechMonth, string empId, string wid, string lineIDs)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetSaleOrderTotalInfo(searechMonth, empId, lineIDs);
        }


        /// <summary>
        ///  订单信息
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static DeliverOrderInfo GetDeliverOrderInfo(string orderId, string wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetDeliverOrderInfo(orderId, wid);
        }

        /// <summary>
        ///  订单信息
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static DeliverOrderInfo GetDeliverOrderInfoExt(string orderId, string wid)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetDeliverOrderInfoExt(orderId, wid);
        }
        /// <summary>
        /// 正在拣货门店集合
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static IList<PickingData> GetPickingData(string wid, string lineIDs)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetPickingData(wid, lineIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static IList<ProductData> GetProductData(string wid, string orderId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetProductData(wid, orderId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmpId"></param>
        /// <param name="WID"></param>
        /// <param name="LineIDs"></param>
        /// <returns></returns>
        public static IList<ProductDetailExt> GetProductDataExt(string wid, string orderId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid).GetProductDataExt(wid, orderId);
        }



    }
}