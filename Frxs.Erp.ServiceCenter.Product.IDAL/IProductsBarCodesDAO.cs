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
    /// ### 商品国际条码ProductsBarCodes数据库访问接口
    /// </summary>
    public partial interface IProductsBarCodesDAO
    {


        #region 成员方法
        #region 根据主键验证ProductsBarCodes是否存在
        /// <summary>
        /// 根据主键验证ProductsBarCodes是否存在
        /// </summary>
        /// <param name="model">ProductsBarCodes对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsBarCodes model);
        #endregion


        #region 添加一个ProductsBarCodes

        /// <summary>
        /// 添加一个国际条码
        /// </summary>
        /// <param name="model">国际条码对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象 </param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsBarCodes model, IDbConnection conn, IDbTransaction tran);
        #endregion


        #region 更新一个ProductsBarCodes
        /// <summary>
        /// 更新一个ProductsBarCodes
        /// </summary>
        /// <param name="model">ProductsBarCodes对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsBarCodes model);
        #endregion


        #region 删除一个ProductsBarCodes
        /// <summary>
        /// 删除一个ProductsBarCodes
        /// </summary>
        /// <param name="model">ProductsBarCodes对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsBarCodes model);
        #endregion


        #region 根据主键逻辑删除一个ProductsBarCodes
        /// <summary>
        /// 根据主键逻辑删除一个ProductsBarCodes
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取ProductsBarCodes对象
        /// <summary>
        /// 根据字典获取ProductsBarCodes对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsBarCodes对象</returns>
        ProductsBarCodes GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ProductsBarCodes对象
        /// <summary>
        /// 根据主键获取ProductsBarCodes对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsBarCodes对象</returns>
        ProductsBarCodes GetModel(int iD);
        #endregion


        #region 根据字典获取ProductsBarCodes集合
        /// <summary>
        /// 根据字典获取ProductsBarCodes集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsBarCodes> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsBarCodes数据集
        /// <summary>
        /// 根据字典获取ProductsBarCodes数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsBarCodes集合
        /// <summary>
        /// 分页获取ProductsBarCodes集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsBarCodes> GetPageList(PageListBySql<ProductsBarCodes> page, IDictionary<string, object> conditionDict);
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

    public partial interface IProductsBarCodesDAO
    {

        /// <summary>
        /// 商品国际条码是否存在
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="barCode">国际条码</param>
        /// <returns>是否存在</returns>
        bool ProductsBarCodesIsExists(int productId, string barCode);

        /// <summary>
        /// 获取商品全部的国际条码
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <returns>国际条码列表</returns>
        IList<ProductsBarCodes> GetProductsBarCodes(int productId);

        /// <summary>
        /// 删除商品条码
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="barCode">商品条码</param>
        /// <returns>是否成功删除</returns>
        int DeleteByProductIdAndBarCode(int productId, string barCode);

        /// <summary>
        /// 清空商品的所有国际条码
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">连接数据库对象</param>
        /// <param name="trans">事务对象</param>
        int DeleteByProductId(int productId, IDbConnection conn, IDbTransaction trans);
    }

}