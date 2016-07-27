
/*****************************
* Author:CR
*
* Date:2016-04-05
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
    /// 仓库待装区表WStationNumber业务逻辑类
    /// </summary>
    public partial class WStationNumberBLO
    {
        #region 成员方法
        #region 根据主键验证WStationNumber是否存在
        /// <summary>
        /// 根据主键验证WStationNumber是否存在
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WStationNumber
        /// <summary>
        /// 添加一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().Save(model);
        }
        #endregion


        #region 更新一个WStationNumber
        /// <summary>
        /// 更新一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().Edit(model);
        }
        #endregion

        #region 更新一个WStationNumber中线路信息
        /// <summary>
        /// 更新一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        public static int EditLineInfo(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().EditLineInfo(model);
        }
        #endregion


        #region 删除一个WStationNumber
        /// <summary>
        /// 删除一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WStationNumber
        /// <summary>
        /// 根据主键逻辑删除一个WStationNumber
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().LogicDelete(model);
        }
        #endregion


        #region 根据字典获取WStationNumber对象
        /// <summary>
        /// 根据字典获取WStationNumber对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WStationNumber对象</returns>
        public static WStationNumber GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WStationNumber对象
        /// <summary>
        /// 根据主键获取WStationNumber对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WStationNumber对象</returns>
        public static WStationNumber GetModel(int iD)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取WStationNumber集合
        /// <summary>
        /// 根据字典获取WStationNumber集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WStationNumber> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WStationNumber数据集
        /// <summary>
        /// 根据字典获取WStationNumber数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WStationNumber集合
        /// <summary>
        /// 分页获取WStationNumber集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WStationNumber> GetPageList(PageListBySql<WStationNumber> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #region
        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsWStationNumber(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().ExistsWStationNumber(model);
        }
        #endregion

        #region
        /// <summary>
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static int ResetWStationNumber(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().ResetWStationNumber(model);
        }
        /// <summary>
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static int ResetWStationNumberExt(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().ResetWStationNumberExt(model);
        }
        /// <summary>
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static int ResetWStationNumberByOrderId(WStationNumber model)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().ResetWStationNumberByOrderId(model);
        }
        
        #endregion


        #endregion
    }

    /// <summary>
    /// 仓库待装区表WStationNumber业务逻辑类
    /// 龙武
    /// </summary>
    public partial class WStationNumberBLO
    {
        /// <summary>
        /// 根据仓库编号获取空闲待装区
        /// </summary>
        /// <param name="wId">仓库编号</param>
        /// <returns></returns>
        public static WStationNumber GetFreeStationNumber(int wId)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().GetFreeStationNumber(wId);
        }

        /// <summary>
        /// 拣货完成还原待装区数据
        /// </summary>
        /// <param name="userId">操作人编号</param>
        /// <param name="userName">操作人姓名</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public static bool UpdateStationNumberIsNull(int status, int orderStatus, int userId, string userName, string orderId)
        {
            return DALFactory.GetLazyInstance<IWStationNumberDAO>().UpdateStationNumberIsNull(status,orderStatus,userId, userName, orderId);
        }
    }
}