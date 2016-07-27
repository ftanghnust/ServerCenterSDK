
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
    /// ### SaleOrderDetailsExt数据库访问接口
    /// </summary>
    public partial interface ISaleOrderDetailsExtDAO
    {


        #region 成员方法

        #region 根据字典获取SaleOrderPreDetailsExt集合
        /// <summary>
        /// 根据字典获取SaleOrderPreDetailsExt集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderDetailsExt> GetList(IDictionary<string, object> conditionDict);
        #endregion



        #region 根据主键验证SaleOrderDetailsExt是否存在
        /// <summary>
        /// 根据主键验证SaleOrderDetailsExt是否存在
        /// </summary>
        /// <param name="model">SaleOrderDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderDetailsExt model);
        #endregion


        #region 添加一个SaleOrderDetailsExt
        /// <summary>
        /// 添加一个SaleOrderDetailsExt
        /// </summary>
        /// <param name="model">SaleOrderDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderDetailsExt model);
        #endregion


        #region 添加一个SaleOrderDetailsExt(事务处理)
        /// <summary>
        /// 添加一个SaleOrderDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetailsExt对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderDetailsExt model);
        #endregion


        #region 更新一个SaleOrderDetailsExt
        /// <summary>
        /// 更新一个SaleOrderDetailsExt
        /// </summary>
        /// <param name="model">SaleOrderDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderDetailsExt model);
        #endregion


        #region 更新一个SaleOrderDetailsExt(事务处理)
        /// <summary>
        /// 更新一个SaleOrderDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderDetailsExt model);
        #endregion


        #region 删除一个SaleOrderDetailsExt
        /// <summary>
        /// 删除一个SaleOrderDetailsExt
        /// </summary>
        /// <param name="model">SaleOrderDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderDetailsExt
        /// </summary>
        /// <param name="iD">编号(SaleOrderDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion





        #region 根据主键获取SaleOrderDetailsExt对象
        /// <summary>
        /// 根据主键获取SaleOrderDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(SaleOrderDetails.ID)</param>
        /// <returns>SaleOrderDetailsExt对象</returns>
        SaleOrderDetailsExt GetModel(string iD);
        #endregion



        #region 根据字典获取SaleOrderDetailsExt数据集
        /// <summary>
        /// 根据字典获取SaleOrderDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderDetailsExt集合
        /// <summary>
        /// 分页获取SaleOrderDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderDetailsExt> GetPageList(PageListBySql<SaleOrderDetailsExt> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }
}