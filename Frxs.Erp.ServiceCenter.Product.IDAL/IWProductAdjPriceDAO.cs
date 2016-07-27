
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库商品价格调整表WProductAdjPrice数据库访问接口
    /// </summary>
    public partial interface IWProductAdjPriceDAO
    {


        #region 成员方法
        #region 根据主键验证WProductAdjPrice是否存在
        /// <summary>
        /// 根据主键验证WProductAdjPrice是否存在
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductAdjPrice model);
        #endregion


        #region 添加一个WProductAdjPrice
        /// <summary>
        /// 添加一个WProductAdjPrice
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductAdjPrice model);
        #endregion


        #region 更新一个WProductAdjPrice
        /// <summary>
        /// 更新一个WProductAdjPrice
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductAdjPrice model);
        #endregion


        #region 删除一个WProductAdjPrice
        /// <summary>
        /// 删除一个WProductAdjPrice
        /// </summary>
        /// <param name="model">WProductAdjPrice对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductAdjPrice model);
        #endregion


        #region 根据主键逻辑删除一个WProductAdjPrice
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjPrice
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int adjID);
        #endregion


        #region 根据字典获取WProductAdjPrice对象
        /// <summary>
        /// 根据字典获取WProductAdjPrice对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductAdjPrice对象</returns>
        WProductAdjPrice GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WProductAdjPrice对象
        /// <summary>
        /// 根据主键获取WProductAdjPrice对象
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>WProductAdjPrice对象</returns>
        WProductAdjPrice GetModel(int adjID);
        #endregion


        #region 根据字典获取WProductAdjPrice集合
        /// <summary>
        /// 根据字典获取WProductAdjPrice集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductAdjPrice> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductAdjPrice数据集
        /// <summary>
        /// 根据字典获取WProductAdjPrice数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductAdjPrice集合
        /// <summary>
        /// 分页获取WProductAdjPrice集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProductAdjPrice> GetPageList(PageListBySql<WProductAdjPrice> page, IDictionary<string, object> conditionDict);
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

        /// <summary>
        /// 删除调价单
        /// </summary>
        /// <param name="AdjId"></param>
        /// <returns></returns>
        void Delete(int AdjId);


        #endregion

        /// <summary>
        /// 批量确认调价单
        /// </summary>
        /// <param name="adjType">调整类型(0:采购(进货)价;1:配送(批发)价;2:费率及积分)</param>
        /// <returns></returns>
        int JobPosting(int adjType);


    }
}