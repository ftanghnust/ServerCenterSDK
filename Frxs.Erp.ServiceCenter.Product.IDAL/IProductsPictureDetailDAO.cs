
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
    /// ### 商品图片明细表ProductsPictureDetail数据库访问接口
    /// </summary>
    public partial interface IProductsPictureDetailDAO
    {


        #region 成员方法
        #region 根据主键验证ProductsPictureDetail是否存在
        /// <summary>
        /// 根据主键验证ProductsPictureDetail是否存在
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ProductsPictureDetail model);
        #endregion


        #region 添加一个ProductsPictureDetail

        /// <summary>
        /// 添加一个ProductsPictureDetail
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        int Save(ProductsPictureDetail model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 更新一个ProductsPictureDetail
        /// <summary>
        /// 更新一个ProductsPictureDetail
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        int Edit(ProductsPictureDetail model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 删除一个ProductsPictureDetail

        /// <summary>
        /// 删除一个ProductsPictureDetail
        /// </summary>
        /// <param name="model">ProductsPictureDetail对象</param>
        /// <param name="conn"> </param>
        /// <param name="trans"> </param>
        /// <returns>数据库影响行数</returns>
        int Delete(ProductsPictureDetail model, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据主键逻辑删除一个ProductsPictureDetail
        /// <summary>
        /// 根据主键逻辑删除一个ProductsPictureDetail
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取ProductsPictureDetail对象
        /// <summary>
        /// 根据字典获取ProductsPictureDetail对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ProductsPictureDetail对象</returns>
        ProductsPictureDetail GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ProductsPictureDetail对象
        /// <summary>
        /// 根据主键获取ProductsPictureDetail对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>ProductsPictureDetail对象</returns>
        ProductsPictureDetail GetModel(int iD);
        #endregion


        #region 根据字典获取ProductsPictureDetail集合
        /// <summary>
        /// 根据字典获取ProductsPictureDetail集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ProductsPictureDetail> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ProductsPictureDetail数据集
        /// <summary>
        /// 根据字典获取ProductsPictureDetail数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ProductsPictureDetail集合
        /// <summary>
        /// 分页获取ProductsPictureDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ProductsPictureDetail> GetPageList(PageListBySql<ProductsPictureDetail> page, IDictionary<string, object> conditionDict);
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


    public partial interface IProductsPictureDetailDAO
    {
        /// <summary>
        /// 新增子商品图片
        /// </summary>
        /// <param name="pics"></param>
        /// <returns></returns>
        int ProductsPictureDetailAdd(IEnumerable<ProductsPictureDetail> pics, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 删除子商品图片
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        int ProductsPictureDetailDelete(int productId, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 获取图片集合
        /// </summary>
        /// <param name="imageProductId"></param>
        /// <returns></returns>
        IList<ProductsPictureDetail> ProductsPictureDetailsGet(int imageProductId);
    }
}