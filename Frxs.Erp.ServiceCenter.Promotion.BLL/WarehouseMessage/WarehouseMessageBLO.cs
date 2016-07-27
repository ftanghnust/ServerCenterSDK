
/*****************************
* Author:chujl 
*
* Date:2016-03-23
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Promotion.BLL
{
    /// <summary>
    /// 仓库消息表WarehouseMessage业务逻辑类
    /// </summary>
    public partial class WarehouseMessageBLO
    {
        #region 成员方法
        #region 根据主键验证WarehouseMessage是否存在
        /// <summary>
        /// 根据主键验证WarehouseMessage是否存在
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WarehouseMessage model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个WarehouseMessage
       /// <summary>
        /// 添加一个WarehouseMessage
       /// </summary>
       /// <param name="model"></param>
       /// <param name="warehouseId">仓库ID</param>
       /// <returns></returns>
        public static int Save(WarehouseMessage model, string warehouseId)
        {

            int row = 0;
            var connection = DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                IWarehouseMessageShopsDAO iWarehouseMessageShops = DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId);

                int id = DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).Save(model, connection, trans);
               
                
                if (id > 0)
                {
                    //添加消息 门店分组
                    if (model.detailList != null && model.detailList.Count > 0)
                    {
                        foreach (WarehouseMessageShops detailObj in model.detailList)
                        {
                            detailObj.WarehouseMessageID = id;
                            iWarehouseMessageShops.Save(detailObj, connection, trans);
                        }
                    }
                    row = row + 1;
                }
                else
                {
                    trans.Rollback();
                    return 0;
                }


                trans.Commit();
                return row;
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

        }
        #endregion


        #region 更新一个WarehouseMessage
       /// <summary>
        /// 更新一个WarehouseMessage
       /// </summary>
       /// <param name="model"></param>
       /// <param name="warehouseId"></param>
       /// <returns></returns>
        public static string Edit(WarehouseMessage model, string warehouseId)
        {

            WarehouseMessage tempModel = WarehouseMessageBLO.GetModel(model.ID.Value, warehouseId);
            if (tempModel == null || tempModel.Status != 0)
            {
                return "编辑信息失败，信息已删除或状态不为未发布状态！";
            }

            int row = 0;
            var connection = DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                IWarehouseMessageShopsDAO iWarehouseMessageShops = DALFactory.GetLazyInstance<IWarehouseMessageShopsDAO>(warehouseId);
                iWarehouseMessageShops.LogicDelete(model.ID.Value, connection, trans);
                if (model.detailList != null && model.detailList.Count > 0)
                {
                    foreach (WarehouseMessageShops detailObj in model.detailList)
                    {
                        iWarehouseMessageShops.Save(detailObj, connection, trans);
                    }
                }

                if (DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).Edit(model, connection, trans) > 0)
                {
                    row = row + 1;
                }
                else
                {
                    trans.Rollback();
                    return "编辑信息失败!";
                }

                trans.Commit();
                return "1";
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

        }
        #endregion


        #region 删除一个WarehouseMessage
        /// <summary>
        /// 删除一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WarehouseMessage model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).Delete(model);
        }

        /// <summary>
        /// 删除一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string ids, string warehouseId)
        {
            var idsArr = ids.Split(',');

            IList<WarehouseMessage> modelList = new List<WarehouseMessage>();
            foreach (var id in idsArr)
            {
                WarehouseMessage modelobj = WarehouseMessageBLO.GetModel(Convert.ToInt32(id), warehouseId);
                if (modelobj.Status == 0)
                {
                    modelList.Add(modelobj);
                }
            }

            int row = 0;
            var connection = DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (WarehouseMessage model in modelList)
                {
                    WarehouseMessageShopsBLO.LogicDelete(model.ID.Value, connection, trans, warehouseId);
                    if (WarehouseMessageBLO.LogicDelete(model.ID.Value, connection, trans, warehouseId) > 0)
                    {
                        row = row + 1;
                    }
                    else
                    {
                        trans.Rollback();
                        return 0;
                    }

                }
                trans.Commit();
                return row;
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
        }

        #endregion


        #region 根据主键逻辑删除一个WarehouseMessage
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessage
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).LogicDelete(iD);
        }

        /// <summary>
        /// 根据主键逻辑删除一个WarehouseMessage
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD, IDbConnection conn, IDbTransaction trans, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).LogicDelete(iD, conn, trans);
        }

        #endregion


        #region 根据字典获取WarehouseMessage对象
        /// <summary>
        /// 根据字典获取WarehouseMessage对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseMessage对象</returns>
        public static WarehouseMessage GetModel(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WarehouseMessage对象
        /// <summary>
        /// 根据主键获取WarehouseMessage对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WarehouseMessage对象</returns>
        public static WarehouseMessage GetModel(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取WarehouseMessage集合
        /// <summary>
        /// 根据字典获取WarehouseMessage集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WarehouseMessage> GetList(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WarehouseMessage数据集
        /// <summary>
        /// 根据字典获取WarehouseMessage数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WarehouseMessage集合
        /// <summary>
        /// 分页获取WarehouseMessage集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WarehouseMessage> GetPageList(PageListBySql<WarehouseMessage> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetPageList(page, conditionDict);
        }
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #region 批量更改WarehouseMessage状态
        /// <summary>
        /// 批量更改WarehouseMessage状态
        /// </summary>
        /// <param name="buyids"></param>
        /// <param name="status"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int ChangeStatus(string ids, int status, int userid, string username, string warehouseId)
        {
            var idsArr = ids.Split(',');
            int row = 0;
            IList<WarehouseMessage> modelList = new List<WarehouseMessage>();
            foreach (var id in idsArr)
            {
                WarehouseMessage modelobj = WarehouseMessageBLO.GetModel(Convert.ToInt32(id), warehouseId);
                modelList.Add(modelobj);
            }

            var connection = DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var model in modelList)
                {
                    if (model != null)
                    {
                        if (model.Status == 0 && status == 1) //确认
                        {
                            model.ConfTime = DateTime.Now;
                            model.ConfUserID = userid;
                            model.ConfUserName = username;
                        }
                        else if (model.Status == 1 && status == 2) //停止
                        {
                        }
                        else if (model.Status == 1 && status == 0) //反确认
                        {
                            model.ConfTime = null;
                            model.ConfUserID = null;
                            model.ConfUserName = null;
                        }
                        else
                        {
                            //其他状态为错误操作时，返回操作
                            trans.Rollback();
                            return 0;
                        }
                        model.Status = status;
                        model.ModityUserID = userid;
                        model.ModityUserName = username;
                        model.ModityTime = DateTime.Now;

                        if (WarehouseMessageBLO.Edit(model, connection, trans, warehouseId) > 0)
                        {
                            row = row + 1;
                        }
                        else
                        {
                            trans.Rollback();
                            return 0;
                        }
                    }
                    else
                    {
                        trans.Rollback();
                        return 0;
                    }

                }
                trans.Commit();
                return row;
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

        }
        #endregion


        #region 更新一个WarehouseMessage
        /// <summary>
        /// 更新一个WarehouseMessage
        /// </summary>
        /// <param name="model">WarehouseMessage对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WarehouseMessage model, IDbConnection conn, IDbTransaction trans, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWarehouseMessageDAO>(warehouseId).Edit(model, conn, trans);
        }
        #endregion
        #endregion
    }
}