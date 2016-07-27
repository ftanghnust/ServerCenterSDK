
/*****************************
* Author:CR
*
* Date:2016-03-25
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Product.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Product.IDAL
{
    /// <summary>
    /// ### 仓库商品限购主表WProductNoSale数据库访问接口
    /// </summary>
    public partial interface IWProductNoSaleDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证WProductNoSale是否存在
        /// <summary>
        /// 根据主键验证WProductNoSale是否存在
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductNoSale model);
        #endregion


        #region 添加一个WProductNoSale
        /// <summary>
        /// 添加一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductNoSale model);
        #endregion


        #region 更新一个WProductNoSale
        /// <summary>
        /// 更新一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductNoSale model);
        #endregion


        #region 删除一个WProductNoSale
        /// <summary>
        /// 删除一个WProductNoSale
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductNoSale model);
        #endregion


        #region 根据主键逻辑删除一个WProductNoSale
        /// <summary>
        /// 根据主键逻辑删除一个WProductNoSale
        /// </summary>
        /// <param name="noSaleID">主键ID(WID + GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string noSaleID);
        #endregion


        #region 根据字典获取WProductNoSale对象
        /// <summary>
        /// 根据字典获取WProductNoSale对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductNoSale对象</returns>
        WProductNoSale GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WProductNoSale对象
        /// <summary>
        /// 根据主键获取WProductNoSale对象
        /// </summary>
        /// <param name="noSaleID">主键ID(WID + GUID)</param>
        /// <returns>WProductNoSale对象</returns>
        WProductNoSale GetModel(string noSaleID);
        #endregion


        #region 根据字典获取WProductNoSale集合
        /// <summary>
        /// 根据字典获取WProductNoSale集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductNoSale> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductNoSale数据集
        /// <summary>
        /// 根据字典获取WProductNoSale数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductNoSale集合
        /// <summary>
        /// 分页获取WProductNoSale集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProductNoSale> GetPageList(PageListBySql<WProductNoSale> page, IDictionary<string, object> conditionDict);
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


    public partial interface IWProductNoSaleDAO : IBaseDAO
    {
        #region 添加一个WProductNoSale 事务操作
        /// <summary>
        /// 添加一个WProducts 事务操作
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductNoSale model, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 更新一个WProductNoSale 事务操作
        /// <summary>
        /// 更新一个WProducts 事务操作        
        /// </summary>
        /// <param name="model">WProductNoSale对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductNoSale model, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 删除一个WProductNoSale 事务操作
        /// <summary>
        /// 删除一个WProductNoSale 事务操作        
        /// </summary>
        /// <param name="NoSaleID">限购单号</param>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(string NoSaleID, IDbConnection conn, IDbTransaction tran);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        int JobPosting(int userId, string userName);
    }
}