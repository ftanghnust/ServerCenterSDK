
/*****************************
* Author:CR
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
    /// ### 仓库用户员工表WarehouseEmp数据库访问接口
    /// </summary>
    public partial interface IWarehouseEmpDAO
    {
        #region 成员方法
        #region 根据主键验证WarehouseEmp是否存在
        /// <summary>
        /// 根据主键验证WarehouseEmp是否存在
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WarehouseEmp model);
        #endregion


        #region 添加一个WarehouseEmp
        /// <summary>
        /// 添加一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WarehouseEmp model);
        #endregion


        #region 更新一个WarehouseEmp
        /// <summary>
        /// 更新一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WarehouseEmp model);
        #endregion


        #region 删除一个WarehouseEmp
        /// <summary>
        /// 删除一个WarehouseEmp
        /// </summary>
        /// <param name="model">WarehouseEmp对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WarehouseEmp model);
        #endregion


        #region 根据主键逻辑删除一个WarehouseEmp
        /// <summary>
        /// 根据主键逻辑删除一个WarehouseEmp
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(WarehouseEmp model);
        #endregion


        #region 根据主键冻结或解冻一个WarehouseEmp
        /// <summary>
        /// 根据主键冻结或解冻一个WarehouseEmp
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        int LogicIsFrozenDelete(WarehouseEmp model);
        #endregion


        #region 根据字典获取WarehouseEmp对象
        /// <summary>
        /// 根据字典获取WarehouseEmp对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WarehouseEmp对象</returns>
        WarehouseEmp GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WarehouseEmp对象
        /// <summary>
        /// 根据主键获取WarehouseEmp对象
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>WarehouseEmp对象</returns>
        WarehouseEmp GetModel(int empID);
        #endregion


        #region 根据字典获取WarehouseEmp集合
        /// <summary>
        /// 根据字典获取WarehouseEmp集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WarehouseEmp> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WarehouseEmp数据集
        /// <summary>
        /// 根据字典获取WarehouseEmp数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WarehouseEmp集合
        /// <summary>
        /// 分页获取WarehouseEmp集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WarehouseEmp> GetPageList(PageListBySql<WarehouseEmp> page, IDictionary<string, object> conditionDict);
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

        #region 验证是否存在
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        bool ExistsWarehouseEmpCode(WarehouseEmp model);
       
        #endregion

        #region 根据主键重置密码
        /// <summary>
        /// 根据主键重置密码
        /// </summary>
        /// <param name="empID">用户编号</param>
        /// <returns>数据库影响行数</returns>
        int EditResetPassWord(WarehouseEmp model);
       
        #endregion

        #region 检查账户关系
        /// <summary>
        /// 检查账户关系
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns>数据集合</returns>
        string ExistsWarehouseEmp(int EmpID, int num);
      
        #endregion

        #endregion
    }

    /// <summary>
    /// ### 仓库用户员工表WarehouseEmp数据库访问接口
    /// 龙武
    /// </summary>
    public partial interface IWarehouseEmpDAO
    {
        /// <summary>
        /// 登录-查询信息
        /// </summary>
        /// <param name="userAccout">帐号</param>
        /// <returns></returns>
        WarehouseEmpInfo PickingLogin(string userAccount, int userType);

        /// <summary>
        /// 登录-查询信息(配送APP)
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        WarehouseEmpInfo DeliverLogin(string userAccount, int userType);

        /// <summary>
        /// 根据登录名获取用户信息
        /// </summary>
        /// <param name="userAccount">登录帐号</param>
        /// <returns>用户对象</returns>
        WarehouseEmp PickingGetModelByAccount(string userAccount, int userType);

        /// <summary>
        /// 根据商品编号获取制定仓库中用户名和用户编号
        /// </summary>
        /// <param name="productIds">商品编号-多个商品编号请用,隔开(如:1,2,3,4)</param>
        /// <param name="wId">仓库编号</param>
        /// <returns></returns>
        List<WarehouseEmp> GetPickUsersByProductId(string productIds, int wId, int userId);

        /// <summary>
        /// 查询登录用户是否存在该货位信息
        /// </summary>
        /// <param name="empId">用户编号</param>
        /// <param name="shelfCode">货位编号</param>
        /// <returns></returns>
        bool CheckShelfOfLogin(int empId, string shelfCode);
        
    }
}