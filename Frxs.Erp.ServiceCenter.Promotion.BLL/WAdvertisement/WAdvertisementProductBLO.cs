
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
    /// 仓库--广告商品表WAdvertisementProduct业务逻辑类
    /// </summary>
    public partial class WAdvertisementProductBLO
    {
        #region 成员方法
        #region 根据主键验证WAdvertisementProduct是否存在
        /// <summary>
        /// 根据主键验证WAdvertisementProduct是否存在
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WAdvertisementProduct model)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(model.WID.ToString()).Exists(model);
        }
        #endregion


        #region 添加一个WAdvertisementProduct
        /// <summary>
        /// 添加一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WAdvertisementProduct model)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(model.WID.ToString()).Save(model);
        }
        #endregion


        #region 更新一个WAdvertisementProduct
        /// <summary>
        /// 更新一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WAdvertisementProduct model)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(model.WID.ToString()).Edit(model);
        }
        #endregion


        #region 删除一个WAdvertisementProduct
        /// <summary>
        /// 删除一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WAdvertisementProduct model, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WAdvertisementProduct
        /// <summary>
        /// 根据主键逻辑删除一个WAdvertisementProduct
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WAdvertisementProduct对象
        /// <summary>
        /// 根据字典获取WAdvertisementProduct对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WAdvertisementProduct对象</returns>
        public static WAdvertisementProduct GetModel(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WAdvertisementProduct对象
        /// <summary>
        /// 根据主键获取WAdvertisementProduct对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WAdvertisementProduct对象</returns>
        public static WAdvertisementProduct GetModel(int iD, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).GetModel(iD);
        }
        #endregion


        #region 根据字典获取WAdvertisementProduct集合
        /// <summary>
        /// 根据字典获取WAdvertisementProduct集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WAdvertisementProduct> GetList(IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WAdvertisementProduct数据集
        /// <summary>
        /// 根据字典获取WAdvertisementProduct数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WAdvertisementProduct集合
        /// <summary>
        /// 分页获取WAdvertisementProduct集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WAdvertisementProduct> GetPageList(PageListBySql<WAdvertisementProduct> page, IDictionary<string, object> conditionDict, string warehouseId)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(warehouseId).UpdateField(fieldList, whereConditionList);
        }
        #endregion

        


        #endregion


    }

    public partial class WAdvertisementProductBLO
    {
        public static int Save(WAdvertisementProduct model, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(model.WID.ToString()).Save(model, conn, tran);
        }

        public static int DeleteByWAdvertisement(int WID, int AdvertisementID)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(WID.ToString()).DeleteByWAdvertisement(WID, AdvertisementID);
        }

        public static int DeleteByWAdvertisement(int wid, int advertisementID, IDbConnection conn, IDbTransaction tran)
        {
            return DALFactory.GetLazyInstance<IWAdvertisementProductDAO>(wid.ToString()).DeleteByWAdvertisement(wid, advertisementID, conn, tran);
        }
    }
}