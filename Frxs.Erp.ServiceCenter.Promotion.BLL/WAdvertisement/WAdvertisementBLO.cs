
/*****************************
* Author:zhoujin
*
* Date:2016-03-29
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
    /// 仓库--广告、橱窗信息表WAdvertisement业务逻辑类
    /// </summary>
    public partial class WAdvertisementBLO
    {
        #region 成员方法
        #region 根据主键验证WAdvertisement是否存在
        /// <summary>
        /// 根据主键验证WAdvertisement是否存在
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WAdvertisement model)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(model.WID.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个WAdvertisement
        /// <summary>
        /// 添加一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WAdvertisement model)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(model.WID.ToString()).Save(model);
        }
        #endregion


        #region 更新一个WAdvertisement
        /// <summary>
        /// 更新一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WAdvertisement model)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(model.WID.ToString()).Edit(model);
        }
        #endregion


        #region 删除一个WAdvertisement
        /// <summary>
        /// 删除一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WAdvertisement model)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(model.WID.ToString()).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WAdvertisement
        /// <summary>
        /// 根据主键逻辑删除一个WAdvertisement
        /// </summary>
        /// <param name="advertisementID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int advertisementID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).LogicDelete(advertisementID);
        }

        public static int LogicDelete(int advertisementID, string warehouseId, IDbConnection conn, IDbTransaction trans)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).LogicDelete(advertisementID, conn, trans);
        }

        public static int Delete(string ids, string warehouseId)
        {
            var idsArr = ids.Split(',');
            int row = 0;
            var connection = DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                foreach (var id in idsArr)
                {
                    if (WAdvertisementBLO.LogicDelete(DataTypeHelper.GetInt(id), warehouseId, connection, trans) > 0)
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


        #region 根据字典获取WAdvertisement对象
        /// <summary>
        /// 根据字典获取WAdvertisement对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WAdvertisement对象</returns>
        public static WAdvertisement GetModel(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WAdvertisement对象
        /// <summary>
        /// 根据主键获取WAdvertisement对象
        /// </summary>
        /// <param name="advertisementID">主键ID</param>
        /// <returns>WAdvertisement对象</returns>
        public static WAdvertisement GetModel(int advertisementID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).GetModel(advertisementID);
        }
        #endregion


        #region 根据字典获取WAdvertisement集合
        /// <summary>
        /// 根据字典获取WAdvertisement集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WAdvertisement> GetList(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WAdvertisement数据集
        /// <summary>
        /// 根据字典获取WAdvertisement数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WAdvertisement集合
        /// <summary>
        /// 分页获取WAdvertisement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WAdvertisement> GetPageList(PageListBySql<WAdvertisement> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            var conditionDictNew = new Dictionary<string, object>();
            conditionDictNew.Add("WID", conditionDict["WID"]);
            conditionDictNew.Add("IsDelete", conditionDict["IsDelete"]);
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).GetPageList(page, conditionDictNew);
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
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class WAdvertisementBLO
    {
        #region 添加一个WAdvertisement 事务操作
        /// <summary>
        /// 添加一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WAdvertisement model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(model.WID.ToString()).Save(model, conn, tran);
        }
        #endregion

        #region 更新一个WAdvertisement 事务操作
        /// <summary>
        /// 更新一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WAdvertisement model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementDAO>(model.WID.ToString()).Edit(model, conn, tran);
        }
        #endregion
    }

    public partial class WAdvertisementBLO
    {
        /// <summary>
        /// 商品推荐主从表事务处理
        /// </summary>
        /// <param name="wAdvertisement"></param>
        /// <param name="wAdvertisementProducts"></param>
        /// <param name="conn"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static int SaveWAdvertisementAndProducts(WAdvertisement wAdvertisement, List<WAdvertisementProduct> wAdvertisementProducts)
        {
            var conn = DALFactory.GetLazyInstance<IWAdvertisementDAO>(wAdvertisement.WID.ToString()).GetConnection();
            conn.Open();
            var tran = conn.BeginTransaction();

            try
            {
                var result = 0;
                var newAdvertisementID = WAdvertisementBLO.Save(wAdvertisement, conn, tran);
                result += 1;
                wAdvertisement.AdvertisementID = newAdvertisementID;
                result += WAdvertisementProductBLO.DeleteByWAdvertisement(wAdvertisement.WID, wAdvertisement.AdvertisementID, conn, tran);
                foreach (var wAdvertisementProduct in wAdvertisementProducts)
                {
                    wAdvertisementProduct.WID = wAdvertisement.WID;
                    wAdvertisementProduct.AdvertisementID = wAdvertisement.AdvertisementID;
                    WAdvertisementProductBLO.Save(wAdvertisementProduct, conn, tran);
                    result += 1;
                }
                return result;
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                tran.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public static int EditWAdvertisementAndProducts(WAdvertisement wAdvertisement, List<WAdvertisementProduct> wAdvertisementProducts)
        {
            var conn = DALFactory.GetLazyInstance<IWAdvertisementDAO>(wAdvertisement.WID.ToString()).GetConnection();
            conn.Open();
            var tran = conn.BeginTransaction();

            try
            {
                var result = 0;
                result += WAdvertisementBLO.Edit(wAdvertisement, conn, tran);
                result += WAdvertisementProductBLO.DeleteByWAdvertisement(wAdvertisement.WID, wAdvertisement.AdvertisementID, conn, tran);
                foreach (var wAdvertisementProduct in wAdvertisementProducts)
                {
                    wAdvertisementProduct.WID = wAdvertisement.WID;
                    wAdvertisementProduct.AdvertisementID = wAdvertisement.AdvertisementID;
                    WAdvertisementProductBLO.Save(wAdvertisementProduct, conn, tran);
                    result += 1;
                }
                return result;
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                tran.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}