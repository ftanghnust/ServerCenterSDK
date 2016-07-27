
/*****************************
* Author:CR
*
* Date:2016-06-20
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// SysArea业务逻辑类
    /// </summary>
    public partial class SysAreaBLO
    {
        #region 成员方法
        #region 根据主键验证SysArea是否存在
        /// <summary>
        /// 根据主键验证SysArea是否存在
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SysArea model)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().Exists(model);
        }
        #endregion


        #region 添加一个SysArea
        /// <summary>
        /// 添加一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(SysArea model)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().Save(model);
        }
        #endregion


        #region 更新一个SysArea
        /// <summary>
        /// 更新一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SysArea model)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().Edit(model);
        }
        #endregion


        #region 删除一个SysArea
        /// <summary>
        /// 删除一个SysArea
        /// </summary>
        /// <param name="model">SysArea对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SysArea model)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SysArea
        /// <summary>
        /// 根据主键逻辑删除一个SysArea
        /// </summary>
        /// <param name="areaID">主键ID(区域邮政编号)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int areaID)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().LogicDelete(areaID);
        }
        #endregion


        #region 根据字典获取SysArea对象
        /// <summary>
        /// 根据字典获取SysArea对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>SysArea对象</returns>
        public static SysArea GetModel(SysAreaQuery query)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().GetModel(query);
        }
        #endregion


        #region 根据主键获取SysArea对象
        /// <summary>
        /// 根据主键获取SysArea对象
        /// </summary>
        /// <param name="areaID">主键ID(区域邮政编号)</param>
        /// <returns>SysArea对象</returns>
        public static SysArea GetModel(int areaID)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().GetModel(areaID);
        }
        #endregion


        #region 根据字典获取SysArea集合
        /// <summary>
        /// 根据字典获取SysArea集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public static IList<SysArea> GetList(SysAreaQuery query)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().GetList(query);
        }
        #endregion


        #region 根据字典获取SysArea数据集
        /// <summary>
        /// 根据字典获取SysArea数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SysArea集合
        /// <summary>
        /// 分页获取SysArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SysArea> GetPageList(PageListBySql<SysArea> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }

    public partial class SysAreaBLO
    {
        #region 根据ID集合取SysArea集合
        /// <summary>
        /// 根据ID集合取SysArea集合
        /// </summary>
        /// <param name="ids">ID集合</param>
        /// <returns>数据集合</returns>
        public static IList<SysArea> GetListByIDs(IList<int> ids)
        {
            return DALFactory.GetLazyInstance<ISysAreaDAO>().GetListByIDs(ids);
        }
        #endregion
    }
}