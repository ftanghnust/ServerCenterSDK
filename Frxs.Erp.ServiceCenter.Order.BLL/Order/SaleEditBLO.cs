
/*****************************
* Author:leidong
*
* Date:2016-04-20
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using System.Linq;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// SaleEdit业务逻辑类
    /// </summary>
    public partial class SaleEditBLO
    {
        #region 成员方法

        #region 根据主键验证SaleEdit是否存在

        /// <summary>
        /// 根据主键验证SaleEdit是否存在
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleEdit model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).Exists(model);
        }

        #endregion


        #region 添加一个SaleEdit

        /// <summary>
        /// 添加一个SaleEdit
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleEdit model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).Save(model);
        }

        #endregion


        #region 更新一个SaleEdit

        /// <summary>
        /// 更新一个SaleEdit
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleEdit model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).Edit(model);
        }

        #endregion





        #region 根据主键逻辑删除一个SaleEdit

        /// <summary>
        /// 根据主键逻辑删除一个SaleEdit
        /// </summary>
        /// <param name="editID">改单ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string editID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).LogicDelete(editID);
        }

        #endregion

        

        #region 根据主键获取SaleEdit对象

        /// <summary>
        /// 根据主键获取SaleEdit对象
        /// </summary>
        /// <param name="editID">改单ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleEdit对象</returns>
        public static SaleEdit GetModel(string editID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).GetModel(editID);
        }

        #endregion


        #region 根据字典获取SaleEdit集合

        /// <summary>
        /// 根据字典获取SaleEdit集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<SaleEdit> GetList(SaleEditQuery query, out int total, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).GetList(query,out total);
        }

        #endregion


        #region 根据字典获取SaleEdit数据集

        /// <summary>
        /// 根据字典获取SaleEdit数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName,
                                         string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }

        #endregion


        #region 分页获取SaleEdit集合

        /// <summary>
        /// 分页获取SaleEdit集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleEdit> GetPageList(PageListBySql<SaleEdit> page,
                                                          IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(warehouseId).GetPageList(page, conditionDict);
        }

        #endregion


        #endregion
    }

    public partial class SaleEditBLO
    {
        #region 删除一个SaleEdit

        /// <summary>
        /// 删除一个SaleEdit
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static BackMessage<bool> Delete(string editId, string wid)
        {
            var edit = DALFactory.GetLazyInstance<ISaleEditDAO>(wid).GetModel(editId);
            if(edit==null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个改单数据");
            }
            var connection = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                var flag = DALFactory.GetLazyInstance<ISaleEditDAO>(wid).Delete(edit, connection, trans);
                if(flag<=0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除改单数据失败");
                }
                flag = DALFactory.GetLazyInstance<ISaleEditDetailsDAO>(wid).DeleteByEditId(editId, connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除改单明细数据失败");
                }
                flag = DALFactory.GetLazyInstance<ISaleEditDetailsExtDAO>(wid).DeleteByEditId(editId, connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除改单明细扩展数据失败");
                }
                flag = DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid).DeleteByEditId(editId, connection, trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除改单订单数据失败");
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

        /// <summary>
        /// 批量删除改单数据
        /// </summary>
        /// <param name="editIds">改单ID列表</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> DeleteList(IList<string> editIds,string wid )
        {
            //防重处理，防止出现事务死锁
            var list = new List<string>();
            foreach (var editId in editIds)
            {
                if (string.IsNullOrEmpty(editId)) continue;
                var tmp = list.FirstOrDefault(x => x == editId);
                if (tmp == null)
                {
                    list.Add(editId);
                }
            }

            foreach (var editId in list)
            {
                var edit = DALFactory.GetLazyInstance<ISaleEditDAO>(wid).GetModel(editId);
                if (edit == null)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("没有编号为{0}的改单数据",editId));
                }
            }

            var connection = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var editId in list)
                {
                    var flag = DALFactory.GetLazyInstance<ISaleEditDAO>(wid).Delete(new SaleEdit(){EditID = editId}, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "删除改单数据失败");
                    }
                    flag = DALFactory.GetLazyInstance<ISaleEditDetailsDAO>(wid).DeleteByEditId(editId, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "删除改单明细数据失败");
                    }
                    flag = DALFactory.GetLazyInstance<ISaleEditDetailsExtDAO>(wid).DeleteByEditId(editId, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "删除改单明细扩展数据失败");
                    }
                    flag = DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid).DeleteByEditId(editId, connection, trans);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "删除改单订单数据失败");
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
        /// 改单数据检查
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        public static BackMessage<bool> CheckSaleEdit(SaleEdit edit)
        {
            if (string.IsNullOrEmpty(edit.EditID))
            {
                edit.EditID = Guid.NewGuid().ToString();
            }
            if (edit.EditDate.Year < 1970)
            {
                edit.EditDate = DateTime.Now;
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 改单明细检查
        /// </summary>
        /// <param name="details">明细</param>
        /// <param name="editId">改单ID</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> CheckDetails(IList<SaleEditDetails> details, string editId, int wid)
        {
            if (details == null || details.Count <= 0)
            {
                return BackMessage<bool>.FailBack(false, "明细数据不能为空");
            }

            #region 检查订单实时状态，若订单已经开始捡货，则不保存，避免录入无效的数据
            ////(后续的过账环节，也会自动忽略已经不符合条件的订单，这个环节增加验证主要是改进用户体验)
            ////检查订单实时状态，在明细表中，通过订单ID(去重复处理)检查明细对应的订单实时状态
            //string msg = string.Empty;//准备返回的信息

            ////明细表中找出所有要修改的(预)订单号
            //var orderIds = details.ToList().Select(o => o.OrderID).Distinct().ToList();
            //if (orderIds != null && orderIds.Count > 0)
            //{
            //    //批量获取到相关的(准备修改的)预订单信息
            //    var saleOrderPres = SaleOrderPreBLO.GetList(orderIds, wid.ToString());
            //    if (saleOrderPres != null && saleOrderPres.Count > 0)
            //    {
            //        #region 找出已经“交易完成”的订单
            //        if (saleOrderPres.Count < orderIds.Count)
            //        {
            //            //查询到的结果少于传入的ID个数，说明有的单据在这个时间差之内已经完成了，数据转移到了SaleOrder表
            //            string finishedOrderIds = string.Empty;
            //            var unfinishedIds = saleOrderPres.Select(o => o.OrderId).ToList();//能查询到的预订单号
            //            var finishedIds = orderIds.Except(unfinishedIds).ToList();//取出差集 完成了的（预）订单号
            //            if (finishedIds != null && finishedIds.Count > 0)
            //            {
            //                foreach (var id in finishedIds)
            //                {
            //                    finishedOrderIds += id + " ";//已经转移到SaleOrder表的记录
            //                }
            //            }
            //            msg += string.Format("订单[{0}]已经交易完成，不能修改。", finishedOrderIds);
            //        }
            //        #endregion

            //        #region 查找出不是“等待捡货”状态的订单
            //        var orderStatusNotFit = saleOrderPres.ToList().Where(o => (o.Status != 1 && o.Status != 2)).Select(o => o.OrderId).ToList();
            //        if (orderStatusNotFit != null && orderStatusNotFit.Count > 0)
            //        {
            //            string orderIdStatusNotFit = string.Empty;
            //            foreach (var notFitID in orderStatusNotFit)
            //            {
            //                orderIdStatusNotFit += notFitID + " ";
            //            }
            //            msg += string.Format("订单[{0}]的状态已经变化，不能修改。", orderIdStatusNotFit);
            //        }
            //        #endregion
            //    }
            //}
            //if (!string.IsNullOrEmpty(msg))
            //{
            //    return BackMessage<bool>.FailBack(false, string.Format("数据异常<br />{0}", msg));
            //}
            #endregion

            foreach (var detail in details)
            {
                detail.EditID = editId;
                if (string.IsNullOrEmpty(detail.ID))
                {
                    detail.ID = wid.ToString() + Guid.NewGuid().ToString();
                }
                if (string.IsNullOrEmpty(detail.OrderID))
                {
                    return BackMessage<bool>.FailBack(false, "明细数据中，订单编号不能为空");
                }
                if (detail.WID <= 0)
                {
                    detail.WID = wid;
                }
                if (detail.ProductId <= 0)
                {
                    return BackMessage<bool>.FailBack(false, "明细数据中，商品编号不能为空");
                }
                if (detail.WCProductID <= 0)
                {
                    return BackMessage<bool>.FailBack(false, "明细数据中，仓库商品编号不能为空");
                }
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 改单明细扩展检查
        /// </summary>
        /// <param name="detailsExts">明细扩展</param>
        /// <param name="editId">改单ID</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> CheckDetailExts(IList<SaleEditDetailsExt> detailsExts, string editId, int wid)
        {
            if (detailsExts == null || detailsExts.Count <= 0)
            {
                return BackMessage<bool>.FailBack(false, "明细扩展数据不能为空");
            }
            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 改单订单检查
        /// </summary>
        /// <param name="orders">订单</param>
        /// <param name="editId">改单ID</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> CheckOrders(IList<SaleEditOrders> orders, string editId, int wid)
        {
            if (orders == null || orders.Count <= 0)
            {
                return BackMessage<bool>.FailBack(false, "订单列表不能为空");
            }
            foreach (var order in orders)
            {
                if (string.IsNullOrEmpty(order.EditID))
                {
                    order.EditID = editId;
                }
                if (string.IsNullOrEmpty(order.OrderID))
                {
                    return BackMessage<bool>.FailBack(false, "订单编号不能为空");
                }
                if (order.WID <= 0)
                {
                    order.WID = wid;
                }
            }
            return BackMessage<bool>.SuccessBack(true);
        }


        /// <summary>
        /// 保存改单数据
        /// </summary>
        /// <param name="edit">改单数据</param>
        /// <param name="details">明细</param>
        /// <param name="detailsExts">明细扩展</param>
        /// <param name="orders">订单</param>
        /// <param name="user">操作者</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> Save(SaleEdit edit, IList<SaleEditDetails> details,
                                             IList<SaleEditDetailsExt> detailsExts, IList<SaleEditOrders> orders,
                                             BaseUserModel user, int wid)
        {
            #region 数据检查

            var checkResult = CheckSaleEdit(edit);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }

            checkResult = CheckDetails(details, edit.EditID, wid);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }


            checkResult = CheckDetailExts(detailsExts, edit.EditID, wid);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }

            checkResult = CheckOrders(orders, edit.EditID, wid);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }

            if (details.Count != detailsExts.Count)
            {
                return BackMessage<bool>.FailBack(false, "明细与明细扩展数据不匹配");
            }

            foreach (var order in orders)
            {
                var detail = details.FirstOrDefault(x => x.OrderID == order.OrderID);
                if (detail == null)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("订单{0}没有明细数据", order.OrderID));
                }
            }

            #endregion

            #region 数据处理

            //开始事务
            var connection = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                #region 添加改单
                edit.CreateUserID = user.UserId;
                edit.CreateUserName = user.UserName;
                edit.CreateTime = DateTime.Now;
                edit.ModifyUserID = user.UserId;
                edit.ModifyUserName = user.UserName;
                edit.ModifyTime = DateTime.Now;
                var flag = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).Save(connection, trans, edit);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "写入改单数据失败");
                }
                #endregion

                #region 添加明细及扩展
                for (int i = 0; i < details.Count; i++)
                {
                    var detail = details[i];
                    detail.ModifyTime = DateTime.Now;
                    detail.ModifyUserID = user.UserId;
                    detail.ModifyUserName = user.UserName;

                    detailsExts[i].ID = detail.ID;
                    detailsExts[i].ModifyTime = DateTime.Now;
                    detailsExts[i].ModifyUserID = user.UserId;
                    detailsExts[i].ModifyUserName = user.UserName;

                    flag = DALFactory.GetLazyInstance<ISaleEditDetailsDAO>(wid.ToString()).Save(connection, trans,
                                                                                                detail);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "写入改单明细数据失败");
                    }
                    flag = DALFactory.GetLazyInstance<ISaleEditDetailsExtDAO>(wid.ToString()).Save(connection, trans,
                                                                                                   detailsExts[i]);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "写入改单明细扩展数据失败");
                    }
                }
                #endregion

                #region 添加订单列表
                foreach (var saleEditOrderse in orders)
                {
                    saleEditOrderse.EditID = edit.EditID;
                    saleEditOrderse.CreateTime = DateTime.Now;
                    saleEditOrderse.CreateUserID = user.UserId;
                    saleEditOrderse.CreateUserName = user.UserName;
                    flag = DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Save(connection, trans,
                                                                                               saleEditOrderse);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "写入改单订单数据失败");
                    }
                }
                #endregion
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

            #endregion
        }


        /// <summary>
        /// 修改改单数据
        /// </summary>
        /// <param name="edit">改单数据</param>
        /// <param name="details">明细</param>
        /// <param name="detailsExts">明细扩展</param>
        /// <param name="orders">订单</param>
        /// <param name="user">操作者</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> Edit(SaleEdit edit, IList<SaleEditDetails> details,
                                             IList<SaleEditDetailsExt> detailsExts, IList<SaleEditOrders> orders,
                                             BaseUserModel user, int wid)
        {
            #region 数据检查
            if(string.IsNullOrEmpty(edit.EditID))
            {
                return BackMessage<bool>.FailBack(false, "错误的改单编号");
            }

            var old = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetModel(edit.EditID);
            if(old==null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个改单信息");
            }

            var checkResult = CheckSaleEdit(edit);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }

            checkResult = CheckDetails(details, edit.EditID, wid);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }


            checkResult = CheckDetailExts(detailsExts, edit.EditID, wid);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }

            checkResult = CheckOrders(orders, edit.EditID, wid);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }

            if (details.Count != detailsExts.Count)
            {
                return BackMessage<bool>.FailBack(false, "明细与明细扩展数据不匹配");
            }

            foreach (var order in orders)
            {
                var detail = details.FirstOrDefault(x => x.OrderID == order.OrderID);
                if (detail == null)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("订单{0}没有明细数据", order.OrderID));
                }
            }

            #endregion

            #region 数据处理

            //开始事务
            var connection = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                #region 改单处理
                edit.ModifyUserID = user.UserId;
                edit.ModifyUserName = user.UserName;
                edit.ModifyTime = DateTime.Now;
                edit.CreateTime = old.CreateTime;
                edit.CreateUserID = old.CreateUserID;
                edit.CreateUserName = old.CreateUserName;
                var flag = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).Edit(connection, trans, edit);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "写入改单数据失败");
                }
                #endregion

                #region 明细处理
                flag =DALFactory.GetLazyInstance<ISaleEditDetailsDAO>(wid.ToString()).DeleteByEditId(edit.EditID, connection,
                                                                                               trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除原改单明细失败");
                }
                flag = DALFactory.GetLazyInstance<ISaleEditDetailsExtDAO>(wid.ToString()).DeleteByEditId(edit.EditID, connection,
                                                                               trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除原改单明细扩展失败");
                }
                for (int i = 0; i < details.Count; i++)
                {
                    var detail = details[i];
                    detail.ModifyTime = DateTime.Now;
                    detail.ModifyUserID = user.UserId;
                    detail.ModifyUserName = user.UserName;

                    detailsExts[i].ID = detail.ID;
                    detailsExts[i].ModifyTime = DateTime.Now;
                    detailsExts[i].ModifyUserID = user.UserId;
                    detailsExts[i].ModifyUserName = user.UserName;

                    flag = DALFactory.GetLazyInstance<ISaleEditDetailsDAO>(wid.ToString()).Save(connection, trans,
                                                                                                detail);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "写入改单明细数据失败");
                    }
                    flag = DALFactory.GetLazyInstance<ISaleEditDetailsExtDAO>(wid.ToString()).Save(connection, trans,
                                                                                                   detailsExts[i]);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "写入改单明细扩展数据失败");
                    }
                }
                #endregion

                #region 订单处理
                flag = DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).DeleteByEditId(edit.EditID, connection,
                                                                               trans);
                if (flag <= 0)
                {
                    trans.Rollback();
                    return BackMessage<bool>.FailBack(false, "删除原改单订单列表失败");
                }
                foreach (var saleEditOrderse in orders)
                {
                    saleEditOrderse.EditID = edit.EditID;
                    saleEditOrderse.CreateTime = DateTime.Now;
                    saleEditOrderse.CreateUserID = user.UserId;
                    saleEditOrderse.CreateUserName = user.UserName;
                    flag = DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Save(connection, trans,
                                                                                               saleEditOrderse);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "写入改单订单数据失败");
                    }
                }
                #endregion
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

            #endregion
        }

        /// <summary>
        /// 改单查询
        /// </summary>
        /// <param name="query">改单查询</param>
        /// <param name="total">总量</param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static IList<SaleEdit> Query(SaleEditQuery query, out int total, int wid)
        {
            return DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetList(query, out total);
        }

        /// <summary>
        /// 更新改单状态
        /// </summary>
        /// <param name="editId">改单Id</param>
        /// <param name="status">状态</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> UpdateStatus(string editId,int status,int wid,BaseUserModel user)
        {
            var model = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetModel(editId);
            if(model==null)
            {
                return BackMessage<bool>.FailBack(false, "没有这个改单信息");
            }
            switch (status)
            {
                case 0:
                    if(model.Status!=1)
                    {
                        return BackMessage<bool>.FailBack(false, "不能进行反确认的状态");
                    }
                    model.ConfTime =null;
                    model.ConfUserID = null;
                    model.ConfUserName = string.Empty;
                    break;
                case 1:
                    if(model.Status!=0)
                    {
                        return BackMessage<bool>.FailBack(false, "不能进行确认的状态");
                    }
                    model.ConfTime = DateTime.Now;
                    model.ConfUserID = user.UserId;
                    model.ConfUserName = user.UserName;
                    break;
                case 2:
                    if(model.Status!=1)
                    {
                        return BackMessage<bool>.FailBack(false, "不能进行过帐的状态");
                    }
                     model.PostingTime = DateTime.Now;
                    model.PostingUserID = user.UserId;
                    model.PostingUserName = user.UserName;
                    break;
                default:
                    return BackMessage<bool>.FailBack(false, "错误的改单状态");
                    break;
            }
            model.Status = status;
            model.ModifyUserID = user.UserId;
            model.ModifyUserName = user.UserName;
            model.ModifyTime = DateTime.Now;
            var flag = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).Edit(model);
            if(flag>=0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "更新失败");
            }
        } 

        /// <summary>
        /// 批量修改改单状态
        /// </summary>
        /// <param name="editIds">改单ID列表</param>
        /// <param name="status">状态</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> UpdateStatusList(IList<string> editIds,int status,int wid,BaseUserModel user)
        {
            //防重处理，防止出现事务死锁
            var list = new List<string>();
            foreach (var editId in editIds)
            {
                if(string.IsNullOrEmpty(editId)) continue;
                var tmp = list.FirstOrDefault(x => x == editId);
                if(tmp==null)
                {
                    list.Add(editId);
                }
            }

            var connection = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var editId in list)
                {
                    var model = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetModel(editId);
                    if (model == null)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, string.Format("没有编号为{0}这个改单信息", editId));
                    }
                    switch (status)
                    {
                        case 0:
                            if (model.Status != 1)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, string.Format("改单{0}为不能进行反确认的状态",editId));
                            }
                             model.ConfTime =null;
                             model.ConfUserID = null;
                            model.ConfUserName = string.Empty;
                    
                            break;
                        case 1:
                            if (model.Status != 0)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false,  string.Format("改单{0}为不能进行确认的状态",editId));
                            }
                             model.ConfTime = DateTime.Now;
                            model.ConfUserID = user.UserId;
                            model.ConfUserName = user.UserName;
                            break;
                        case 2:
                            if (model.Status != 1)
                            {
                                trans.Rollback();
                                return BackMessage<bool>.FailBack(false, string.Format("改单{0}为不能进行过帐的状态",editId));
                            }
                            model.PostingTime = DateTime.Now;
                            model.PostingUserID = user.UserId;
                            model.PostingUserName = user.UserName;
                            break;
                        default:
                            trans.Rollback();
                            return BackMessage<bool>.FailBack(false,  "错误的改单状态");
                            break;
                    }
                    model.Status = status;
                    model.ModifyUserID = user.UserId;
                    model.ModifyUserName = user.UserName;
                    model.ModifyTime = DateTime.Now;
                    var flag = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).Edit(model);
                    if (flag <= 0)
                    {
                        trans.Rollback();
                        return BackMessage<bool>.FailBack(false, "更新失败");
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
        /// 获取改单订单信息
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <param name="wid">仓库号</param>
        /// <returns></returns>
        public static IList<SaleEditOrders> GetOrders(string editId,int wid)
        {
            return DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).GetList(editId);
        }

        /// <summary>
        /// 获取改单明细信息
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <param name="wid">仓库号</param>
        /// <returns></returns>
        public static IList<SaleEditDetails> GetDetail(string editId,int wid)
        {
            var condition = new Dictionary<string, object>();
            condition.Add("EditID", editId);
            return DALFactory.GetLazyInstance<ISaleEditDetailsDAO>(wid.ToString()).GetList(editId); 
        }

        /// <summary>
        /// 获取改单明细扩展信息
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <param name="wid">仓库号</param>
        /// <returns></returns>
        public static IList<SaleEditDetailsExt> GetDetailExt(string editId,int wid)
        {
            var condition = new Dictionary<string, object>();
            condition.Add("EditID", editId);
            return DALFactory.GetLazyInstance<ISaleEditDetailsExtDAO>(wid.ToString()).GetList(editId);
        } 

        /// <summary>
        /// 过帐
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <param name="wid">仓库ID</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static BackMessage<int> Modify(string editId,int wid,BaseUserModel user)
        {
            var edit = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetModel(editId);
            if(edit==null)
            {
                return BackMessage<int>.FailBack(0, "没有这个改单");
            }
            if(edit.Status!=1)
            {
                return BackMessage<int>.FailBack(1, "不能进行过帐的状态"); 
            }
   
            var details =
                DALFactory.GetLazyInstance<ISaleEditDetailsDAO>(wid.ToString()).GetList(editId);
            if(details==null|| details.Count<=0 )
            {
                return BackMessage<int>.FailBack(0, "没有找到明细数据");
            }

            var detailExts=
                DALFactory.GetLazyInstance<ISaleEditDetailsExtDAO>(wid.ToString()).GetList(editId);
            if (detailExts == null || detailExts.Count <= 0)
            {
                return BackMessage<int>.FailBack(0, "没有找到明细扩展数据");
            }

            var orders =
                 DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).GetList(editId);
            if (orders == null || orders.Count <= 0)
            {
                return BackMessage<int>.FailBack(0, "没有找到订单数据");
            }

            var errOrderList = new List<string>();
            var errMsgList = new List<string>();


            #region 订单循环开始

            string orderIdMsgPast = "";
            string orderIdMsgErr = "";
            foreach (var order in orders)
            {
                if(order.ProcFlag!=0) continue;
                var orderPre = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid.ToString()).GetModel(order.OrderID);
                if (orderPre == null)
                {
                    order.ProcFlag = 3;
                    order.ProcRemark = "没有找到这个订单或者这个订单已完成";
                    DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                    orderIdMsgPast += order.OrderID + ",";
                    continue;
                }
                if (orderPre.Status != (int)OrderStatus.WaitPick && orderPre.Status != (int)OrderStatus.WaitConfirm)
                {
                    order.ProcFlag = 3;
                    order.ProcRemark = "该订单不在等待确认或等待拣货状态";
                    DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                    orderIdMsgPast += order.OrderID + ",";
                    continue;
                }
                var orderDetail = SaleOrderPreBLO.GetDetailByOrderId(order.OrderID, wid);
                var orderDetailExts = SaleOrderPreBLO.GetDetailExsByOrderId(order.OrderID, wid);
                //var orderShelf =
                //    DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(wid.ToString()).GetOrderPick(order.OrderID);
                var orderArea = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(wid.ToString()).GetModelByOrderId(order.OrderID);

                var tmpDetails = new List<SaleEditDetails>();
                var tmpDetailExts = new List<SaleEditDetailsExt>();
                for (int i = 0; i < details.Count; i++)
                {
                    var detail = details[i];
                    var detailExt = detailExts[i];
                    if(detail.OrderID==order.OrderID)
                    {
                        tmpDetails.Add(detail);
                        tmpDetailExts.Add(detailExt);
                    }
                }
                if(tmpDetails.Count<=0)
                {
                    errOrderList.Add(order.OrderID);
                    order.ProcFlag = 0;
                    order.ProcRemark = "没有找到这个订单的明细数据";
                    DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                    orderIdMsgErr += order.OrderID+",";
                    continue;
                }

                var newTrack = new SaleOrderTrack()
                                   {
                                       CreateTime = DateTime.Now,
                                       CreateUserID = user.UserId,
                                       CreateUserName = user.UserName,
                                       ID = wid+Guid.NewGuid().ToString(),
                                       IsDisplayUser = 0,
                                       OrderID = order.OrderID,
                                       OrderStatusName = "订单修改",
                                       Remark = "客服人员提交了订单，等待拣货",
                                       WID = wid,
                                       OrderStatus = orderPre.Status
                                   };
                
                 //开始事务
                var connection = DALFactory.GetLazyInstance<ISaleEditDAO>(wid.ToString()).GetConnection();
                connection.Open();
                var trans = connection.BeginTransaction();
                try
                {
                    #region 单条订单数据处理
                    var count = orderDetail.Max(x => x.SerialNumber);
                    foreach (var detail in tmpDetails)
                    {
                        //原订单中有这个商品，不处理
                        var tmp = orderDetail.FirstOrDefault(x => x.ProductId == detail.ProductId);
                        if (tmp != null)
                        {
                            continue;
                        }
                        count++;
                        var newDetail = new SaleOrderPreDetails();
                        newDetail = detail.Map<SaleOrderPreDetails>();
                        newDetail.ID = wid.ToString() + Guid.NewGuid().ToString();
                        newDetail.IsAppend = 1;
                        newDetail.EditID = editId;
                        newDetail.SerialNumber = count;
                        newDetail.ModifyTime = DateTime.Now;
                        newDetail.ModifyUserID = user.UserId;
                        newDetail.ModifyUserName = user.UserName;
                        newDetail.PreQty = newDetail.SaleQty.HasValue?newDetail.SaleQty.Value:0;
                        orderDetail.Add(newDetail);
                       

                        var newDetailExt = new SaleOrderPreDetailsExt();
                        newDetailExt = tmpDetailExts.FirstOrDefault(x => x.ID == detail.ID).Map<SaleOrderPreDetailsExt>();
                        newDetailExt.ModifyTime = DateTime.Now;
                        newDetailExt.ModifyUserID = user.UserId;
                        newDetailExt.ModifyUserName = user.UserName;
                        newDetailExt.ID = newDetail.ID;
                        newDetailExt.OrderID = order.OrderID;
                        orderDetailExts.Add(newDetailExt);
                                              

                        var flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsDAO>(wid.ToString()).Save(newDetail, connection,trans);
                        if (flag <= 0)
                        {
                            errOrderList.Add(order.OrderID);
                            trans.Rollback();
                            order.ProcFlag = 0;
                            order.ProcRemark = "添加明细数据失败";
                            DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                            orderIdMsgErr += order.OrderID + ",";
                            break;
                        }

                        flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsExtDAO>(wid.ToString()).Save(newDetailExt, connection,trans);
                        if (flag <= 0)
                        {
                            errOrderList.Add(order.OrderID);
                            trans.Rollback();
                            order.ProcFlag = 0;
                            order.ProcRemark = "添加明细扩展数据失败";
                            DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                            orderIdMsgErr += order.OrderID + ",";
                            break;
                        }

                        if (orderPre.Status>=2) //已确认的订单才需要添加拣货和货区信息
                        {
                            var newPick = new SaleOrderPreDetailsPick();
                            newPick = detail.Map<SaleOrderPreDetailsPick>();
                            newPick.ModifyTime = DateTime.Now;
                            newPick.ModifyUserID = user.UserId;
                            newPick.ModifyUserName = user.UserName;
                            newPick.ID = newDetail.ID;
                            newPick.OrderID = newDetail.OrderID;



                            var newShelf = new SaleOrderPreShelfArea();
                            newShelf = detail.Map<SaleOrderPreShelfArea>();
                            newShelf.ID = wid.ToString() + Guid.NewGuid().ToString();
                            newShelf.ModifyTime = DateTime.Now;
                            newShelf.ModifyUserID = user.UserId;
                            newShelf.ModifyUserName = user.UserName;
                            newShelf.OrderID = newDetail.OrderID;
                            var tmpExist = orderArea.FirstOrDefault(x => x.OrderID == newShelf.OrderID && x.ShelfAreaID == newShelf.ShelfAreaID);
                            var bExist = false;
                            if (tmpExist == null)
                            {
                                orderArea.Add(newShelf);
                            }
                            else
                            {
                                bExist = true;
                            }
                        

                            flag = DALFactory.GetLazyInstance<ISaleOrderPreDetailsPickDAO>(wid.ToString()).Save(connection, trans, newPick);
                            if (flag <= 0)
                            {
                                errOrderList.Add(order.OrderID);
                                trans.Rollback();
                                order.ProcFlag = 0;
                                order.ProcRemark = "添加拣货数据失败";
                                DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                                orderIdMsgErr += order.OrderID + ",";
                                break;
                            }
                            
                            if (!bExist)
                            {
                                flag = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(wid.ToString()).Save(connection, trans, newShelf);
                                if (flag <= 0)
                                {
                                    errOrderList.Add(order.OrderID);
                                    trans.Rollback();
                                    order.ProcFlag = 0;
                                    order.ProcRemark = "添加货区数据失败";
                                    DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                                    orderIdMsgErr += order.OrderID + ",";
                                    break;
                                }
                            }
                        }
                    }
                    #region 计算订单数据信息
                    orderPre.CouponAmt = 0;
                    orderPre.TotalAddAmt = orderDetail.Sum(x => x.SubAddAmt);
                    orderPre.TotalProductAmt = orderDetail.Where(x => x.SubAmt.HasValue).Sum(x => x.SubAmt.Value);
                    orderPre.PayAmount = orderPre.TotalAddAmt.Value + orderPre.TotalProductAmt;
                    orderPre.TotalPoint = orderDetail.Where(x => x.SubPoint.HasValue).Sum(x => x.SubPoint.Value);
                    orderPre.TotalBasePoint = orderDetail.Sum(x => x.SubBasePoint);
                    var iflag = DALFactory.GetLazyInstance<ISaleOrderPreDAO>(wid.ToString()).Edit(orderPre, connection,trans);
                    if (iflag <= 0)
                    {
                        errOrderList.Add(order.OrderID);
                        trans.Rollback();
                        order.ProcFlag = 0;
                        order.ProcRemark = "更新订单数据失败";
                        DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                        orderIdMsgErr += order.OrderID + ",";
                        break;
                    }
                    #endregion
                    #endregion

                    var orderFlag = DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(wid.ToString()).Save(connection, trans,
                                                                                newTrack);
                    if (orderFlag <= 0)
                    {
                        errOrderList.Add(order.OrderID);
                        trans.Rollback();
                        order.ProcFlag = 0;
                        order.ProcRemark = "添加改单跟踪失败";
                        DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                        orderIdMsgErr += order.OrderID + ",";
                        continue;
                    }

                    order.ProcFlag = 1;
                    order.ProcRemark = "已完成改单";
                    orderFlag=DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(connection,trans,order);
                    if (orderFlag <= 0)
                    {
                        errOrderList.Add(order.OrderID);
                        trans.Rollback();
                        order.ProcFlag = 0;
                        order.ProcRemark = "改单失败";
                        DALFactory.GetLazyInstance<ISaleEditOrdersDAO>(wid.ToString()).Edit(order);
                        orderIdMsgErr += order.OrderID + ",";
                        continue;
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    orderIdMsgErr += order.OrderID + ",";
                    trans.Rollback();
                    return BackMessage<int>.FailBack(0, ex.Message);
                }
                finally
                {
                    trans.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
            }
            #endregion

            string returnMsg = "";
            if (!string.IsNullOrEmpty(orderIdMsgPast))
            {
                returnMsg = "  以下订单因为已经处理，推荐失败：" + orderIdMsgPast.Substring(0, orderIdMsgPast.Length - 1) + ";\n";
            }
            if(!string.IsNullOrEmpty(orderIdMsgErr))
            {
                returnMsg = "  以下订单因为异常，推荐失败：" + orderIdMsgErr.Substring(0, orderIdMsgErr.Length - 1)+";\n";
            }
            if(!string.IsNullOrEmpty(returnMsg))
            {
                returnMsg = string.Format("改单[{0}]\n", editId)+returnMsg;
            }
            //if(errOrderList.Count>0)
            //{
            //    string msg = "";
            //    foreach (var id in errOrderList)
            //    {
            //        msg += id + ",";
            //    }
            //   msg = "订单" + msg.Substring(0, msg.Length - 1) + "改单失败，请确认改单数据正确后再试";
            //   return BackMessage<int>.SuccessBack(2);
            //}
            var bFlag= UpdateStatus(editId, 2, wid, user);
            if(bFlag.IsSuccess)
            {
                return BackMessage<int>.SuccessBack(2,returnMsg);
            }
            else
            {
                return BackMessage<int>.FailBack(0, bFlag.Message);
            }
        } 
    }
}