
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.IDAL;
using Frxs.Erp.ServiceCenter.Order.IDAL.Order;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.IOCFactory;
using Frxs.Platform.Utility;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Order.BLL.Order
{
    /// <summary>
    /// SaleOrderPreShelfArea业务逻辑类
    /// </summary>
    public partial class SaleOrderPreShelfAreaBLO
    {
        #region 成员方法
        #region 根据主键验证SaleOrderPreShelfArea是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreShelfArea是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>是否存在</returns>
        public static bool Exists(SaleOrderPreShelfArea model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).Exists(model);
        }
        #endregion


        #region 添加一个SaleOrderPreShelfArea
        /// <summary>
        /// 添加一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>最新标识列</returns>
        public static int Save(SaleOrderPreShelfArea model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).Save(model);
        }
        #endregion


        #region 更新一个SaleOrderPreShelfArea
        /// <summary>
        /// 更新一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(SaleOrderPreShelfArea model, string warehouseId, IDbConnection conn = null, IDbTransaction tran = null)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).Edit(model);
        }

        public static int EditByAreaID(SaleOrderPreShelfArea model, string warehouseId, IDbConnection conn = null, IDbTransaction tran = null)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).EditByAreaID(model, conn, tran);
        }
        #endregion


        #region 删除一个SaleOrderPreShelfArea
        /// <summary>
        /// 删除一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(SaleOrderPreShelfArea model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPreShelfArea
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="iD">主键ID(WID + GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取SaleOrderPreShelfArea对象
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        public static SaleOrderPreShelfArea GetModel(IDictionary<string, object> query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).GetModel(query);
        }
        #endregion


        #region 根据主键获取SaleOrderPreShelfArea对象
        /// <summary>
        /// 根据主键获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">主键ID(WID + GUID)</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        public static SaleOrderPreShelfArea GetModel(string iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取SaleOrderPreShelfArea集合
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集合</returns>
        public static IList<SaleOrderPreShelfArea> GetList(IDictionary<string, object> query, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).GetList(query);
        }
        #endregion


        #region 根据字典获取SaleOrderPreShelfArea数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取SaleOrderPreShelfArea集合
        /// <summary>
        /// 分页获取SaleOrderPreShelfArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<SaleOrderPreShelfArea> GetPageList(PageListBySql<SaleOrderPreShelfArea> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    /// <summary>
    /// SaleOrderPreShelfArea业务逻辑类
    /// 龙武
    /// </summary>
    public partial class SaleOrderPreShelfAreaBLO
    {
        /// <summary>
        /// 根据订单编号获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">订单编号</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        public static List<SaleOrderPreShelfArea> GetModelByOrderId(string orderId, string warehouseId, object RequestDto = null)
        {
            return DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId).GetModelByOrderId(orderId);
        }

        /// <summary>
        /// 开始拣货
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="userId">用户编号</param>
        /// <param name="userName">用户名称</param>
        /// <param name="stationNumber">流水号</param>
        /// /// <param name="isFirstPick">是否是第一次拣货</param>
        /// <returns></returns>
        public static SaleOrderPre StartPick(string orderId, string warehouseId, string shelfAreaID, int userId, string userName, string stationNumber, bool isFirstPick)
        {
            var FactoryObj = DALFactory.GetLazyInstance<ISaleOrderPreShelfAreaDAO>(warehouseId);
            IDbConnection conn = FactoryObj.GetConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                List<SaleOrderPreShelfArea> preShelfAreaModel = null;
                if (string.IsNullOrWhiteSpace(shelfAreaID) || Utils.StrToInt(shelfAreaID, 0) < 1)
                {
                    preShelfAreaModel = FactoryObj.GetModelByOrderId(orderId, conn, tran);
                    if (preShelfAreaModel == null)
                    {
                        return null;
                    }
                    preShelfAreaModel.ForEach(x =>
                    {
                        x.BeginTime = DateTime.Now;                        
                        x.ModifyUserID = userId;
                        x.ModifyUserName = userName;
                        int editResult = SaleOrderPreShelfAreaBLO.Edit(x, warehouseId, conn, tran);
                    });
                }
                else
                {
                    preShelfAreaModel = FactoryObj.GetModelByOrderIdAndAreaID(orderId, shelfAreaID, conn, tran);
                    if (preShelfAreaModel == null)
                    {
                        return null;
                    }
                    preShelfAreaModel.ForEach(x =>
                    {
                        x.ModifyUserID = userId;
                        x.ModifyUserName = userName;
                        x.ShelfAreaID = Utils.StrToInt(shelfAreaID, 0);
                        x.OrderID = orderId;
                        int editResult = SaleOrderPreShelfAreaBLO.EditByAreaID(x, warehouseId, conn, tran);
                    });
                }

                if (isFirstPick)//判断是否是第一次拣货，否则更新订单表
                {
                    int result = SaleOrderPreBLO.UpdateSaleOrderPick(orderId, 3, Utils.StrToInt(stationNumber, 0), conn, tran, Utils.StrToInt(warehouseId, 0));
                    SaleOrderTrack trackModel = new SaleOrderTrack();
                    trackModel.ID = warehouseId + Guid.NewGuid().ToString();
                    trackModel.OrderID = orderId;
                    trackModel.WID = Utils.StrToInt(warehouseId, 0);
                    trackModel.Remark = "您的订单已开始拣货";
                    trackModel.IsDisplayUser = 1;
                    trackModel.OrderStatus = 3;
                    trackModel.OrderStatusName = "开始拣货";
                    trackModel.CreateTime = DateTime.Now;
                    trackModel.CreateUserID = userId;
                    trackModel.CreateUserName = userName;
                    SaleOrderTrackBLO.Save(trackModel, warehouseId, conn, tran);
                }
                SaleOrderPre saleOrderPreModel = SaleOrderPreBLO.GetModel(orderId, Utils.StrToInt(warehouseId, 0), conn, tran);
                if (saleOrderPreModel == null)
                {
                    return null;
                }

                tran.Commit();
                return saleOrderPreModel;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
