
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
    /// ### 商品多规格属性值表ProductsAttributes数据库访问接口
    /// </summary>
    public partial interface IProductsAttributesDAO
    {


        #region 成员方法
        #region 根据主键验证ProductsAttributes是否存在
        /// <summary>
        /// 根据主键验证ProductsAttributes是否存在
        /// </summary>
        /// <param name="model">ProductsAttributes对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsAttributes model);
        #endregion


        #region 添加一个ProductsAttributes

        /// <summary>
        /// 级联添加一个ProductsAttributes
        /// </summary>
        /// <param name="model">ProductsAttributes对象</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">执行事务对象 </param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsAttributes model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个ProductsAttributes
        /// <summary>
        /// 级联更新一个ProductsAttributes
        /// </summary>
        /// <param name="model">ProductsAttributes对象</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">执行事务对象 </param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsAttributes model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 删除一个ProductsAttributes
        /// <summary>
        /// 级联删除一个ProductsAttributes
        /// </summary>
        /// <param name="model">ProductsAttributes对象</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">执行事务对象 </param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsAttributes model, IDbConnection conn, IDbTransaction trans);
        #endregion



        #region 根据主键逻辑删除一个ProductsAttributes
        /// <summary>
        /// 根据主键逻辑删除一个ProductsAttributes
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取ProductsAttributes对象
        /// <summary>
        /// 根据字典获取ProductsAttributes对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsAttributes对象</returns>
        ProductsAttributes GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ProductsAttributes对象
        /// <summary>
        /// 根据主键获取ProductsAttributes对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsAttributes对象</returns>
        ProductsAttributes GetModel(int iD);
        #endregion


        #region 根据字典获取ProductsAttributes集合
        /// <summary>
        /// 根据字典获取ProductsAttributes集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsAttributes> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsAttributes数据集
        /// <summary>
        /// 根据字典获取ProductsAttributes数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsAttributes集合
        /// <summary>
        /// 分页获取ProductsAttributes集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsAttributes> GetPageList(PageListBySql<ProductsAttributes> page, IDictionary<string, object> conditionDict);
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


    public partial interface IProductsAttributesDAO
    {
        /// <summary>
        /// 获取商品的规格属性集合
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        IList<ProductsAttributes> ProductsAttributesGet(int productId);

        /// <summary>
        /// 删除商品属性规格
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">数据库连接对象 </param>
        /// <param name="trans">执行事务对象 </param>
        int ProductsAttributesDelete(int productId, IDbConnection conn, IDbTransaction trans);
    }
}