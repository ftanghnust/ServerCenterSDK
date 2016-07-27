
/*****************************
* Author:CR
*
* Date:2016-03-31
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库商品限购明细表WProductNoSaleDetails数据库访问接口
    /// </summary>
    public partial interface IWProductNoSaleDetailsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证WProductNoSaleDetails是否存在
        /// <summary>
        /// 根据主键验证WProductNoSaleDetails是否存在
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductNoSaleDetails model);
        #endregion


        #region 添加一个WProductNoSaleDetails
        /// <summary>
        /// 添加一个WProductNoSaleDetails
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductNoSaleDetails model);
        #endregion


        #region 更新一个WProductNoSaleDetails
        /// <summary>
        /// 更新一个WProductNoSaleDetails
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductNoSaleDetails model);
        #endregion


        #region 删除一个WProductNoSaleDetails
        /// <summary>
        /// 删除一个WProductNoSaleDetails
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductNoSaleDetails model);
        #endregion


        #region 根据主键逻辑删除一个WProductNoSaleDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSaleDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取WProductNoSaleDetails对象
        /// <summary>
        /// 根据字典获取WProductNoSaleDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSaleDetails对象</returns>
        WProductNoSaleDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        


        #region 根据字典获取WProductNoSaleDetails集合
        /// <summary>
        /// 根据字典获取WProductNoSaleDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductNoSaleDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductNoSaleDetails数据集
        /// <summary>
        /// 根据字典获取WProductNoSaleDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductNoSaleDetails集合
        /// <summary>
        /// 分页获取WProductNoSaleDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProductNoSaleDetails> GetPageList(PageListBySql<WProductNoSaleDetails> page, IDictionary<string, object> conditionDict);
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

    /// <summary>
    /// 自定义方法 仓库商品限购明细表WProductNoSaleDetails数据库访问接口
    /// </summary>
    public partial interface IWProductNoSaleDetailsDAO : IBaseDAO
    {
        #region 根据 NoSaleID 获取 WProductNoSaleDetails对象集合
        /// <summary>
        /// 根据主键获取WProductNoSaleDetails对象集合
        /// </summary>
        /// <param name="NoSaleID">NoSaleID</param>
        /// <returns>WProductNoSaleDetails对象集合</returns>
        IList<WProductNoSaleDetails> GetList(string NoSaleID);
        #endregion


        #region 添加一个WProductNoSaleDetails 事务操作
        /// <summary>
        /// 添加一个WProductNoSaleDetails 事务操作
        /// </summary>
        /// <param name="model">WProductNoSaleDetails对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductNoSaleDetails model, IDbConnection conn, IDbTransaction tran);
        #endregion


        #region 根据 NoSaleID 删除 WProductNoSaleDetails 事务操作
        /// <summary>
        /// 根据 NoSaleID 删除 WProductNoSaleDetails 事务操作
        /// </summary>
        /// <param name="noSaleID">限购ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string noSaleID, IDbConnection conn, IDbTransaction tran);
        #endregion
    }

}