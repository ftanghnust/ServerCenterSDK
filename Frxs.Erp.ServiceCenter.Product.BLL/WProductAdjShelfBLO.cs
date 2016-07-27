
/*****************************
* Author:CHUJL
*
* Date:2016-04-09
******************************/
using System;
using System.Collections.Generic;

using System.Linq;
using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 仓库商品货架调整表WProductAdjShelf业务逻辑类
    /// </summary>
    public partial class WProductAdjShelfBLO
    {
        #region 成员方法
        #region 根据主键验证WProductAdjShelf是否存在
        /// <summary>
        /// 根据主键验证WProductAdjShelf是否存在
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductAdjShelf model)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WProductAdjShelf
        /// <summary>
        /// 添加一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>最新标识列</returns>
        public static string Save(WProductAdjShelf model, int wareHouseId)
        {

            IList<WProductAdjShelfDetails> detailList = new List<WProductAdjShelfDetails>();
            foreach (var detailobj in model.wProductAdjShelfDetailsList)
            {
                IDictionary<string, object> wheredic = new Dictionary<string, object>();
                wheredic.Add("ShelfCode", detailobj.ShelfCode);
                wheredic.Add("WID", wareHouseId);
                Shelf shelf = DALFactory.GetLazyInstance<IShelfDAO>().GetModel(wheredic);
                if (shelf == null || shelf.ShelfID <= 0)
                {
                    return "新增货位调整失败,请检查新货位号:" + detailobj.ShelfCode + "是否正确";
                }
                detailobj.ShelfID = shelf.ShelfID;
                detailList.Add(detailobj);
            }

            var connection = DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                int id = DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().Save(model, connection, trans);
                if (id <= 0)
                {
                    trans.Rollback();
                    return "0";
                }
                int detailscount = 0;
                foreach (var obj in detailList)
                {

                    if (DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Save(obj, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return "0";
                    }
                    detailscount = detailscount + 1;
                }
                if (detailscount == model.wProductAdjShelfDetailsList.Count)
                {
                    trans.Commit();
                    return "1";
                }
                else
                {
                    trans.Rollback();
                    return "0";
                }
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


        #region 更新一个WProductAdjShelf
        /// <summary>
        /// 更新一个WProductAdjShelf
        /// </summary>
        /// <param name="model"></param>
        /// <returns>数据库影响行数</returns>
        public static string ChangeStatus(string adjIDs, int status, int userId, string userName)
        {
            var idsArr = adjIDs.Split(',');
            IList<WProductAdjShelf> modelList = new List<WProductAdjShelf>();
            foreach (var id in idsArr)
            {
                WProductAdjShelf model = WProductAdjShelfBLO.GetModel(id);
                modelList.Add(model);
            }

            modelList = modelList.OrderBy(o => o.AdjID).ToList();
            var connection = DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var model in modelList)
                {

                    if (model != null)
                    {
                        if (status == 2 && model.Status != 1)
                        {
                            //过账状态验证
                            trans.Rollback();
                            return "状态错误，不能更改";
                        }
                        if (status == 0 && model.Status != 1)
                        {
                            //由确认到反确认
                            trans.Rollback();
                            return "状态错误，不能更改";
                        }
                        if (status == 1 && model.Status != 0)
                        {
                            //由录单到确认
                            trans.Rollback();
                            return "状态错误，不能更改";
                        }

                        
                        model.ModifyUserID = userId;
                        model.ModifyUserName = userName;
                        model.ModifyTime = DateTime.Now;

                        if (status == 1 && model.Status == 0) //状态(状态(0:未提交;1:已确认;2:已过帐;))
                        {
                            model.Status = status;
                            model.ConfTime = DateTime.Now;
                            model.ConfUserID = userId;
                            model.ConfUserName = userName;
                            if (WProductAdjShelfBLO.Edit(model, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return string.Format("确认调整单{0}失败", model.AdjID);
                            }
                        }
                        else if (status == 2 && model.Status == 1)//过帐
                        {
                            model.Status = status;
                            model.PostingTime = DateTime.Now;
                            model.PostingUserID = userId;
                            model.PostingUserName = userName;
                            //修改仓库货位ID 
                            DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().EditToWProduct(model.AdjID, userId, userName, connection, trans);
                            if (WProductAdjShelfBLO.Edit(model, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return string.Format("过账调整单{0}失败", model.AdjID);
                            }
                        }
                        else if (status == 0 && model.Status == 1)//反确认
                        {
                            model.Status = status;
                            model.ConfTime = null;
                            model.ConfUserID = null;
                            model.ConfUserName = "";
                            if (WProductAdjShelfBLO.Edit(model, connection, trans) <= 0)
                            {
                                trans.Rollback();
                                return string.Format("反确认调整单{0}失败", model.AdjID);
                            }
                        }
                    }
                }
                trans.Commit();
                return "1";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
            finally
            {
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion

        #region 更新一个WProductAdjShelf
        /// <summary>
        /// 更新一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public static string Edit(WProductAdjShelf model, int wareHouseId)
        {

            WProductAdjShelf wProductAdjShelf = DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetModel(model.AdjID);
            if (wProductAdjShelf == null || wProductAdjShelf.Status != 0)
            {
                return "编辑货位调整失败,此调整单已删除或状态不为录单！";
            }

            IList<WProductAdjShelfDetails> detailList = new List<WProductAdjShelfDetails>();
            foreach (var detailobj in model.wProductAdjShelfDetailsList)
            {
                IDictionary<string, object> wheredic = new Dictionary<string, object>();
                wheredic.Add("ShelfCode", detailobj.ShelfCode);
                wheredic.Add("WID", wareHouseId);
                Shelf shelf = DALFactory.GetLazyInstance<IShelfDAO>().GetModel(wheredic);
                if (shelf == null || shelf.ShelfID <= 0)
                {
                    return "新增货位调整失败,请检查新货位号:" + detailobj.ShelfCode + "是否正确";
                }
                detailobj.ShelfID = shelf.ShelfID;
                detailList.Add(detailobj);
            }

            var connection = DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {

                int id = DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().Edit(model, connection, trans);
                if (id <= 0)
                {
                    trans.Rollback();
                    return "0";
                }
                int detailscount = 0;
                DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Delete(model.AdjID, connection, trans);
                foreach (var obj in detailList)
                {

                    if (DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Save(obj, connection, trans) <= 0)
                    {
                        trans.Rollback();
                        return "0";
                    }
                    detailscount = detailscount + 1;
                }
                if (detailscount == model.wProductAdjShelfDetailsList.Count)
                {
                    trans.Commit();
                    return "1";
                }
                else
                {
                    trans.Rollback();
                    return "0";
                }
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


        #region 删除一个WProductAdjShelf
        /// <summary>
        /// 删除一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string ids)
        {
            var idsArr = ids.Split(',');
            int row = 0;
            IList<WProductAdjShelf> modelList = new List<WProductAdjShelf>();
            foreach (var id in idsArr)
            {
                WProductAdjShelf model = WProductAdjShelfBLO.GetModel(id);
                if (model.Status != 0)
                {
                    return 0;
                }
                modelList.Add(model);
            }

            var connection = DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var model in modelList)
                {

                    DALFactory.GetLazyInstance<IWProductAdjShelfDetailsDAO>().Delete(model.AdjID, connection, trans);
                    if (DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().Delete(model.AdjID, connection, trans) > 0)
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


        #region 根据主键逻辑删除一个WProductAdjShelf
        /// <summary>
        /// 根据主键逻辑删除一个WProductAdjShelf
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string adjID)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().LogicDelete(adjID);
        }
        #endregion


        //#region 根据字典获取WProductAdjShelf对象
        ///// <summary>
        ///// 根据字典获取WProductAdjShelf对象
        ///// </summary>
        ///// <param name="query">查询对象</param>
        ///// <returns>WProductAdjShelf对象</returns>
        //public static WProductAdjShelf GetModel(WProductAdjShelfQuery query)
        //{
        //    return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetModel(query);
        //}
        //#endregion

        /// <summary>
        /// 更新一个WProductAdjShelf
        /// </summary>
        /// <param name="model">WProductAdjShelf对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductAdjShelf model, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().Edit(model, conn, trans);
        }


        #region 根据主键获取WProductAdjShelf对象
        /// <summary>
        /// 根据主键获取WProductAdjShelf对象
        /// </summary>
        /// <param name="adjID">调整ID</param>
        /// <returns>WProductAdjShelf对象</returns>
        public static WProductAdjShelf GetModel(string adjID)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetModel(adjID);
        }
        #endregion


        //#region 根据字典获取WProductAdjShelf集合
        ///// <summary>
        ///// 根据字典获取WProductAdjShelf集合
        ///// </summary>
        ///// <param name="query">查询对象</param>
        ///// <returns>数据集合</returns>
        //public static IList<WProductAdjShelf> GetList(WProductAdjShelfQuery query)
        //{
        //    return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetList(query);
        //}
        //#endregion


        #region 根据字典获取WProductAdjShelf数据集
        /// <summary>
        /// 根据字典获取WProductAdjShelf数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductAdjShelf集合
        /// <summary>
        /// 分页获取WProductAdjShelf集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductAdjShelf> GetPageList(PageListBySql<WProductAdjShelf> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWProductAdjShelfDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }
}