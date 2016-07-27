
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
    /// ### 从原表Buymoo_BrandCategories 复制结构及名称BrandCategories数据库访问接口
    /// </summary>
    public partial interface IBrandCategoriesDAO
    {


        #region 成员方法
        #region 根据主键验证BrandCategories是否存在
        /// <summary>
        /// 根据主键验证BrandCategories是否存在
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>是否存在</returns>
        bool Exists(BrandCategories model);
        #endregion


        #region 添加一个BrandCategories
        /// <summary>
        /// 添加一个BrandCategories
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(BrandCategories model);
        #endregion


        #region 更新一个BrandCategories
        /// <summary>
        /// 更新一个BrandCategories
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(BrandCategories model);
        #endregion


        #region 删除一个BrandCategories
        /// <summary>
        /// 删除一个BrandCategories
        /// </summary>
        /// <param name="model">BrandCategories对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(BrandCategories model);
        #endregion


        #region 根据主键逻辑删除一个BrandCategories
        /// <summary>
        /// 根据主键逻辑删除一个BrandCategories
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int brandId);
        #endregion


        #region 根据字典获取BrandCategories对象
        /// <summary>
        /// 根据字典获取BrandCategories对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>BrandCategories对象</returns>
        BrandCategories GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取BrandCategories对象
        /// <summary>
        /// 根据主键获取BrandCategories对象
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <returns>BrandCategories对象</returns>
        BrandCategories GetModel(int brandId);
        #endregion


        #region 根据字典获取BrandCategories集合
        /// <summary>
        /// 根据字典获取BrandCategories集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<BrandCategories> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取BrandCategories数据集
        /// <summary>
        /// 根据字典获取BrandCategories数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取BrandCategories集合
        /// <summary>
        /// 分页获取BrandCategories集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<BrandCategories> GetPageList(PageListBySql<BrandCategories> page, IDictionary<string, object> conditionDict);
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

    public partial interface IBrandCategoriesDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandIds"></param>
        /// <param name="brandName"></param>
        /// <param name="hasLogo"></param>
        /// <returns></returns>
        IList<BrandCategories> GetList(List<int> brandIds, string brandName, bool? hasLogo);


        /// <summary>
        /// 是否存在同名称品牌
        /// </summary>
        /// <param name="model">品牌对象</param>
        /// <returns>true or false</returns>
        bool ExistsName(BrandCategories model);


        /// <summary>
        /// 是否关联了母商品
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>关联的第一个母商品名称</returns>
        string UsedName(int id);

    }
}