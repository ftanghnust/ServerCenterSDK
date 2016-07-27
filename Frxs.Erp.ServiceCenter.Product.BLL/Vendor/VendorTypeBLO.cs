
/*****************************
* Author:CR
*
* Date:2016-03-09
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
    /// 供应商类型VendorType业务逻辑类
    /// </summary>
    public partial class VendorTypeBLO
    {
        #region 成员方法
        #region 根据主键验证VendorType是否存在
        /// <summary>
        /// 根据主键验证VendorType是否存在
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(VendorType model)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().Exists(model);
        }
        #endregion


        #region 添加一个VendorType
        /// <summary>
        /// 添加一个VendorType
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(VendorType model)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().Save(model);
        }
        #endregion


        #region 更新一个VendorType
        /// <summary>
        /// 更新一个VendorType
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(VendorType model)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().Edit(model);
        }
        #endregion


        #region 删除一个VendorType
        /// <summary>
        /// 删除一个VendorType
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(VendorType model)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个VendorType
        /// <summary>
        /// 根据主键逻辑删除一个VendorType
        /// </summary>
        /// <param name="vendorTypeID">供应商分类ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int vendorTypeID)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().LogicDelete(vendorTypeID);
        }
        #endregion


        #region 根据字典获取VendorType对象
        /// <summary>
        /// 根据字典获取VendorType对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>VendorType对象</returns>
        public static VendorType GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取VendorType对象
        /// <summary>
        /// 根据主键获取VendorType对象
        /// </summary>
        /// <param name="vendorTypeID">供应商分类ID</param>
        /// <returns>VendorType对象</returns>
        public static VendorType GetModel(int vendorTypeID)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().GetModel(vendorTypeID);
        }
        #endregion


        #region 根据字典获取VendorType集合
        /// <summary>
        /// 根据字典获取VendorType集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<VendorType> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取VendorType数据集
        /// <summary>
        /// 根据字典获取VendorType数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取VendorType集合
        /// <summary>
        /// 分页获取VendorType集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<VendorType> GetPageList(PageListBySql<VendorType> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion
    }

    public partial class VendorTypeBLO
    {
        #region 根据主键验证 关联的供应商 仓库商品表采购表 是否存在记录
        /// <summary>
        /// 根据主键验证 关联的供应商 仓库商品表采购表 是否存在记录
        /// </summary>
        /// <param name="model">VendorType对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsVendor(VendorType model)
        {
            return DALFactory.GetLazyInstance<IVendorTypeDAO>().ExistsVendor(model);
        }
        #endregion
    }
}