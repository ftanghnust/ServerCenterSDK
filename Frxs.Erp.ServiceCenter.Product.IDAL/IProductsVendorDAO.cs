
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
    /// ### 供应商商品表ProductsVendor数据库访问接口
    /// </summary>
    public partial interface IProductsVendorDAO : IBaseDAO
    {



        #region 成员方法
        #region 根据主键验证ProductsVendor是否存在
        /// <summary>
        /// 根据主键验证ProductsVendor是否存在
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsVendor model);
        #endregion


        #region 添加一个ProductsVendor
        /// <summary>
        /// 添加一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsVendor model);
        /// <summary>
        /// 添加一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsVendor model, IDbConnection conn, IDbTransaction trans);

        #endregion


        #region 更新一个ProductsVendor
        /// <summary>
        /// 更新一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsVendor model);


        /// <summary>
        /// 更新最后采购价（通过仓库编号，商品编号，更新上编号）
        /// </summary>
        /// <param name="model">要更新的字段和查询条件字段</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>返回值,1表示成功，0表示失败</returns>
        int EditLastBuyPrice(ProductsVendor model, IDbConnection conn, IDbTransaction trans);



        /// <summary>
        ///设置商品供应商为非主供应商
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>返回对象</returns>
        int EditByProductId(int productId, IDbConnection conn, IDbTransaction trans);


        /// <summary>
        ///设置商品供应商为主供应商
        /// </summary>
        /// <param name="productId">商品编号</param>
        /// <param name="vendorId">供应商编号</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>返回对象</returns>
        int EditByProductIdToMaster(int productId, int vendorId, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 删除一个ProductsVendor
        /// <summary>
        /// 删除一个ProductsVendor
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsVendor model);

        /// <summary>
        /// 删除ProductsVendor
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(int vendorId, IDbConnection conn, IDbTransaction trans);
        /// <summary>
        /// 删除ProductsVendor
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int Delete(int vendorId, int ProductId, int wid, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据主键逻辑删除一个ProductsVendor
        /// <summary>
        /// 根据主键逻辑删除一个ProductsVendor
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(long iD);
        #endregion


        #region 根据字典获取ProductsVendor对象
        /// <summary>
        /// 根据字典获取ProductsVendor对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsVendor对象</returns>
        ProductsVendor GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ProductsVendor对象
        /// <summary>
        /// 根据主键获取ProductsVendor对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsVendor对象</returns>
        ProductsVendor GetModel(long iD);
        #endregion


        #region 根据字典获取ProductsVendor集合
        /// <summary>
        /// 根据字典获取ProductsVendor集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsVendor> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsVendor数据集
        /// <summary>
        /// 根据字典获取ProductsVendor数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsVendor集合
        /// <summary>
        /// 分页获取ProductsVendor集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsVendor> GetPageList(PageListBySql<ProductsVendor> page, IDictionary<string, object> conditionDict);


        /// <summary>
        /// 分页获取ProductsVendor集合 扩展 ，用于读取供应商商品关系数据
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        IDictionary<string, object> GetListExtByPage(IDictionary<string, object> conditionDict);
        /// <summary>
        /// ProductsVendor集合
        /// </summary>
        /// <param name="conditionDict"></param>
        /// <returns></returns>
        IList<ProductsVendor> GetListNoPage(IDictionary<string, object> conditionDict);
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

    public partial interface IProductsVendorDAO : IBaseDAO
    {
        /// <summary>
        /// 修改主供应商
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isMaster"></param>
        void IsMasterUpdate(long id, int isMaster);

        /// <summary>
        /// 查询供应商查在记录数
        /// </summary>
        /// <param name="model">ProductsVendor对象</param>
        /// <returns>是否存在</returns>
        long GetVendProductsCount(int vendorID);
    }

}