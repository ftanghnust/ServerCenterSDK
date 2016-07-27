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
    /// ### ProductsAttributesPicture数据库访问接口
    /// </summary>
    public partial interface IProductsAttributesPictureDAO
    {


        #region 成员方法
        #region 根据主键验证ProductsAttributesPicture是否存在
        /// <summary>
        /// 根据主键验证ProductsAttributesPicture是否存在
        /// </summary>
        /// <param name="model">ProductsAttributesPicture对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsAttributesPicture model);
        #endregion


        #region 添加一个ProductsAttributesPicture
        /// <summary>
        /// 添加一个ProductsAttributesPicture
        /// </summary>
        /// <param name="model">ProductsAttributesPicture对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsAttributesPicture model, IDbConnection conn = null, IDbTransaction trans = null);
        #endregion


        #region 更新一个ProductsAttributesPicture

        /// <summary>
        /// 更新一个ProductsAttributesPicture
        /// </summary>
        /// <param name="model">ProductsAttributesPicture对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsAttributesPicture model, IDbConnection conn = null, IDbTransaction trans = null);
        #endregion



        #region 删除一个ProductsAttributesPicture

        /// <summary>
        /// 级联删除，在事务内删除
        /// </summary>
        /// <param name="model">ProductsAttributesPicture对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsAttributesPicture model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据主键逻辑删除一个ProductsAttributesPicture
        /// <summary>
        /// 根据主键逻辑删除一个ProductsAttributesPicture
        /// </summary>
        /// <param name="productId">商品ID(Product.ProductId)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int productId);
        #endregion


        #region 根据字典获取ProductsAttributesPicture对象
        /// <summary>
        /// 根据字典获取ProductsAttributesPicture对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsAttributesPicture对象</returns>
        ProductsAttributesPicture GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ProductsAttributesPicture对象
        /// <summary>
        /// 根据主键获取ProductsAttributesPicture对象
        /// </summary>
        /// <param name="productId">商品ID(Product.ProductId)</param>
        /// <returns>ProductsAttributesPicture对象</returns>
        ProductsAttributesPicture GetModel(int productId);
        #endregion


        #region 根据字典获取ProductsAttributesPicture集合
        /// <summary>
        /// 根据字典获取ProductsAttributesPicture集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsAttributesPicture> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsAttributesPicture数据集
        /// <summary>
        /// 根据字典获取ProductsAttributesPicture数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsAttributesPicture集合
        /// <summary>
        /// 分页获取ProductsAttributesPicture集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsAttributesPicture> GetPageList(PageListBySql<ProductsAttributesPicture> page, IDictionary<string, object> conditionDict);
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

    public partial interface IProductsAttributesPictureDAO
    {
        /// <summary>
        /// 通过商品编号得到商品规格属性对象
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <returns>商品规格属性对象</returns>
        ProductsAttributesPicture ProductsAttributesPictureGet(int productId);
    }
}