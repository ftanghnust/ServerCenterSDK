/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/

using System;
using System.Collections.Generic;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 多规格属性表Attributes数据库访问接口
    /// </summary>
    public partial interface IAttributesDAO : IBaseDAO
    {

        #region 成员方法

        #region 添加一个Attributes
        /// <summary>
        /// 添加一个Attributes
        /// </summary>
        /// <param name="model">Attributes对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Attributes model);
        #endregion


        #region 更新一个Attributes
        /// <summary>
        /// 更新一个Attributes
        /// </summary>
        /// <param name="model">Attributes对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(Attributes model);
        #endregion


        //#region 删除一个Attributes
        ///// <summary>
        ///// 删除一个Attributes
        ///// </summary>
        ///// <param name="model">Attributes对象</param>
        ///// <returns>数据库影响行数</returns>
        //int Delete(Attributes model);
        //#endregion


        #region 根据主键逻辑删除一个Attributes

        /// <summary>
        /// 根据主键逻辑删除一个Attributes
        /// </summary>
        /// <param name="model">Attributes对象</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(Attributes model);

        #endregion


        #region 根据字典获取Attributes对象
        /// <summary>
        /// 根据字典获取Attributes对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Attributes对象</returns>
        Attributes GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取Attributes对象
        /// <summary>
        /// 根据主键获取Attributes对象
        /// </summary>
        /// <param name="attributeId">主键ID</param>
        /// <returns>Attributes对象</returns>
        Attributes GetModel(int attributeId);
        #endregion


        #region 根据字典获取Attributes集合
        /// <summary>
        /// 根据字典获取Attributes集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<Attributes> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取Attributes数据集
        /// <summary>
        /// 根据字典获取Attributes数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Attributes集合
        /// <summary>
        /// 分页获取Attributes集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Attributes> GetPageList(PageListBySql<Attributes> page, IDictionary<string, object> conditionDict);
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

    public partial interface IAttributesDAO : IBaseDAO
    {

        #region 根据规格名称验证Attributes是否存在
        /// <summary>
        /// 根据规格名称验证Attributes是否存在
        /// </summary>
        /// <param name="attributeName">规格名称</param>
        /// <param name="attributeId">规格编号</param>
        /// <returns>是否存在</returns>
        bool ExistsAttributeName(string attributeName, int attributeId);
        #endregion

        #region  根据主键验证Attributes是否存在
        /// <summary>
        /// 根据主键验证Attributes是否存在
        /// </summary>
        /// <param name="attributeId">规格编号</param>
        /// <returns>是否存在</returns>
        bool ExistsAttributeId(int attributeId);
        #endregion

        #region 分页获取包含商品集合
        /// <summary>
        /// 分页获取包含商品集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<AttributesProducts> ProductsGetPageList(PageListBySql<AttributesProducts> page, Dictionary<string, object> conditionDict);
        #endregion
    }
}