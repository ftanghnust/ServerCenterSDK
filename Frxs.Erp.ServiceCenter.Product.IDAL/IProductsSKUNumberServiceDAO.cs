
/*****************************
* Author:luojing
*
* Date:2016-03-10
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### SKU编号服务表ProductsSKUNumberService数据库访问接口
    /// </summary>
    public partial interface IProductsSKUNumberServiceDAO
    {


        #region 成员方法
        #region 根据主键验证ProductsSKUNumberService是否存在
        /// <summary>
        /// 根据主键验证ProductsSKUNumberService是否存在
        /// </summary>
        /// <param name="model">ProductsSKUNumberService对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsSKUNumberService model);
        #endregion


        #region 添加一个ProductsSKUNumberService
        /// <summary>
        /// 添加一个ProductsSKUNumberService
        /// </summary>
        /// <param name="model">ProductsSKUNumberService对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsSKUNumberService model);
        #endregion


        #region 更新一个ProductsSKUNumberService
        /// <summary>
        /// 更新一个ProductsSKUNumberService
        /// </summary>
        /// <param name="model">ProductsSKUNumberService对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsSKUNumberService model);
        #endregion


        #region 删除一个ProductsSKUNumberService
        /// <summary>
        /// 删除一个ProductsSKUNumberService
        /// </summary>
        /// <param name="model">ProductsSKUNumberService对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsSKUNumberService model);
        #endregion


        #region 根据主键逻辑删除一个ProductsSKUNumberService
        /// <summary>
        /// 根据主键逻辑删除一个ProductsSKUNumberService
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取ProductsSKUNumberService对象
        /// <summary>
        /// 根据字典获取ProductsSKUNumberService对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsSKUNumberService对象</returns>
        ProductsSKUNumberService GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ProductsSKUNumberService对象
        /// <summary>
        /// 根据主键获取ProductsSKUNumberService对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsSKUNumberService对象</returns>
        ProductsSKUNumberService GetModel(int iD);
        #endregion


        #region 根据字典获取ProductsSKUNumberService集合
        /// <summary>
        /// 根据字典获取ProductsSKUNumberService集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsSKUNumberService> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsSKUNumberService数据集
        /// <summary>
        /// 根据字典获取ProductsSKUNumberService数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsSKUNumberService集合
        /// <summary>
        /// 分页获取ProductsSKUNumberService集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsSKUNumberService> GetPageList(PageListBySql<ProductsSKUNumberService> page, IDictionary<string, object> conditionDict);
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

    public partial interface IProductsSKUNumberServiceDAO : IBaseDAO
    {
        /// <summary>
        /// 获取一个商品序列号
        /// </summary>
        /// <returns></returns>
        int CreateProductId();
    }
}