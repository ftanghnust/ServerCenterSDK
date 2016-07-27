/*****************************
* Author:罗靖
*
* Date:2016-06-17
******************************/

using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SettlementDetail数据库访问接口
    /// </summary>
    public partial interface ISettlementDetailDAO
    {

        #region  成员方法
        #region 根据主键验证SettlementDetail是否存在
        /// <summary>
        /// 根据主键验证SettlementDetail是否存在
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SettlementDetail model);
        #endregion


        #region 添加一个SettlementDetail
        /// <summary>
        /// 添加一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SettlementDetail model);
        #endregion


        #region 添加一个SettlementDetail(事务处理)
        /// <summary>
        /// 添加一个SettlementDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SettlementDetail model);
        #endregion


        #region 更新一个SettlementDetail
        /// <summary>
        /// 更新一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SettlementDetail model);
        #endregion


        #region 更新一个SettlementDetail(事务处理)
        /// <summary>
        /// 更新一个SettlementDetail(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SettlementDetail model);
        #endregion


        #region 删除一个SettlementDetail
        /// <summary>
        /// 删除一个SettlementDetail
        /// </summary>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SettlementDetail model);
        #endregion


        #region 根据主键逻辑删除一个SettlementDetail
        /// <summary>
        /// 根据主键逻辑删除一个SettlementDetail
        /// </summary>
        /// <param name="iD">ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取SettlementDetail对象
        /// <summary>
        /// 根据字典获取SettlementDetail对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SettlementDetail对象</returns>
        SettlementDetail GetModel(SettlementDetailQuery query);
        #endregion


        #region 根据主键获取SettlementDetail对象
        /// <summary>
        /// 根据主键获取SettlementDetail对象
        /// </summary>
        /// <param name="iD">ID</param>
        /// <returns>SettlementDetail对象</returns>
        SettlementDetail GetModel(int iD);
        #endregion


        #region 根据字典获取SettlementDetail集合
        /// <summary>
        /// 根据字典获取SettlementDetail集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<SettlementDetail> GetList(SettlementDetailQuery query);
        #endregion


        #region 根据字典获取SettlementDetail数据集
        /// <summary>
        /// 根据字典获取SettlementDetail数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SettlementDetail集合
        /// <summary>
        /// 分页获取SettlementDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SettlementDetail> GetPageList(PageListBySql<SettlementDetail> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion

    }

    public partial interface ISettlementDetailDAO
    {
        /// <summary>
        /// 根据条件获取日结数据列表（部分逻辑写入了存储过程）
        /// </summary>
        /// <param name="query">条件</param>
        /// <param name="procedureName">存储过程名称</param>
        /// <returns>数据集合</returns>
        IList<SettlementDetail> GetProductStockList(GetProductStockQuery query, string procedureName);


        /// <summary>
        /// 删除一个SettlementDetail
        /// </summary>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <param name="model">SettlementDetail对象</param>
        /// <returns>数据库影响行数</returns>
        int DeleteSettlementDetail(IDbConnection conn, IDbTransaction tran, SettlementDetail model);

   
    

    }

    /// <summary>
    /// 结算单明细表 - SettlementDetail  数据库访问接口  --- 龙武
    /// </summary>
    public partial interface ISettlementDetailDAO
    {
        /// <summary>
        /// 分页获取SettlementDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        SettlementDetailsList GetDetailsPageList(PageListBySql<SettlementDetail> page, IDictionary<string, object> conditionDict);
    }
}
