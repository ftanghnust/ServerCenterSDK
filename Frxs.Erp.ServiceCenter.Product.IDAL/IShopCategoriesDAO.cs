
/*****************************
* Author:CR
*
* Date:2016-03-14
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 产品运营分类(直接用)ShopCategories数据库访问接口
    /// </summary>
    public partial interface IShopCategoriesDAO
    {


        #region 成员方法
        #region 根据主键验证ShopCategories是否存在
        /// <summary>
        /// 根据主键验证ShopCategories是否存在
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ShopCategories model);
        #endregion


        #region 添加一个ShopCategories
        /// <summary>
        /// 添加一个ShopCategories
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ShopCategories model);
        #endregion


        #region 更新一个ShopCategories
        /// <summary>
        /// 更新一个ShopCategories
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ShopCategories model);
        #endregion


        #region 删除一个ShopCategories
        /// <summary>
        /// 删除一个ShopCategories
        /// </summary>
        /// <param name="model">ShopCategories对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ShopCategories model);
        #endregion


        #region 根据主键逻辑删除一个ShopCategories
        /// <summary>
        /// 根据主键逻辑删除一个ShopCategories
        /// </summary>
        /// <param name="categoryId">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int categoryId);
        #endregion


        #region 根据字典获取ShopCategories对象
        /// <summary>
        /// 根据字典获取ShopCategories对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShopCategories对象</returns>
        ShopCategories GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ShopCategories对象
        /// <summary>
        /// 根据主键获取ShopCategories对象
        /// </summary>
        /// <param name="categoryId">主键ID</param>
        /// <returns>ShopCategories对象</returns>
        ShopCategories GetModel(int categoryId);
        #endregion


        #region 根据字典获取ShopCategories集合
        /// <summary>
        /// 根据字典获取ShopCategories集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ShopCategories> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ShopCategories数据集
        /// <summary>
        /// 根据字典获取ShopCategories数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ShopCategories集合
        /// <summary>
        /// 分页获取ShopCategories集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ShopCategories> GetPageList(PageListBySql<ShopCategories> page, IDictionary<string, object> conditionDict);
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


    public partial interface IShopCategoriesDAO
    {

        /// <summary>
        /// 获取当前节点的子节点
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IList<ShopCategories> GetChilds(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IList<ShopCategories> GetParents(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        IList<ShopCategories> GetList(List<int> categoryIds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        ShopCategories GetPreModel(int categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        ShopCategories GetNextModel(int categoryId);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ShopCategories> ShopCategoriesHasWProductsGet(int wid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        bool IsReferenceByProduct(int categoryId);
    }
}