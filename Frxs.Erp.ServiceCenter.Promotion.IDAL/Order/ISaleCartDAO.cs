
/*****************************
* Author:leidong
*
* Date:2016-04-06
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Promotion.IDAL
{
    /// <summary>
    /// ### 销售购物车表SaleCart数据库访问接口
    /// </summary>
    public partial interface ISaleCartDAO:IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleCart是否存在
        /// <summary>
        /// 根据主键验证SaleCart是否存在
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleCart model);
        #endregion


        #region 添加一个SaleCart
        /// <summary>
        /// 添加一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleCart model, IDbConnection conn=null, IDbTransaction tran=null);
        #endregion


        #region 更新一个SaleCart
        /// <summary>
        /// 更新一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleCart model, IDbConnection conn=null, IDbTransaction tran=null);
        #endregion


        #region 删除一个SaleCart
        /// <summary>
        /// 删除一个SaleCart
        /// </summary>
        /// <param name="model">SaleCart对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleCart model, IDbConnection conn=null, IDbTransaction tran=null);
        #endregion


        #region 根据主键逻辑删除一个SaleCart
        /// <summary>
        /// 根据主键逻辑删除一个SaleCart
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(long iD);
        #endregion


        #region 根据字典获取SaleCart对象
        /// <summary>
        /// 根据字典获取SaleCart对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleCart对象</returns>
        SaleCart GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleCart对象
        /// <summary>
        /// 根据主键获取SaleCart对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>SaleCart对象</returns>
        SaleCart GetModel(long iD);
        #endregion


        #region 根据字典获取SaleCart集合
        /// <summary>
        /// 根据字典获取SaleCart集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleCart> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleCart数据集
        /// <summary>
        /// 根据字典获取SaleCart数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleCart集合
        /// <summary>
        /// 分页获取SaleCart集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SaleCart> GetPageList(PageListBySql<SaleCart> page, IDictionary<string, object> conditionDict);
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

    public partial interface ISaleCartDAO:IBaseDAO
    {
        /// <summary>
        /// 删除购物车列表
        /// </summary>
        /// <param name="shopId">门店ID</param>
        /// <param name="wId">仓库Id</param>
        /// <returns>true or false</returns>
        bool DeleteList(int shopId, int wId = 0,  IList<int> productIds=null,IDbConnection conn = null, IDbTransaction tran = null);


        /// <summary>
        /// 获取购物车商品数量
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        decimal GetCartsCount(int shopId, int? productId);
    }
}