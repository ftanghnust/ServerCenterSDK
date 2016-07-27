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
    /// ### 电商商品图文表ProductsDescriptionPicture数据库访问接口
    /// </summary>
    public partial interface IProductsDescriptionPictureDAO
    {


        #region 成员方法
        //#region 根据主键验证ProductsDescriptionPicture是否存在
        ///// <summary>
        ///// 根据主键验证ProductsDescriptionPicture是否存在
        ///// </summary>
        ///// <param name="model">ProductsDescriptionPicture对象</param>
        ///// <returns>是否存在</returns>
        //bool Exists(ProductsDescriptionPicture model);
        //#endregion


        #region 事务处理 添加一个ProductsDescriptionPicture

        /// <summary>
        /// 事务处理 添加一个商品图文详情表
        /// </summary>
        /// <param name="model">商品图文详情对象</param>
        /// <param name="conn">连接数据库对象 </param>
        /// <param name="trans">事务对象 </param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsDescriptionPicture model, IDbConnection conn = null, IDbTransaction trans = null);
        #endregion


        //#region 更新一个ProductsDescriptionPicture
        ///// <summary>
        ///// 更新一个ProductsDescriptionPicture
        ///// </summary>
        ///// <param name="model">ProductsDescriptionPicture对象</param>
        ///// <returns>数据库影响行数</returns>
        //int Edit(ProductsDescriptionPicture model);
        //#endregion


        #region 删除一个ProductsDescriptionPicture
        /// <summary>
        /// 删除一个ProductsDescriptionPicture
        /// </summary>
        /// <param name="model">ProductsDescriptionPicture对象</param>
        /// <param name="conn">连接数据库对象 </param>
        /// <param name="trans">事务对象 </param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsDescriptionPicture model, IDbConnection conn = null, IDbTransaction trans = null);
        #endregion


        //#region 根据主键逻辑删除一个ProductsDescriptionPicture
        ///// <summary>
        ///// 根据主键逻辑删除一个ProductsDescriptionPicture
        ///// </summary>

        ///// <returns>数据库影响行数</returns>
        //int LogicDelete();
        //#endregion


        #region 根据字典获取ProductsDescriptionPicture对象
        /// <summary>
        /// 根据字典获取ProductsDescriptionPicture对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsDescriptionPicture对象</returns>
        ProductsDescriptionPicture GetModel(IDictionary<string, object> conditionDict);
        #endregion


        //#region 根据母商品编号获取ProductsDescriptionPicture对象
        ///// <summary>
        ///// 根据母商品编号获取ProductsDescriptionPicture对象
        ///// </summary>
        ///// <param name="baseProductId">母商品编号</param>
        ///// <returns>ProductsDescriptionPicture对象</returns>
        //ProductsDescriptionPicture GetModel(int baseProductId);
        //#endregion


        #region 根据字典获取ProductsDescriptionPicture集合
        /// <summary>
        /// 根据字典获取ProductsDescriptionPicture集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsDescriptionPicture> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsDescriptionPicture数据集
        /// <summary>
        /// 根据字典获取ProductsDescriptionPicture数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsDescriptionPicture集合
        /// <summary>
        /// 分页获取ProductsDescriptionPicture集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsDescriptionPicture> GetPageList(PageListBySql<ProductsDescriptionPicture> page, IDictionary<string, object> conditionDict);
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

    public partial interface IProductsDescriptionPictureDAO
    {

        /// <summary>
        /// 获取商品图文详情列表
        /// </summary>
        /// <param name="baseProductId">母商品编号</param>
        /// <returns></returns>
        IList<ProductsDescriptionPicture> ProductsDescriptionPictureGet(int baseProductId);

        ///// <summary>
        ///// 删除商品图文详情列表
        ///// </summary>
        ///// <param name="baseProductId"></param>
        ///// <returns></returns>
        //int ProductsDescriptionPictureDelete(int baseProductId, IDbConnection conn = null, IDbTransaction tran = null);


    }

}