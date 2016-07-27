﻿
/*****************************
* Author:leidong
*
* Date:2016-04-11
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleOrderTrack数据库访问接口
    /// </summary>
    public partial interface ISaleOrderTrackDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderTrack是否存在
        /// <summary>
        /// 根据主键验证SaleOrderTrack是否存在
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderTrack model);
        #endregion


        #region 添加一个SaleOrderTrack
        /// <summary>
        /// 添加一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderTrack model);
        #endregion


        #region 添加一个SaleOrderTrack(事务处理)
        /// <summary>
        /// 添加一个SaleOrderTrack(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderTrack model);
        #endregion


        #region 更新一个SaleOrderTrack
        /// <summary>
        /// 更新一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderTrack model);
        #endregion


        #region 更新一个SaleOrderTrack(事务处理)
        /// <summary>
        /// 更新一个SaleOrderTrack(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderTrack model);
        #endregion


        #region 删除一个SaleOrderTrack
        /// <summary>
        /// 删除一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderTrack model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderTrack
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderTrack
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleOrderTrack对象
        /// <summary>
        /// 根据字典获取SaleOrderTrack对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderTrack对象</returns>
        SaleOrderTrack GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderTrack对象
        /// <summary>
        /// 根据主键获取SaleOrderTrack对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <returns>SaleOrderTrack对象</returns>
        SaleOrderTrack GetModel(string iD);
        #endregion


        #region 根据字典获取SaleOrderTrack集合
        /// <summary>
        /// 根据字典获取SaleOrderTrack集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderTrack> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderTrack数据集
        /// <summary>
        /// 根据字典获取SaleOrderTrack数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderTrack集合
        /// <summary>
        /// 分页获取SaleOrderTrack集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderTrack> GetPageList(PageListBySql<SaleOrderTrack> page, IDictionary<string, object> conditionDict);
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
}