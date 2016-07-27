
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
    /// ### 仓库系统参数表SysParamsWH数据库访问接口
    /// </summary>
    public partial interface ISysParamsWHDAO
    {


        #region 成员方法
        #region 根据主键验证SysParamsWH是否存在
        /// <summary>
        /// 根据主键验证SysParamsWH是否存在
        /// </summary>
        /// <param name="model">SysParamsWH对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SysParamsWH model);
        #endregion


        #region 添加一个SysParamsWH
        /// <summary>
        /// 添加一个SysParamsWH
        /// </summary>
        /// <param name="model">SysParamsWH对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SysParamsWH model);
        #endregion


        #region 更新一个SysParamsWH
        /// <summary>
        /// 更新一个SysParamsWH
        /// </summary>
        /// <param name="model">SysParamsWH对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SysParamsWH model);
        #endregion


        #region 删除一个SysParamsWH
        /// <summary>
        /// 删除一个SysParamsWH
        /// </summary>
        /// <param name="model">SysParamsWH对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SysParamsWH model);
        #endregion


        #region 根据主键逻辑删除一个SysParamsWH
        /// <summary>
        /// 根据主键逻辑删除一个SysParamsWH
        /// </summary>
        /// <param name="iD">编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取SysParamsWH对象
        /// <summary>
        /// 根据字典获取SysParamsWH对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SysParamsWH对象</returns>
        SysParamsWH GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SysParamsWH对象
        /// <summary>
        /// 根据主键获取SysParamsWH对象
        /// </summary>
        /// <param name="iD">编号</param>
        /// <returns>SysParamsWH对象</returns>
        SysParamsWH GetModel(int iD);
        #endregion


        #region 根据字典获取SysParamsWH集合
        /// <summary>
        /// 根据字典获取SysParamsWH集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SysParamsWH> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SysParamsWH数据集
        /// <summary>
        /// 根据字典获取SysParamsWH数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SysParamsWH集合
        /// <summary>
        /// 分页获取SysParamsWH集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<SysParamsWH> GetPageList(PageListBySql<SysParamsWH> page, IDictionary<string, object> conditionDict);
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

        /// <summary>
        /// 获取仓库业务设置
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        IList<SysParams> GetWHSysParams(int wid, string paramCode);

        #endregion
    }
}