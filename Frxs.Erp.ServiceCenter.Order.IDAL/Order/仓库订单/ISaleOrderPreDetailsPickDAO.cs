
/*****************************
* Author:leidong
*
* Date:2016-04-05
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;
using Frxs.Erp.ServiceCenter.Order.Model.Order;



namespace Frxs.Erp.ServiceCenter.Order.IDAL
{ 
    /// <summary>
    /// ### SaleOrderPreDetailsPick数据库访问接口
    /// </summary>
    public partial interface ISaleOrderPreDetailsPickDAO
    {
    

        #region  成员方法
        #region 根据主键验证SaleOrderPreDetailsPick是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreDetailsPick是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderPreDetailsPick model);
        #endregion


        #region 添加一个SaleOrderPreDetailsPick
        /// <summary>
        /// 添加一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderPreDetailsPick model);
        #endregion


        #region 添加一个SaleOrderPreDetailsPick(事务处理)
        /// <summary>
        /// 添加一个SaleOrderPreDetailsPick(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderPreDetailsPick model);
        #endregion


        #region 更新一个SaleOrderPreDetailsPick
        /// <summary>
        /// 更新一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderPreDetailsPick model);
        #endregion


        #region 更新一个SaleOrderPreDetailsPick(事务处理)
        /// <summary>
        /// 更新一个SaleOrderPreDetailsPick(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderPreDetailsPick model);
        #endregion


        #region 删除一个SaleOrderPreDetailsPick
        /// <summary>
        /// 删除一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="model">SaleOrderPreDetailsPick对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderPreDetailsPick model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPreDetailsPick
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreDetailsPick
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据主键获取SaleOrderPreDetailsPick对象
        /// <summary>
        /// 根据主键获取SaleOrderPreDetailsPick对象
        /// </summary>
        /// <param name="iD">编号(=SaleOrderDetails.ID)</param>
        /// <returns>SaleOrderPreDetailsPick对象</returns>
        SaleOrderPreDetailsPick GetModel(string iD);
        #endregion


        #region 根据字典获取SaleOrderPreDetailsPick数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreDetailsPick数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderPreDetailsPick集合
        /// <summary>
        /// 分页获取SaleOrderPreDetailsPick集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderPreDetailsPick> GetPageList(PageListBySql<SaleOrderPreDetailsPick> page, IDictionary<string, object> conditionDict);
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

        public partial interface ISaleOrderPreDetailsPickDAO
        {
            /// <summary>
            /// 根据OrderId删除商品明细
            /// </summary>
            /// <param name="orderId">订单ID</param>
            /// <param name="conn">连接</param>
            /// <param name="tran">事务</param>
            /// <returns></returns>
            int DeleteByOrderId(string orderId, IDbConnection conn, IDbTransaction tran);

            /// <summary>
            /// 根据订单号获取捡货明细
            /// </summary>
            /// <param name="orderId">订单号</param>
            /// <returns></returns>
            IList<SaleOrderPreDetailsPick> GetOrderPick(string orderId);
        }
}
