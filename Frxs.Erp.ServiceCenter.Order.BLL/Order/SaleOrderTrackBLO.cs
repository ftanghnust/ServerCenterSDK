
/*****************************
* Author:leidong
*
* Date:2016-04-11
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility.Pager;
using System.Linq;


namespace Frxs.Erp.ServiceCenter.Order.BLL
{
    /// <summary>
    /// SaleOrderTrack业务逻辑类
    /// </summary>
    public partial class SaleOrderTrackBLO
    {
        #region 成员方法
        #region 根据主键验证SaleOrderTrack是否存在
        /// <summary>
        /// 根据主键验证SaleOrderTrack是否存在
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleOrderTrack model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个SaleOrderTrack
        /// <summary>
        /// 添加一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleOrderTrack model, string warehouseId, IDbConnection conn = null, IDbTransaction tran = null)
        {
            if(conn!=null && tran!=null)
            {
                return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).Save(conn, tran, model);
            }
            else
            {
                return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).Save(model);
            }
        }
        #endregion


        #region 更新一个SaleOrderTrack
        /// <summary>
        /// 更新一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleOrderTrack model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个SaleOrderTrack
        /// <summary>
        /// 删除一个SaleOrderTrack
        /// </summary>
        /// <param name="model">SaleOrderTrack对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleOrderTrack model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleOrderTrack
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderTrack
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion

        #region 根据主键获取SaleOrderTrack对象
        /// <summary>
        /// 根据主键获取SaleOrderTrack对象
        /// </summary>
        /// <param name="iD">编号(仓库ID+GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleOrderTrack对象</returns>
        public static SaleOrderTrack GetModel(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取SaleOrderTrack集合
        ///// <summary>
        ///// 根据字典获取SaleOrderTrack集合
        ///// </summary>
        ///// <param name="query">查询对象</param>
        ///// <param name="warehouseId">仓库ID</param>
        ///// <returns>数据集合</returns>
        //public static IList<SaleOrderTrack> GetList(SaleOrderTrackQuery query, string warehouseId)
        //{
        //    //return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).GetList(query);
        //}
        #endregion


        #region 根据字典获取SaleOrderTrack数据集
        /// <summary>
        /// 根据字典获取SaleOrderTrack数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleOrderTrack集合
        /// <summary>
        /// 分页获取SaleOrderTrack集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderTrack> GetPageList(PageListBySql<SaleOrderTrack> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }


    public partial class SaleOrderTrackBLO
    {
        /// <summary>
        /// 取订单跟踪列表
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public static IList<SaleOrderTrack> GetTracks(string orderId, int wid)
        {
            var condition = new Dictionary<string, object>();
            condition.Add("OrderId", orderId);
            var list =
            DALFactory.GetLazyInstance<ISaleOrderTrackDAO>(wid.ToString()).GetList(condition);
            return list;
        }
    }
}