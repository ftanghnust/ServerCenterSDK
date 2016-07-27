
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
    /// ### SaleOrderShopDetails数据库访问接口
    /// </summary>
    public partial interface ISaleOrderShopDetailsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderShopDetails是否存在
        /// <summary>
        /// 根据主键验证SaleOrderShopDetails是否存在
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderShopDetails model);
        #endregion


        #region 添加一个SaleOrderShopDetails
        /// <summary>
        /// 添加一个SaleOrderShopDetails
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderShopDetails model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个SaleOrderShopDetails
        /// <summary>
        /// 更新一个SaleOrderShopDetails
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderShopDetails model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 删除一个SaleOrderShopDetails
        /// <summary>
        /// 删除一个SaleOrderShopDetails
        /// </summary>
        /// <param name="model">SaleOrderShopDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderShopDetails model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderShopDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderShopDetails
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleOrderShopDetails对象
        /// <summary>
        /// 根据字典获取SaleOrderShopDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderShopDetails对象</returns>
        SaleOrderShopDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderShopDetails对象
        /// <summary>
        /// 根据主键获取SaleOrderShopDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleOrderShopDetails对象</returns>
        SaleOrderShopDetails GetModel(string iD);
        #endregion


        #region 根据字典获取SaleOrderShopDetails集合
        /// <summary>
        /// 根据字典获取SaleOrderShopDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderShopDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderShopDetails数据集
        /// <summary>
        /// 根据字典获取SaleOrderShopDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderShopDetails集合
        /// <summary>
        /// 分页获取SaleOrderShopDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleOrderShopDetails> GetPageList(PageListBySql<SaleOrderShopDetails> page, IDictionary<string, object> conditionDict);
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList);
        #endregion


        #endregion


    }
     public partial interface ISaleOrderShopDetailsDAO : IBaseDAO
     {
         /// <summary>
         /// 根据orderId清除订单商品明细
         /// </summary>
         /// <param name="orderId">订单ID</param>
         /// <returns>true or false</returns>
         bool DeleteByOrderId(string orderId, IDbConnection conn = null, IDbTransaction tran = null);
     }
}