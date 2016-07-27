
/*****************************
* Author:leidong
*
* Date:2016-04-14
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleOrderDetails数据库访问接口
    /// </summary>
    public partial interface ISaleOrderDetailsDAO
    {


        #region 成员方法

        #region 根据字典获取SaleOrderPreDetails集合
        /// <summary>
        /// 根据字典获取SaleOrderPreDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion

        #region 根据主键验证SaleOrderDetails是否存在
        /// <summary>
        /// 根据主键验证SaleOrderDetails是否存在
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderDetails model);
        #endregion


        #region 添加一个SaleOrderDetails
        /// <summary>
        /// 添加一个SaleOrderDetails
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderDetails model);
        #endregion


        #region 添加一个SaleOrderDetails(事务处理)
        /// <summary>
        /// 添加一个SaleOrderDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderDetails model);
        #endregion


        #region 更新一个SaleOrderDetails
        /// <summary>
        /// 更新一个SaleOrderDetails
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderDetails model);
        #endregion


        #region 更新一个SaleOrderDetails(事务处理)
        /// <summary>
        /// 更新一个SaleOrderDetails(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderDetails model);
        #endregion


        #region 删除一个SaleOrderDetails
        /// <summary>
        /// 删除一个SaleOrderDetails
        /// </summary>
        /// <param name="model">SaleOrderDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderDetails model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderDetails
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderDetails
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion




        #region 根据主键获取SaleOrderDetails对象
        /// <summary>
        /// 根据主键获取SaleOrderDetails对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleOrderDetails对象</returns>
        SaleOrderDetails GetModel(string iD);
        #endregion




        #region 根据字典获取SaleOrderDetails数据集
        /// <summary>
        /// 根据字典获取SaleOrderDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderDetails集合
        /// <summary>
        /// 分页获取SaleOrderDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderDetails> GetPageList(PageListBySql<SaleOrderDetails> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }


    public partial interface ISaleOrderDetailsDAO
    {
        /// <summary>
        /// 根据OrderId删除商品明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        int DeleteByOrderId(string orderId, IDbConnection conn, IDbTransaction tran);

    }
}