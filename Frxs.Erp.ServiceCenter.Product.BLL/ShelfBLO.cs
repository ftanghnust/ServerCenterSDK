
/*****************************
* Author:CR
*
* Date:2016-03-07
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
    /// 仓库货架表Shelf业务逻辑类
    /// </summary>
    public partial class ShelfBLO
    {
        #region 成员方法
        #region 根据主键验证Shelf是否存在
        /// <summary>
        /// 根据主键验证Shelf是否存在
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(Shelf model)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().Exists(model);
        }
        #endregion


        #region 添加一个Shelf
        /// <summary>
        /// 添加一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(Shelf model)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().Save(model);
        }
        #endregion


        #region 更新一个Shelf
        /// <summary>
        /// 更新一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(Shelf model)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().Edit(model);
        }
        #endregion


        #region 删除一个Shelf
        /// <summary>
        /// 删除一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(Shelf model)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个Shelf
        /// <summary>
        /// 根据主键逻辑删除一个Shelf
        /// </summary>
        /// <param name="shelfID">ID(主键)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int shelfID)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().LogicDelete(shelfID);
        }
        #endregion


        #region 根据字典获取Shelf对象
        /// <summary>
        /// 根据字典获取Shelf对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Shelf对象</returns>
        public static Shelf GetModel(Dictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取Shelf对象
        /// <summary>
        /// 根据主键获取Shelf对象
        /// </summary>
        /// <param name="shelfID">ID(主键)</param>
        /// <returns>Shelf对象</returns>
        public static Shelf GetModel(int shelfID)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().GetModel(shelfID);
        }
        #endregion


        #region 根据字典获取Shelf集合
        /// <summary>
        /// 根据字典获取Shelf集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<Shelf> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取Shelf数据集
        /// <summary>
        /// 根据字典获取Shelf数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(Dictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取Shelf集合
        /// <summary>
        /// 分页获取Shelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Shelf> GetPageList(PageListBySql<Shelf> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IShelfDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #region 根据货位编号(同一个仓库不能重复)验证货位是否存在
        /// <summary>
        /// 根据货位编号(同一个仓库不能重复)验证货位是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsShelfCode(Shelf model)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().ExistsShelfCode(model);
        }
        #endregion

        #region 根据货位编号(同一个仓库不能重复)验证货位是否使用
        /// <summary>
        /// 根据货位编号(同一个仓库不能重复)验证货位是否使用
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static IList<Shelf> ExistsShelIDs(string ShelIDs)
        {
            return DALFactory.GetLazyInstance<IShelfDAO>().ExistsShelIDs(ShelIDs);
        }
        #endregion


        #region 添加一个Shelf
        /// <summary>
        /// 添加一个Shelf
        /// </summary>
        /// <param name="model">Shelf对象</param>
        /// <returns>最新标识列</returns>
        public static string SaveList(IList<Shelf> modeList, int userId, string userName)
        {
             string message = string.Empty;

             var connection = DALFactory.GetLazyInstance<IShelfDAO>().GetConnection();
             connection.Open();
             var trans = connection.BeginTransaction();
             try
             {
                 foreach (var mode in modeList)
                 {
                     if (ShelfBLO.ExistsShelfCode(mode))
                     {
                         trans.Rollback();
                         message = mode.ShelfCode + "的货位编号已经存在！";
                         return message;                        
                     }
                     else
                     {
                         mode.ModifyUserID = userId;
                         mode.ModifyUserName = userName;
                         mode.Status = "0";
                         ShelfBLO.Save(mode);
                     }

                 }
                 trans.Commit();
             }
             catch
             {
                 trans.Rollback();
                 throw;
             }
             finally
             {
                 connection.Close();
                 trans.Dispose();
                 connection.Dispose();
             }

             return message;
        }
        #endregion


        #endregion
    }
}