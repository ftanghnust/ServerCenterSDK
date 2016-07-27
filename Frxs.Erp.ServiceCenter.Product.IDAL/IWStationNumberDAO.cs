
/*****************************
* Author:CR
*
* Date:2016-04-05
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库待装区表WStationNumber数据库访问接口
    /// </summary>
    public partial interface IWStationNumberDAO
    {
        #region 成员方法
        #region 根据主键验证WStationNumber是否存在
        /// <summary>
        /// 根据主键验证WStationNumber是否存在
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WStationNumber model);
        #endregion


        #region 添加一个WStationNumber
        /// <summary>
        /// 添加一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WStationNumber model);
        #endregion


        #region 更新一个WStationNumber
        /// <summary>
        /// 更新一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WStationNumber model);
        #endregion

        #region 更新一个WStationNumber 中的线路信息
        /// <summary>
        /// 更新一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int EditLineInfo(WStationNumber model);
        #endregion


        #region 删除一个WStationNumber
        /// <summary>
        /// 删除一个WStationNumber
        /// </summary>
        /// <param name="model">WStationNumber对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WStationNumber model);
        #endregion


        #region 根据主键逻辑删除一个WStationNumber
        /// <summary>
        /// 根据主键逻辑删除一个WStationNumber
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(WStationNumber model);
        #endregion


        #region 根据字典获取WStationNumber对象
        /// <summary>
        /// 根据字典获取WStationNumber对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WStationNumber对象</returns>
        WStationNumber GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WStationNumber对象
        /// <summary>
        /// 根据主键获取WStationNumber对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WStationNumber对象</returns>
        WStationNumber GetModel(int iD);
        #endregion


        #region 根据字典获取WStationNumber集合
        /// <summary>
        /// 根据字典获取WStationNumber集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WStationNumber> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WStationNumber数据集
        /// <summary>
        /// 根据字典获取WStationNumber数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WStationNumber集合
        /// <summary>
        /// 分页获取WStationNumber集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WStationNumber> GetPageList(PageListBySql<WStationNumber> page, IDictionary<string, object> conditionDict);
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
        /// 验证是否存在
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        bool ExistsWStationNumber(WStationNumber model);
        #endregion

        #region
        /// <summary>
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        int ResetWStationNumber(WStationNumber model);
        /// <summary>
        /// 清空订单数据
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns>是否存在</returns>
        int ResetWStationNumberExt(WStationNumber model);
        
        /// <summary>
        /// 清空订单数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int  ResetWStationNumberByOrderId(WStationNumber model);
        #endregion


        #endregion
    }

     /// <summary>
    /// ### 仓库待装区表WStationNumber数据库访问接口
    /// 龙武
    /// </summary>
    public partial interface IWStationNumberDAO
    {
        /// <summary>
        /// 根据仓库编号获取空闲待装区
        /// </summary>
        /// <param name="wId">仓库编号</param>
        /// <returns></returns>
        WStationNumber GetFreeStationNumber(int wId);

        /// <summary>
        /// 拣货完成还原待装区数据
        /// </summary>
        /// <param name="userId">操作人编号</param>
        /// <param name="userName">操作人姓名</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        bool UpdateStationNumberIsNull(int status, int orderStatus, int userId, string userName, string orderId);
    }
}