
/*****************************
* Author:chujl
*
* Date:2016-03-28
******************************/
using System;
using System.Collections.Generic;


using Frxs.Erp.ServiceCenter.Order.Model;
using System.Data;
using Frxs.Platform.Utility.Pager;


namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleFee数据库访问接口
    /// </summary>
    public partial interface ISaleFeeDAO :IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleFee是否存在
        /// <summary>
        /// 根据主键验证SaleFee是否存在
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleFee model);
        #endregion


        #region 添加一个SaleFee
        /// <summary>
        /// 添加一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleFee model);
        #endregion


        #region 更新一个SaleFee
        /// <summary>
        /// 更新一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleFee model, IDbConnection conn, IDbTransaction trans);

        /// <summary>
        /// 更新一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleFee model);
        #endregion


        #region 删除一个SaleFee
        /// <summary>
        /// 删除一个SaleFee
        /// </summary>
        /// <param name="model">SaleFee对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleFee model);
        #endregion


        #region 根据主键逻辑删除一个SaleFee
        /// <summary>
        /// 根据主键逻辑删除一个SaleFee
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string feeID);

        /// <summary>
        /// 根据主键逻辑删除一个SaleFee
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string feeID, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 根据字典获取SaleFee对象
        /// <summary>
        /// 根据字典获取SaleFee对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleFee对象</returns>
        SaleFee GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleFee对象
        /// <summary>
        /// 根据主键获取SaleFee对象
        /// </summary>
        /// <param name="feeID">费用ID(SaleFee.FeeID)</param>
        /// <returns>SaleFee对象</returns>
        SaleFee GetModel(string feeID);
        #endregion


        #region 根据字典获取SaleFee集合
        /// <summary>
        /// 根据字典获取SaleFee集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleFee> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleFee数据集
        /// <summary>
        /// 根据字典获取SaleFee数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleFee集合

        /// <summary>
        /// 分页获取SaleFee集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <param name="totalAmt">总合计</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleFee> GetPageList(PageListBySql<SaleFee> page, IDictionary<string, object> conditionDict, out decimal totalAmt);
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
}