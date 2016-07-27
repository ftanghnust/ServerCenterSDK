
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
    /// ### WProductsBuy数据库访问接口
    /// </summary>
    public partial interface IWProductsBuyDAO
    {


        #region 成员方法
        #region 根据主键验证WProductsBuy是否存在
        /// <summary>
        /// 根据主键验证WProductsBuy是否存在
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>是否存在</returns>
        bool Exists(WProductsBuy model);
        #endregion


        #region 添加一个WProductsBuy
        /// <summary>
        /// 添加一个WProductsBuy
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(WProductsBuy model);
        #endregion


        #region 更新一个WProductsBuy
        /// <summary>
        /// 更新一个WProductsBuy
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(WProductsBuy model);

        /// <summary>
        /// 绑定商品与供应商关系
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="productId"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        int EditByProductID(int vendorId, int productId, IDbConnection conn, IDbTransaction trans);
        #endregion


        #region 删除一个WProductsBuy
        /// <summary>
        /// 删除一个WProductsBuy
        /// </summary>
        /// <param name="model">WProductsBuy对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(WProductsBuy model);
        #endregion


        #region 根据主键逻辑删除一个WProductsBuy
        /// <summary>
        /// 根据主键逻辑删除一个WProductsBuy
        /// </summary>
        /// <param name="wProductID">主键ID(WProduct.WProductID 1对1的关系)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(long wProductID);
        #endregion


        #region 根据字典获取WProductsBuy对象
        /// <summary>
        /// 根据字典获取WProductsBuy对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>WProductsBuy对象</returns>
        WProductsBuy GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取WProductsBuy对象
        /// <summary>
        /// 根据主键获取WProductsBuy对象
        /// </summary>
        /// <param name="wProductID">主键ID(WProduct.WProductID 1对1的关系)</param>
        /// <returns>WProductsBuy对象</returns>
        WProductsBuy GetModel(long wProductID);
        #endregion


        #region 根据字典获取WProductsBuy集合
        /// <summary>
        /// 根据字典获取WProductsBuy集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<WProductsBuy> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取WProductsBuy数据集
        /// <summary>
        /// 根据字典获取WProductsBuy数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取WProductsBuy集合
        /// <summary>
        /// 分页获取WProductsBuy集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>

        PageListBySql<WProductsBuy> GetPageList(PageListBySql<WProductsBuy> page, IDictionary<string, object> conditionDict);
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

        /// <summary>
        /// 搜索采购价格数据
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="pdList"></param>
        /// <returns></returns>
        IList<WProductsBuyQModel> GetWProductsBuyList(int wid, IList<int> pdList);
    }
}