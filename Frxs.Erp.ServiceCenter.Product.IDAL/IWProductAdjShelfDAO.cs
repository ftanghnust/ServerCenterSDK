
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
    /// ### 仓库商品货架调整表WProductAdjShelf数据库访问接口
    /// </summary>
    public partial interface IWProductAdjShelfDAO:IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证WProductAdjShelf是否存在
        /// <summary>
        /// 根据主键验证WProductAdjShelf是否存在
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductAdjShelf model);
        #endregion


        #region 添加一个WProductAdjShelf
        /// <summary>
        /// 添加一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductAdjShelf model);

        
       /// <summary>
        /// WProductAdjShelf
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        int Save(WProductAdjShelf model, IDbConnection conn, IDbTransaction trans);

        
        #endregion


        #region 更新一个WProductAdjShelf
        /// <summary>
        /// 更新一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductAdjShelf model);


        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Edit(WProductAdjShelf model, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int EditToWProduct(string adjId, int userid, string userName, IDbConnection conn, IDbTransaction trans);

        #endregion


        #region 删除一个WProductAdjShelf
        /// <summary>
        /// 删除一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductAdjShelf model);

        /// <summary>
        /// 删除一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string id, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据主键逻辑删除一个WProductAdjShelf
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjShelf
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string adjID);
        #endregion


        #region 根据字典获取WProductAdjShelf对象
        /// <summary>
        /// 根据字典获取WProductAdjShelf对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductAdjShelf对象</returns>
        WProductAdjShelf GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WProductAdjShelf对象
        /// <summary>
        /// 根据主键获取WProductAdjShelf对象
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>WProductAdjShelf对象</returns>
        WProductAdjShelf GetModel(string adjID);
        #endregion


        #region 根据字典获取WProductAdjShelf集合
        /// <summary>
        /// 根据字典获取WProductAdjShelf集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductAdjShelf> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductAdjShelf数据集
        /// <summary>
        /// 根据字典获取WProductAdjShelf数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductAdjShelf集合
        /// <summary>
        /// 分页获取WProductAdjShelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProductAdjShelf> GetPageList(PageListBySql<WProductAdjShelf> page, IDictionary<string, object> conditionDict);
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