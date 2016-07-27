﻿
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
    /// ### 仓库--广告商品表WAdvertisementProduct数据库访问接口
    /// </summary>
    public partial interface IWAdvertisementProductDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证WAdvertisementProduct是否存在
        /// <summary>
        /// 根据主键验证WAdvertisementProduct是否存在
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WAdvertisementProduct model);
        #endregion


        #region 添加一个WAdvertisementProduct
        /// <summary>
        /// 添加一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WAdvertisementProduct model);
        #endregion


        #region 更新一个WAdvertisementProduct
        /// <summary>
        /// 更新一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WAdvertisementProduct model);
        #endregion


        #region 删除一个WAdvertisementProduct
        /// <summary>
        /// 删除一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WAdvertisementProduct model);
        #endregion


        #region 根据主键逻辑删除一个WAdvertisementProduct
        /// <summary>
        /// 根据主键逻辑删除一个WAdvertisementProduct
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int iD);
        #endregion


        #region 根据字典获取WAdvertisementProduct对象
        /// <summary>
        /// 根据字典获取WAdvertisementProduct对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WAdvertisementProduct对象</returns>
        WAdvertisementProduct GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WAdvertisementProduct对象
        /// <summary>
        /// 根据主键获取WAdvertisementProduct对象
        /// </summary>
        /// <param name="iD">主键ID</param>
        /// <returns>WAdvertisementProduct对象</returns>
        WAdvertisementProduct GetModel(int iD);
        #endregion


        #region 根据字典获取WAdvertisementProduct集合
        /// <summary>
        /// 根据字典获取WAdvertisementProduct集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WAdvertisementProduct> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WAdvertisementProduct数据集
        /// <summary>
        /// 根据字典获取WAdvertisementProduct数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WAdvertisementProduct集合
        /// <summary>
        /// 分页获取WAdvertisementProduct集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WAdvertisementProduct> GetPageList(PageListBySql<WAdvertisementProduct> page, IDictionary<string, object> conditionDict);
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

    public partial interface IWAdvertisementProductDAO : IBaseDAO
    {
        #region 添加一个WAdvertisementProduct
        /// <summary>
        /// 添加一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WAdvertisementProduct model, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 删除一个WAdvertisementProduct
        /// <summary>
        /// 删除一个WAdvertisementProduct
        /// </summary>
        /// <param name="model">WAdvertisementProduct对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WAdvertisementProduct model, IDbConnection conn, IDbTransaction tran);
        #endregion
    }

    public partial interface IWAdvertisementProductDAO : IBaseDAO
    {
        int DeleteByWAdvertisement(int WID, int AdvertisementID);

        int DeleteByWAdvertisement(int WID, int AdvertisementID, IDbConnection conn, IDbTransaction tran);
    }
}