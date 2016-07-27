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
    /// 多规格属性表Attributes业务逻辑类
    /// </summary>
    public partial class AttributesBLO
    {
        #region 成员方法

        #region 添加一个Attributes
        /// <summary>
        /// 添加一个Attributes
        /// </summary>
        /// <param name="model">Attributes对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(Attributes model)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().Save(model);
        }
        #endregion


        #region 更新一个Attributes
        /// <summary>
        /// 更新一个Attributes
        /// </summary>
        /// <param name="model">Attributes对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(Attributes model)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().Edit(model);
        }
        #endregion


        //#region 删除一个Attributes
        ///// <summary>
        ///// 删除一个Attributes
        ///// </summary>
        ///// <param name="model">Attributes对象</param>
        ///// <returns>数据库影响行数</returns>
        //public static int Delete(Attributes model)
        //{
        //    return DALFactory.GetLazyInstance<IAttributesDAO>().Delete(model);
        //}
        //#endregion


        #region 根据主键逻辑删除一个Attributes
        /// <summary>
        /// 根据主键逻辑删除一个Attributes
        /// </summary>
        /// <param name="model">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(Attributes model)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().LogicDelete(model);
        }
        #endregion


        #region 根据字典获取Attributes对象
        /// <summary>
        /// 根据字典获取Attributes对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Attributes对象</returns>
        public static Attributes GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取Attributes对象
        /// <summary>
        /// 根据主键获取Attributes对象
        /// </summary>
        /// <param name="attributeId">主键ID</param>
        /// <returns>Attributes对象</returns>
        public static Attributes GetModel(int attributeId)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().GetModel(attributeId);
        }
        #endregion


        #region 根据字典获取Attributes集合，不支持分页
        /// <summary>
        /// 根据字典获取Attributes集合，不支持分页
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<Attributes> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取Attributes数据集
        /// <summary>
        /// 根据字典获取Attributes数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取Attributes集合
        /// <summary>
        /// 分页获取Attributes集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Attributes> GetPageList(PageListBySql<Attributes> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IAttributesDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }


    /// <summary>
    /// 
    /// </summary>
    public partial class AttributesBLO
    {

        ///// <summary>
        ///// 获取Attributes集合
        ///// </summary>
        ///// <param name="id">条件参数</param>
        ///// <returns>数据集合</returns>
        //public static Attributes GetModel(int id)
        //{
        //    Dictionary<string, object> conditionDict = new Dictionary<string, object>();
        //    conditionDict.Add("AttributeId", id);
        //    return DALFactory.GetLazyInstance<IAttributesDAO>().GetModel(conditionDict);
        //}

        ///// <summary>
        ///// 输出属性
        ///// </summary>
        ///// <param name="id"></param>
        //public static BackMessage<int> AttributesDelete(int attributeId)
        //{
        //    var model = GetModel(attributeId);
        //    if (model != null)
        //    {
        //        model.IsDeleted = 1;
        //        Edit(model);
        //    }
        //    return new BackMessage<int>()
        //    {
        //        IsSuccess = true,
        //        Data = attributeId,
        //        Message = "删除分类成功"
        //    };
        //}


        ///// <summary>
        ///// 获取商品规格下面的所有规格值
        ///// </summary>
        ///// <param name="attributeId"></param>
        ///// <returns></returns>
        //public static IList<AttributesValues> AttributesValuesGet(int attributeId)
        //{
        //    return LazyDAOObjectCreator.IAttributesValuesDAOObj.AttributesValuesGetList(attributeId);
        //}

        ///// <summary>
        ///// 添加规格值
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static int AttributesValuesAdd(AttributesValues value)
        //{
        //    return LazyDAOObjectCreator.IAttributesValuesDAOObj.AttributesValuesAdd(value);
        //}

        ///// <summary>
        ///// 删除规格值
        ///// </summary>
        ///// <param name="valuesId"></param>
        ///// <returns></returns>
        //public static int AttributesValuesDelete(int valuesId)
        //{
        //    return LazyDAOObjectCreator.IAttributesValuesDAOObj.AttributesValuesDelete(valuesId);
        //}

        #region 分页获取包含商品集合
        /// <summary>
        /// 分页获取包含商品集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<AttributesProducts> ProductsGetPageList(PageListBySql<AttributesProducts> page, Dictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IAttributesDAO>().ProductsGetPageList(page, conditionDict);
        }
        #endregion
    }
}