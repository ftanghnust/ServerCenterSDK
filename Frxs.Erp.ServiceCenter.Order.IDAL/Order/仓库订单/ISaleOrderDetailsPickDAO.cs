
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
    /// ### SaleOrderDetailsPick数据库访问接口
    /// </summary>
    public partial interface ISaleOrderDetailsPickDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderDetailsPick是否存在
        /// <summary>
        /// 根据主键验证SaleOrderDetailsPick是否存在
        /// </summary>
        /// <param name="model">SaleOrderDetailsPick对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderDetailsPick model);
        #endregion


        #region 添加一个SaleOrderDetailsPick
        /// <summary>
        /// 添加一个SaleOrderDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderDetailsPick model);
        #endregion


        #region 添加一个SaleOrderDetailsPick(事务处理)
        /// <summary>
        /// 添加一个SaleOrderDetailsPick(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetailsPick对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderDetailsPick model);
        #endregion


        #region 更新一个SaleOrderDetailsPick
        /// <summary>
        /// 更新一个SaleOrderDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderDetailsPick model);
        #endregion


        #region 更新一个SaleOrderDetailsPick(事务处理)
        /// <summary>
        /// 更新一个SaleOrderDetailsPick(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderDetailsPick model);
        #endregion


        #region 删除一个SaleOrderDetailsPick
        /// <summary>
        /// 删除一个SaleOrderDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderDetailsPick model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderDetailsPick
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderDetailsPick
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion
        

        #region 根据主键获取SaleOrderDetailsPick对象
        /// <summary>
        /// 根据主键获取SaleOrderDetailsPick对象
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>SaleOrderDetailsPick对象</returns>
        SaleOrderDetailsPick GetModel(string iD);
        #endregion




        #region 根据字典获取SaleOrderDetailsPick数据集
        /// <summary>
        /// 根据字典获取SaleOrderDetailsPick数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderDetailsPick集合
        /// <summary>
        /// 分页获取SaleOrderDetailsPick集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderDetailsPick> GetPageList(PageListBySql<SaleOrderDetailsPick> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }
}