
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
    /// ### 促销门店群组表ShopGroup数据库访问接口
    /// </summary>
    public partial interface IShopGroupDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证ShopGroup是否存在
        /// <summary>
        /// 根据主键验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        bool Exists(ShopGroup model);
        #endregion


        #region 添加一个ShopGroup
        /// <summary>
        /// 添加一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ShopGroup model);
        #endregion


        #region 更新一个ShopGroup
        /// <summary>
        /// 更新一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ShopGroup model);
        #endregion


        #region 删除一个ShopGroup
        /// <summary>
        /// 删除一个ShopGroup
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(ShopGroup model);
        #endregion


        #region 根据主键逻辑删除一个ShopGroup
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroup
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int groupID);
        #endregion


        #region 根据字典获取ShopGroup对象
        /// <summary>
        /// 根据字典获取ShopGroup对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>ShopGroup对象</returns>
        ShopGroup GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取ShopGroup对象
        /// <summary>
        /// 根据主键获取ShopGroup对象
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <returns>ShopGroup对象</returns>
        ShopGroup GetModel(int groupID);
        #endregion


        #region 根据字典获取ShopGroup集合
        /// <summary>
        /// 根据字典获取ShopGroup集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<ShopGroup> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取ShopGroup数据集
        /// <summary>
        /// 根据字典获取ShopGroup数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取ShopGroup集合
        /// <summary>
        /// 分页获取ShopGroup集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<ShopGroup> GetPageList(PageListBySql<ShopGroup> page, IDictionary<string, object> conditionDict);
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


    public partial interface IShopGroupDAO : IBaseDAO
    {
        #region 根据 群组编号 验证ShopGroup是否存在
        /// <summary>
        /// 根据 群组编号 验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        bool ExistsGroupCode(ShopGroup model);
        #endregion

        #region 根据 群组名称 验证ShopGroup是否存在
        /// <summary>
        /// 根据 群组名称 验证ShopGroup是否存在
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <returns>是否存在</returns>
        bool ExistsGroupName(ShopGroup model);
        #endregion

        #region 根据主键逻辑删除一个ShopGroup 支持事物操作
        /// <summary>
        /// 根据主键逻辑删除一个ShopGroup
        /// </summary>
        /// <param name="groupID">主键ID</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(int groupID, IDbConnection conn, IDbTransaction trans);
        #endregion

        #region 添加一个ShopGroup 事务操作
        /// <summary>
        /// 添加一个ShopGroup 事务操作
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(ShopGroup model, IDbConnection conn, IDbTransaction tran);
        #endregion

        #region 更新一个ShopGroup 事务操作
        /// <summary>
        /// 更新一个ShopGroup 事务操作
        /// </summary>
        /// <param name="model">ShopGroup对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(ShopGroup model, IDbConnection conn, IDbTransaction tran);
        #endregion
    }
}