
/*****************************
* Author:leidong
*
* Date:2016-04-05
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Erp.ServiceCenter.Order.Model.Deliver;

namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleOrderPre数据库访问接口
    /// </summary>
    public partial interface ISaleOrderPreDAO : IBaseDAO
    {
        #region 成员方法
        #region 根据主键验证SaleOrderPre是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPre是否存在
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderPre model);
        #endregion


        #region 添加一个SaleOrderPre
        /// <summary>
        /// 添加一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个SaleOrderPre
        /// <summary>
        /// 更新一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null);

        /// <summary>
        /// 更新一个SaleOrderPre 状态
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int EditSatusByOrderId(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 删除一个SaleOrderPre
        /// <summary>
        /// 删除一个SaleOrderPre
        /// </summary>
        /// <param name="model">SaleOrderPre对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderPre model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPre
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPre
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string orderId);
        #endregion


        #region 根据字典获取SaleOrderPre对象
        /// <summary>
        /// 根据字典获取SaleOrderPre对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderPre对象</returns>
        SaleOrderPre GetModel(IDictionary<string, object> conditionDict);
        #endregion

        #region 根据字典获取SaleOrderPre集合
        /// <summary>
        /// 根据字典获取SaleOrderPre集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPre> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderPre数据集
        /// <summary>
        /// 根据字典获取SaleOrderPre数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderPre集合
        /// <summary>
        /// 分页获取SaleOrderPre集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleOrderPre> GetPageList(PageListBySql<SaleOrderPre> page, IDictionary<string, object> conditionDict);
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #endregion
    }

    /// <summary>
    /// ### SaleOrderPre数据库访问接口
    /// 龙武
    /// </summary>
    public partial interface ISaleOrderPreDAO : IBaseDAO
    {
        /// <summary>
        /// 获取待拣货数量
        /// </summary>
        /// <param name="shelfAreaID">获取编号</param>
        /// <returns></returns>
        int? GetWaitPickingNum(int shelfAreaID);

        /// <summary>
        /// 分页获取等待拣货订单列表
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderPreWaitPickingList> GetPageWaitPickList(PageListBySql<SaleOrderPreWaitPickingList> page, IDictionary<string, object> conditionDict);

        /// <summary>
        /// 获取订单详情(APP)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        SaleOrderPreWaitPickingList GetWaitPickDetails(string orderId, int shelfAreaID);

        /// <summary>
        /// 获取订单详情(后台)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="shelfAreaID">货区编号</param>
        SaleOrderPreWaitPickingList GetWaitPickDetails(string orderId);

        /// <summary>
        /// 分页获取正在拣货订单列表
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderPre7ShelfArea> GetPageAtPickList(PageListBySql<SaleOrderPre7ShelfArea> page, IDictionary<string, object> conditionDict);

        /// <summary>
        /// 开始拣货更新订单数据
        /// </summary>
        /// <param name="status"></param>
        /// <param name="stationNumber"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int UpdateSaleOrderPick(string orderID, int status, int stationNumber, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 提交拣货
        /// </summary>
        /// <param name="orderDetails">拣货数据</param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        ReturnSubmitInfo SubmitPick(SubmitPickOrder orderDetails, string warehouseId, List<PickUserIdAndUserName> userInfo, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 提交对货
        /// </summary>
        /// <param name="shelfAreaId">货区编号</param>
        /// <param name="checkedUserId">拣货人编号</param>
        /// <param name="checkedUserName">贱货人名称</param>
        /// <param name="orderId">订单编号</param>
        /// <param name="goodsInfo">商品信息</param>
        /// <returns></returns>
        string SubmitCheckedGoods(int shelfAreaId, int checkedUserId, string checkedUserName, string orderId, List<CheckedGoodsNumInfo> goodsInfo, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 开始拣货操作更新库存数量
        /// </summary>
        /// <param name="stockModel">商品编号和对应库存数</param>
        /// <param name="orderId">订单编号</param>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns></returns>
        bool EditEnQty(IList<ProductUserQty> stockModel, string orderId, string shelfAreaId, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 获取装箱订单列表
        /// </summary>
        /// <param name="WID">仓库编号</param>
        /// <returns></returns>
        IList<SaleOrderPre> GetPackingList(string WID);

        /// <summary>
        /// 获取拣货时间
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="shelfAreaID"></param>
        /// <returns></returns>
        PickTimeModel GetPickTimeByOrderIdAndAreaID(string orderId, string shelfAreaID);
    }

    /// <summary>
    /// ### SaleOrderPre数据库访问接口
    /// chujl
    /// </summary>
    public partial interface ISaleOrderPreDAO : IBaseDAO
    {
        /// <summary>
        /// 等待配送
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="empId"></param>
        /// <param name="lineIDs"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        IList<WaitDeliverData> GetWaitDeliverData(string orderId, string empId, string lineIDs, string status);

        /// <summary>
        /// 配送对账明细
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="empId"></param>
        /// <param name="lineIDs"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        IList<SaleDeliverOrderInfo> GetSaleOrderDetailInfo(string searchDate, string empId, string lineIDs);

        /// <summary>
        /// 配送对账汇总
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="empId"></param>
        /// <param name="lineIDs"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        IList<SaleDeliverOrderInfo> GetSaleOrderTotalInfo(string searchMonth, string empId, string lineIDs);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="lineIDs"></param>
        /// <returns></returns>
        IList<PickingData> GetPickingData(string wid, string lineIDs);

        /// <summary>
        /// 商品信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        IList<ProductData> GetProductData(string wid, string orderId);

        /// <summary>
        /// 商品信息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        IList<ProductDetailExt> GetProductDataExt(string wid, string orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        DeliverOrderInfo GetDeliverOrderInfo(string orderId, string wid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        DeliverOrderInfo GetDeliverOrderInfoExt(string orderId, string wid);
    }
    public partial interface ISaleOrderPreDAO : IBaseDAO
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        IList<SaleOrderPre> Query(OrderQuery query, out int total);

        /// <summary>
        /// 修改订单线路
        /// </summary>
        /// <param name="model">订单模型，包含orderId,lineId,lineName即可</param>
        /// <returns></returns>
        int UpdateLine(SaleOrderPre model, BaseUserModel user);

        #region 根据主键获取SaleOrderPre对象(事物)
        /// <summary>
        /// 根据主键获取SaleOrderPre对象(事物)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        SaleOrderPre GetModel(IDbConnection conn, IDbTransaction tran, string orderId, string shelfAreaID);

        #endregion
        #region 根据主键获取SaleOrderPre对象(事物)
        /// <summary>
        /// 根据主键获取SaleOrderPre对象(事物)
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderPre对象</returns>
        SaleOrderPre GetModel(IDbConnection conn, IDbTransaction tran, string orderId);

        #endregion
        #region 根据主键获取SaleOrderPre对象
        SaleOrderPre GetModel(string orderId);
        #endregion

        /// <summary>
        /// 根据订单号集合获取订单信息集合
        /// </summary>
        /// <param name="orderIds">订单号集合</param>
        /// <returns>订单信息集合</returns>
        IList<SaleOrderPre> GetList(IList<string> orderIds);
    }
}