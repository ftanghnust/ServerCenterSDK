
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


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 仓库商品限购门店明细表WProductNoSaleShops业务逻辑类
    /// </summary>
    public partial class WProductNoSaleShopsBLO
    {
        #region 成员方法
        #region 根据主键验证WProductNoSaleShops是否存在
        /// <summary>
        /// 根据主键验证WProductNoSaleShops是否存在
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WProductNoSaleShops model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WProductNoSaleShops
        /// <summary>
        /// 添加一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WProductNoSaleShops model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().Save(model);
        }
        #endregion


        #region 更新一个WProductNoSaleShops
        /// <summary>
        /// 更新一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WProductNoSaleShops model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WProductNoSaleShops
        /// <summary>
        /// 删除一个WProductNoSaleShops
        /// </summary>
        /// <param name="model">WProductNoSaleShops对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WProductNoSaleShops model)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WProductNoSaleShops
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSaleShops
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int iD)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().LogicDelete(iD);
        }
        #endregion


        #region 根据字典获取WProductNoSaleShops对象
        /// <summary>
        /// 根据字典获取WProductNoSaleShops对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSaleShops对象</returns>
        public static WProductNoSaleShops GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WProductNoSaleShops对象
        /// <summary>
        /// 根据主键获取WProductNoSaleShops对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WProductNoSaleShops对象</returns>
        public static WProductNoSaleShops GetModel(int iD)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().GetModel(iD);
        }
        #endregion


        #region 根据字典获取WProductNoSaleShops集合
        /// <summary>
        /// 根据字典获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WProductNoSaleShops> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WProductNoSaleShops数据集
        /// <summary>
        /// 根据字典获取WProductNoSaleShops数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WProductNoSaleShops集合
        /// <summary>
        /// 分页获取WProductNoSaleShops集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WProductNoSaleShops> GetPageList(PageListBySql<WProductNoSaleShops> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWProductNoSaleShopsDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }
}