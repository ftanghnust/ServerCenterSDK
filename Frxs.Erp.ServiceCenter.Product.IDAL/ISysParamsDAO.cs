
/*****************************
* Author:CR
*
* Date:2016-03-23
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### SysParams数据库访问接口
    /// </summary>
    public partial interface ISysParamsDAO
    {


        #region 成员方法
        #region 根据主键验证SysParams是否存在
        /// <summary>
        /// 根据主键验证SysParams是否存在
        /// </summary>
        /// <param name="model">SysParams对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SysParams model);
        #endregion


        #region 添加一个SysParams
        /// <summary>
        /// 添加一个SysParams
        /// </summary>
        /// <param name="model">SysParams对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SysParams model);
        #endregion


        #region 更新一个SysParams
        /// <summary>
        /// 更新一个SysParams
        /// </summary>
        /// <param name="model">SysParams对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SysParams model);
        #endregion


        #region 删除一个SysParams
        /// <summary>
        /// 删除一个SysParams
        /// </summary>
        /// <param name="model">SysParams对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SysParams model);
        #endregion


        #region 根据主键逻辑删除一个SysParams
        /// <summary>
        /// 根据主键逻辑删除一个SysParams
        /// </summary>
        /// <param name="paramCode">编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string paramCode);
        #endregion


        #region 根据字典获取SysParams对象
        /// <summary>
        /// 根据字典获取SysParams对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SysParams对象</returns>
        SysParams GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SysParams对象
        /// <summary>
        /// 根据主键获取SysParams对象
        /// </summary>
        /// <param name="paramCode">编号</param>
        /// <returns>SysParams对象</returns>
        SysParams GetModel(string paramCode);
        #endregion


        #region 根据字典获取SysParams集合
        /// <summary>
        /// 根据字典获取SysParams集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SysParams> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SysParams数据集
        /// <summary>
        /// 根据字典获取SysParams数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SysParams集合
        /// <summary>
        /// 分页获取SysParams集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SysParams> GetPageList(PageListBySql<SysParams> page, IDictionary<string, object> conditionDict);
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