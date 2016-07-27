
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
    /// ### 商品多单位表ProductsUnit数据库访问接口
    /// </summary>
    public partial interface IProductsUnitDAO
    {


        #region 成员方法
        #region 根据主键验证ProductsUnit是否存在
        /// <summary>
        /// 根据主键验证ProductsUnit是否存在
        /// </summary>
        /// <param name="model">ProductsUnit对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsUnit model);
        #endregion


        #region 添加一个ProductsUnit

        /// <summary>
        /// 添加一个ProductsUnit
        /// </summary>
        /// <param name="model">ProductsUnit对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsUnit model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个ProductsUnit
        /// <summary>
        /// 更新一个ProductsUnit
        /// </summary>
        /// <param name="model">ProductsUnit对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsUnit model);
        #endregion


        #region 删除一个ProductsUnit
        /// <summary>
        /// 删除一个ProductsUnit
        /// </summary>
        /// <param name="model">ProductsUnit对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsUnit model);
        #endregion


        #region 根据主键逻辑删除一个ProductsUnit
        /// <summary>
        /// 根据主键逻辑删除一个ProductsUnit
        /// </summary>
        /// <param name="productsUnitID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int productsUnitID);
        #endregion


        #region 根据字典获取ProductsUnit对象
        /// <summary>
        /// 根据字典获取ProductsUnit对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsUnit对象</returns>
        ProductsUnit GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ProductsUnit对象
        /// <summary>
        /// 根据主键获取ProductsUnit对象
        /// </summary>
        /// <param name="productsUnitID">主键ID</param>
        /// <returns>ProductsUnit对象</returns>
        ProductsUnit GetModel(int productsUnitID);
        #endregion


        #region 根据字典获取ProductsUnit集合
        /// <summary>
        /// 根据字典获取ProductsUnit集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsUnit> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsUnit数据集
        /// <summary>
        /// 根据字典获取ProductsUnit数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsUnit集合
        /// <summary>
        /// 分页获取ProductsUnit集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsUnit> GetPageList(PageListBySql<ProductsUnit> page, IDictionary<string, object> conditionDict);
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

    /// <summary>
    /// ### 商品多单位表ProductsUnit数据库访问接口
    /// </summary>
    public partial interface IProductsUnitDAO
    {

        /// <summary>
        /// 商品单位名称是否重复
        /// </summary>
        /// <returns></returns>
        bool ExistsProductsUnitName(ProductsUnit model);

 
        /// <summary>
        /// 清空商品的所有单位
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">连接数据库对象</param>
        /// <param name="trans">事务对象</param>
        int DeleteByProductId(int productId, IDbConnection conn, IDbTransaction trans);
    }


}