/*****************************
* Author:叶求
*
* Date:2016-03-09
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 供应商表Vendor数据库访问接口
    /// </summary>
    public partial interface IVendorDAO
    {

        #region 成员方法
        List<int> GetExitsVendorID(string vendorCode, string vendorName);

        #region 添加一个Vendor
        /// <summary>
        /// 添加一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(Vendor model, IDbTransaction tran = null, IDbConnection conn = null);
        #endregion


        #region 更新一个Vendor
        /// <summary>
        /// 更新一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(Vendor model, IDbTransaction tran = null, IDbConnection conn = null);
        #endregion


        #region 删除一个Vendor
        /// <summary>
        /// 删除一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(Vendor model);
        #endregion


        #region 根据主键逻辑删除一个Vendor
        /// <summary>
        /// 根据主键逻辑删除一个Vendor
        /// </summary>
        /// <param name="vendorID">供应商分类ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int vendorID);
        #endregion


        #region 根据字典获取Vendor对象
        /// <summary>
        /// 根据字典获取Vendor对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Vendor对象</returns>
        Vendor GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取Vendor对象
        /// <summary>
        /// 根据主键获取Vendor对象
        /// </summary>
        /// <param name="vendorID">供应商分类ID</param>
        /// <returns>Vendor对象</returns>
        Vendor GetModel(int vendorID);
        #endregion


        #region 根据字典获取Vendor集合
        /// <summary>
        /// 根据字典获取Vendor集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<Vendor> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取Vendor数据集
        /// <summary>
        /// 根据字典获取Vendor数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取Vendor集合
        /// <summary>
        /// 分页获取Vendor集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<Vendor> GetPageList(PageListBySql<Vendor> page, IDictionary<string, object> conditionDict);
        #endregion


        #region 更新字段
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="fieldList">需更新字段集合</param>
        /// <param name="whereConditionList">更新条件字段集合</param>
        /// <returns>数据库影响行数</returns>
        int UpdateField(IList<Field> fieldList, IList<WhereCondition> whereConditionList);
        #endregion


        #endregion

    }
    public partial interface IVendorDAO
    {
        #region 获取数据库连接
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>连接对象</returns>
        IDbConnection GetConnection();
        #endregion

        #region 更新供应商状态
        /// <summary>
        /// 更新供应商状态
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="status"></param>
        /// <param name="dateTime"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int UpdateStatus(string shelfId, int status, DateTime dateTime, int userID, string userName, IDbTransaction tran, IDbConnection conn);
        #endregion

        
        /// <summary>
        /// 获取供应商引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        IList<WarehouseSelectModel> GetVendorWarehouse(int vendorID);

        /// <summary>
        /// 获取供应商没有引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        IList<WarehouseSelectModel> GetNoneVendorWarehouse(int vendorID);
        
        /// <summary>
        /// 清空指定供应商与仓库关联关系
        /// </summary>
        /// <param name="vendorID"></param>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int ClearVendorWarehouse(int vendorID, IDbTransaction tran, IDbConnection conn);
        
            /// <summary>
        /// 获取供应商没有引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        int AddVendorWarehouse(WarehouseSelectModel model, IDbTransaction tran, IDbConnection conn);

        /// <summary>
        /// 删除现有供应商关联仓库信息
        /// </summary>
        /// <param name="vendorID"></param>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        int DeleteVendorWHouseList(int vendorID, IDbTransaction tran, IDbConnection conn);

        /// <summary>
        /// 保存供应商所属仓库信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int SaveVendorWHouse(int vendorID, int userID, string userName, List<int> widList, IDbTransaction tran, IDbConnection conn);

        /// <summary>
        /// 获取某个仓库下的商品最后一次进货的供应商信息集合
        /// </summary>
        /// <param name="wid">仓库ID</param>
        /// <param name="productIds">要指定查询的商品ID集合，允许为空</param>
        /// <returns>仓库下的商品最后一次进货的供应商信息集合</returns>
        IList<VendorLastBuy> GetLastBuyVendors(int wid, IList<int> productIds =null);
    }
}
