
/*****************************
* Author:CR
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 门店资料表Shop数据库访问接口
    /// </summary>
    public partial interface IShopDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证Shop是否存在
        /// <summary>
        /// 根据主键验证Shop是否存在
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>是否存在</returns>
        bool Exists(Shop model);
        #endregion


        #region 添加一个Shop
        /// <summary>
        /// 添加一个Shop
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Shop model);
        #endregion


        #region 更新一个Shop
        /// <summary>
        /// 更新一个Shop
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(Shop model);
        #endregion


        #region 删除一个Shop
        /// <summary>
        /// 删除一个Shop
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(Shop model);
        #endregion



        #region 根据字典获取Shop对象
        /// <summary>
        /// 根据字典获取Shop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Shop对象</returns>
        Shop GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取Shop对象
        /// <summary>
        /// 根据主键获取Shop对象
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns>Shop对象</returns>
        Shop GetModel(int shopID);
        #endregion


        #region 根据字典获取Shop集合
        /// <summary>
        /// 根据字典获取Shop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<Shop> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取Shop数据集
        /// <summary>
        /// 根据字典获取Shop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Shop集合
        /// <summary>
        /// 分页获取Shop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Shop> GetPageList(PageListBySql<Shop> page, IDictionary<string, object> conditionDict);
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

    public partial interface IShopDAO : IBaseDAO
    {
        /// <summary>
        /// 验证门店编号是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool ExistsShopCode(Shop model);

        /// <summary>
        /// 验证门店名称是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool ExistsShopName(Shop model);

        #region 逻辑删除一个Shop
        /// <summary>
        /// 根据对象逻辑删除一个Shop
        /// </summary>
        /// <param name="shopID">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(Shop model);
        #endregion

        #region 冻结或解冻一个Shop
        /// <summary>
        /// 冻结或解冻一个Shop
        /// </summary>
        /// <param name="shopID">Shop对象</param>
        /// <returns>数据库影响行数</returns>
        int ShopFreeze(Shop model);
        #endregion

        #region 仓库后台分页获取Shop集合
        /// <summary>
        /// 仓库后台分页获取Shop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Shop> GetWhPageList(PageListBySql<Shop> page, IDictionary<string, object> conditionDict);
        #endregion

        #region 仓库后台根据主键获取Shop对象
        /// <summary>
        /// 仓库后台根据主键获取Shop对象
        /// </summary>
        /// <param name="shopID">门店ID</param>
        /// <returns>Shop对象</returns>
        Shop GetModelInWh(int shopID);
        #endregion

        #region 添加一个Shop 事务处理
        /// <summary>
        /// 添加一个Shop 事务处理
        /// </summary>
        /// <param name="model">Shop对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Shop model, IDbConnection conn, IDbTransaction tran);
        #endregion
    }
    /// <summary>
    /// chujl
    /// </summary>
    public partial interface IShopDAO
    {


        /// <summary>
        /// 获取Shop 排单信息
        /// </summary>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        IList<ShopExt> GetShopAndOrderList(IDictionary<string, object> conditionDict);

    }

    /// <summary>
    /// 龙武
    /// </summary>
    public partial interface IShopDAO
    {
        /// <summary>
        /// 根据门店编号获取门店所属线路信息
        /// </summary>
        /// <param name="shopId">门店编号</param>
        /// <returns></returns>
        WarehouseLine GetShopLine(int shopId);
    }
}