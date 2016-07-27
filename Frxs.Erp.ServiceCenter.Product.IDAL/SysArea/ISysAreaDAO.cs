
/*****************************
* Author:CR
*
* Date:2016-06-20
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### SysArea数据库访问接口
    /// </summary>
    public partial interface ISysAreaDAO
    {


        #region 成员方法
        #region 根据主键验证SysArea是否存在
        /// <summary>
        /// 根据主键验证SysArea是否存在
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SysArea model);
        #endregion


        #region 添加一个SysArea
        /// <summary>
        /// 添加一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SysArea model);
        #endregion


        #region 添加一个SysArea(事务处理)
        /// <summary>
        /// 添加一个SysArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SysArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SysArea model);
        #endregion


        #region 更新一个SysArea
        /// <summary>
        /// 更新一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SysArea model);
        #endregion


        #region 更新一个SysArea(事务处理)
        /// <summary>
        /// 更新一个SysArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SysArea model);
        #endregion


        #region 删除一个SysArea
        /// <summary>
        /// 删除一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SysArea model);
        #endregion


        #region 根据主键逻辑删除一个SysArea
        /// <summary>
        /// 根据主键逻辑删除一个SysArea
        /// </summary>
        /// <param name="areaID">主键ID(区域邮政编号)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int areaID);
        #endregion


        #region 根据字典获取SysArea对象
        /// <summary>
        /// 根据字典获取SysArea对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SysArea对象</returns>
        SysArea GetModel(SysAreaQuery query);
        #endregion


        #region 根据主键获取SysArea对象
        /// <summary>
        /// 根据主键获取SysArea对象
        /// </summary>
        /// <param name="areaID">主键ID(区域邮政编号)</param>
        /// <returns>SysArea对象</returns>
        SysArea GetModel(int areaID);
        #endregion


        #region 根据字典获取SysArea集合
        /// <summary>
        /// 根据字典获取SysArea集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        IList<SysArea> GetList(SysAreaQuery query);
        #endregion


        #region 根据字典获取SysArea数据集
        /// <summary>
        /// 根据字典获取SysArea数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SysArea集合
        /// <summary>
        /// 分页获取SysArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SysArea> GetPageList(PageListBySql<SysArea> page, IDictionary<string, object> conditionDict);
        #endregion


        #endregion


    }


    public partial interface ISysAreaDAO
    {
        #region 根据ID集合获取SysArea集合
        /// <summary>
        /// 根据ID集合获取SysArea集合
        /// </summary>
        /// <param name="query">ID集合</param>
        /// <returns>数据集合</returns>
        IList<SysArea> GetListByIDs(IList<int> ids);
        #endregion
    }
}