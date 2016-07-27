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
    /// ### ProductsDescription数据库访问接口
    /// </summary>
    public partial interface IProductsDescriptionDAO
    {
        #region 成员方法
        #region 根据主键验证ProductsDescription是否存在
        /// <summary>
        /// 通过商品母表编号验证商品描述对象是否存在 
        /// </summary>
        /// <param name="model">商品描述对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsDescription model);
        #endregion


        #region 添加一个ProductsDescription

        /// <summary>
        /// 添加一个ProductsDescription
        /// </summary>
        /// <param name="model">ProductsDescription对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsDescription model, IDbConnection conn = null, IDbTransaction tran = null);

        #endregion


        #region 更新一个ProductsDescription

        /// <summary>
        /// 更新一个ProductsDescription
        /// </summary>
        /// <param name="model">ProductsDescription对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsDescription model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 删除一个ProductsDescription

        /// <summary>
        /// 删除一个ProductsDescription
        /// </summary>
        /// <param name="model">ProductsDescription对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsDescription model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 根据主键逻辑删除一个ProductsDescription
        /// <summary>
        /// 根据主键逻辑删除一个ProductsDescription
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和BaseProduct.BaseProductID一样)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int baseProductId);
        #endregion


        #region 根据字典获取ProductsDescription对象
        /// <summary>
        /// 根据字典获取ProductsDescription对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsDescription对象</returns>
        ProductsDescription GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 通过商品母表编号读取商品描述对象
        /// <summary>
        /// 通过商品母表编号读取商品描述对象
        /// </summary>
        /// <param name="baseProductId">商品母表ID（初始值和BaseProduct.BaseProductID一样)</param>
        /// <returns>商品描述对象</returns>
        ProductsDescription GetModel(int baseProductId);
        #endregion


        #region 根据字典获取ProductsDescription集合
        /// <summary>
        /// 根据字典获取ProductsDescription集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsDescription> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsDescription数据集
        /// <summary>
        /// 根据字典获取ProductsDescription数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsDescription集合
        /// <summary>
        /// 分页获取ProductsDescription集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsDescription> GetPageList(PageListBySql<ProductsDescription> page, IDictionary<string, object> conditionDict);
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
}