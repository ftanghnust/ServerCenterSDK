/*****************************
* Author:
*
* Date:2016-04-07
******************************/

using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Promotion.IDAL
{
    /// <summary>
    /// ### WProductPromotionShops数据库访问接口
    /// </summary>
    public partial interface IWProductPromotionShopsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证WProductPromotionShops是否存在
        /// <summary>
        /// 根据主键验证WProductPromotionShops是否存在
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductPromotionShops model);
        #endregion


        #region 添加一个WProductPromotionShops
        /// <summary>
        /// 添加一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductPromotionShops model);
        #endregion


        #region 添加一个WProductPromotionShops(事务处理)
        /// <summary>
        /// 添加一个WProductPromotionShops(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, WProductPromotionShops model);
        #endregion


        #region 更新一个WProductPromotionShops
        /// <summary>
        /// 更新一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductPromotionShops model);
        #endregion


        #region 更新一个WProductPromotionShops(事务处理)
        /// <summary>
        /// 更新一个WProductPromotionShops(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, WProductPromotionShops model);
        #endregion


        #region 删除一个WProductPromotionShops
        /// <summary>
        /// 删除一个WProductPromotionShops
        /// </summary>
        /// <param name="model">WProductPromotionShops对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductPromotionShops model);
        #endregion


        #region 根据主键逻辑删除一个WProductPromotionShops
        /// <summary>
        /// 根据主键逻辑删除一个WProductPromotionShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取WProductPromotionShops对象
        /// <summary>
        /// 根据字典获取WProductPromotionShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductPromotionShops对象</returns>
        WProductPromotionShops GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WProductPromotionShops对象
        /// <summary>
        /// 根据主键获取WProductPromotionShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductPromotionShops对象</returns>
        WProductPromotionShops GetModel(int iD);
        #endregion


        #region 根据字典获取WProductPromotionShops集合
        /// <summary>
        /// 根据字典获取WProductPromotionShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductPromotionShops> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductPromotionShops数据集
        /// <summary>
        /// 根据字典获取WProductPromotionShops数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductPromotionShops集合
        /// <summary>
        /// 分页获取WProductPromotionShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<WProductPromotionShops> GetPageList(PageListBySql<WProductPromotionShops> page, IDictionary<string, object> conditionDict);
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

    public partial interface IWProductPromotionShopsDAO : IBaseDAO
    {

        #region 根据 促销ID 删除一批WProductPromotionShops 事务操作
        /// <summary>
        /// 根据 促销ID 删除一批WProductPromotionShops 事务操作
        /// </summary>        
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="promotionID">促销ID</param>
        /// <returns>数据库影响行数</returns>
        int Delete(IDbConnection conn, IDbTransaction tran, string promotionID);
        #endregion

        #region 根据 促销ID 获取WProductPromotionShops集合
        /// <summary>
        /// 根据 促销ID 获取WProductPromotionShops集合
        /// </summary>
        /// <param name="promotionID">促销ID</param>
        /// <returns>数据集合</returns>
        IList<WProductPromotionShops> GetList(string promotionID);
        #endregion
    }
}
