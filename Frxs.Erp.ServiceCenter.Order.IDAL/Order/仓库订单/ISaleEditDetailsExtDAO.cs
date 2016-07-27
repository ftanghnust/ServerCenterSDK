
/*****************************
* Author:leidong
*
* Date:2016-04-20
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleEditDetailsExt数据库访问接口
    /// </summary>
    public partial interface ISaleEditDetailsExtDAO
    {


        #region 成员方法
        #region 根据主键验证SaleEditDetailsExt是否存在
        /// <summary>
        /// 根据主键验证SaleEditDetailsExt是否存在
        /// </summary>
        /// <param name="model">SaleEditDetailsExt对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleEditDetailsExt model);
        #endregion


        #region 添加一个SaleEditDetailsExt
        /// <summary>
        /// 添加一个SaleEditDetailsExt
        /// </summary>
        /// <param name="model">SaleEditDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleEditDetailsExt model);
        #endregion


        #region 添加一个SaleEditDetailsExt(事务处理)
        /// <summary>
        /// 添加一个SaleEditDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleEditDetailsExt对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleEditDetailsExt model);
        #endregion


        #region 更新一个SaleEditDetailsExt
        /// <summary>
        /// 更新一个SaleEditDetailsExt
        /// </summary>
        /// <param name="model">SaleEditDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleEditDetailsExt model);
        #endregion


        #region 更新一个SaleEditDetailsExt(事务处理)
        /// <summary>
        /// 更新一个SaleEditDetailsExt(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleEditDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleEditDetailsExt model);
        #endregion


        #region 删除一个SaleEditDetailsExt
        /// <summary>
        /// 删除一个SaleEditDetailsExt
        /// </summary>
        /// <param name="model">SaleEditDetailsExt对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleEditDetailsExt model);
        #endregion


        #region 根据主键逻辑删除一个SaleEditDetailsExt
        /// <summary>
        /// 根据主键逻辑删除一个SaleEditDetailsExt
        /// </summary>
        /// <param name="iD">编号(SaleEditDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion




        #region 根据主键获取SaleEditDetailsExt对象
        /// <summary>
        /// 根据主键获取SaleEditDetailsExt对象
        /// </summary>
        /// <param name="iD">编号(SaleEditDetails.ID)</param>
        /// <returns>SaleEditDetailsExt对象</returns>
        SaleEditDetailsExt GetModel(string iD);
        #endregion





        #region 根据字典获取SaleEditDetailsExt数据集
        /// <summary>
        /// 根据字典获取SaleEditDetailsExt数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleEditDetailsExt集合
        /// <summary>
        /// 分页获取SaleEditDetailsExt集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleEditDetailsExt> GetPageList(PageListBySql<SaleEditDetailsExt> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }

    public partial interface ISaleEditDetailsExtDAO
    {
        /// <summary>
        /// 根据EditId删除明细扩展
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        int DeleteByEditId(string editId, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 根据editId查询列表
        /// </summary>
        /// <param name="editId">改单ID</param>
        /// <returns></returns>
        IList<SaleEditDetailsExt> GetList(string editId);
    }

}