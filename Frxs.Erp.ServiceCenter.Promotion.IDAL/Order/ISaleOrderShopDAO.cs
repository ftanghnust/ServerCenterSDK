
/*****************************
* Author:leidong
*
* Date:2016-04-06
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Promotion.IDAL
{
    /// <summary>
    /// ### SaleOrderShop数据库访问接口
    /// </summary>
    public partial interface ISaleOrderShopDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderShop是否存在
        /// <summary>
        /// 根据主键验证SaleOrderShop是否存在
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderShop model);
        #endregion


        #region 添加一个SaleOrderShop
        /// <summary>
        /// 添加一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderShop model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个SaleOrderShop
        /// <summary>
        /// 更新一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderShop model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 删除一个SaleOrderShop
        /// <summary>
        /// 删除一个SaleOrderShop
        /// </summary>
        /// <param name="model">SaleOrderShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderShop model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderShop
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderShop
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string orderId);
        #endregion


        #region 根据字典获取SaleOrderShop对象
        /// <summary>
        /// 根据字典获取SaleOrderShop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderShop对象</returns>
        SaleOrderShop GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderShop对象
        /// <summary>
        /// 根据主键获取SaleOrderShop对象
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns>SaleOrderShop对象</returns>
        SaleOrderShop GetModel(string orderId);
        #endregion


        #region 根据字典获取SaleOrderShop集合
        /// <summary>
        /// 根据字典获取SaleOrderShop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderShop> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderShop数据集
        /// <summary>
        /// 根据字典获取SaleOrderShop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderShop集合
        /// <summary>
        /// 分页获取SaleOrderShop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleOrderShop> GetPageList(PageListBySql<SaleOrderShop> page, IDictionary<string, object> conditionDict);
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

        #region 用于门店排单
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="searchDate"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        IList<ShopOrder> GetShopOrder(string searchDate, int wid);

        #endregion
        #endregion


    }

    public partial interface ISaleOrderShopDAO : IBaseDAO
    {
        /// <summary>
        /// 获得未确认订单
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <returns></returns>
        SaleOrderShop GetUnConfirmOrder(int shopId);

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        IList<SaleOrderShop> Query(OrderQuery query,out int total);
    }
}