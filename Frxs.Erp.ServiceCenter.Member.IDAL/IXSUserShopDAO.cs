
/*****************************
* Author:CR
*
* Date:2016-03-22
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Member.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Member.IDAL
{
    /// <summary>
    /// ### 兴盛用户门店表XSUserShop数据库访问接口
    /// </summary>
    public partial interface IXSUserShopDAO
    {


        #region 成员方法
        #region 根据主键验证XSUserShop是否存在
        /// <summary>
        /// 根据主键验证XSUserShop是否存在
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>是否存在</returns>
        bool Exists(XSUserShop model);
        #endregion


        #region 添加一个XSUserShop
        /// <summary>
        /// 添加一个XSUserShop
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(XSUserShop model);
        #endregion


        #region 更新一个XSUserShop
        /// <summary>
        /// 更新一个XSUserShop
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(XSUserShop model);
        #endregion


        #region 删除一个XSUserShop
        /// <summary>
        /// 删除一个XSUserShop
        /// </summary>
        /// <param name="model">XSUserShop对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(XSUserShop model);
        #endregion


        #region 根据主键逻辑删除一个XSUserShop
        /// <summary>
        /// 根据主键逻辑删除一个XSUserShop
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取XSUserShop对象
        /// <summary>
        /// 根据字典获取XSUserShop对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>XSUserShop对象</returns>
        XSUserShop GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取XSUserShop对象
        /// <summary>
        /// 根据主键获取XSUserShop对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>XSUserShop对象</returns>
        XSUserShop GetModel(int iD);
        #endregion


        #region 根据字典获取XSUserShop集合
        /// <summary>
        /// 根据字典获取XSUserShop集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<XSUserShop> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取XSUserShop数据集
        /// <summary>
        /// 根据字典获取XSUserShop数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取XSUserShop集合
        /// <summary>
        /// 分页获取XSUserShop集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<XSUserShop> GetPageList(PageListBySql<XSUserShop> page, IDictionary<string, object> conditionDict);
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

    public partial interface IXSUserShopDAO
    {
        #region 根据ShopID验证XSUserShop是否存在
        /// <summary>
        /// 根据ShopID验证XSUserShop是否存在
        /// </summary>
        /// <param name="ShopID">ShopID</param>
        /// <returns>是否存在</returns>
        bool ExistsShopID(int ShopID);
        #endregion

        #region 根据ShopID删除XSUserShop
        /// <summary>
        /// 根据ShopID删除XSUserShop
        /// </summary>
        /// <param name="ShopID">ShopID</param>
        /// <returns>数据库影响行数</returns>
        int DeleteByShopID(int ShopID);
        #endregion
    }

}