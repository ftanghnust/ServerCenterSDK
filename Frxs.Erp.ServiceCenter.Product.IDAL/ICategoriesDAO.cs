
/*****************************
* Author:CR
*
* Date:2016-03-14
******************************/
using System;
using System.Collections.Generic;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### Categories数据库访问接口
    /// </summary>
    public partial interface ICategoriesDAO
    {


        #region 成员方法
        #region 根据主键验证Categories是否存在
        /// <summary>
        /// 根据主键验证Categories是否存在
        /// </summary>
        /// <param name="model">Categories对象</param>
        /// <returns>是否存在</returns>
        bool Exists(Categories model);
        #endregion


        #region 添加一个Categories
        /// <summary>
        /// 添加一个Categories
        /// </summary>
        /// <param name="model">Categories对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Categories model);
        #endregion


        #region 更新一个Categories
        /// <summary>
        /// 更新一个Categories
        /// </summary>
        /// <param name="model">Categories对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(Categories model);
        #endregion


        #region 删除一个Categories
        /// <summary>
        /// 删除一个Categories
        /// </summary>
        /// <param name="model">Categories对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(Categories model);
        #endregion


        #region 根据主键逻辑删除一个Categories
        /// <summary>
        /// 根据主键逻辑删除一个Categories
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int categoryId);
        #endregion


        #region 根据字典获取Categories对象
        /// <summary>
        /// 根据字典获取Categories对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Categories对象</returns>
        Categories GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取Categories对象
        /// <summary>
        /// 根据主键获取Categories对象
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <returns>Categories对象</returns>
        Categories GetModel(int categoryId);
        #endregion


        #region 根据字典获取Categories集合
        /// <summary>
        /// 根据字典获取Categories集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<Categories> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取Categories数据集
        /// <summary>
        /// 根据字典获取Categories数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Categories集合
        /// <summary>
        /// 分页获取Categories集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Categories> GetPageList(PageListBySql<Categories> page, IDictionary<string, object> conditionDict);
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

    public partial interface ICategoriesDAO
    {

        /// <summary>
        /// 获取当前节点的子节点
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IList<Categories> GetChilds(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IList<Categories> GetParents(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        IList<Categories> GetList(List<int> categoryIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Categories GetPreModel(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Categories GetNextModel(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        bool IsReferenceByProduct(int categoryId);
    }
}