
/*****************************
* Author:CR
*
* Date:2016-03-31
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.IDAL;
using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Platform.IOCFactory;
using System.ComponentModel;


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// WProductNoSale业务逻辑类
    /// </summary>
    public partial class WProductNoSaleBLO
    {
        #region 成员方法
        #region 根据主键验证WProductNoSale是否存在
        /// <summary>
        /// 根据主键验证WProductNoSale是否存在
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductNoSale model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WProductNoSale
        /// <summary>
        /// 添加一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductNoSale model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Save(model);
        }
        #endregion


        #region 更新一个WProductNoSale
        /// <summary>
        /// 更新一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductNoSale model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WProductNoSale
        /// <summary>
        /// 删除一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WProductNoSale model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WProductNoSale
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSale
        /// </summary>
        /// <param name="noSaleID">主键ID(WID + GUID)</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string noSaleID)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().LogicDelete(noSaleID);
        }
        #endregion


        #region 根据字典获取WProductNoSale对象
        /// <summary>
        /// 根据字典获取WProductNoSale对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSale对象</returns>
        public static WProductNoSale GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WProductNoSale对象
        /// <summary>
        /// 根据主键获取WProductNoSale对象
        /// </summary>
        /// <param name="noSaleID">主键ID(WID + GUID)</param>
        /// <returns>WProductNoSale对象</returns>
        public static WProductNoSale GetModel(string noSaleID)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetModel(noSaleID);
        }
        #endregion


        #region 根据字典获取WProductNoSale集合
        /// <summary>
        /// 根据字典获取WProductNoSale集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WProductNoSale> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WProductNoSale数据集
        /// <summary>
        /// 根据字典获取WProductNoSale数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductNoSale集合
        /// <summary>
        /// 分页获取WProductNoSale集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductNoSale> GetPageList(PageListBySql<WProductNoSale> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    /// <summary>
    /// 自定义的方法 根据业务逻辑实现
    /// </summary>
    public partial class WProductNoSaleBLO
    {

        #region 添加一个WProductNoSale 事务处理
        /// <summary>
        /// 添加一个WProductNoSale 事务处理
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductNoSale model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Save(model, conn, tran);
        }
        #endregion

        #region 更新一个WProductNoSale 事务处理
        /// <summary>
        /// 更新一个WProductNoSale 事务处理
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductNoSale model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Edit(model, conn, tran);
        }
        #endregion

        #region 新增商品限购信息 同时会保存相关的 仓库商品限购明细表 和 仓库商品限购门店明细表

        /// <summary>
        /// 保存 商品限购信息 
        /// 同时会保存相关的 仓库商品限购明细表 和 仓库商品限购门店明细表
        /// </summary>
        /// <returns></returns>
        public static int SaveInfo(WProductNoSale model, List<WProductNoSaleDetails> detailsList, List<WProductNoSaleShops> shopList)
        {
            var connection = DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                WProductNoSaleBLO.Save(model, connection, trans);

                //保存 仓库商品限购明细表
                if (detailsList.Count > 0)
                {
                    foreach (var detailsItem in detailsList)
                    {
                        DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().Save(detailsItem, connection, trans);
                    }
                }
                //保存 仓库商品限购门店明细表
                if (shopList.Count > 0)
                {
                    foreach (var shopItem in shopList)
                    {
                        DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().Save(shopItem, connection, trans);
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


        #region 修改商品限购信息 同时会保存相关的 仓库商品限购明细表 和 仓库商品限购门店明细表

        /// <summary>
        /// 修改 商品限购信息 
        /// 同时会保存相关的 仓库商品限购明细表 和 仓库商品限购门店明细表
        /// </summary>
        /// <returns></returns>
        public static int EditInfo(WProductNoSale model, List<WProductNoSaleDetails> detailsList, List<WProductNoSaleShops> shopList)
        {
            var connection = DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                WProductNoSaleBLO.Edit(model, connection, trans);

                //删除 旧的 仓库商品限购明细表
                IWProductNoSaleDetailsDAO iNoSaleDetails = DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>();
                int delDetailNum = iNoSaleDetails.Delete(model.NoSaleID, connection, trans);

                //保存 仓库商品限购明细表
                if (detailsList.Count > 0)
                {
                    foreach (var detailsItem in detailsList)
                    {
                        iNoSaleDetails.Save(detailsItem, connection, trans);
                    }
                }

                //删除 旧的 仓库商品限购门店明细表
                IWProductNoSaleShopsDAO iNoSaleShops = DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>();
                int delShopNum = iNoSaleShops.Delete(model.NoSaleID, connection, trans);
                //保存 仓库商品限购门店明细表
                if (shopList.Count > 0)
                {
                    foreach (var shopItem in shopList)
                    {
                        iNoSaleShops.Save(shopItem, connection, trans);
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

        #region 删除一个WProductNoSale 事务操作
        /// <summary>
        /// 删除一个WProductNoSale 事务操作
        /// </summary>
        /// <param name="NoSaleID">限购单号</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(string NoSaleID, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Delete(NoSaleID, conn, tran);
        }
        #endregion

        #region 删除一个WProductNoSale 并删除相关的子表信息 事务操作
        /// <summary>
        /// 删除一个WProductNoSale 并删除相关的子表信息 事务操作
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        public static int DeleteInfo(string NoSaleID)
        {
            var connection = DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetConnection();
            connection.Open();
            var trans = connection.BeginTransaction();

            try
            {
                //删除 仓库商品限购 主表
                int delNum = DALFactory.GetLazyInstance<IWProductNoSaleDAO>().Delete(NoSaleID, connection, trans);

                //删除 仓库商品限购明细表
                DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().Delete(NoSaleID, connection, trans);

                //删除 旧的 仓库商品限购门店明细表
                DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().Delete(NoSaleID, connection, trans);

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

        #region 更新一个WProductNoSale的状态
        /// <summary>
        /// 更新一个WProductNoSale的状态
        /// </summary>
        /// <param name="idList">ID序列</param>
        /// <param name="status">状态(0:未提交;1:已提交;2:已过帐/已开始;3:已停用)</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>数据库影响行数</returns>
        public static int UpdateStatus(List<string> idList, NoSaleStatus status, int userID, string userName)
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
            IList<string> noSaleIdList = idList;
            System.Collections.ArrayList noSaleIDs = new System.Collections.ArrayList();
            foreach (string gender in noSaleIdList)
            {
                noSaleIDs.Add(gender);
            }
            IList<WhereCondition> whereConditionList = new List<WhereCondition> 
            { 
                new WhereCondition 
                { 
                    AttachSymbol = Attach.And, 
                    CompareSymbol = Compare.In, 
                    FieldObj = new Field 
                    { 
                        FieldName = "NoSaleID", 
                        FieldValue = noSaleIDs, 
                        FieldDbType = DbTypeConverter.SqlDbType2DbType(SqlDbType.VarChar)
                    }
                }
            };

            #region 记录相关操作人和时间信息
            if (status == NoSaleStatus.Uncommitted)//反确认操作的时候，咨询胡总确认，要清空 确认人、确认时间的信息
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
            else if (status == NoSaleStatus.Submitted)//确认操作，要记录 确认人、确认时间的信息
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
            else if (status == NoSaleStatus.Posted)//生效操作，要记录 生效人、生效时间的信息
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
            else if (status == NoSaleStatus.Stopped)//停用操作，要记录 修改人、修改时间的信息
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
            return WProductNoSaleBLO.UpdateField(fieldList, whereConditionList);
        }

        #endregion
        /// <summary>
        /// 商品限购表的状态 (0:未提交/反确认过的 ;1:已提交/确认过的 ;2:已生效/已过帐/已开始;3:已停用)
        /// </summary>
        public enum NoSaleStatus
        {
            /// <summary>
            /// 未提交
            /// </summary>
            [Description("未提交/反确认过的")]
            Uncommitted = 0,

            /// <summary>
            /// 已提交
            /// </summary>
            [Description("已提交/确认过的")]
            Submitted = 1,

            /// <summary>
            /// 已过帐/已开始
            /// </summary>
            [Description("已生效/已过帐/已开始")]
            Posted = 2,

            /// <summary>
            /// 已停用
            /// </summary>
            [Description("已停用")]
            Stopped = 3
        }

        #region 根据主键获取WProductNoSale对象 包含限购商品信息和门店群组信息
        /// <summary>
        /// 根据主键获取WProductNoSaleInfo对象 包含限购商品信息和门店群组信息
        /// </summary>
        /// <param name="noSaleID">主键ID(WID + GUID)</param>
        /// <returns>WProductNoSaleInfo对象</returns>
        public static WProductNoSaleInfo GetModelInfo(string noSaleID)
        {
            WProductNoSaleInfo wProductNoSaleInfo = new WProductNoSaleInfo();
            wProductNoSaleInfo.wProductNoSale = DALFactory.GetLazyInstance<IWProductNoSaleDAO>().GetModel(noSaleID);
            wProductNoSaleInfo.productdetails = DALFactory.GetLazyInstance<IWProductNoSaleDetailsDAO>().GetList(noSaleID);
            wProductNoSaleInfo.shopGroups = DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().GetList(noSaleID);
            return wProductNoSaleInfo;
        }
        #endregion
    }
}