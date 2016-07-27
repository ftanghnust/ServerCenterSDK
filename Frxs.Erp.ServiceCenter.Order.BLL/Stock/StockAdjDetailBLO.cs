
/*****************************
* Author:CR
*
* Date:2016-04-15
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// StockAdjDetail业务逻辑类
    /// </summary>
    public partial class StockAdjDetailBLO
    {
        #region 成员方法
        #region 根据主键验证StockAdjDetail是否存在
        /// <summary>
        /// 根据主键验证StockAdjDetail是否存在
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(StockAdjDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个StockAdjDetail
        /// <summary>
        /// 添加一个StockAdjDetail
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(StockAdjDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个StockAdjDetail
        /// <summary>
        /// 更新一个StockAdjDetail
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(StockAdjDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个StockAdjDetail
        /// <summary>
        /// 删除一个StockAdjDetail
        /// </summary>
        /// <param name="model">StockAdjDetail对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(StockAdjDetail model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个StockAdjDetail
        /// <summary>
        /// 根据主键逻辑删除一个StockAdjDetail
        /// </summary>
        /// <param name="iD">主键(仓库ID+GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取StockAdjDetail对象
        /// <summary>
        /// 根据字典获取StockAdjDetail对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>StockAdjDetail对象</returns>
        public static StockAdjDetail GetModel(StockAdjDetailQuery query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetModel(query);
        }
        #endregion


        #region 根据主键获取StockAdjDetail对象
        /// <summary>
        /// 根据主键获取StockAdjDetail对象
        /// </summary>
        /// <param name="iD">主键(仓库ID+GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>StockAdjDetail对象</returns>
        public static StockAdjDetail GetModel(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取StockAdjDetail集合
        /// <summary>
        /// 根据字典获取StockAdjDetail集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<StockAdjDetail> GetList(StockAdjDetailQuery query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetList(query);
        }
        #endregion


        #region 根据字典获取StockAdjDetail数据集
        /// <summary>
        /// 根据字典获取StockAdjDetail数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取StockAdjDetail集合
        /// <summary>
        /// 分页获取StockAdjDetail集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<StockAdjDetail> GetPageList(PageListBySql<StockAdjDetail> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #endregion
    }


    public partial class StockAdjDetailBLO
    {
        #region 删除一个StockAdjDetail
        /// <summary>
        /// 删除一个StockAdjDetail
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string id, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Delete(id);
        }
        #endregion

        #region 删除一个StockAdjDetail 同步删除 扩展表信息StockAdjDetailsExt 事务处理
        /// <summary>
        /// 删除一个StockAdjDetail 同步删除 扩展表信息StockAdjDetailsExt 事务处理
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int DeleteInfo(string id, string warehouseId)
        {
            int row = 0;
            var connection = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {//同步删除相关的详情表和详情扩展表的记录，采用事务处理
                row += DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Delete(connection, trans, id);
                DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Delete(connection, trans, id);
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return row;
        }
        #endregion

        #region 根据AdjID删除一批StockAdjDetail 同步删除 扩展表信息StockAdjDetailsExt 事务处理
        /// <summary>
        /// 根据AdjID删除一批StockAdjDetail 同步删除 扩展表信息StockAdjDetailsExt 事务处理
        /// </summary>
        /// <param name="adjID">调整单ID</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int DeleteInfoByAdjID(string adjID, string warehouseId)
        {
            int row = 0;
            var connection = DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {//同步删除相关的详情表和详情扩展表的记录，采用事务处理                
                row += DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).Delete(adjID, connection, trans);
                DALFactory.GetLazyInstance<IStockAdjDetailsExtDAO>(warehouseId).Delete(adjID, connection, trans);
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return row;
        }
        #endregion

        #region 根据adjID获取所有SKU集合
        /// <summary>
        /// 根据adjID获取所有SKU集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>商品编号集合</returns>
        public static IList<string> GetSkuList(string adjID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IStockAdjDetailDAO>(warehouseId).GetSkuList(adjID);
        }
        #endregion
    }
}