
/*****************************
* Author:CR
*
* Date:2016-03-24
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库商品表WProducts数据库访问接口
    /// </summary>
    public partial interface IWProductsDAO
    {


        #region 成员方法
        #region 根据主键验证WProducts是否存在
        /// <summary>
        /// 根据主键验证WProducts是否存在
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProducts model);
        #endregion


        #region 添加一个WProducts
        /// <summary>
        /// 添加一个WProducts
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProducts model);
        #endregion


        #region 更新一个WProducts
        /// <summary>
        /// 更新一个WProducts
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProducts model);
        #endregion


        #region 删除一个WProducts
        /// <summary>
        /// 删除一个WProducts
        /// </summary>
        /// <param name="model">WProducts对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProducts model);
        #endregion


        #region 根据主键逻辑删除一个WProducts
        /// <summary>
        /// 根据主键逻辑删除一个WProducts
        /// </summary>
        /// <param name="wProductID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(long wProductID);
        #endregion


        #region 根据字典获取WProducts对象
        /// <summary>
        /// 根据字典获取WProducts对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProducts对象</returns>
        WProducts GetModel(IDictionary<string, object> conditionDict);


        
        #endregion


        #region 根据主键获取WProducts对象
        /// <summary>
        /// 根据主键获取WProducts对象
        /// </summary>
        /// <param name="wProductID">主键ID</param>
        /// <returns>WProducts对象</returns>
        WProducts GetModel(long wProductID);
        #endregion


        #region 根据字典获取WProducts集合
        /// <summary>
        /// 根据字典获取WProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProducts> GetList(IDictionary<string, object> conditionDict);

        /// <summary>
        /// 根据字典获取WProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProducts> GetListByIDs(IDictionary<string, object> conditionDict);
        
        /// <summary>
        /// 根据字典获取WProducts集合 增加了扩展信息
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductExt> GetListByIDsExt(IDictionary<string, object> conditionDict);
        /// <summary>
        /// 根据字典获取WProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        IList<WProductExt> GetListToB2B(IDictionary<string, object> conditionDict);


        /// <summary>
        /// 根据字典获取WProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        IDictionary<string, object> GetListToB2BByPage(IDictionary<string, object> conditionDict);

        /// <summary>
        /// 根据字典获取WProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        IList<WProductExt> GetListToB2BExt(IDictionary<string, object> conditionDict);


        /// <summary>
        /// 根据字典获取WProducts集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        IDictionary<string, object> GetListToB2BExtByPage(IDictionary<string, object> conditionDict);

        #endregion


        #region 根据字典获取WProducts数据集
        /// <summary>
        /// 根据字典获取WProducts数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProducts集合
        /// <summary>
        /// 分页获取WProducts集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProducts> GetPageList(PageListBySql<WProducts> page, IDictionary<string, object> conditionDict);
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
    /// 
    /// </summary>
    public partial interface IWProductsDAO
    {
        /// <summary>
        /// 获取商品供应商列表
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        IList<ProductVendorModel> GetProductVendors(int wid, int productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wproductId"></param>
        /// <param name="vendorID"></param>
        void VendorIDUpdate(long wproductId, int vendorID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        IList<Products> GetSubProductIds(int wid, int productId);
    }
}