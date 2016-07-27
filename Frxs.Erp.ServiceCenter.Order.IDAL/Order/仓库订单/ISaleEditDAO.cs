﻿
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
    /// ### SaleEdit数据库访问接口
    /// </summary>
    public partial interface ISaleEditDAO
    {


        #region 成员方法
        #region 根据主键验证SaleEdit是否存在
        /// <summary>
        /// 根据主键验证SaleEdit是否存在
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleEdit model);
        #endregion


        #region 添加一个SaleEdit
        /// <summary>
        /// 添加一个SaleEdit
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleEdit model);
        #endregion


        #region 添加一个SaleEdit(事务处理)
        /// <summary>
        /// 添加一个SaleEdit(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleEdit对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleEdit model);
        #endregion


        #region 更新一个SaleEdit
        /// <summary>
        /// 更新一个SaleEdit
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleEdit model);
        #endregion


        #region 更新一个SaleEdit(事务处理)
        /// <summary>
        /// 更新一个SaleEdit(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleEdit对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleEdit model);
        #endregion


        #region 删除一个SaleEdit

        /// <summary>
        /// 删除一个SaleEdit
        /// </summary>
        /// <param name="model">SaleEdit对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleEdit model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 根据主键逻辑删除一个SaleEdit
        /// <summary>
        /// 根据主键逻辑删除一个SaleEdit
        /// </summary>
        /// <param name="editID">改单ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string editID);
        #endregion
  

        #region 根据主键获取SaleEdit对象
        /// <summary>
        /// 根据主键获取SaleEdit对象
        /// </summary>
        /// <param name="editID">改单ID</param>
        /// <returns>SaleEdit对象</returns>
        SaleEdit GetModel(string editID);
        #endregion
        
        #region 根据字典获取SaleEdit数据集
        /// <summary>
        /// 根据字典获取SaleEdit数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleEdit集合
        /// <summary>
        /// 分页获取SaleEdit集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleEdit> GetPageList(PageListBySql<SaleEdit> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }

    public partial interface ISaleEditDAO : IBaseDAO
     {
         /// <summary>
         /// 查询
         /// </summary>
         /// <param name="query">查询条件</param>
         /// <param name="total">总数量</param>
         /// <returns></returns>
         IList<SaleEdit> GetList(SaleEditQuery query,out int total);
     }
}