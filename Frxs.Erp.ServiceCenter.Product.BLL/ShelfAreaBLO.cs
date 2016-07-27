
/*****************************
* Author:CR
*
* Date:2016-03-09
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
    /// 仓库货区ShelfArea业务逻辑类
    /// </summary>
    public partial class ShelfAreaBLO
    {
        #region 成员方法
        #region 根据主键验证ShelfArea是否存在
        /// <summary>
        /// 根据主键验证ShelfArea是否存在
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(ShelfArea model)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().Exists(model);
        }
        #endregion


        #region 添加一个ShelfArea
        /// <summary>
        /// 添加一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(ShelfArea model)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().Save(model);
        }
        #endregion


        #region 更新一个ShelfArea
        /// <summary>
        /// 更新一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(ShelfArea model)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().Edit(model);
        }
        #endregion


        #region 删除一个ShelfArea
        /// <summary>
        /// 删除一个ShelfArea
        /// </summary>
        /// <param name="model">ShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(ShelfArea model)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个ShelfArea
        /// <summary>
        /// 根据主键逻辑删除一个ShelfArea
        /// </summary>
        /// <param name="shelfAreaID">ID(主键)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int shelfAreaID)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().LogicDelete(shelfAreaID);
        }
        #endregion


        #region 根据字典获取ShelfArea对象
        /// <summary>
        /// 根据字典获取ShelfArea对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShelfArea对象</returns>
        public static ShelfArea GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取ShelfArea对象
        /// <summary>
        /// 根据主键获取ShelfArea对象
        /// </summary>
        /// <param name="shelfAreaID">ID(主键)</param>
        /// <returns>ShelfArea对象</returns>
        public static ShelfArea GetModel(int shelfAreaID)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().GetModel(shelfAreaID);
        }
        #endregion


        #region 根据字典获取ShelfArea集合
        /// <summary>
        /// 根据字典获取ShelfArea集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<ShelfArea> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取ShelfArea数据集
        /// <summary>
        /// 根据字典获取ShelfArea数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取ShelfArea集合
        /// <summary>
        /// 分页获取ShelfArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<ShelfArea> GetPageList(PageListBySql<ShelfArea> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #region 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// <summary>
        /// 根据货区编号(同一个仓库不能重复)验证货区是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsShelfAreaCode(ShelfArea model)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().ExistsShelfAreaCode(model);
        }
        #endregion

        #region 根据货区编号(同一个仓库不能重复)验证货区是否使用
        /// <summary>
        /// 根据货区编号(同一个仓库不能重复)验证货区是否使用
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static IList<ShelfArea> ExistsShelfAreaCode(string ShelfAreaIDs)
        {
            return DALFactory.GetLazyInstance<IShelfAreaDAO>().ExistsShelfAreaCode(ShelfAreaIDs);
        }
        #endregion

        #endregion
    }
}