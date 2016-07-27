
/*****************************
* Author:WR
*
* Date:2016-04-15
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
//using Frxs.Erp.ServiceCenter.Order.IOCFactory;
using Frxs.Platform.IOCFactory;
using System.ComponentModel;
using Frxs.Erp.ServiceCenter.Order.Model.Stock;
using Frxs.Erp.ServiceCenter.Order.BLL.Stock;
using System.Linq;

namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// StockAdj业务逻辑类
    /// </summary>
    public partial class StockAdjBLO
    {
        #region 成员方法
        #region 根据主键验证StockAdj是否存在
        /// <summary>
        /// 根据主键验证StockAdj是否存在
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(StockAdj model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个StockAdj
        /// <summary>
        /// 添加一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(StockAdj model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个StockAdj
        /// <summary>
        /// 更新一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(StockAdj model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个StockAdj
        /// <summary>
        /// 删除一个StockAdj
        /// </summary>
        /// <param name="model">StockAdj对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(StockAdj model, string warehouseId)
        {
            model = GetModel(model.AdjID, warehouseId);
            if (model.AdjType == 1)
            {
                var models = GetListByRefBID(model.AdjID, int.Parse(warehouseId));
                if (models != null && models.Count > 0)
                {
                    //存在盘盈单号
                    var connection = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetConnection();
                    connection.Open();
                    var trans = connection.BeginTransaction();
                    try
                    {
                        var flag = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Delete(connection, trans, model.AdjID);
                        if (flag <= 0)
                        {
                            trans.Rollback();
                            return 0;
                        }
                        foreach (var stockAdj in models)
                        {
                            stockAdj.IsDispose = 0;
                            stockAdj.RefAdjID = "";
                            flag = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(connection, trans, stockAdj);
                            if (flag <= 0)
                            {
                                trans.Rollback();
                                return 0;
                            }
                        }
                        trans.Commit();
                        return 1;
                    }
                    catch (Exception ex)
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
                else
                {
                    return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Delete(model);
                }
            }
            else
            {
                return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Delete(model);
            }
        }
        #endregion


        #region 根据主键逻辑删除一个StockAdj
        /// <summary>
        /// 根据主键逻辑删除一个StockAdj
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).LogicDelete(adjID);
        }
        #endregion


        #region 根据字典获取StockAdj对象
        /// <summary>
        /// 根据字典获取StockAdj对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>StockAdj对象</returns>
        public static StockAdj GetModel(StockAdjQuery query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetModel(query);
        }
        #endregion


        #region 根据主键获取StockAdj对象
        /// <summary>
        /// 根据主键获取StockAdj对象
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>StockAdj对象</returns>
        public static StockAdj GetModel(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetModel(adjID);
        }
        #endregion


        #region 根据字典获取StockAdj集合
        /// <summary>
        /// 根据字典获取StockAdj集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<StockAdj> GetList(StockAdjQuery query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetList(query);
        }
        #endregion


        #region 根据字典获取StockAdj数据集
        /// <summary>
        /// 根据字典获取StockAdj数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取StockAdj集合
        /// <summary>
        /// 分页获取StockAdj集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<StockAdj> GetPageList(PageListBySql<StockAdj> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }

    public partial class StockAdjBLO
    {
        #region 删除一个StockAdj
        /// <summary>
        /// 删除一个StockAdj
        /// </summary>
        /// <param name="adjID">主键</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Delete(adjID);
        }
        #endregion

        #region 删除一个StockAdj 同步删除 关联的详情表和详情扩展表
        /// <summary>
        /// 删除一个StockAdj 同步删除 关联的详情表和详情扩展表
        /// </summary>
        /// <param name="adjID">主键</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int DeleteInfo(string adjID, string warehouseId)
        {
            //获取单据现有状态，为盘亏单查找是否有关联的自动盘盈单做准备
            var model = GetModel(adjID, warehouseId);
            var models = new List<StockAdj>();
            if (model.AdjType == 1)
            {
                //查找盘亏单对应的自动盘盈单 注意：要在事务操作前查询
                models = GetListByRefBID(model.AdjID, int.Parse(warehouseId)).ToList();
            }
            int row = 0;
            var connection = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {   //删除主表记录时，同步删除相关的详情表和详情扩展表的记录，采用事务处理
                row += DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Delete(connection, trans, adjID);
                DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Delete(adjID, connection, trans);
                DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Delete(adjID, connection, trans);
                if (model.AdjType == 1)
                {
                    if (models != null && models.Count > 0)
                    {
                        //修改对应的盘盈单的字段值
                        foreach (var stockAdj in models)
                        {
                            stockAdj.IsDispose = 0;
                            stockAdj.RefAdjID = "";
                            var flag = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(connection, trans, stockAdj);
                            if (flag <= 0)
                            {
                                row = 0;
                                trans.Rollback();
                            }
                        }
                    }
                }
                trans.Commit();
            }
            catch (Exception)
            {
                row = 0;
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return row;
        }
        #endregion

        #region 盘点调整主表(盘亏盘盈表) 状态更新
        /// <summary>
        /// 盘点调整主表(盘亏盘盈表) 状态更新
        /// </summary>
        /// <param name="adjID">盘点ID</param>
        /// <param name="status">盘点调整主表(盘亏盘盈表) 状态</param>
        /// <param name="userID">操作用户ID</param>
        /// <param name="userName">操作用户名称</param>
        /// <param name="warehouseId">仓库ID，决定连接哪个数据库</param>
        /// <param name="message">执行后的提示信息</param>
        /// <returns>影响的行数</returns>
        public static int UpdateStatus(string adjID, StockAdjStatus status, int userID, string userName, string warehouseId, ref string message)
        {
            int row = 0;
            string msg = string.Empty;
            StockAdj updateModel = new StockAdj();

            updateModel.AdjID = adjID;
            updateModel.ModifyTime = DateTime.Now;
            updateModel.ModifyUserID = userID;
            updateModel.ModifyUserName = userName;
            updateModel.Status = (int)status;

            //现有数据库中的记录 准备给后续的操作
            StockAdj nowModel = StockAdjBLO.GetModel(adjID, warehouseId);
            //调整类型(0:调增库存;1:调减库存)
            int adjType = nowModel.AdjType;

            //查找盘亏单是否有对应的自动盘盈单
            IList<StockAdj> models = new List<StockAdj>();
            //性能优化 只有在盘亏单的过账操作时 才需要查询
            if (status == StockAdjStatus.Posted && adjType == 1)
            {
                models = GetListByRefBID(adjID, int.Parse(warehouseId));
            }

            #region 确认/反确认/过账时，更新相应的时间和用户信息字段
            if (status == StockAdjStatus.Submitted)
            {
                updateModel.ConfTime = DateTime.Now;
                updateModel.ConfUserID = userID;
                updateModel.ConfUserName = userName;
            }
            else if (status == StockAdjStatus.Posted)
            {
                updateModel.PostingTime = DateTime.Now;
                updateModel.PostingUserID = userID;
                updateModel.PostingUserName = userName;
            }
            else if (status == StockAdjStatus.Uncommitted)
            {
                updateModel.ConfTime = null;
                updateModel.ConfUserID = null;
                updateModel.ConfUserName = null;
            }
            #endregion

            #region 获取该单据下的明细
            IList<StockAdjDetail> stockAdjDetails = new List<StockAdjDetail>();
            //性能优化 只有过账操作才需要查询明细
            if (status == StockAdjStatus.Posted)
            {
                StockAdjDetailQuery detailQuery = new StockAdjDetailQuery() { AdjID = adjID };
                stockAdjDetails = StockAdjDetailBLO.GetList(detailQuery, warehouseId);
            }

            #endregion

            //如果是盘盈单的过账操作，要同时更新库存,采用事务处理
            if (status == StockAdjStatus.Posted && adjType == 0)
            {
                //2016-7-1 胡总反馈 经过再次开会讨论，2016-6-30的逻辑取消 要求代码先注释掉
                #region 2016-6-30 开会讨论 需求方要求 在盘点单过账时 要更新盘点调整明细表的 供应商的信息为最后一次供应商的信息，如果不存在，则取商品主供应商的信息
                ////准备调用 产品SDK,获取到 基本资料中心客户端SDK访问对象 （根据2016-3-22 胡勇提供的 “5个服务中心的依赖关系”，订单SDK可以调用基本资料SDK，但不可反向调用）
                //var productWorkContext = WorkContext.CreateProductSdkClient();
                //var requestDto = new Product.SDK.Request.FrxsErpProductVendorLastBuyGetRequest() { WID = int.Parse(warehouseId), UserId = userID, UserName = userName };
                //var prdResp = productWorkContext.Execute(requestDto);
                //if (prdResp == null)
                //{
                //    message += "调用基础资料服务中心接口失败!";
                //    return 0;
                //}
                #endregion

                #region 如果是盘盈单的过账操作，要同时更新库存

                #region 更新主表状态字段 + 遍历明细 更新库存信息 事务处理
                var connection = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetConnection();
                connection.Open();
                var trans = connection.BeginTransaction();
                try
                {
                    //修改盘盈单主表的状态字段
                    row += DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(connection, trans, updateModel);

                    #region 遍历明细 批量改库存
                    BatStockInModel stockInModel = new BatStockInModel();
                    stockInModel.BatchNO = adjID; ////盘亏盘赢调整编号
                    stockInModel.WID = nowModel.WID;
                    stockInModel.WCode = nowModel.WCode;
                    stockInModel.WName = nowModel.WName;
                    stockInModel.SubWID = nowModel.SubWID;
                    stockInModel.SubWName = nowModel.SubWName;
                    stockInModel.CreateUserID = userID;
                    stockInModel.CreateUserName = userName;
                    IList<StockFIFOInModel> InPList = new List<StockFIFOInModel>();
                    foreach (var adjDetail in stockAdjDetails)
                    {
                        StockFIFOInModel temp = new StockFIFOInModel();
                        temp.BatchNO = adjID;//盘亏盘赢调整编号
                        temp.WID = nowModel.WID;
                        temp.WCode = nowModel.WCode;
                        temp.WName = nowModel.WName;
                        temp.SubWID = nowModel.SubWID;
                        temp.SubWName = nowModel.SubWName;
                        temp.ProductID = adjDetail.ProductId;
                        temp.SKU = adjDetail.SKU;
                        temp.ProductName = adjDetail.ProductName;
                        temp.StockQty = 0.0m;
                        temp.BillType = 2;//单据类型(0：采购入库;1:销售退货;2:盘盈)
                        temp.BillID = adjID;//盘亏盘赢调整编号
                        temp.BillDetailID = adjDetail.ID;//盘盈单调整明细表的单号
                        temp.Unit = adjDetail.Unit;
                        temp.Qty = adjDetail.UnitQty;
                        temp.TotalOutQty = 0.0m;
                        temp.Flag = 0;
                        temp.VendorID = adjDetail.VendorID;
                        temp.VendorCode = adjDetail.VendorCode;
                        temp.VendorName = adjDetail.VendorName;

                        //2016-7-1 胡总反馈 经过再次开会讨论，2016-6-30的逻辑取消 要求代码先注释掉
                        #region 2016-6-30 新需求 找出该明细对应的最新供应商信息,更新该条明细的供应商信息
                        //if (prdResp.Data != null && prdResp.Data.Count > 0)
                        //{
                        //    var vendor = prdResp.Data.FirstOrDefault(o => o.ProductId == adjDetail.ProductId);
                        //    if (vendor == null || vendor.VendorID <= 0 || string.IsNullOrEmpty(vendor.VendorCode))
                        //    {//按照叶求的意见，如果发现供应商信息为空，认为整批数据不可靠，整个事务终止。
                        //        message += string.Format("数据异常：[{0}]主供应商为空！", adjDetail.SKU);
                        //        trans.Rollback();
                        //        return 0;
                        //    }
                        //    //供应商信息有变化的时候更新明细表
                        //    if (vendor.VendorID != adjDetail.VendorID)// 是否需要盘点 VendorCode不为空？
                        //    {
                        //        StockAdjDetail updateDetailModel = new StockAdjDetail();
                        //        updateDetailModel.ID = adjDetail.ID;
                        //        updateDetailModel.VendorID = vendor.VendorID;
                        //        updateDetailModel.VendorCode = vendor.VendorCode;
                        //        updateDetailModel.VendorName = vendor.VendorName;
                        //        //更新该条明细的供应商信息 新平台框架的映射方法，只会更新指定的字段的值
                        //        DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Edit(connection, trans, updateDetailModel);
                        //        //调用接口传值的时候也传入新的值
                        //        temp.VendorID = vendor.VendorID;
                        //        temp.VendorCode = vendor.VendorCode;
                        //        temp.VendorName = vendor.VendorName;
                        //    }
                        //}
                        #endregion

                        temp.InPrice = adjDetail.BuyPrice;
                        temp.StockTime = DateTime.Now;
                        temp.ModifyTime = DateTime.Now;
                        InPList.Add(temp);
                    }
                    stockInModel.InPList = InPList;
                    StockMangerBLO.BatStockIn(stockInModel, connection, trans);
                    #endregion

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    message += ex.Message;
                    trans.Rollback();
                    if (ex.StackTrace.Contains("StockMangerBLO.BatStockIn"))
                    {
                        message = string.Format("批次入库失败:{0}", message);
                        return 0;
                    }
                    throw;
                }
                finally
                {
                    trans.Dispose();
                    connection.Close();
                    connection.Dispose();
                }

                #endregion
                #endregion
            }
            else if (status == StockAdjStatus.Posted && adjType == 1)
            {
                #region 盘亏单过账时更新出库库存
                var connection = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetConnection();
                connection.Open();
                var trans = connection.BeginTransaction();
                try
                {
                    //修改盘盈单主表的状态字段
                    row += DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(connection, trans, updateModel);

                    #region 遍历明细 修改库存 出库
                    BatStockOutModel outMod = new BatStockOutModel();
                    outMod.WID = nowModel.WID;
                    outMod.SubWID = nowModel.SubWID;
                    outMod.BillType = 5; //单据类型(3：采购退库;4:销售出货;5:盘亏)
                    outMod.BillID = adjID;//盘亏盘赢调整编号
                    outMod.CreateUserID = userID;
                    outMod.CreateUserName = userName;
                    IList<StockOutInPutInModel> OutPList = new List<StockOutInPutInModel>();
                    foreach (var adjDetail in stockAdjDetails)
                    {
                        StockOutInPutInModel temp = new StockOutInPutInModel();
                        temp.BillDetailID = adjDetail.ID;
                        temp.ProductID = adjDetail.ProductId;
                        temp.SKU = adjDetail.SKU;
                        temp.OutQty = adjDetail.UnitQty;
                        OutPList.Add(temp);
                    }
                    outMod.OutPList = OutPList;

                    bool updateBatStockOut = StockMangerBLO.BatStockOut(outMod, false, connection, trans, ref message);
                    if (!updateBatStockOut)
                    {
                        //异常
                        message = string.Format("盘亏单[{0}]更新库存失败!<br /> {1}", adjID, message);
                        msg += message;
                        trans.Rollback();
                        return row - 1;
                    }

                    //修改盘亏单对应的自动盘盈单的状态
                    if (models != null && models.Count > 0)
                    {
                        //有对应盘盈单数据
                        foreach (var stockAdj in models)
                        {
                            if (stockAdj.IsDispose != 2)
                            {
                                trans.Rollback();
                                message = string.Format("盘盈单[{0}]状态已发生变化，不能进行盘亏处理!<br />", stockAdj.AdjID);
                                msg += message;

                            }
                            stockAdj.IsDispose = 1;
                            var flag = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(connection, trans, stockAdj);
                            if (flag <= 0)
                            {
                                trans.Rollback();
                                message = string.Format("盘盈单[{0}]状态更新失败，不能进行盘亏处理!<br />", stockAdj.AdjID);
                                msg += message;
                            }
                        }
                    }

                    trans.Commit();
                    #endregion


                }
                catch (Exception ex)
                {
                    msg = ex.StackTrace;
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    trans.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
                #endregion
            }
            else
            {
                row += Edit(updateModel, warehouseId);
            }
            return row;
        }
        #endregion


        #region 盘点调整单状态

        /// <summary>
        /// 盘点调整主表(盘亏盘盈表) 状态
        /// </summary>
        public enum StockAdjStatus
        {
            /// <summary>
            /// 未提交
            /// </summary>
            [Description("未提交/反确认过的")]
            Uncommitted = 0,

            /// <summary>
            /// 已提交
            /// </summary>
            [Description("已提交/确认过的")]
            Submitted = 1,

            /// <summary>
            /// 已过帐
            /// </summary>
            [Description("已过帐")]
            Posted = 2,

            /// <summary>
            /// 作废
            /// </summary>
            [Description("作废")]
            Obsolete = 3
        }
        #endregion

        #region 根据AdjID获取明细表数量
        /// <summary>
        /// 根据AdjID获取明细表数量
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>明细表数量</returns>
        public static int GetDetailCount(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetDetailCount(adjID);
        }
        #endregion

        #region 根据AdjID获取明细表最大序号
        /// <summary>
        /// 根据AdjID获取明细表最大序号
        /// </summary>
        /// <param name="adjID">调整ID(WID+ ID服务)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>明细表最大序号</returns>
        public static int GetDetailMaxSerialNumber(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetDetailMaxSerialNumber(adjID);
        }
        #endregion

        #region 根据AdjID获取调整总数和总金额
        /// <summary>
        /// 根据AdjID获取调整总数和总金额
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>盘点调整单下的总计对象(总数、总金额)</returns>
        public static StockAdjSum GetSumQtyAmt(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetSumQtyAmt(adjID);
        }
        #endregion

        #region 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// <summary>
        /// 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>明细的差额对象集合</returns>
        public static IList<StockAdjDif> GetAdjDif(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetAdjDif(adjID);
        }
        #endregion

        #region 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// <summary>
        /// 根据AdjID获取调整 明细的差额对象集合，适用于盘亏单过账操作的异常数据预先排查
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <returns>明细的差额对象集合</returns>
        public static IList<StockAdjDif> GetAdjQtys(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetAdjQtys(adjID);
        }
        #endregion

        #region 检查盘亏单的明细的调整数和实时库存的差额
        /// <summary>
        /// 检查盘亏单的明细的调整数和实时库存的差额
        /// </summary>
        /// <param name="adjID">盘点调整单ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="subWid">子机构ID</param>
        /// <returns>明细的差额对象集合</returns>
        public static IList<StockAdjDif> GetAdjQtysCheck(string adjID, string warehouseId, int subWid)
        {
            //初始化要返回的集合对象
            IList<StockAdjDif> adjDifs = new List<StockAdjDif>();

            //现有的明细记录的 调整数，库存数量清单
            List<StockAdjDif> ajdDetail = GetAdjQtys(adjID, warehouseId).ToList();

            //将集合切割成适合接口调用的大小
            var splitList = new StockAdjTool().SplitList(ajdDetail, 500);

            int batchIndex = 1;
            foreach (var splitItem in splitList)
            {
                #region 批量获取库存数量
                //取出splitItem列表的SKU列 作为入参 批量查询商品详情和库存信息
                var skuQueryList = splitItem.Select(o => { return o.SKU; }).ToList();
                StockNQtyQuery stockQuery = new StockNQtyQuery() { WIDList = new List<int>() { int.Parse(warehouseId) }, SKUList = skuQueryList };
                var stockList = StockQueryBLO.QueryOStockQty(stockQuery).ToList();
                #endregion

                #region 判断库存  判断调用库存的访问对象是否可用
                if (stockList != null || stockList.Count > 0)
                {
                    foreach (var skuItem in splitItem)
                    {
                        #region 将查询到的库存不足的记录添加到集合
                        //匹配库存信息
                        var currentStock = stockList.FirstOrDefault(o => o.SKU == skuItem.SKU && o.SubWID == subWid);
                        //创建待加入集合的模型
                        StockAdjDif model = new StockAdjDif();
                        model.SKU = skuItem.SKU;
                        model.UnitQty = skuItem.UnitQty;

                        if (currentStock == null)
                        {
                            //查不到库存信息，则实时库存为0
                            model.StockQty = 0;
                            model.Dif = skuItem.UnitQty; //实时的库存差额
                            adjDifs.Add(model);
                        }
                        else
                        {
                            if (currentStock.StockQty < skuItem.UnitQty)
                            {
                                //查到库存信息不足的记录添加进集合
                                model.StockQty = currentStock.StockQty;//更新实时的库存量
                                model.Dif = skuItem.UnitQty - currentStock.StockQty; //实时的库存差额
                                adjDifs.Add(model);
                            }
                        }
                        #endregion
                    }
                }
                else
                {   //若调用库存的返回对象不可用
                    throw new Exception(string.Format("查询库存信息失败!(第{0}批次查询)", batchIndex));
                }
                #endregion
                batchIndex++;
            }
            return adjDifs;
        }
        #endregion
    }


    public partial class StockAdjBLO
    {
        /// <summary>
        /// 根据盘亏单号查找对应的盘盈单
        /// </summary>
        /// <param name="refBid"></param>
        /// <returns></returns>
        private static IList<StockAdj> GetListByRefBID(string refBid, int wid)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(wid.ToString()).GetList(new StockAdjQuery() { RefAdjID = refBid });
        }


        /// <summary>
        /// 创建盘亏单（对应自动盘盈）
        /// </summary>
        /// <param name="adjIds">对应的盘盈单号列表</param>
        /// <param name="wid">仓库ID</param>
        /// <param name="wCode">仓库Code</param>
        /// <param name="wName">仓库名称</param>
        /// <param name="subWid">子仓库ID</param>
        /// <param name="subWcode">子仓库Code</param>
        /// <param name="subWName">子仓库名称</param>
        /// <param name="user">操作者</param>
        /// <returns></returns>
        public static BackMessage<bool> SaveStockAdjDeficit(IList<string> adjIds, int wid, string wCode, string wName, int subWid, string subWcode, string subWName, BaseUserModel user)
        {
            #region 创建主表
            var id = CreateId(wid, user);
            if (!id.IsSuccess)
            {
                return BackMessage<bool>.FailBack(false, id.Message);
            }
            #region 记录备注信息
            string adjIdStr = string.Empty;
            int adjIdCount = 0;
            if (adjIds.ToList().Count > 0)
            {
                adjIdCount = adjIds.ToList().Count;
                foreach (var item in adjIds.ToList())
                {
                    adjIdStr += string.Format(" {0}, ", item);
                }
            }
            adjIdStr = string.Format("根据{0}笔自动盘盈单生成{1}", adjIdCount, adjIdStr);
            #endregion
            var stock = new StockAdj()
            {
                AdjID = id.Data,
                AdjDate = DateTime.Now,
                PlanID = null,
                WID = wid,
                WCode = wCode,
                WName = wName,
                SubWID = subWid,
                SubWCode = subWcode,
                SubWName = subWName,
                Status = 0,
                AdjType = 1,
                CreateFlag = 0,
                IsDispose = 0,
                RefBID = null,
                RefAdjID = null,
                ConfTime = null,
                ConfUserID = null,
                ConfUserName = null,
                PostingTime = null,
                PostingUserID = null,
                PostingUserName = null,
                Remark = string.Format("{0}根据{1}笔自动盘盈单生成", DateTime.Now.ToString("d"), adjIdCount),
                CreateTime = DateTime.Now,
                CreateUserID = user.UserId,
                CreateUserName = user.UserName,
                ModifyTime = DateTime.Now,
                ModifyUserID = user.UserId,
                ModifyUserName = user.UserName
            };
            #endregion

            #region 获取并合并明细
            var details = new List<StockAdjDetail>();
            var detailsExt = new List<StockAdjDetailsExt>();
            var prdouctList = new List<string>();
            var count = 0;
            foreach (var adjId in adjIds)
            {
                var tmpDetails = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(wid.ToString()).GetList(new StockAdjDetailQuery() { AdjID = adjId });
                var tmpDetailExt =
                    DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(wid.ToString()).GetList(
                        new StockAdjDetailsExtQuery() { AdjID = adjId });


                if (tmpDetails != null && tmpDetails.Count > 0 && tmpDetailExt != null && tmpDetailExt.Count > 0)
                {
                    if (tmpDetails.Count != tmpDetailExt.Count)
                    {
                        return BackMessage<bool>.FailBack(false, "明细与明细扩展数据不匹配");
                    }
                    for (int i = 0; i < tmpDetails.Count; i++)
                    {
                        var detail = tmpDetails[i];
                        var detailExt = tmpDetailExt.FirstOrDefault(x => x.ID == detail.ID);
                        if (detailExt == null)
                        {
                            return BackMessage<bool>.FailBack(false, "明细数据与扩展数据不匹配");
                        }
                        var tmpDetail =
                            details.FirstOrDefault(x => x.ProductId == detail.ProductId && x.AdjUnit == detail.AdjUnit);
                        if (tmpDetail == null)
                        {
                            detail.SerialNumber = count;
                            detail.ID = Guid.NewGuid().ToString();
                            detail.AdjID = stock.AdjID;
                            detail.ModifyTime = DateTime.Now;
                            detail.ModifyUserID = user.UserId;
                            detail.ModifyUserName = user.UserName;
                            details.Add(detail);

                            detailExt.ID = detail.ID;
                            detailExt.AdjID = stock.AdjID;
                            detailExt.ModifyTime = DateTime.Now;
                            detailExt.ModifyUserID = user.UserId;
                            detailExt.ModifyUserName = user.UserName;
                            detailsExt.Add(detailExt);

                            prdouctList.Add(detail.SKU);
                            count++;
                        }
                        else
                        {
                            tmpDetail.AdjQty += detail.AdjQty;
                            tmpDetail.AdjAmt += detail.AdjAmt;
                        }
                    }
                }
            }

            #region 批量获取库存数量
            StockNQtyQuery stockQuery = new StockNQtyQuery() { WIDList = new List<int>() { wid }, SKUList = prdouctList };
            var stockList = StockQueryBLO.QueryOStockQty(stockQuery).ToList();

            foreach (var detail in details)
            {
                if (stockList == null || stockList.Count <= 0)
                {
                    detail.StockQty = 0;
                }
                else
                {
                    var tmp = stockList.FirstOrDefault(x => x.SKU == detail.SKU && x.SubWID == subWid);
                    if (tmp == null)
                    {
                        detail.StockQty = 0;
                    }
                    else
                    {
                        detail.StockQty = tmp.StockQty;
                    }
                }
            }

            #endregion


            #endregion
            //查找盘亏单对应的自动盘盈单 注意：要在事务操作前查询
            var models = DALFactory.GetLazyInstance<IStockAdjDAO>(wid.ToString()).GetListByAdjIds(adjIds);

            #region 数据写入 事务操作开始
            var conn = DALFactory.GetLazyInstance<IStockAdjDAO>(wid.ToString()).GetConnection();
            conn.Open();
            var tran = conn.BeginTransaction();
            try
            {
                #region 主体数据写入
                var flag = DALFactory.GetLazyInstance<IStockAdjDAO>(wid.ToString()).Save(conn, tran, stock);
                if (flag <= 0)
                {
                    tran.Rollback();
                    return BackMessage<bool>.FailBack(false, "创建盘亏单数据失败");
                }

                foreach (var adjDetails in details)
                {
                    flag = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(wid.ToString()).Save(conn, tran, adjDetails);
                    if (flag <= 0)
                    {
                        tran.Rollback();
                        return BackMessage<bool>.FailBack(false, "创建盘亏单明细数据失败");
                    }
                }

                foreach (var adjDetailsExt in detailsExt)
                {
                    flag = DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(wid.ToString()).Save(conn, tran, adjDetailsExt);
                    if (flag <= 0)
                    {
                        tran.Rollback();
                        return BackMessage<bool>.FailBack(false, "创建盘亏单明细数据失败");
                    }
                }
                #endregion

                #region 更新盘盈单状态 事务操作
                if (models == null || models.Count <= 0)
                {
                    tran.Rollback();
                    return BackMessage<bool>.FailBack(false, "找不到对应的盘盈单信息");
                }
                foreach (var stockAdj in models)
                {
                    if (stockAdj.CreateFlag != 1)
                    {
                        tran.Rollback();
                        return BackMessage<bool>.FailBack(false, "不是自动盘盈生成的盘盈单不允许使用此方式进行盘亏处理");
                    }
                    if (stockAdj.IsDispose != 0)
                    {
                        tran.Rollback();
                        return BackMessage<bool>.FailBack(false, "盘盈单信息发生了变化，请刷新数据后重试");
                    }
                    stockAdj.RefAdjID = stock.AdjID;
                    stockAdj.IsDispose = 2;
                    flag = DALFactory.GetLazyInstance<IStockAdjDAO>(wid.ToString()).Edit(conn, tran, stockAdj);
                    if (flag <= 0)
                    {
                        tran.Rollback();
                        return BackMessage<bool>.FailBack(false, "更新盘盈单状态失败");
                    }
                }
                #endregion

                tran.Commit();
                return BackMessage<bool>.SuccessBack(true);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return BackMessage<bool>.FailBack(false, ex.Message);
            }
            finally
            {
                tran.Dispose();
                conn.Close();
                conn.Dispose();
            }

            #endregion
        }


        /// <summary>
        /// 自动盘盈数据检查
        /// </summary>
        /// <param name="stockAdj">盘盈单</param>
        /// <param name="details">明细</param>
        /// <param name="detailsExts">明细扩展</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        private static BackMessage<bool> CheckStockAdj(StockAdj stockAdj, IList<StockAdjDetail> details, IList<StockAdjDetailsExt> detailsExts, int wid)
        {
            #region 检查主表
            if (stockAdj.WID <= 0)
            {
                stockAdj.WID = wid;
            }
            if (string.IsNullOrEmpty(stockAdj.RefBID))
            {
                return BackMessage<bool>.FailBack(false, "自动盘盈单必须对应订单号");
            }
            if (details.Count != detailsExts.Count)
            {
                return BackMessage<bool>.FailBack(false, "商品明细和明细扩展不匹配");
            }

            #endregion

            #region 检查明细表
            int count = 1;
            foreach (var detail in details)
            {
                detail.ID = Guid.NewGuid().ToString();

                if (detail.WID <= 0)
                {
                    detail.WID = wid;
                }
                if (string.IsNullOrEmpty(detail.AdjID))
                {
                    detail.AdjID = stockAdj.AdjID;
                }
                if (detail.ProductId <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]编号不能为空", detail.SKU));
                }
                if (string.IsNullOrEmpty(detail.SKU))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]编码不能为空", detail.SKU));
                }
                if (string.IsNullOrEmpty(detail.ProductName))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]名称不能为空", detail.SKU));
                }
                if (string.IsNullOrEmpty(detail.AdjUnit))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]单位不能为空", detail.SKU));
                }
                if (detail.AdjPackingQty <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]包装数不能为空", detail.SKU));
                }
                if (detail.AdjQty <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]数量不能为空", detail.SKU));
                }
                //if (detail.BuyPrice <= 0) //采购价不能为空 2016-7-7 确认采购价允许为0
                //{
                //    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]采购价不能为空", detail.SKU));
                //}
                if (detail.SalePrice <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]配送价为零,不能自动盘盈！", detail.SKU));
                }
                if (detail.AdjAmt <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]金额不能为空", detail.SKU));
                }
                if (detail.VendorID <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]供应商不能为空", detail.SKU));
                }
                if (string.IsNullOrEmpty(detail.VendorCode))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]供应商编号不能为空", detail.SKU));
                }
                if (string.IsNullOrEmpty(detail.VendorName))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品[{0}]供应商名称不能为空", detail.SKU));
                }
                if (detail.UnitQty <= 0)
                {//注意：实际操作库存的时候是使用UnitQty这个字段而不是AdjQty
                    detail.UnitQty = detail.AdjQty;
                }
                detail.SerialNumber = count;
                detail.ModifyTime = DateTime.Now;


                count++;
            }

            #endregion

            #region 检查明细扩展表

            count = 0;
            foreach (var detailsExt in detailsExts)
            {
                detailsExt.ID = details[count].ID;
                detailsExt.AdjID = stockAdj.AdjID;
                if (detailsExt.CategoryId1 <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的基本分类1编号为空", details[count].ProductName));
                }
                if (detailsExt.CategoryId2 <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的基本分类2编号为空", details[count].ProductName));
                }
                if (detailsExt.CategoryId2 <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的基本分类3编号为空", details[count].ProductName));
                }
                if (string.IsNullOrEmpty(detailsExt.CategoryId1Name))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的基本分类1名称为空", details[count].ProductName));
                }
                if (string.IsNullOrEmpty(detailsExt.CategoryId2Name))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的基本分类2名称为空", details[count].ProductName));
                }
                if (string.IsNullOrEmpty(detailsExt.CategoryId3Name))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的基本分类3名称为空", details[count].ProductName));
                }


                if (detailsExt.ShopCategoryId1 <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的运营分类1编号为空", details[count].ProductName));
                }
                if (detailsExt.ShopCategoryId2 <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的运营分类2编号为空", details[count].ProductName));
                }
                if (detailsExt.ShopCategoryId2 <= 0)
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的运营分类3编号为空", details[count].ProductName));
                }
                if (string.IsNullOrEmpty(detailsExt.ShopCategoryId1Name))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的运营分类1名称为空", details[count].ProductName));
                }
                if (string.IsNullOrEmpty(detailsExt.ShopCategoryId2Name))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的运营分类2名称为空", details[count].ProductName));
                }
                if (string.IsNullOrEmpty(detailsExt.ShopCategoryId3Name))
                {
                    return BackMessage<bool>.FailBack(false, string.Format("商品{0}的运营分类3名称为空", details[count].ProductName));
                }

                detailsExt.ModifyTime = DateTime.Now;
                count++;
            }
            #endregion

            return BackMessage<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 生成新的盘盈单号
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private static BackMessage<string> CreateId(int wid, BaseUserModel user)
        {
            var service = WorkContext.CreateIDSdkClient();
            var resp = service.Execute(new Frxs.Erp.ServiceCenter.ID.SDK.Request.FrxsErpIdIdsGetRequest()
            {
                WID = wid,
                Type = Frxs.Erp.ServiceCenter.ID.SDK.Request.FrxsErpIdIdsGetRequest.IDTypes.StockAdj,
                UserId = user.UserId,
                UserName = user.UserName
            });
            if (resp == null)
            {
                throw new Exception("生成单据号失败");
            }
            if (resp.Flag == 0)
            {
                return BackMessage<string>.SuccessBack(resp.Data);
            }
            return BackMessage<string>.FailBack("", resp.Info);
        }

        /// <summary>
        /// 创建自动盘盈单
        /// </summary>
        /// <param name="stockAdj">盘盈单</param>
        /// <param name="details">明细</param>
        /// <param name="detailsExts">明细扩展</param>
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static BackMessage<bool> CreateAutoStockAdjSurplus(StockAdj stockAdj, IList<StockAdjDetail> details, IList<StockAdjDetailsExt> detailsExts, int wid, BaseUserModel user, IDbConnection conn = null, IDbTransaction tran = null)
        {
            var old = GetModelByOrderId(stockAdj.RefBID, null, wid.ToString());
            if (old != null && old.Count > 0)
            {
                return BackMessage<bool>.FailBack(false, "订单已存在盘盈单或盘亏单");
            }
            stockAdj.AdjDate = DateTime.Now;
            stockAdj.CreateTime = DateTime.Now;
            stockAdj.CreateUserID = user.UserId;
            stockAdj.CreateUserName = user.UserName;
            stockAdj.ModifyTime = DateTime.Now;
            stockAdj.ModifyUserID = user.UserId;
            stockAdj.ModifyUserName = user.UserName;
            stockAdj.CreateFlag = 1;
            stockAdj.AdjType = 0;

            var id = CreateId(wid, user);
            if (!id.IsSuccess)
            {
                return BackMessage<bool>.FailBack(false, id.Message);
            }
            else
            {
                stockAdj.AdjID = id.Data;
            }

            var checkResult = CheckStockAdj(stockAdj, details, detailsExts, wid);
            if (!checkResult.IsSuccess)
            {
                return checkResult;
            }
            var bflag = false;
            if (conn == null || tran == null)
            {
                conn = DALFactory.GetLazyInstance<IStockAdjDAO>(wid.ToString()).GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();
                bflag = true;
            }
            try
            {
                //自动盘盈单为已过帐状态
                stockAdj.Status = 2;
                stockAdj.ConfTime = DateTime.Now;
                stockAdj.ConfUserID = user.UserId;
                stockAdj.ConfUserName = user.UserName;
                stockAdj.PostingTime = DateTime.Now;
                stockAdj.PostingUserID = user.UserId;
                stockAdj.PostingUserName = user.UserName;
                var flag = DALFactory.GetLazyInstance<IStockAdjDAO>(wid.ToString()).Save(conn, tran, stockAdj);
                if (flag <= 0)
                {
                    if (bflag) tran.Rollback();
                    return BackMessage<bool>.FailBack(false, "添加盘盈单失败");
                }
                foreach (var detail in details)
                {
                    flag = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(wid.ToString()).Save(conn, tran, detail);
                    if (flag <= 0)
                    {
                        if (bflag) tran.Rollback();
                        return BackMessage<bool>.FailBack(false, "添加盘盈单明细失败");
                    }
                }
                foreach (var detailExt in detailsExts)
                {
                    flag = DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(wid.ToString()).Save(conn, tran, detailExt);
                    if (flag <= 0)
                    {
                        if (bflag) tran.Rollback();
                        return BackMessage<bool>.FailBack(false, "添加盘盈单明细扩展失败");
                    }
                }

                #region 批量改库存
                BatStockInModel stockInModel = new BatStockInModel();
                stockInModel.BatchNO = stockAdj.AdjID; ////盘亏盘赢调整编号
                stockInModel.WID = wid;
                stockInModel.WCode = stockAdj.WCode;
                stockInModel.WName = stockAdj.WName;
                stockInModel.SubWID = stockAdj.SubWID;
                stockInModel.SubWName = stockAdj.SubWName;
                stockInModel.CreateUserID = user.UserId;
                stockInModel.CreateUserName = user.UserName;
                IList<StockFIFOInModel> InPList = new List<StockFIFOInModel>();
                foreach (var adjDetail in details)
                {
                    StockFIFOInModel temp = new StockFIFOInModel();
                    temp.BatchNO = stockAdj.AdjID;//盘亏盘赢调整编号
                    temp.WID = stockAdj.WID;
                    temp.WCode = stockAdj.WCode;
                    temp.WName = stockAdj.WName;
                    temp.SubWID = stockAdj.SubWID;
                    temp.SubWName = stockAdj.SubWName;
                    temp.ProductID = adjDetail.ProductId;
                    temp.SKU = adjDetail.SKU;
                    temp.ProductName = adjDetail.ProductName;
                    temp.StockQty = 0.0m;
                    temp.BillType = 2;//单据类型(0：采购入库;1:销售退货;2:盘盈)
                    temp.BillID = stockAdj.AdjID;//盘亏盘赢调整编号
                    temp.BillDetailID = adjDetail.ID;//盘盈单调整明细表的单号
                    temp.Unit = adjDetail.Unit;
                    temp.Qty = adjDetail.UnitQty;
                    temp.TotalOutQty = 0.0m;
                    temp.Flag = 0;
                    temp.VendorID = adjDetail.VendorID;
                    temp.VendorCode = adjDetail.VendorCode;
                    temp.VendorName = adjDetail.VendorName;
                    temp.InPrice = adjDetail.BuyPrice;
                    temp.StockTime = DateTime.Now;
                    temp.ModifyTime = DateTime.Now;
                    InPList.Add(temp);
                }
                stockInModel.InPList = InPList;
                StockMangerBLO.BatStockIn(stockInModel, conn, tran);
                #endregion

                if (bflag) tran.Commit();
                return BackMessage<bool>.SuccessBack(true);
            }
            catch (Exception ex)
            {
                if (bflag) tran.Rollback();
                return BackMessage<bool>.FailBack(false, ex.Message);
            }
            finally
            {
                if (bflag)
                {
                    tran.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
        }



        /// <summary>
        ///  根据orderId获取其盘盈盘亏单
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="adjType">0-盘盈单 1-盘亏单</param>
        /// <returns></returns>
        public static IList<StockAdj> GetModelByOrderId(string orderId, int? adjType, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).GetModelByOrderId(orderId, adjType);
        }

        /// <summary>
        /// 自动盘盈做完盘亏后，回写盘盈单状态
        /// </summary>
        /// <param name="adjId">盘盈单单号</param>
        /// <param name="backAdjId">盘亏单单号</param>
        /// <param name="isDispose">是否已做盘亏标志</param>
        /// <param name="conn">事务链接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public static BackMessage<bool> UpdateAutoStockAdjStatus(string adjId, string backAdjId, int isDispose, string warehouseId, IDbConnection conn = null, IDbTransaction tran = null)
        {
            var stockAdj = GetModel(adjId, warehouseId);
            if (stockAdj == null)
            {
                return BackMessage<bool>.FailBack(false, "没有找到这笔盘盈单数据");
            }
            if (stockAdj.IsDispose == isDispose)
            {
                return BackMessage<bool>.FailBack(false, "盘盈单状态已改变，请刷新后重试");
            }
            stockAdj.IsDispose = isDispose;
            stockAdj.RefAdjID = backAdjId;
            var flag = 0;
            if (conn == null || tran == null)
            {
                flag = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(stockAdj);
            }
            else
            {
                flag = DALFactory.GetLazyInstance<IStockAdjDAO>(warehouseId).Edit(conn, tran, stockAdj);
            }
            if (flag != 0)
            {
                return BackMessage<bool>.SuccessBack(true);
            }
            else
            {
                return BackMessage<bool>.FailBack(false, "更新状态失败");
            }

        }

    }
}