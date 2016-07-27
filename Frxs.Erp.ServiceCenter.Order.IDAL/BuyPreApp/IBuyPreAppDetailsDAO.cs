
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
    /// ### BuyPreAppDetails数据库访问接口
    /// </summary>
    public partial interface IBuyPreAppDetailsDAO
    {


        #region 成员方法
        #region 根据主键验证BuyPreAppDetails是否存在
        /// <summary>
        /// 根据主键验证BuyPreAppDetails是否存在
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BuyPreAppDetails model);
        #endregion


        #region 添加一个BuyPreAppDetails
        /// <summary>
        /// 添加一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BuyPreAppDetails model);
        #endregion


        #region 添加一个BuyPreAppDetails(事务处理)
        /// <summary>
        /// 添加一个BuyPreAppDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, BuyPreAppDetails model);
        #endregion


        #region 更新一个BuyPreAppDetails
        /// <summary>
        /// 更新一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BuyPreAppDetails model);
        #endregion


        #region 更新一个BuyPreAppDetails(事务处理)
        /// <summary>
        /// 更新一个BuyPreAppDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, BuyPreAppDetails model);
        #endregion


        #region 删除一个BuyPreAppDetails
        /// <summary>
        /// 删除一个BuyPreAppDetails
        /// </summary>
        /// <param name="model">BuyPreAppDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BuyPreAppDetails model);


        /// <summary>
        /// Delete一个BuyPreAppDetails(事务处理)
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        int Delete(IDbConnection conn, IDbTransaction tran, string appId);

        #endregion


        #region 根据主键逻辑删除一个BuyPreAppDetails
        /// <summary>
        /// 根据主键逻辑删除一个BuyPreAppDetails
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion




        #region 根据主键获取BuyPreAppDetails对象
        /// <summary>
        /// 根据主键获取BuyPreAppDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>BuyPreAppDetails对象</returns>
        BuyPreAppDetails GetModel(string iD);

        /// <summary>
        /// 根据主键获取BuyPreAppDetails对象
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        IList<BuyPreAppDetails> GetModelList(string appId);

        #endregion



        #region 根据字典获取BuyPreAppDetails数据集
        /// <summary>
        /// 根据字典获取BuyPreAppDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BuyPreAppDetails集合
        /// <summary>
        /// 分页获取BuyPreAppDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<BuyPreAppDetails> GetPageList(PageListBySql<BuyPreAppDetails> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }
}