/*****************************
* Author:叶求
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 供应商类型VendorType数据库访问接口
    /// </summary>
    public partial interface IVendorTypeDAO
    {


        #region 成员方法
        #region 根据主键验证VendorType是否存在
        /// <summary>
        /// 根据主键验证VendorType是否存在
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>是否存在</returns>
        bool Exists(VendorType model);
        #endregion


        #region 添加一个VendorType
        /// <summary>
        /// 添加一个VendorType
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(VendorType model);
        #endregion


        #region 更新一个VendorType
        /// <summary>
        /// 更新一个VendorType
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(VendorType model);
        #endregion


        #region 删除一个VendorType
        /// <summary>
        /// 删除一个VendorType
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(VendorType model);
        #endregion


        #region 根据主键逻辑删除一个VendorType
        /// <summary>
        /// 根据主键逻辑删除一个VendorType
        /// </summary>
        /// <param name="vendorTypeID">供应商分类ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int vendorTypeID);
        #endregion


        #region 根据字典获取VendorType对象
        /// <summary>
        /// 根据字典获取VendorType对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>VendorType对象</returns>
        VendorType GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取VendorType对象
        /// <summary>
        /// 根据主键获取VendorType对象
        /// </summary>
        /// <param name="vendorTypeID">供应商分类ID</param>
        /// <returns>VendorType对象</returns>
        VendorType GetModel(int vendorTypeID);
        #endregion


        #region 根据字典获取VendorType集合
        /// <summary>
        /// 根据字典获取VendorType集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<VendorType> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取VendorType数据集
        /// <summary>
        /// 根据字典获取VendorType数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取VendorType集合
        /// <summary>
        /// 分页获取VendorType集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<VendorType> GetPageList(PageListBySql<VendorType> page, IDictionary<string, object> conditionDict);
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

    public partial interface IVendorTypeDAO
    {
        #region 根据主键验证 关联的供应商 仓库商品表采购表 是否存在记录
        /// <summary>
        /// 根据主键验证 关联的供应商 仓库商品表采购表 是否存在记录
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>是否存在</returns>
        bool ExistsVendor(VendorType model);
        #endregion
    }
}
