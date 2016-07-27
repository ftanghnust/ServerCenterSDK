﻿
/*****************************
* Author:CR
*
* Date:2016-04-25
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### BuyPreAppDetailsExt数据库访问接口
    /// </summary>
    public partial interface IBuyPreAppDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证BuyPreAppDetailsExt是否存在
        /// <summary>
        /// 根据主键验证BuyPreAppDetailsExt是否存在
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyPreAppDetailsExt model);
        #endregion


        #region 添加一个BuyPreAppDetailsExt
        /// <summary>
        /// 添加一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyPreAppDetailsExt model);
        #endregion


        #region 添加一个BuyPreAppDetailsExt(事务处理)
        /// <summary>
        /// 添加一个BuyPreAppDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, BuyPreAppDetailsExt model);
        #endregion


        #region 更新一个BuyPreAppDetailsExt
        /// <summary>
        /// 更新一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyPreAppDetailsExt model);
        #endregion


        #region 更新一个BuyPreAppDetailsExt(事务处理)
        /// <summary>
        /// 更新一个BuyPreAppDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, BuyPreAppDetailsExt model);
        #endregion


        #region 删除一个BuyPreAppDetailsExt
        /// <summary>
        /// 删除一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="model">BuyPreAppDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyPreAppDetailsExt model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        int Delete(IDbConnection conn, IDbTransaction tran, string appid);

        #endregion


        #region 根据主键逻辑删除一个BuyPreAppDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreAppDetailsExt
        /// </summary>
        /// <param name="iD">编号(BuyPreAppDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion



        #region 根据主键获取BuyPreAppDetailsExt对象
        /// <summary>
        /// 根据主键获取BuyPreAppDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(BuyPreAppDetails.ID)</param>
        /// <returns>BuyPreAppDetailsExt对象</returns>
        BuyPreAppDetailsExt GetModel(string iD);


        /// <summary>
        /// 根据主键获取BuyPreAppDetails对象
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        IList<BuyPreAppDetailsExt> GetModelList(string appId);
        #endregion



        #region 根据字典获取BuyPreAppDetailsExt数据集
        /// <summary>
        /// 根据字典获取BuyPreAppDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BuyPreAppDetailsExt集合
        /// <summary>
        /// 分页获取BuyPreAppDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<BuyPreAppDetailsExt> GetPageList(PageListBySql<BuyPreAppDetailsExt> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }
}