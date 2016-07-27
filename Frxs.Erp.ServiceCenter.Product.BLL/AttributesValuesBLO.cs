/*****************************
* Author:luojing
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 多规格属性值表AttributesValues业务逻辑类
    /// </summary>
    public partial class AttributesValuesBLO
    {
        #region 成员方法
        #region 根据主键验证AttributesValues是否存在
        /// <summary>
        /// 根据主键验证AttributesValues是否存在
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(AttributesValues model)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().Exists(model);
        }
        #endregion


        #region 添加一个AttributesValues
        /// <summary>
        /// 添加一个AttributesValues
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(AttributesValues model)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().Save(model);
        }
        #endregion


        #region 更新一个AttributesValues
        /// <summary>
        /// 更新一个AttributesValues
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(AttributesValues model)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().Edit(model);
        }
        #endregion


        #region 删除一个AttributesValues
        /// <summary>
        /// 删除一个AttributesValues
        /// </summary>
        /// <param name="model">AttributesValues对象</param>
        /// <returns>数据库影响行数</returns>
        [Obsolete("已废弃")]
        public static int Delete(AttributesValues model)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个AttributesValues
        /// <summary>
        /// 逻辑删除商品规格值，更新
        /// 要求判断商品规格值是否存在、商品规格是否已被商品引用
        /// </summary>
        /// <param name="model">商品规格值对象</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(AttributesValues model)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().LogicDelete(model);
        }
        #endregion


        #region 根据字典获取AttributesValues对象
        /// <summary>
        /// 根据字典获取AttributesValues对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>AttributesValues对象</returns>
        public static AttributesValues GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取AttributesValues对象
        /// <summary>
        /// 根据主键获取AttributesValues对象
        /// </summary>
        /// <param name="valuesId">主键ID</param>
        /// <returns>AttributesValues对象</returns>
        public static AttributesValues GetModel(int valuesId)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().GetModel(valuesId);
        }
        #endregion


        #region 根据字典获取AttributesValues集合
        /// <summary>
        /// 根据字典获取AttributesValues集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<AttributesValues> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取AttributesValues数据集
        /// <summary>
        /// 根据字典获取AttributesValues数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取AttributesValues集合
        /// <summary>
        /// 分页获取AttributesValues集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<AttributesValues> GetPageList(PageListBySql<AttributesValues> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion

     
    }


    public partial class AttributesValuesBLO
    {
        #region 取AttributesValues对象列
        /// <summary>
        /// 取AttributesValues对象列
        /// </summary>
        /// <param name="attributeId">AttributeId</param>
        /// <returns>AttributesValues对象列</returns>
        public static IList<AttributesValues> AttributesValuesGetList(int attributeId)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().AttributesValuesGetList(attributeId);
        }
        #endregion


        #region 规格值上移下移
        /// <summary>
        /// 规格值上移下移
        /// </summary>
        public static int DisplaySequence(AttributesValues modelA, AttributesValues modelB)
        {
            return DALFactory.GetLazyInstance<IAttributesValuesDAO>().DisplaySequence(modelA, modelB);
        }
        #endregion
    }

}