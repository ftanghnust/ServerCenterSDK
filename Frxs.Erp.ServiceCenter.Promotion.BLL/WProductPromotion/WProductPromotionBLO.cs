/*****************************
* Author:
*
* Date:2016-04-07
******************************/

using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.IDAL;
using Frxs.Erp.ServiceCenter.Promotion.Model;

using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using System.ComponentModel;


namespace Frxs.Erp.ServiceCenter.Promotion.BLL
{
    /// <summary>
    /// WProductPromotion业务逻辑类
    /// </summary>
    public partial class WProductPromotionBLO
    {
        #region 成员方法
        #region 根据主键验证WProductPromotion是否存在
        /// <summary>
        /// 根据主键验证WProductPromotion是否存在
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductPromotion model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个WProductPromotion
        /// <summary>
        /// 添加一个WProductPromotion
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductPromotion model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个WProductPromotion
        /// <summary>
        /// 更新一个WProductPromotion
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductPromotion model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Edit(model);
        }
        #endregion


        #region 删除一个WProductPromotion
        /// <summary>
        /// 删除一个WProductPromotion
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WProductPromotion model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WProductPromotion
        /// <summary>
        /// 根据主键逻辑删除一个WProductPromotion
        /// </summary>
        /// <param name="promotionID">主键ID(WID+ID服务表)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string promotionID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).LogicDelete(promotionID);
        }
        #endregion


        #region 根据字典获取WProductPromotion对象
        /// <summary>
        /// 根据字典获取WProductPromotion对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>WProductPromotion对象</returns>
        public static WProductPromotion GetModel(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WProductPromotion对象
        /// <summary>
        /// 根据主键获取WProductPromotion对象
        /// </summary>
        /// <param name="promotionID">主键ID(WID+ID服务表)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>WProductPromotion对象</returns>
        public static WProductPromotion GetModel(string promotionID, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetModel(promotionID);
        }
        #endregion


        #region 根据字典获取WProductPromotion集合
        /// <summary>
        /// 根据字典获取WProductPromotion集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<WProductPromotion> GetList(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WProductPromotion数据集
        /// <summary>
        /// 根据字典获取WProductPromotion数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductPromotion集合
        /// <summary>
        /// 分页获取WProductPromotion集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductPromotion> GetPageList(PageListBySql<WProductPromotion> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            IWProductPromotionDAO obj = DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId);
            return obj.GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }


    public partial class WProductPromotionBLO
    {
        #region 获取积分促销单据和详情+门店列表
        public static WProductPromotionInfo GetModelInfo(string promotionID, string warehouseId)
        {
            WProductPromotionInfo model = new WProductPromotionInfo();
            model.wProductPromotion = DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetModel(promotionID);
            model.detailsList = DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).GetList(promotionID);
            model.shopList = DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).GetList(promotionID);

            return model;
        }
        #endregion

        #region 添加一个WProductPromotion 事务处理
        /// <summary>
        /// 添加一个WProductPromotion 事务处理
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductPromotion model, string warehouseId, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Save(model, conn, tran);
        }
        #endregion

        #region 更新一个WProductPromotion 事务处理
        /// <summary>
        /// 更新一个WProductPromotion 事务处理
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductPromotion model, string warehouseId, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Edit(model, conn, tran);
        }
        #endregion

        #region 删除一个WProductPromotion 事务处理
        /// <summary>
        /// 删除一个WProductPromotion 事务处理
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string promotionID, string warehouseId, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Delete(conn, tran, promotionID);
        }
        #endregion

        #region 添加一个WProductPromotion 同步更新子表信息 事务处理
        /// <summary>
        /// 添加一个WProductPromotion 同步更新子表信息 事务处理
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="details">商品详情列表</param>
        /// <param name="shops">门店群组列表</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>最新标识列</returns>
        public static int SaveInfo(WProductPromotion model, IList<WProductPromotionDetails> detailsList, IList<WProductPromotionShops> shopList, string warehouseId)
        {

            var connection = DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                WProductPromotionBLO.Save(model, warehouseId, connection, trans);

                //保存 仓库商品 促销 明细表
                if (detailsList.Count > 0)
                {
                    foreach (var detailsItem in detailsList)
                    {
                        DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Save(connection, trans, detailsItem);
                    }
                }
                //保存 仓库商品 促销 门店群组 明细表
                if (shopList.Count > 0)
                {
                    foreach (var shopItem in shopList)
                    {
                        DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Save(connection, trans, shopItem);
                    }
                }
                trans.Commit();
                return 1;
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


        #region 修改一个WProductPromotion 同步更新子表信息 事务处理
        /// <summary>
        /// 修改一个WProductPromotion 同步更新子表信息 事务处理
        /// </summary>
        /// <param name="model">WProductPromotion对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="details">商品详情列表</param>
        /// <param name="shops">门店群组列表</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>最新标识列</returns>
        public static int EditInfo(WProductPromotion model, IList<WProductPromotionDetails> detailsList, IList<WProductPromotionShops> shopList, string warehouseId)
        {

            var connection = DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                WProductPromotionBLO.Edit(model, warehouseId, connection, trans);
                //删除 促销 明细表
                int delDetailNum = DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Delete(connection, trans, model.PromotionID);
                //保存 仓库商品 促销 明细表
                if (detailsList.Count > 0)
                {
                    foreach (var detailsItem in detailsList)
                    {
                        DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Save(connection, trans, detailsItem);
                    }
                }

                //删除原来的门店信息表
                int delShopGroupNum = DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Delete(connection, trans, model.PromotionID);
                //保存 仓库商品 促销 门店 明细表
                if (shopList.Count > 0)
                {
                    foreach (var shopItem in shopList)
                    {
                        DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Save(connection, trans, shopItem);
                    }
                }
                trans.Commit();
                return 1;
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

        #region 删除一个WProductPromotion 同步删除子表信息 事务处理
        /// <summary>
        /// 删除一个WProductPromotion 同步删除子表信息 事务处理
        /// </summary>
        /// <param name="promotionID">促销ID</param>
        /// <param name="warehouseId">仓库ID</param>        
        /// <returns>数据库影响行数</returns>
        public static int DeleteInfo(string promotionID, string warehouseId)
        {

            var connection = DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                //删除 仓库商品促销 主表
                int delNum = DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).Delete(connection, trans, promotionID);

                //删除 仓库商品促销 明细表
                DALFactory.GetLazyInstance<IWProductPromotionDetailsDAO>(warehouseId).Delete(connection, trans, promotionID);

                //删除 仓库商品促销 门店明细表
                DALFactory.GetLazyInstance<IWProductPromotionShopsDAO>(warehouseId).Delete(connection, trans, promotionID);

                trans.Commit();
                return delNum;
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

        #region 更新一个WProductPromotion的状态
        /// <summary>
        /// 更新一个WProductPromotion的状态
        /// </summary>
        /// <param name="idList">ID序列</param>
        /// <param name="status">状态(0:录单;1:已确认;2:已生效;3:已停用)</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateStatus(List<string> idList, PromotionStatus status, int userID, string userName, string warehouseId)
        {

            IList<Field> fieldList = new List<Field> 
                    { 
                        new Field 
                        { 
                            FieldName = "Status", 
                            FieldValue = status, 
                            FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int) 
                        } 
                    };
            IList<string> promotionIDList = idList;
            System.Collections.ArrayList promotionIDs = new System.Collections.ArrayList();
            foreach (string gender in promotionIDList)
            {
                promotionIDs.Add(gender);
            }
            IList<WhereCondition> whereConditionList = new List<WhereCondition> 
            { 
                new WhereCondition 
                { 
                    AttachSymbol = Attach.And, 
                    CompareSymbol = Compare.In, 
                    FieldObj = new Field 
                    { 
                        FieldName = "PromotionID", 
                        FieldValue = promotionIDs, 
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar)
                    }
                }
            };

            #region 记录相关操作人和时间信息
            if (status == PromotionStatus.Uncommitted)//反确认操作的时候，咨询胡总确认，要清空 确认人、确认时间的信息
            {
                fieldList.Add(new Field
                {
                    FieldName = "ConfTime",
                    FieldValue = null,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "ConfUserID",
                    FieldValue = null,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                    FieldLength = 4
                });
                fieldList.Add(new Field
                {
                    FieldName = "ConfUserName",
                    FieldValue = null,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                    FieldLength = 64
                });
            }
            else if (status == PromotionStatus.Submitted)//确认操作，要记录 确认人、确认时间的信息
            {
                fieldList.Add(new Field
                {
                    FieldName = "ConfTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "ConfUserID",
                    FieldValue = userID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                    FieldLength = 4
                });
                fieldList.Add(new Field
                {
                    FieldName = "ConfUserName",
                    FieldValue = userName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                    FieldLength = 64
                });
            }
            else if (status == PromotionStatus.Posted)//生效操作，要记录 生效人、生效时间的信息
            {
                fieldList.Add(new Field
                {
                    FieldName = "PostingTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "PostingUserID",
                    FieldValue = userID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                    FieldLength = 4
                });
                fieldList.Add(new Field
                {
                    FieldName = "PostingUserName",
                    FieldValue = userName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                    FieldLength = 64
                });
            }
            else if (status == PromotionStatus.Stopped)//停用操作，要记录 修改人、修改时间的信息
            {
                fieldList.Add(new Field
                {
                    FieldName = "ModifyTime",
                    FieldValue = DateTime.Now,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.DateTime)
                });
                fieldList.Add(new Field
                {
                    FieldName = "ModifyUserID",
                    FieldValue = userID,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.Int),
                    FieldLength = 4
                });
                fieldList.Add(new Field
                {
                    FieldName = "ModifyUserName",
                    FieldValue = userName,
                    FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar),
                    FieldLength = 64
                });
            }

            #endregion
            return WProductPromotionBLO.UpdateField(fieldList, whereConditionList, warehouseId);

        }

        #endregion

        #region 判断 互斥条件
        /// <summary>
        /// 积分促销/平台费率调整单 互斥信息
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        /// <param name="PromotionType">促销类型(1:门店积分促销;2:平台费率促销)</param>
        /// <param name="promotionID">费率调整单ID</param>       
        /// <param name="wid">仓库ID</param>
        /// <returns></returns>
        public static RepeatPromotionInfo GetRepeatInfo(string warehouseId, int PromotionType, string promotionID, int wid)
        {
            return DALFactory.GetLazyInstance<IWProductPromotionDAO>(warehouseId).GetRepeatInfo(promotionID, PromotionType, wid);
        }
        #endregion

        /// <summary>
        /// 商品促销表的状态 (状态(0:录单;1:已确认;2:已生效;3:已停用))
        /// </summary>
        public enum PromotionStatus
        {
            /// <summary>
            /// 录单
            /// </summary>
            [Description("录单")]
            Uncommitted = 0,

            /// <summary>
            /// 已确认
            /// </summary>
            [Description("已确认")]
            Submitted = 1,

            /// <summary>
            /// 已生效
            /// </summary>
            [Description("已生效")]
            Posted = 2,

            /// <summary>
            /// 已停用
            /// </summary>
            [Description("已停用")]
            Stopped = 3
        }
    }
}
