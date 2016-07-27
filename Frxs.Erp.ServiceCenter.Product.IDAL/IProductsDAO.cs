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
    /// ### Products数据库访问接口
    /// </summary>
    public partial interface IProductsDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证Products是否存在
        /// <summary>
        /// 根据主键验证Products是否存在
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <returns>是否存在</returns>
        bool Exists(Products model);
        #endregion


        #region 根据主键逻辑删除一个Products
        /// <summary>
        /// 根据主键逻辑删除一个Products
        /// </summary>
        /// <param name="productId">商品ID(主键)SKUNumberService.ID取得</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int productId);
        #endregion


        #region 根据字典获取Products对象
        /// <summary>
        /// 根据字典获取Products对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Products对象</returns>
        Products GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取Products对象
        /// <summary>
        /// 根据主键获取Products对象
        /// </summary>
        /// <param name="productId">商品ID(主键)SKUNumberService.ID取得</param>
        /// <returns>Products对象</returns>
        Products GetModel(int productId);
        #endregion


        #region 根据字典获取Products集合
        /// <summary>
        /// 根据字典获取Products集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<Products> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取Products数据集
        /// <summary>
        /// 根据字典获取Products数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Products集合
        /// <summary>
        /// 分页获取Products集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Products> GetPageList(PageListBySql<Products> page, IDictionary<string, object> conditionDict);
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


    public partial interface IProductsDAO : IBaseDAO
    {

        #region 添加一个Products

        /// <summary>
        /// 添加一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        int Save(Products model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个Products

        /// <summary>
        /// 更新一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <param name="conn"> </param>
        /// <returns>数据库影响行数</returns>
        int Edit(Products model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 删除一个Products

        /// <summary>
        /// 删除一个Products
        /// </summary>
        /// <param name="model">Products对象</param>
        /// <param name="conn"> </param>
        /// <param name="tran"> </param>
        /// <returns>数据库影响行数</returns>
        int Delete(Products model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Products ProductGetByProductId(int productId);

        /// <summary>
        /// 是否已使用名称
        /// </summary>
        /// <param name="model">商品模型</param>
        /// <returns>true or false</returns>
        bool ExistName(Products model);

        /// <summary>
        /// 商品SEO设置
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        int ProductKeyWordUpdate(int productId, string keyword);

        /// <summary>
        /// ERP重复检测
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool ExistERP(Model.Products model);

        /// <summary>
        /// 是否被网仓使用
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <returns>true or false</returns>
        bool bUsedByWc(int productId);

        /// <summary>
        /// 是否被门店使用
        /// </summary>
        /// <param name="productId">商品Id</param>
        /// <returns>true or false</returns>
        bool bUsedBySupplier(int productId);

        /// <summary>
        /// 获取ERP编码返回集合
        /// </summary>
        /// <returns>数据集合</returns>
        Dictionary<int, string> GetProductErpCodeList(IList<int> products);

        /// <summary>
        /// 添加编辑促销时--根据商品或订单促销验证同一时间段是否有相同的商品或基本分类
        /// </summary>
        /// <param name="conditionDict">查询条件</param>
        /// <returns></returns>
        bool IsPromotionDataTimeProductList(Dictionary<string, string> conditionDict);


        /// <summary>
        /// 商品销量增加
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="quantity">增加数量</param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int SaleAdd(int productId, int quantity, IDbConnection conn, IDbTransaction tran);

        /// <summary>
        /// 商品销量减少
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="quantity">减少数量</param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        int SaleSubtract(int productId, int quantity, IDbConnection conn, IDbTransaction tran);
    }
}