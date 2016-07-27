
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
    /// ### 仓库商品限购门店明细表WProductNoSaleShops数据库访问接口
    /// </summary>
    public partial interface IWProductNoSaleShopsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证WProductNoSaleShops是否存在
        /// <summary>
        /// 根据主键验证WProductNoSaleShops是否存在
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductNoSaleShops model);
        #endregion


        #region 添加一个WProductNoSaleShops
        /// <summary>
        /// 添加一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductNoSaleShops model);
        #endregion


        #region 更新一个WProductNoSaleShops
        /// <summary>
        /// 更新一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductNoSaleShops model);
        #endregion


        #region 删除一个WProductNoSaleShops
        /// <summary>
        /// 删除一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductNoSaleShops model);
        #endregion


        #region 根据主键逻辑删除一个WProductNoSaleShops
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSaleShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取WProductNoSaleShops对象
        /// <summary>
        /// 根据字典获取WProductNoSaleShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSaleShops对象</returns>
        WProductNoSaleShops GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WProductNoSaleShops对象
        /// <summary>
        /// 根据主键获取WProductNoSaleShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductNoSaleShops对象</returns>
        WProductNoSaleShops GetModel(int iD);
        #endregion


        #region 根据字典获取WProductNoSaleShops集合
        /// <summary>
        /// 根据字典获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductNoSaleShops> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductNoSaleShops数据集
        /// <summary>
        /// 根据字典获取WProductNoSaleShops数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductNoSaleShops集合
        /// <summary>
        /// 分页获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProductNoSaleShops> GetPageList(PageListBySql<WProductNoSaleShops> page, IDictionary<string, object> conditionDict);
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

    public partial interface IWProductNoSaleShopsDAO : IBaseDAO
    {
        #region 根据 NoSaleID 获取WProductNoSaleShops集合
        /// <summary>
        /// 根据 NoSaleID 获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="NoSaleID">限购单号</param>
        /// <returns>数据集合</returns>
        IList<WProductNoSaleShops> GetList(string NoSaleID);
        #endregion

        #region 添加一个WProductNoSaleShops 事务操作
        /// <summary>
        /// 添加一个WProductNoSaleShops 事务操作
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductNoSaleShops model, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 根据 NoSaleID 删除 WProductNoSaleShops 事务操作
        /// <summary>
        /// 根据 NoSaleID 删除 WProductNoSaleShops 事务操作
        /// </summary>
        /// <param name="noSaleID">noSaleID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string noSaleID, IDbConnection conn, IDbTransaction tran);
        #endregion
    }
}