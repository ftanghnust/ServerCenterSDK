/*********************************************************
 * FRXS 小马哥 2016/4/12 17:44:57
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frxs.Erp.ServiceCenter.Order.Model;
using Frxs.Erp.ServiceCenter.Order.Model.Order;
using Frxs.Platform.Utility.Pager;

namespace Frxs.Erp.ServiceCenter.Order.IDAL
{
    /// <summary>
    /// ### SaleOrderPreShelfArea数据库访问接口
    /// </summary>
    public partial interface ISaleOrderPreShelfAreaDAO : IBaseDAO
    {


        #region 成员方法
        #region 根据主键验证SaleOrderPreShelfArea是否存在
        /// <summary>
        /// 根据主键验证SaleOrderPreShelfArea是否存在
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>是否存在</returns>
        bool Exists(SaleOrderPreShelfArea model);
        #endregion


        #region 添加一个SaleOrderPreShelfArea
        /// <summary>
        /// 添加一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Save(SaleOrderPreShelfArea model);
        #endregion


        #region 添加一个SaleOrderPreShelfArea(事务处理)
        /// <summary>
        /// 添加一个SaleOrderPreShelfArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>主键自增则返回最新标识列，否则则返回数据库影响行数</returns>
        int Save(IDbConnection conn, IDbTransaction tran, SaleOrderPreShelfArea model);
        #endregion


        #region 更新一个SaleOrderPreShelfArea
        /// <summary>
        /// 更新一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(SaleOrderPreShelfArea model);

        ///
        int EditByAreaID(SaleOrderPreShelfArea model, IDbConnection conn = null, IDbTransaction tran = null);
        #endregion


        #region 更新一个SaleOrderPreShelfArea(事务处理)
        /// <summary>
        /// 更新一个SaleOrderPreShelfArea(事务处理)
        /// </summary>
        /// <param name="conn">连接对象</param>
        /// <param name="tran">事务对象</param>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Edit(IDbConnection conn, IDbTransaction tran, SaleOrderPreShelfArea model);
        #endregion


        #region 删除一个SaleOrderPreShelfArea
        /// <summary>
        /// 删除一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="model">SaleOrderPreShelfArea对象</param>
        /// <returns>数据库影响行数</returns>
        int Delete(SaleOrderPreShelfArea model);
        #endregion


        #region 根据主键逻辑删除一个SaleOrderPreShelfArea
        /// <summary>
        /// 根据主键逻辑删除一个SaleOrderPreShelfArea
        /// </summary>
        /// <param name="iD">主键ID(WID + GUID)</param>
        /// <returns>数据库影响行数</returns>
        int LogicDelete(string iD);
        #endregion


        #region 根据字典获取SaleOrderPreShelfArea对象
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        SaleOrderPreShelfArea GetModel(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据主键获取SaleOrderPreShelfArea对象
        /// <summary>
        /// 根据主键获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">主键ID(WID + GUID)</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        SaleOrderPreShelfArea GetModel(string iD);
        #endregion


        #region 根据字典获取SaleOrderPreShelfArea集合
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea集合
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <returns>数据集合</returns>
        IList<SaleOrderPreShelfArea> GetList(IDictionary<string, object> conditionDict);
        #endregion


        #region 根据字典获取SaleOrderPreShelfArea数据集
        /// <summary>
        /// 根据字典获取SaleOrderPreShelfArea数据集
        /// </summary>
        /// <param name="conditionDict">条件参数</param>
        /// <param name="sqlConfigName">SQL配置名称</param>
        /// <returns>数据集</returns>
        DataSet GetDataSet(IDictionary<string, object> conditionDict, string sqlConfigName);
        #endregion


        #region 分页获取SaleOrderPreShelfArea集合
        /// <summary>
        /// 分页获取SaleOrderPreShelfArea集合
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="conditionDict">查询条件</param>
        /// <returns>分页对象集合</returns>
        PageListBySql<SaleOrderPreShelfArea> GetPageList(PageListBySql<SaleOrderPreShelfArea> page, IDictionary<string, object> conditionDict);
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

    /// <summary>
    /// ### SaleOrderPreShelfArea数据库访问接口
    /// 龙武
    /// </summary>
    public partial interface ISaleOrderPreShelfAreaDAO : IBaseDAO
    {
        /// <summary>
        /// 根据订单编号获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">订单编号</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        List<SaleOrderPreShelfArea> GetModelByOrderId(string orderId,IDbConnection conn = null, IDbTransaction tran = null);

        /// <summary>
        /// 根据订单编号获取SaleOrderPreShelfArea对象
        /// </summary>
        /// <param name="iD">订单编号</param>
        /// <returns>SaleOrderPreShelfArea对象</returns>
        List<SaleOrderPreShelfArea> GetModelByOrderIdAndAreaID(string orderId, string shelfAreaID, IDbConnection conn = null, IDbTransaction tran = null);
    }

    /// <summary>
    /// By leidong扩展
    /// </summary>
    public partial interface ISaleOrderPreShelfAreaDAO : IBaseDAO
    {
        /// <summary>
        /// 根据OrderId删除商品明细
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="conn">连接</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        int DeleteByOrderId(string orderId, IDbConnection conn, IDbTransaction tran);
    }
}
