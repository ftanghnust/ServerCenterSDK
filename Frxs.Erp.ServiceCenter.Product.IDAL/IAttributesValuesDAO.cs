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
    /// ### 多规格属性值表AttributesValues数据库访问接口
    /// </summary>
    public partial interface IAttributesValuesDAO
    {

        #region 成员方法
        #region 根据主键验证AttributesValues是否存在
        /// <summary>
        /// 根据主键验证AttributesValues是否存在
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>是否存在</returns>
        bool Exists(AttributesValues model);
        #endregion


        #region 添加一个AttributesValues
        /// <summary>
        /// 添加一个AttributesValues
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(AttributesValues model);
        #endregion


        #region 更新一个AttributesValues
        /// <summary>
        /// 更新一个AttributesValues
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(AttributesValues model);
        #endregion


        #region 删除一个AttributesValues
        /// <summary>
        /// 删除一个AttributesValues
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(AttributesValues model);
        #endregion


        #region 根据对象逻辑删除一个商品规格值
        /// <summary>
        /// 逻辑删除商品规格值，更新
        /// 要求判断商品规格值是否存在、商品规格是否已被商品引用
        /// </summary>
        /// <param name="model">商品规格值对象</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(AttributesValues model);
        #endregion


        #region 根据字典获取AttributesValues对象
        /// <summary>
        /// 根据字典获取AttributesValues对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>AttributesValues对象</returns>
        AttributesValues GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取AttributesValues对象
        /// <summary>
        /// 根据主键获取AttributesValues对象
        /// </summary>
        /// <param name="valuesId">主键ID</param>
        /// <returns>AttributesValues对象</returns>
        AttributesValues GetModel(int valuesId);
        #endregion


        #region 根据字典获取AttributesValues集合
        /// <summary>
        /// 根据字典获取AttributesValues集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<AttributesValues> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取AttributesValues数据集
        /// <summary>
        /// 根据字典获取AttributesValues数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取AttributesValues集合
        /// <summary>
        /// 分页获取AttributesValues集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<AttributesValues> GetPageList(PageListBySql<AttributesValues> page, IDictionary<string, object> conditionDict);
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

    public partial interface IAttributesValuesDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeId"></param>
        /// <returns></returns>
        IList<AttributesValues> AttributesValuesGetList(int attributeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int AttributesValuesAdd(AttributesValues value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valuesId"></param>
        /// <returns></returns>
        int AttributesValuesDelete(int valuesId);

        /// <summary>
        /// 规格值上移下移
        /// </summary>
        /// <param name="modelA"></param>
        /// <param name="modelB"></param>
        /// <returns></returns>
        int DisplaySequence(AttributesValues modelA, AttributesValues modelB);
    }

}