
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
    /// ### 兴盛用户表(B2B,O2O,线下会员)XSUser数据库访问接口
    /// </summary>
    public partial interface IXSUserDAO
    {


        #region 成员方法
        #region 根据主键验证XSUser是否存在
        /// <summary>
        /// 根据主键验证XSUser是否存在
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>是否存在</returns>
        bool Exists(XSUser model);
        #endregion


        #region 添加一个XSUser
        /// <summary>
        /// 添加一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(XSUser model);
        #endregion


        #region 更新一个XSUser
        /// <summary>
        /// 更新一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(XSUser model);
        #endregion


        #region 删除一个XSUser
        /// <summary>
        /// 删除一个XSUser
        /// </summary>
        /// <param name="model">XSUser对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(XSUser model);
        #endregion


        #region 根据主键逻辑删除一个XSUser
        /// <summary>
        /// 根据主键逻辑删除一个XSUser
        /// </summary>
        /// <param name="xSUserID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int xSUserID);
        #endregion


        #region 根据字典获取XSUser对象
        /// <summary>
        /// 根据字典获取XSUser对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>XSUser对象</returns>
        XSUser GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取XSUser对象
        /// <summary>
        /// 根据主键获取XSUser对象
        /// </summary>
        /// <param name="xSUserID">用户编号</param>
        /// <returns>XSUser对象</returns>
        XSUser GetModel(int xSUserID);
        #endregion


        #region 根据字典获取XSUser集合
        /// <summary>
        /// 根据字典获取XSUser集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<XSUser> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取XSUser数据集
        /// <summary>
        /// 根据字典获取XSUser数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取XSUser集合
        /// <summary>
        /// 分页获取XSUser集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<XSUser> GetPageList(PageListBySql<XSUser> page, IDictionary<string, object> conditionDict);
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

    public partial interface IXSUserDAO
    {
        #region 根据帐号获取XSUser对象
        /// <summary>
        /// 根据帐号获取XSUser对象
        /// </summary>
        /// <param name="xSUserID">用户帐号</param>
        /// <returns>XSUser对象</returns>
        XSUser GetModelByAccount(string UserAccount);
        #endregion
        
        #region 根据帐号验证XSUser是否存在
        /// <summary>
        /// 根据帐号验证XSUser是否存在
        /// </summary>
        /// <param name="model">用户帐号</param>
        /// <returns>是否存在</returns>
        bool ExistsAccount(string UserAccount);
        #endregion
    }
}
