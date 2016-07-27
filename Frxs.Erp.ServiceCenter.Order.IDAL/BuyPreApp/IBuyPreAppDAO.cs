
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
    /// ### BuyPreApp数据库访问接口
    /// </summary>
    public partial interface IBuyPreAppDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证BuyPreApp是否存在
        /// <summary>
        /// 根据主键验证BuyPreApp是否存在
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyPreApp model);
        #endregion


        #region 添加一个BuyPreApp
        /// <summary>
        /// 添加一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyPreApp model);
        #endregion


        #region 添加一个BuyPreApp(事务处理)
        /// <summary>
        /// 添加一个BuyPreApp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, BuyPreApp model);
        #endregion


        #region 更新一个BuyPreApp
        /// <summary>
        /// 更新一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyPreApp model);
        #endregion


        #region 更新一个BuyPreApp(事务处理)
        /// <summary>
        /// 更新一个BuyPreApp(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, BuyPreApp model);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        int EditStatus(BuyPreApp model, IDbConnection conn, IDbTransaction tran);
        
        #endregion


        #region 删除一个BuyPreApp

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int Delete(string appId, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 删除一个BuyPreApp
        /// </summary>
        /// <param name="model">BuyPreApp对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyPreApp model);
        #endregion


        #region 根据主键逻辑删除一个BuyPreApp
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreApp
        /// </summary>
        /// <param name="appID">申请ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string appID);
        #endregion



        #region 根据主键获取BuyPreApp对象
        /// <summary>
        /// 根据主键获取BuyPreApp对象
        /// </summary>
        /// <param name="appID">申请ID</param>
        /// <returns>BuyPreApp对象</returns>
        BuyPreApp GetModel(string appID);
        #endregion




        #region 根据字典获取BuyPreApp数据集
        /// <summary>
        /// 根据字典获取BuyPreApp数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BuyPreApp集合
        /// <summary>
        /// 分页获取BuyPreApp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<BuyPreApp> GetPageList(PageListBySql<BuyPreApp> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }
}