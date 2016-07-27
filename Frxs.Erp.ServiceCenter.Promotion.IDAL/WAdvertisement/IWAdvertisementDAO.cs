
/*****************************
* Author:zhoujin
*
* Date:2016-03-29
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Promotion.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Promotion.IDAL
{
    /// <summary>
    /// ### 仓库--广告、橱窗信息表WAdvertisement数据库访问接口
    /// </summary>
    public partial interface IWAdvertisementDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证WAdvertisement是否存在
        /// <summary>
        /// 根据主键验证WAdvertisement是否存在
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WAdvertisement model);
        #endregion


        #region 添加一个WAdvertisement
        /// <summary>
        /// 添加一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WAdvertisement model);
        #endregion


        #region 更新一个WAdvertisement
        /// <summary>
        /// 更新一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WAdvertisement model);
        #endregion


        #region 删除一个WAdvertisement
        /// <summary>
        /// 删除一个WAdvertisement
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WAdvertisement model);
        #endregion


        #region 根据主键逻辑删除一个WAdvertisement
        /// <summary>
        /// 根据主键逻辑删除一个WAdvertisement
        /// </summary>
        /// <param name="advertisementID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int advertisementID);
        int LogicDelete(int advertisementID, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据字典获取WAdvertisement对象
        /// <summary>
        /// 根据字典获取WAdvertisement对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WAdvertisement对象</returns>
        WAdvertisement GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WAdvertisement对象
        /// <summary>
        /// 根据主键获取WAdvertisement对象
        /// </summary>
        /// <param name="advertisementID">主键ID</param>
        /// <returns>WAdvertisement对象</returns>
        WAdvertisement GetModel(int advertisementID);
        #endregion


        #region 根据字典获取WAdvertisement集合
        /// <summary>
        /// 根据字典获取WAdvertisement集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WAdvertisement> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WAdvertisement数据集
        /// <summary>
        /// 根据字典获取WAdvertisement数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WAdvertisement集合
        /// <summary>
        /// 分页获取WAdvertisement集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WAdvertisement> GetPageList(PageListBySql<WAdvertisement> page, IDictionary<string, object> conditionDict);
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

    public partial interface IWAdvertisementDAO : IBaseDAO
    {

        #region 添加一个WAdvertisement 事务操作
        /// <summary>
        /// 添加一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WAdvertisement model, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 更新一个WAdvertisement 事务操作
        /// <summary>
        /// 更新一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WAdvertisement model, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 删除一个WAdvertisement 事务操作
        /// <summary>
        /// 删除一个WAdvertisement 事务操作
        /// </summary>
        /// <param name="model">WAdvertisement对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WAdvertisement model, IDbConnection conn, IDbTransaction tran);
        #endregion
    }
}