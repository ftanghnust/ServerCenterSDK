
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
    /// 供应商表Vendor业务逻辑类
    /// </summary>
    public partial class VendorBLO
    {
        #region 成员方法
        #region 根据主键验证Vendor是否存在
        

        /// <summary>
        /// 根据条件获取供应商ID
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <param name="vendorName"></param>
        /// <returns></returns>
        public static List<int> GetExitsVendorID(string vendorCode, string vendorName)
        {
           return DALFactory.GetLazyInstance<IVendorDAO>().GetExitsVendorID(vendorCode, vendorName);
        }
        #endregion

        
        #region 添加一个Vendor
        /// <summary>
        /// 添加一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(Vendor model)
        {
            int sumCount = 0;
            IDbConnection conn = null;
            IDbTransaction tran = null;
            try
            {                
                IVendorDAO iVendor = DALFactory.GetLazyInstance<IVendorDAO>();
                conn = iVendor.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();                
                //更新
                sumCount = iVendor.Save(model, tran, conn);
                if (model.VendorID <= 0)
                {
                    model.VendorID = sumCount;//新创建记录ID
                }
                //删除原有关联关系
                iVendor.DeleteVendorWHouseList(model.VendorID, tran, conn);
                if (!string.IsNullOrEmpty(model.VendorWarehouseDatas))
                {
                    string[] wids = model.VendorWarehouseDatas.Split(',');
                    List<int> wList = new List<int>();
                    foreach (string wid in wids)
                    {
                        if (!string.IsNullOrEmpty(wid))
                        {
                            wList.Add(int.Parse(wid));
                        }

                    }
                    if (wList.Count > 0)
                    {
                        //绑定新关系　
                        iVendor.SaveVendorWHouse(model.VendorID, model.ModifyUserID, model.ModifyUserName, wList, tran, conn);
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex1)
                {
                    throw ex1;
                }
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    tran.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
            return sumCount;
        }
        #endregion


        #region 更新一个Vendor
        /// <summary>
        /// 更新一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(Vendor model)
        {
            int sumCount = 0;
            IDbConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                conn = DALFactory.GetLazyInstance<IVendorDAO>().GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();
                //更新
                sumCount = DALFactory.GetLazyInstance<IVendorDAO>().Edit(model, tran, conn);

                //删除原有关联关系
                DALFactory.GetLazyInstance<IVendorDAO>().DeleteVendorWHouseList(model.VendorID,tran,conn);
                if (!string.IsNullOrEmpty(model.VendorWarehouseDatas))
                {
                    string[] wids = model.VendorWarehouseDatas.Split(',');
                    List<int> wList = new List<int>();
                    foreach (string wid in wids)
                    {
                        if (!string.IsNullOrEmpty(wid))
                        {
                            wList.Add(int.Parse(wid));
                        }
                        
                    }
                    if (wList.Count > 0)
                    {
                        //绑定新关系　
                        DALFactory.GetLazyInstance<IVendorDAO>().SaveVendorWHouse(model.VendorID, model.ModifyUserID, model.ModifyUserName,wList, tran, conn);
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex1)
                {
                    throw ex1;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    tran.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
            return sumCount;
        }
        #endregion


        #region 删除一个Vendor
        /// <summary>
        /// 删除一个Vendor
        /// </summary>
        /// <param name="model">Vendor对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(Vendor model)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个Vendor
        /// <summary>
        /// 根据主键逻辑删除一个Vendor
        /// </summary>
        /// <param name="vendorID">供应商分类ID</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(int vendorID)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().LogicDelete(vendorID);
        }
        #endregion


        #region 根据字典获取Vendor对象
        /// <summary>
        /// 根据字典获取Vendor对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>Vendor对象</returns>
        public static Vendor GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取Vendor对象
        /// <summary>
        /// 根据主键获取Vendor对象
        /// </summary>
        /// <param name="vendorID">供应商分类ID</param>
        /// <returns>Vendor对象</returns>
        public static Vendor GetModel(int vendorID)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetModel(vendorID);
        }
        #endregion


        #region 根据字典获取Vendor集合
        /// <summary>
        /// 根据字典获取Vendor集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<Vendor> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取Vendor数据集
        /// <summary>
        /// 根据字典获取Vendor数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取Vendor集合
        /// <summary>
        /// 分页获取Vendor集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<Vendor> GetPageList(PageListBySql<Vendor> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IVendorDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion


        #endregion

        /// <summary>
        /// 更新供应商状态
        /// </summary>
        /// <param name="shelfIds"></param>
        /// <param name="status"></param>
        /// <param name="dateTime"></param>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        public static int UpdateStatus(string[] shelfIds, int status, DateTime dateTime, int userID, string userName)
        {
            int sumCount = 0;

            IDbConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                conn = DALFactory.GetLazyInstance<IVendorDAO>().GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                for (int i = 0; i < shelfIds.Length; i++)
                {
                    sumCount += DALFactory.GetLazyInstance<IVendorDAO>().UpdateStatus(shelfIds[i], status, dateTime, userID, userName, tran, conn);
                }
                //全部执行成功
                if (sumCount == shelfIds.Length)
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex1)
                {
                    throw ex1;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    tran.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
            return sumCount;
        }


        /// <summary>
        /// 获取供应商引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public static IList<WarehouseSelectModel> GetVendorWarehouse(int vendorID)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetVendorWarehouse(vendorID);
        }

        /// <summary>
        /// 获取供应商没有引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public static IList<WarehouseSelectModel> GetNoneVendorWarehouse(int vendorID)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetNoneVendorWarehouse(vendorID);
        }


        /// <summary>
        /// 获取供应商没有引用的仓库列表
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public static int AddVendorWarehouse(int vendorID, IList<WarehouseSelectModel> modelList)
        {
            int sumCount = 0;

            IDbConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                conn = DALFactory.GetLazyInstance<IVendorDAO>().GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();
                DALFactory.GetLazyInstance<IVendorDAO>().ClearVendorWarehouse(vendorID, tran, conn);
                if (modelList != null && modelList.Count > 0)
                {
                    foreach (var item in modelList)
                    {
                        DALFactory.GetLazyInstance<IVendorDAO>().AddVendorWarehouse(item, tran, conn);
                    }
                }
                //全部执行成功
                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex1)
                {
                    throw ex1;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    tran.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
            return sumCount;
        }

        /// <summary>
        /// 获取某个仓库下的商品最后一次进货的供应商信息集合
        /// </summary>
        /// <param name="wid">仓库ID</param>
        /// <param name="productIds">要指定查询的商品ID集合，允许为空</param>
        /// <returns>该仓库下的商品最后一次进货的供应商信息集合</returns>
        public static IList<VendorLastBuy> GetLastBuyVendors(int wid, IList<int> productIds = null)
        {
            return DALFactory.GetLazyInstance<IVendorDAO>().GetLastBuyVendors(wid, productIds);
        }
    }
}