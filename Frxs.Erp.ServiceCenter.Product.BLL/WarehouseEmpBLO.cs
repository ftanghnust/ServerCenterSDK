
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
using Frxs.Platform.Cache;
using Frxs.Platform.Cache.Provide;
using Frxs.Platform.Utility;


namespace Frxs.Erp.ServiceCenter.Product.BLL
{
    /// <summary>
    /// 仓库用户员工表WarehouseEmp业务逻辑类
    /// </summary>
    public partial class WarehouseEmpBLO
    {
        #region 成员方法
        #region 根据主键验证WarehouseEmp是否存在
        /// <summary>
        /// 根据主键验证WarehouseEmp是否存在
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>是否存在</returns>
        public static bool Exists(WarehouseEmp model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().Exists(model);
        }
        #endregion


        #region 添加一个WarehouseEmp
        /// <summary>
        /// 添加一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>最新标识列</returns>
        public static int Save(WarehouseEmp model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().Save(model);
        }
        #endregion


        #region 更新一个WarehouseEmp
        /// <summary>
        /// 更新一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Edit(WarehouseEmp model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().Edit(model);
        }
        #endregion


        #region 删除一个WarehouseEmp
        /// <summary>
        /// 删除一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        public static int Delete(WarehouseEmp model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().Delete(model);
        }
        #endregion


        #region 根据主键逻辑删除一个WarehouseEmp
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseEmp
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicIsFrozenDelete(WarehouseEmp model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().LogicIsFrozenDelete(model);
        }
        #endregion

        #region 根据主键冻结或解冻一个WarehouseEmp
        /// <summary>
        /// 根据主键冻结或解冻一个WarehouseEmp
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public static int LogicDelete(WarehouseEmp model)
        {


            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().LogicDelete(model);
        }
        #endregion


        #region 根据字典获取WarehouseEmp对象
        /// <summary>
        /// 根据字典获取WarehouseEmp对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseEmp对象</returns>
        public static WarehouseEmp GetModel(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().GetModel(conditionDict);
        }
        #endregion


        #region 根据主键获取WarehouseEmp对象
        /// <summary>
        /// 根据主键获取WarehouseEmp对象
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>WarehouseEmp对象</returns>
        public static WarehouseEmp GetModel(int empID)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().GetModel(empID);
        }
        #endregion


        #region 根据字典获取WarehouseEmp集合
        /// <summary>
        /// 根据字典获取WarehouseEmp集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        public static IList<WarehouseEmp> GetList(IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().GetList(conditionDict);
        }
        #endregion


        #region 根据字典获取WarehouseEmp数据集
        /// <summary>
        /// 根据字典获取WarehouseEmp数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        public static DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().GetDataSet(conditionDict, sqlConfigName);
        }
        #endregion


        #region 分页获取WarehouseEmp集合
        /// <summary>
        /// 分页获取WarehouseEmp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        public static PageListBySql<WarehouseEmp> GetPageList(PageListBySql<WarehouseEmp> page, IDictionary<string, object> conditionDict)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().GetPageList(page, conditionDict);
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
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().UpdateField(fieldList, whereConditionList);
        }
        #endregion

        #region 验证是否存在
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        public static bool ExistsWarehouseEmpCode(WarehouseEmp model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().ExistsWarehouseEmpCode(model);
        }
        #endregion

        #region 根据主键重置密码
        /// <summary>
        /// 根据主键重置密码
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        public static int EditResetPassWord(WarehouseEmp model)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().EditResetPassWord(model);
        }
        #endregion

        #region 检查账户关系
        /// <summary>
        /// 检查账户关系
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        public static string ExistsWarehouseEmp(int EmpID, int num)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().ExistsWarehouseEmp(EmpID, num);
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// 仓库用户员工表WarehouseEmp业务逻辑类
    /// 龙武
    /// </summary>
    public partial class WarehouseEmpBLO
    {
        /// <summary>
        /// 登录-查询信息
        /// </summary>
        /// <param name="userAccout">帐号</param>
        /// <returns></returns>
        public static WarehouseEmpInfo DeliverLogin(string userAccount, int userType)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().DeliverLogin(userAccount, userType);
        }

        /// <summary>
        /// 登录-查询信息
        /// </summary>
        /// <param name="userAccout">帐号</param>
        /// <returns></returns>
        public static WarehouseEmpInfo PickingLogin(string userAccount, int userType)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().PickingLogin(userAccount, userType);
        }

        /// <summary>
        /// 根据登录名获取用户信息
        /// </summary>
        /// <param name="userAccount">登录帐号</param>
        /// <returns>用户对象</returns>
        public static WarehouseEmp PickingGetModelByAccount(string userAccount, int userType)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().PickingGetModelByAccount(userAccount, userType);
        }

        /// <summary>
        /// 根据商品编号获取制定仓库中用户名和用户编号
        /// </summary>
        /// <param name="productIds">商品编号-多个商品编号请用,隔开(如:1,2,3,4)</param>
        /// <param name="wId">仓库编号</param>
        /// <returns></returns>
        public static List<WarehouseEmp> GetPickUsersByProductId(string productIds, int wId, int userId)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().GetPickUsersByProductId(productIds, wId, userId);
        }

        public static void DeleteCache(int EmpID)
        {
            RedisHelper redisHelper = ErpRedisCacheProvide.GetStaffCacheHelper();

            var userredisguid = redisHelper.GetCache<string>(string.Format(ConstDefinition.CACHE_WAREHOUSEEMP_KEY, EmpID));

            if (userredisguid != null)
            {
                redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_WAREHOUSE_GUID_KEY, userredisguid));
            }
            redisHelper.DeleteCache(string.Format(ConstDefinition.CACHE_WAREHOUSEEMP_KEY, EmpID));
        }

        /// <summary>
        /// 查询登录用户是否存在该货位信息
        /// </summary>
        /// <param name="empId">用户编号</param>
        /// <param name="shelfCode">货位编号</param>
        /// <returns></returns>
        public static bool CheckShelfOfLogin(int empId, string shelfCode)
        {
            return DALFactory.GetLazyInstance<IWarehouseEmpDAO>().CheckShelfOfLogin(empId, shelfCode);
        }
    }
}