
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
    /// ### 仓库商品货架调整明细表WProductAdjShelfDetails数据库访问接口
    /// </summary>
    public partial interface IWProductAdjShelfDetailsDAO
    {


        #region 成员方法
        #region 根据主键验证WProductAdjShelfDetails是否存在
        /// <summary>
        /// 根据主键验证WProductAdjShelfDetails是否存在
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductAdjShelfDetails model);
        #endregion


        #region 添加一个WProductAdjShelfDetails
        /// <summary>
        /// 添加一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductAdjShelfDetails model);  

        /// <summary>
        /// WProductAdjShelfDetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Save(WProductAdjShelfDetails model, IDbConnection conn, IDbTransaction trans);

       
        #endregion


        #region 更新一个WProductAdjShelfDetails
        /// <summary>
        /// 更新一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductAdjShelfDetails model);
        #endregion


        #region 删除一个WProductAdjShelfDetails
        /// <summary>
        /// 删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductAdjShelfDetails model);
        /// <summary>
        /// 删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="model">WProductAdjShelfDetails对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string adjId, IDbConnection conn, IDbTransaction trans); 

        #endregion


        #region 根据主键逻辑删除一个WProductAdjShelfDetails
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjShelfDetails
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(long iD);
        #endregion


        #region 根据字典获取WProductAdjShelfDetails对象
        /// <summary>
        /// 根据字典获取WProductAdjShelfDetails对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductAdjShelfDetails对象</returns>
        WProductAdjShelfDetails GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WProductAdjShelfDetails对象
        /// <summary>
        /// 根据主键获取WProductAdjShelfDetails对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductAdjShelfDetails对象</returns>
        WProductAdjShelfDetails GetModel(long iD);
        #endregion


        #region 根据字典获取WProductAdjShelfDetails集合
        /// <summary>
        /// 根据字典获取WProductAdjShelfDetails集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductAdjShelfDetails> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductAdjShelfDetails数据集
        /// <summary>
        /// 根据字典获取WProductAdjShelfDetails数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductAdjShelfDetails集合
        /// <summary>
        /// 分页获取WProductAdjShelfDetails集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProductAdjShelfDetails> GetPageList(PageListBySql<WProductAdjShelfDetails> page, IDictionary<string, object> conditionDict);
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