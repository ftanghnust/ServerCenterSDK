
/*****************************
* Author:CR
*
* Date:2016-03-17
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
    /// 仓库用户拣货区表WarehouseEmpShelf业务逻辑类
    /// </summary>
    public partial class WarehouseEmpShelfBLO
    {
        #region 成员方法
        #region 根据主键验证WarehouseEmpShelf是否存在
        /// <summary>
        /// 根据主键验证WarehouseEmpShelf是否存在
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WarehouseEmpShelf model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WarehouseEmpShelf
        /// <summary>
        /// 添加一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WarehouseEmpShelf model, string[] shelfIds)
        {
            IDbConnection conn = null;
            IDbTransaction tran = null;
            int row = 0;
            try
            {
                conn = DALFactory.GetLazyInstance<IShelfDAO>().GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                row=DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().Delete(conn, tran, model);

                if (shelfIds!=null)
                {
                    foreach (string id in shelfIds)
                    {
                        model.ShelfID = int.Parse(id);
                        row = DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().Save(conn, tran, model);
                    }
                }
                tran.Commit();

            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
                tran.Dispose();
                conn.Dispose();
            }

            return row;
        }
        #endregion


        #region 更新一个WarehouseEmpShelf
        /// <summary>
        /// 更新一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WarehouseEmpShelf model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WarehouseEmpShelf
        /// <summary>
        /// 删除一个WarehouseEmpShelf
        /// </summary>
        /// <param name="model">WarehouseEmpShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WarehouseEmpShelf model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WarehouseEmpShelf
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseEmpShelf
        /// </summary>
        /// <param name="iD">主键</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WarehouseEmpShelf对象
        /// <summary>
        /// 根据字典获取WarehouseEmpShelf对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseEmpShelf对象</returns>
        public static WarehouseEmpShelf GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WarehouseEmpShelf对象
        /// <summary>
        /// 根据主键获取WarehouseEmpShelf对象
        /// </summary>
        /// <param name="iD">主键</param>
        /// <returns>WarehouseEmpShelf对象</returns>
        public static WarehouseEmpShelf GetModel(int iD)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取WarehouseEmpShelf集合
        /// <summary>
        /// 根据字典获取WarehouseEmpShelf集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WarehouseEmpShelf> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WarehouseEmpShelf数据集
        /// <summary>
        /// 根据字典获取WarehouseEmpShelf数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WarehouseEmpShelf集合
        /// <summary>
        /// 分页获取WarehouseEmpShelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WarehouseEmp> GetPageList(PageListBySql<WarehouseEmp> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().GetPageList(page, conditionDict);
        }
        #endregion

        #region 分页获取WarehouseEmpShelf集合
        /// <summary>
        /// 分页获取WarehouseEmpShelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WarehouseEmpShelf> GetPageShelfList(PageListBySql<WarehouseEmpShelf> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().GetPageShelfList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWarehouseEmpShelfDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }
}